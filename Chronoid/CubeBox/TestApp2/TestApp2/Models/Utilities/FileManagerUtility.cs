using GeneralClass.Utility.ImageUpload;
using GeneralClass.Utility.PathChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class FileManagerUtility
    {
        public static string UploadImage(HttpServerUtilityBase server, string imageSource, string destination, string fileName)
        {
            var path = destination;
            if (!PathChecker.IsExist(path))
            {
                PathChecker.GenerateFolderOnPath(destination);
            }
            var file = PathChecker.FindAvailableFileName(path, fileName);
            if (ImageUpload.UriToServer(imageSource, path + "/" + file))
            {
                return file;
            }
            else
            {
                return null;
            }
        }
    }
}