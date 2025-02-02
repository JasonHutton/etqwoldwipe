using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;
using System.IO;

namespace etqwoldwipe
{
    class ETQWData
    {
        private string gamePath;
        private string userPath;
        private DataItems data;
        
        public ETQWData()
        {
            RegistryKey rkLM = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Id\\ET - QUAKE Wars");
            gamePath = rkLM.GetValue("InstallPath").ToString() + "\\base";
            rkLM.Close();
            userPath = Environment.GetEnvironmentVariable("localappdata");
            if (userPath == null)
            {
                userPath = Environment.GetEnvironmentVariable("userprofile")
                    + "\\Local Settings\\Application Data";
            }
            userPath += "\\id Software\\Enemy Territory - QUAKE Wars" + "\\base";

            InvalidateData();
        }

        public void InvalidateData()
        {
            data = new DataItems();
        }

        public DataItems GetData(bool forceRecheck)
        {
            if (data.Count != 0 && forceRecheck == false)
            {
                return data;
            }

            List<string> foundFiles = getPathData(gamePath);
            foundFiles.AddRange(getPathData(userPath));
            foreach (string foundFile in foundFiles)
            {
                data.Add(new DataItem(foundFile));
            }

            return data;
        }

        public DataItems GetData()
        {
            return GetData(false);
        }

        public void SetData(DataItems data)
        {
            this.data = data;
        }

        public List<string> getPathData(string path)
        {
            List<string> allFiles = new List<string>();

            if (path == null || path.Equals(""))
            {
                return allFiles;
            }

            try
            {
                List<string> pk4s = Directory.GetFiles(path, "*.pk4").ToList<string>();
                allFiles.AddRange(pk4s);
            }
            catch (DirectoryNotFoundException) { /* Fail silently. */ }
            try
            {
                List<string> megas = Directory.GetFiles(path + "\\megatextures", "*.mega").ToList<string>();
                allFiles.AddRange(megas);
            }
            catch (DirectoryNotFoundException) { /* Fail silently. */ }

            return allFiles;
        }

        public string GamePath
        {
            get { return gamePath; }
            set { gamePath = value; }
        }

        public string UserPath
        {
            get { return userPath; }
            set { userPath = value; }
        }
    }
}
