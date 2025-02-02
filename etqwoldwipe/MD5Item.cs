using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace etqwoldwipe
{
    class MD5Item
    {
        private string md5hash;
        private string separator;
        private string filetype;
        private string filename;

        public MD5Item(string md5hash, string separator, string filetype, string filename)
        {
            this.md5hash = md5hash;
            this.separator = separator;
            this.filetype = filetype;
            this.filename = filename;
        }

        public MD5Item(string line) 
            : this(line.Substring(0, 32), line.Substring(33, 1), 
            line.Substring(34, 1), line.Substring(35, line.Length - 35)) {}

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}", md5hash, separator, filetype, filename);
        }

        public string MD5Hash
        {
            get { return md5hash; }
            set { md5hash = value; }
        }
        public string Separator
        {
            get { return separator; }
            set { separator = value; }
        }
        public string Filetype
        {
            get { return filetype; }
            set { filetype = value; }
        }
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
    }
}
