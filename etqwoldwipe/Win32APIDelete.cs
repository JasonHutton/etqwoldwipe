using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace etqwoldwipe
{
    public static class Win32APIDelete
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
        private struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.U4)]
            public int wFunc;
            public string pFrom;
            public string pTo;
            public short fFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;

        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);
        private const int FO_DELETE = 3;
        private const int FOF_ALLOWUNDO = 0x40;
        private const int FOF_NOCONFIRMATION = 0x10;    //No prompt dialogs 

        public static void Delete(string filename)
        {
            SHFILEOPSTRUCT shf = new SHFILEOPSTRUCT();
            shf.wFunc = Win32APIDelete.FO_DELETE;
            shf.fFlags = Win32APIDelete.FOF_ALLOWUNDO | Win32APIDelete.FOF_NOCONFIRMATION;
            shf.pFrom = filename;
            if (SHFileOperation(ref shf) != 0)
            {
                throw new Exception("File deletion did not succeed.");
            }
        }
    }
}
