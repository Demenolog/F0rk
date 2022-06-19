using System;
using System.IO;

namespace F0rk.Models.Methods.DirectoryCleaner
{
    public static class DirectoryCleaner
    {
        /// <summary>
        /// Deletes every file in a folder
        /// </summary>
        /// <param name="directory">Folders to delete files</param>
        private static void DeleteFiles(DirectoryInfo directory)
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
        }

        private static void DeleteOldEmails(DirectoryInfo emailDirectory, DateTime todaySubtractMonth)
        {
            foreach (FileInfo email in emailDirectory.GetFiles())
            {
                if (email.LastWriteTime < todaySubtractMonth)
                {
                    try
                    {
                        email.Delete();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
        }

        /// <summary>
        /// Deletes all subfolders in a folder
        /// </summary>
        /// <param name="directory">Folders to remove subfolders</param>
        private static void DeleteDirectories(DirectoryInfo directory)
        {
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

        /// <summary>
        /// Deletes all files and subfolders at address
        /// </summary>
        /// <param name="paths">Paths to clean</param>
        public static void CleanUpComplete(string[] paths)
        {
            foreach (string path in paths)
            {
                var directory = new DirectoryInfo(path);

                if (directory.Exists)
                {
                    DeleteFiles(directory);
                    DeleteDirectories(directory);
                }
            }
        }

        /// <summary>
        /// Deletes all files in a folder and deletes all files in subfolders
        /// </summary>
        /// <param name="paths">Paths to clean</param>
        public static void CleanUpDirectories(string[] paths)
        {
            foreach (string path in paths)
            {
                var directory = new DirectoryInfo(path);

                if (directory.Exists)
                {
                    foreach (DirectoryInfo dir in directory.GetDirectories())
                    {
                        DeleteFiles(dir);
                        DeleteDirectories(dir);
                    }
                    DeleteFiles(directory);
                }
            }
        }

        public static void CleanUpMail(DirectoryInfo directory, DateTime todaySubtractMonth)
        {
            if (!directory.Exists) throw new ArgumentNullException();

            foreach (DirectoryInfo folder in directory.GetDirectories())
            {
                if (!folder.FullName.ToUpperInvariant().Contains("Espoint".ToUpperInvariant())) continue;

                foreach (DirectoryInfo subFolder in folder.GetDirectories())
                {
                    if (subFolder.FullName.ToUpperInvariant().Contains("Junk".ToUpperInvariant()))
                    {
                        DeleteFiles(subFolder);
                    }
                    else if (subFolder.FullName.ToUpperInvariant().Contains("Inbox".ToUpperInvariant()))
                    {
                        foreach (DirectoryInfo inboxFolder in subFolder.GetDirectories())
                        {
                            DeleteOldEmails(inboxFolder, todaySubtractMonth);
                        }
                        DeleteOldEmails(subFolder, todaySubtractMonth);
                    }
                    else
                    {
                        DeleteOldEmails(subFolder, todaySubtractMonth);
                    }
                }
            }
        }
    }
}