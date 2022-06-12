using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F0rk.Methods.DirectoryCleaner
{
    public static class DirectoryCleaner
    {
        /// <summary>
        /// Deletes all files and folders at address
        /// </summary>
        /// <param name="paths">Paths to clean</param>
        public static void CompleteCleanup(string[] paths)
        {
            foreach (string path in paths)
            {
                var directory = new DirectoryInfo(path);

                if (directory.Exists)
                {
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                    foreach (DirectoryInfo dir in directory.GetDirectories())
                    {
                        try
                        {
                            dir.Delete(true);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }
            }
        }
    }
}
