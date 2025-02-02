using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;
using System.IO;

namespace etqwoldwipe
{
    class DataItem
    {
        private string filename;
        private string path;

        private string md5hash;
        private bool md5computed;
        private string expectedMd5hash;
        private bool official;

        public DataItem(string fqFilename)
        {
            int lastSlash = fqFilename.LastIndexOf("\\");
            filename = fqFilename.Substring(lastSlash, fqFilename.Length - lastSlash);
            path = fqFilename.Substring(0, lastSlash);

            md5hash = "";
            expectedMd5hash = "";
            md5computed = false;
            
            official = evalOfficial();
        }

        private bool evalOfficial()
        {
            if(filename.StartsWith("\\game") || filename.StartsWith("\\pak") || filename.StartsWith("\\zpak"))
            {
                return true;
            }
            if (filename.Equals("\\area22_lit.mega") ||
                filename.Equals("\\ark_lit.mega") ||
                filename.Equals("\\canyon_lit.mega") ||
                filename.Equals("\\island_lit.mega") ||
                filename.Equals("\\outskirts_lit.mega") ||
                filename.Equals("\\quarry_lit.mega") ||
                filename.Equals("\\refinery_lit.mega") ||
                filename.Equals("\\salvage_lit.mega") ||
                filename.Equals("\\sewer_lit.mega") ||
                filename.Equals("\\slipgate_lit.mega") ||
                filename.Equals("\\valley_lit.mega") ||
                filename.Equals("\\volcano_lit.mega"))
            {
                return true;
            }

            return false;
        }

        public bool isMD5Computed()
        {
            return md5computed;
        }

        public bool Official
        {
            get { return official; }
        }
            

        public string GetMD5Hash()
        {
            if (!md5hash.Equals(""))
            {
                return this.md5hash;
            }

            FileInfo fi = new FileInfo(path + filename);
            FileStream fs = fi.OpenRead();
            MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider();
            md5hash = BitConverter.ToString(md5csp.ComputeHash(fs)).Replace("-", "").ToLower();
            fs.Close();

            md5computed = true;
            return md5hash;
        }

        public string ExpectedMD5Hash
        {
            get { return expectedMd5hash; }
            set { expectedMd5hash = value; }
        }

        public string Path
        {
            get { return path; }
        }

        public string Filename
        {
            get { return filename; }
        }

        public override string ToString()
        {
            return path + filename;
        }
    }
}
