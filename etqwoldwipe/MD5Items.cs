using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace etqwoldwipe
{
    class MD5Items : List<MD5Item>
    {
        public string GetHashForFile(string filename)
        {
            foreach(MD5Item item in this)
            {
                if (item.MD5Hash != null && !item.MD5Hash.Equals(""))
                {
                    if (item.Filename.Equals(filename))
                    {
                        return item.MD5Hash;
                    }
                }
            }
            return null;
        }
    }
}
