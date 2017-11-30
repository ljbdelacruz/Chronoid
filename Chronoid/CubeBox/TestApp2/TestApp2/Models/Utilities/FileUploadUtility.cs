using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public class FileUploadUtility
    {

        public static string UploadImageFile(HttpRequestBase Request, HttpServerUtilityBase Server, string pathToSave)
        {
            if (Request.Files.Count > 0)
            {
                var path = "";
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        var fileNameWithPath = "";
                        if (file.ContentLength == 0)
                        {
                            return "none";
                        }
                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        Console.WriteLine(file);
                        fname = "UPLOAD0" + "" + DateTime.UtcNow.Day + "_" + DateTime.UtcNow.Month + "_" + DateTime.UtcNow.Year + ".png";
                        fileNameWithPath = Path.Combine(Server.MapPath(pathToSave), "_" + fname);
                        int index = 0;
                        while (true)
                        {
                            if (IsPathExists(fileNameWithPath))
                            {
                                index++;
                                fname = "UPLOAD" + index;
                                fname = fname + "" + DateTime.UtcNow.Day + "_" + DateTime.UtcNow.Month + "_" + DateTime.UtcNow.Year + ".png";
                                fileNameWithPath = Path.Combine(Server.MapPath(pathToSave), "_" + fname);
                            }
                            else
                            {
                                break;
                            }
                        }
                        using (FileStream fileToSave = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            file.InputStream.CopyTo(fileToSave);
                        }
                        path = fileNameWithPath;
                        path = pathToSave + "_" + fname;


                        // Get the complete folder path and store the file inside it.  
                    }
                    // Returns message that successfully uploaded  

                    return path;
                }
                catch (Exception ex)
                {
                    return "error";
                }
            }
            else
            {
                return "error";
            }
        }
        public static bool IsPathExists(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }
    }
}