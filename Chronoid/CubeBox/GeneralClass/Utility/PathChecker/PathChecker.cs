using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClass.Utility.PathChecker
{
    public static class PathChecker
    {
        public static bool IsExist(string path) {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }
        //how to use 
        // server.map('/UPLOADS/Path/File'
        public static string FindAvailableFileName(string fileStart, string fileName) {
            var index = 0;
            while (true) {
                if (!IsExist(fileStart+"/"+fileName+ index+".png")) {
                    return fileName + index+".png";
                }
                index++;
            }
        } 
        //sample how to use this
        //PathChecker.GenerateFolderOnPath(Server.MapPath("/UPLOADS"), "John");
        public static bool GenerateFolderOnPath(string path, string folderName) {
            try {
                System.IO.Directory.CreateDirectory(path + "/" + folderName);
                return true;
            } catch { return false; }
        }
        public static bool GenerateFolderOnPath(string path) {
            try {
                System.IO.Directory.CreateDirectory(path);
                return true;
            } catch { return false; }
        }




    }
}
