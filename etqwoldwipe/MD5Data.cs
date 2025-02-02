using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;

namespace etqwoldwipe
{
    class MD5Data
    {
        private string gamePath;
        private string userPath;
        private MD5Items data;

        public MD5Data(string gamePath, string userPath)
        {
            this.gamePath = gamePath;
            this.userPath = userPath;
            
            InvalidateData();
        }

        public void InvalidateData()
        {
            data = new MD5Items();
        }

        public MD5Items Data
        {
            get { return data; }
            set { data = value; }
        }

        public string getRelativePath(DataItem di)
        {
            string relPath = "";
            if (di.Path.StartsWith(gamePath))
                relPath = gamePath;
            else if (di.Path.StartsWith(userPath))
                relPath = userPath;

            string subPath = "";
            int lastSlash = di.Path.LastIndexOf("\\");
            if (lastSlash >= 0 && !relPath.EndsWith(di.Path.Substring(lastSlash, di.Path.Length - lastSlash)))
            {
                subPath = di.Path.Substring(lastSlash, di.Path.Length - lastSlash);
            }
            relPath = ".";

            return string.Format("{0}{1}{2}", relPath, subPath, di.Filename);
        }

        public int Save(DataItems etqwData, string toFilename, bool saveOfficial)
        {
            int hashesSaved = 0;
            if (etqwData.Count > 0 && etqwData.CountHashes() > 0)
            {
                StreamWriter sw = new StreamWriter(toFilename);
                sw.WriteLine("; ETQW Old Wipe generated.");
                foreach (DataItem di in etqwData)
                {
                    if (!di.Official || saveOfficial)
                    {
                        sw.WriteLine(new MD5Item(di.GetMD5Hash(), " ", "*", getRelativePath(di)));
                        ++hashesSaved;
                    }
                }
                sw.Close();
            }
            return hashesSaved;
        }

        public void Load(string fromFilename)
        {
            InvalidateData();

            string line = "";
            MD5Items items = new MD5Items();

            StreamReader sr = new StreamReader(fromFilename);
            while ((line = sr.ReadLine()) != null)
            {
                if(line.StartsWith(";")) // A comment.
                    continue;
                items.Add(new MD5Item(line));
            }

            data = items;
        }

        public void LoadFromURL(string uri)
        {
            InvalidateData();

            string line = "";
            MD5Items items = new MD5Items();

            StringBuilder sb = new StringBuilder();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            while ((line = sr.ReadLine()) != null)
            {
                if(line.StartsWith(";")) // A comment.
                    continue;
                items.Add(new MD5Item(line));
            }
            response.Close();

            data = items;

        }
    }
}
