using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupCommanderUI.Common
{
    class ProjectFile
    {
        private string path;
        private string fileName;
        private bool firstTime;
        private const string projectExtension = "yaml";

        public string FullPath
        {
            get
            {
                return System.IO.Path.Combine(path, fileName);
            }
        }

        public ProjectFile()
        {
            path = string.Empty;
            fileName = string.Empty;
            firstTime = true;
        }

        public void CreateNew()
        {
            if (firstTime)
            {
                path = System.IO.Directory.GetCurrentDirectory();
                fileName = "new test." + projectExtension;

                var saveFileDialog = new Microsoft.Win32.SaveFileDialog();

                saveFileDialog.InitialDirectory = path;
                saveFileDialog.FileName = fileName;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = projectExtension;

                if (saveFileDialog.ShowDialog() == true)
                {
                    fileName = System.IO.Path.GetFileName(saveFileDialog.FileName);
                    path = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                    firstTime = false;
                }
            }
        }
        public bool Load()
        {
            bool isCancelled = false;
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.InitialDirectory = path;
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = projectExtension;

            if (openFileDialog.ShowDialog() == true)
            {
                fileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                path = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
            }
            else
                isCancelled = true;

            return isCancelled;
        }
        public bool Save()
        {
            bool isCancelled = false;
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.InitialDirectory = path;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = projectExtension; // TODO: extension filter is not working

            if (saveFileDialog.ShowDialog() == true)
            {
                fileName = System.IO.Path.GetFileName(saveFileDialog.FileName);
                path = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
            }
            else
                isCancelled = true;

            return isCancelled;
        }
    }
}
