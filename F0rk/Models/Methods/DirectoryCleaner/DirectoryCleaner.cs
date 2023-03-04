using System;
using System.IO;

namespace F0rk.Models.Methods.DirectoryCleaner
{
    public static class DirectoryCleaner
    {
        /// <summary>
        /// Deletes every file in a folder
        /// </summary>
        /// <param name="folders">Folders to delete all files</param>
        private static void DeleteAllFiles(DirectoryInfo folders)
        {
            foreach (FileInfo file in folders.GetFiles())
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

        /// <summary>
        /// Deletes every file older 30 days in a folder
        /// </summary>
        /// <param name="emailsFolder">Folder with emails</param>
        /// <param name="lastTimeUsedMoreThan">Deletes emails that have not been used for more than x days</param>
        private static void DeleteOldEmails(DirectoryInfo emailsFolder, DateTime lastTimeUsedMoreThan)
        {
            foreach (FileInfo email in emailsFolder.GetFiles())
            {
                if (email.LastWriteTime < lastTimeUsedMoreThan)
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
        /// <param name="folders">Folders to remove all subfolders</param>
        private static void DeleteAllDirectories(DirectoryInfo folders)
        {
            foreach (DirectoryInfo subfolder in folders.GetDirectories())
            {
                try
                {
                    subfolder.Delete(true);
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
        public static void CleanUpCompletely(string[] paths)
        {
            foreach (string path in paths)
            {
                var directory = new DirectoryInfo(path);

                if (directory.Exists)
                {
                    DeleteAllFiles(directory);
                    DeleteAllDirectories(directory);
                }
            }
        }

        /// <summary>
        /// Deletes all files in a folder and deletes all files in subfolders without deleting subfolders
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
                        DeleteAllFiles(dir);
                        DeleteAllDirectories(dir);
                    }
                    DeleteAllFiles(directory);
                }
            }
        }

        public static void CleanUpMail(DirectoryInfo directory, DateTime todaySubtractMonth)
        {
            if (!directory.Exists) throw new ArgumentNullException();

            foreach (DirectoryInfo folder in directory.GetDirectories())
            {
                if (!folder.FullName.ToUpperInvariant().Contains("Espoint".ToUpperInvariant()) ||
                    !folder.FullName.ToUpperInvariant().Contains("SVZ".ToUpperInvariant())) continue;

                foreach (DirectoryInfo subFolder in folder.GetDirectories())
                {
                    if (subFolder.FullName.ToUpperInvariant().Contains("Junk".ToUpperInvariant()) ||
                        subFolder.FullName.ToUpperInvariant().Contains("Deleted Items".ToUpperInvariant()))
                    {
                        DeleteAllFiles(subFolder);
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