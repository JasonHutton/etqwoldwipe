using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace etqwoldwipe
{
    class DataItems : List<DataItem>
    {
        public int CountHashes()
        {
            int count = 0;
            foreach (DataItem di in this)
            {
                if (di.isMD5Computed())
                {
                    ++count;
                }
            }

            return count;
        }

        public int CountOfficial()
        {
            int count = 0;
            foreach (DataItem di in this)
            {
                if (di.Official)
                {
                    ++count;
                }
            }

            return count;
        }
    }
}
