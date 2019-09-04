﻿using System;
using System.IO;

namespace dev.jerry_h.pc_tools.CommonLibrary
{
    public class FileManager
    {
        private void clone(String sourcePath, String destinationDir)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(sourcePath);
                if ((attr & FileAttributes.Directory).Equals(FileAttributes.Directory))   //sourcePath is a directory
                {
                    destinationDir = Path.Combine(destinationDir, Path.GetFileName(sourcePath));
                    if (!Directory.Exists(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }
                    foreach (String directory in Directory.GetDirectories(sourcePath))
                    {
                        clone(directory, Path.Combine(destinationDir, Path.GetFileName(directory)));
                    }
                    foreach (String file in Directory.GetFiles(sourcePath))
                    {
                        String strDestFilePath = "";
                        try
                        {
                            String fileName = Path.GetFileName(file);
                            strDestFilePath = Path.Combine(destinationDir, fileName);
                            //var query = from name in uploadedName
                            //            where name.ToString().Equals(fileName)
                            //            select name;
                            //if (query.Count<String>() == 0)
                            //{
                            File.Copy(file, strDestFilePath, true);
                            //uploadedName.Add(fileName);
                            //}
                        }
                        catch
                        {
                            //MessageBox.Show("[FormScriptUpload]-exception, copy \"" + file + "\" to " + strDestFilePath + "\"");
                        }
                    }
                }
                else //sourcePath is a file
                {
                    //String destinaionDir = destinationDir.Replace(Path.GetFileName(destinationDir), "");
                    if (!Directory.Exists(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }
                    String strDestFilePath = "";
                    try
                    {
                        String fileName = Path.GetFileName(sourcePath);
                        strDestFilePath = Path.Combine(destinationDir, fileName);
                        File.Copy(sourcePath, strDestFilePath, true);
                    }
                    catch
                    {
                        //MessageBox.Show("[FormScriptUpload]-exception, copy \"" + sourcePath + "\" to " + strDestFilePath + "\"");
                    }
                    File.Copy(sourcePath, strDestFilePath, true);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("[FormScriptUpload]-exception, message = \r\n" + ex.Message);
            }
        }
    }
}