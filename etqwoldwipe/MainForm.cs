using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;
using System.IO;
using System.Net;

namespace etqwoldwipe
{
    public partial class MainForm : Form
    {
        private ETQWData data;
        private MD5Data md5data;
        private GetFromURL gfu;

        public MainForm()
        {
            data = new ETQWData();
            md5data = new MD5Data(data.GamePath, data.UserPath);
            gfu = new GetFromURL();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtGamePath.Text = data.GamePath;
            txtUserPath.Text = data.UserPath;
        }

        private void btnSearchGame_Click(object sender, EventArgs e)
        {
            if (!txtGamePath.Text.Equals(data.GamePath) || !txtUserPath.Text.Equals(data.UserPath))
            {
                data.GamePath = txtGamePath.Text;
                data.UserPath = txtUserPath.Text;
                data.InvalidateData();
                md5data.InvalidateData();
                pbHashing.Value = 0;
            }

            fillResultsBox();
            propagateHashFields();
            //lbResults.DataSource = data.GetData();
            //lbResults.data
        }

        private void fillResultsBox()
        {
            lbResults.BeginUpdate();
            lbResults.Items.Clear();
            foreach (DataItem di in data.GetData())
            {
                if (!di.Official || cbExcludeOfficial.CheckState == CheckState.Unchecked )
                {
                    if (md5data.Data.Count > 0 &&
                        (di.ExpectedMD5Hash == null || di.ExpectedMD5Hash.Equals("")))
                    {
                        string hash = md5data.Data.GetHashForFile(di.Filename);
                        if (hash != null && !hash.Equals(""))
                        {
                            // If we've got an expected hash for it already, but don't have it listed, try to load it.
                            // This should be going on somewhere else tbh, but here for now is fine.
                            di.ExpectedMD5Hash = md5data.Data.GetHashForFile(di.Filename);
                        }
                    }
                    lbResults.Items.Add(di);
                }
            }
            lbResults.EndUpdate();
        }

        private void propagateHashFields()
        {
            if (lbResults.SelectedItem != null)
            {
                DataItem di = (DataItem)lbResults.SelectedItem;
                txtMD5Computed.Text = di.isMD5Computed() ? di.GetMD5Hash() : "";
                txtMD5Expected.Text = di.ExpectedMD5Hash;
            }
            else
            {
                txtMD5Computed.Text = "";
                txtMD5Expected.Text = "";
            }
        }

        private void lbResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            propagateHashFields();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            DataItems dis = data.GetData();
            if(dis.Count == 0)
            {
                pbHashing.Value = 0;
                return;
            }
            int count = 0;

            Cursor.Current = Cursors.WaitCursor;
            foreach (DataItem di in dis)
            {
                pbHashing.Value = (int)Math.Floor(((decimal)dis.CountHashes() / (decimal)dis.Count) * 100m);
                if (!di.Official || cbExcludeOfficial.CheckState == CheckState.Unchecked)
                {
                    string humanFilename = di.Filename;
                    if (humanFilename.Length > 1)
                        humanFilename = humanFilename.Substring(1, humanFilename.Length - 1);
                    lblStatus.Text = string.Format("{0} {1}", "Computing MD5 checksum for:", humanFilename);
                    lblStatus.Update();
                    di.GetMD5Hash();
                    ++count;
                }
            }
            propagateHashFields();
            lblStatus.Text = string.Format("MD5 Checksum{0} computed for {1} file{2}.", count != 1 ? "s" : "", count, count != 1 ? "s" : "");
            pbHashing.Value = 100;
            Cursor.Current = Cursors.Default;
            lbResults.Invalidate();
        }

