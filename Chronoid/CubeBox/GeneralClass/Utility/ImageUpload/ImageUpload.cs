using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.IsolatedStorage;

namespace GeneralClass.Utility.ImageUpload
{
    public static class ImageUpload
    {
        public static string UrlToLocal(string source, string path, HttpServerUtilityBase Server) {
            try {
                WebClient webClient = new WebClient();
                var filePath = Path.Combine(Server.MapPath(path), "_" + "UPLOAD0" + DateTime.UtcNow.Day + "_" + DateTime.UtcNow.Month + "_" + DateTime.UtcNow.Year + ".png");
                var dbFilePath = Path.Combine(path, "_" + "UPLOAD0" + DateTime.UtcNow.Day + "_" + DateTime.UtcNow.Month + "_" + DateTime.UtcNow.Year + ".png");
                var index = 0;
                while (true)
                {
                    if (PathChecker.PathChecker.IsExist(filePath))
                    {
                        var file = Path.Combine("_" + "UPLOAD" + index + DateTime.UtcNow.Day + "_" + DateTime.UtcNow.Month + "_" + DateTime.UtcNow.Year + ".png");
                        filePath = Path.Combine(Server.MapPath(path), file);
                        dbFilePath = Path.Combine(path, file);
                    }
                    else
                    {
                        break;
                    }
                    index++;
                }
                webClient.DownloadFile(source, filePath);
                return dbFilePath;
            } catch { return ""; }
        }

        public static bool UriToServer(string source, string filePath)
        {
            var base64Data = Regex.Match(source, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var byteArray = Convert.FromBase64String(base64Data);
            System.IO.File.WriteAllBytes(filePath, byteArray);
            return true;
        }
    }
}
