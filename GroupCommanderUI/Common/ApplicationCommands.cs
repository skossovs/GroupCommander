using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupCommanderUI.Common
{
    static class ApplicationCommands
    {
        public static void ExitApplication()
        {
            System.Environment.Exit(1);
        }

        //public static Object ReadJsonObject(string fullPath, Type t)
        //{
        //    JsonSerializer serializer = new JsonSerializer();
        //    serializer.NullValueHandling = NullValueHandling.Include;
        //    Object result = null;

        //    using (var sr = new StreamReader(fullPath))
        //    using (var reader = new JsonTextReader(sr))
        //    {
        //        JObject jObject = (JObject)serializer.Deserialize(reader);
        //        result = jObject.ToObject(t);
        //    }
        //    return result;
        //}

        //public static void SaveJsonObject(string fullPath, Object obj)
        //{
        //    JsonSerializer serializer = new JsonSerializer();
        //    serializer.NullValueHandling = NullValueHandling.Include;

        //    using (StreamWriter sw = new StreamWriter(fullPath))
        //    using (JsonWriter writer = new JsonTextWriter(sw))
        //    {
        //        serializer.Serialize(writer, obj);
        //    }
        //}
        public static Tuple<bool, string> RunOpenFileDialog(string extension, string initialPath)
        {
            bool isCancelled = false;
            string fileNameFullPath = string.Empty;

            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.InitialDirectory = initialPath;
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = extension;

            if (openFileDialog.ShowDialog() == true)
                fileNameFullPath = openFileDialog.FileName;
            else
                isCancelled = true;

            return new Tuple<bool, string>(isCancelled, fileNameFullPath);
        }
    }
}