        private void loadMD5DataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data.GetData().Count == 0)
            {
            }
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "MD5 Files (*.md5)|*.md5|All Files (*.*)|*.*";
            fd.FilterIndex = 0;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                int lastSlash = fd.FileName.LastIndexOf("\\");
                string humanFilename = fd.FileName.Substring(lastSlash, fd.FileName.Length - lastSlash);
                if (humanFilename.Length > 1)
                    humanFilename = humanFilename.Substring(1, humanFilename.Length - 1);
                lblStatus.Text = string.Format("{0} {1}", "MD5 checksums loaded:", humanFilename);
                md5data.InvalidateData();
                try
                {
                    md5data.Load(fd.FileName);
                    foreach (DataItem di in data.GetData())
                    {
                        foreach (MD5Item md5i in md5data.Data)
                        {
                            string fqrFilename = "." + md5i.Filename;

                            if (fqrFilename.Equals(md5data.getRelativePath(di)))
                            {
                                di.ExpectedMD5Hash = md5i.MD5Hash;
                            }
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show(string.Format("{0} is not a valid set of md5 hashes!", fd.FileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            propagateHashFields();
            lbResults.Invalidate();
        }

        private void saveMD5DataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataItems dis = data.GetData();
            if (dis.Count == 0 ||
                (dis.Count < (dis.CountHashes() - dis.CountOfficial()) &&
                cbExcludeOfficial.CheckState == CheckState.Checked) ||
                (dis.Count < dis.CountHashes()) &&
                cbExcludeOfficial.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show(string.Format("MD5 hash count mismatch. ({0}/{1})", 
                    dis.Count, (cbExcludeOfficial.CheckState == CheckState.Checked ? (dis.CountHashes() - dis.CountOfficial()) : dis.CountHashes())), 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "MD5 Files (*.md5)|*.md5|All Files (*.*)|*.*";
            fd.FilterIndex = 0;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (md5data.Save(dis, fd.FileName, cbExcludeOfficial.CheckState == CheckState.Unchecked) > 0)
                {
                    int lastSlash = fd.FileName.LastIndexOf("\\");
                    string humanFilename = fd.FileName.Substring(lastSlash, fd.FileName.Length - lastSlash);
                    if (humanFilename.Length > 1)
                        humanFilename = humanFilename.Substring(1, humanFilename.Length - 1);
                    lblStatus.Text = string.Format("{0} {1}", "MD5 checksums saved:", humanFilename);
                }
                else
                {
                    lblStatus.Text = "No MD5 checksums available to save.";
                }
            }
            
            propagateHashFields();
            lbResults.Invalidate();
        }

        private void lbResults_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if (e.Index != -1)
                {
                    DataItem di = (DataItem)lbResults.Items[e.Index];

                    e.DrawBackground();
                    Brush myBrush = Brushes.Black;

                    if (!di.isMD5Computed() || di.ExpectedMD5Hash == null || di.ExpectedMD5Hash.Equals(""))
                    {
                        myBrush = Brushes.DarkGoldenrod;
                    }
                    if (di.isMD5Computed() && !di.GetMD5Hash().Equals(di.ExpectedMD5Hash))
                    {
                        myBrush = Brushes.Red;
                        if (di.ExpectedMD5Hash == null || di.ExpectedMD5Hash.Equals(""))
                        {
                            myBrush = Brushes.DarkGoldenrod;
                        }
                    }
                    if (di.Official)
                    {
                        myBrush = Brushes.Lime;
                    }

                    e.Graphics.DrawString(lbResults.Items[e.Index].ToString(),
                        e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

                    e.DrawFocusRectangle();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Fail silently.
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ETQW Old Wipe v0.2\nBy Azuvector\n\nTry Quake Wars: Tactical Assault!\nhttp://qwta.moddb.com", "About ETQW Old Wipe", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manual man = new Manual();
            man.ShowDialog();
        }

        private void lbResults_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lbResults.SelectedIndex = lbResults.IndexFromPoint(e.Location);
                if (lbResults.SelectedIndex != -1)
                {
                    cmResults.Show(lbResults, e.X, e.Y);
                }
            }
        }

        private void computeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbResults.SelectedIndex != -1)
            {
                DataItem di = data.GetData()[lbResults.SelectedIndex];
                string humanFilename = di.Filename;
                if (humanFilename.Length > 1)
                    humanFilename = humanFilename.Substring(1, humanFilename.Length - 1);
                lblStatus.Text = string.Format("{0} {1}", "Computing MD5 checksum for:", humanFilename);
                lblStatus.Update();
                Cursor.Current = Cursors.WaitCursor;
                di.GetMD5Hash();
                propagateHashFields();
                lblStatus.Text = string.Format("MD5 checksum for {0} computed.", humanFilename);
                Cursor.Current = Cursors.Default;
                lbResults.Invalidate();
            }
        }

        private void getMD5sFromURLToolStrip_Click(object sender, EventArgs e)
        {
            if (gfu.ShowDialog() == DialogResult.OK)
            {
                string uri = gfu.getURLText();

                md5data.InvalidateData();
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    lblStatus.Text = string.Format("{0} {1}", "Retrieving MD5 checksums from:", uri);
                    md5data.InvalidateData();
                    md5data.LoadFromURL(uri);
                    foreach (DataItem di in data.GetData())
                    {
                        foreach (MD5Item md5i in md5data.Data)
                        {
                            string fqrFilename = "." + md5i.Filename;

                            if (fqrFilename.Equals(md5data.getRelativePath(di)))
                            {
                                di.ExpectedMD5Hash = md5i.MD5Hash;
                            }
                        }
                    }
                    lblStatus.Text = string.Format("{0} {1}", "MD5 checksums loaded from:", uri);
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = string.Format("{0} {1}", "Unable to load MD5 checksums:", ex.Message);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show(string.Format("{0} is not a valid set of md5 hashes!", uri), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = string.Format("{0} {1}", "Invalid MD5 checksums:", uri);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = string.Format("{0} {1}", "Unable to load MD5 checksums:", ex.Message);
                }
                Cursor.Current = Cursors.Default;
                propagateHashFields();
                lbResults.Invalidate();
            }
            else
            {
                lblStatus.Text = "Ready";
                lbResults.Invalidate();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete non-matching files?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataItems dis = data.GetData();
                DataItems removeDis = new DataItems();

                int count = 0;
                foreach (DataItem di in dis)
                {
                    if (!di.Official &&
                        di.ExpectedMD5Hash != null && !di.ExpectedMD5Hash.Equals("") &&
                        di.isMD5Computed() && !di.ExpectedMD5Hash.Equals(di.GetMD5Hash()))
                    {
                        removeDis.Add(di);
                        ++count;
                    }
                }
                if (count > 0)
                {
                    foreach (DataItem di in removeDis)
                    {
                        //System.IO.File.Delete(di.ToString());
                        try
                        {
                            Win32APIDelete.Delete(di.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        data.GetData().Remove(di);
                    }

                    fillResultsBox();
                }

                lblStatus.Text = string.Format("Deleted {0} file{1}.", count, count == 1 ? "" : "s");
            }
            else
            {
                lblStatus.Text = "Delete cancelled.";
            }
            propagateHashFields();
            lbResults.Invalidate();
        }
    }
}
