namespace FunctionProvider.IO
{
    using SIO = System.IO;

    public class Directory
    {
        /// <summary>
        /// Gets all Drives as DriveInfo.
        /// </summary>
        /// <returns>Array of DriveInfos</returns>
        public static DriveInfo[] GetDrives()
        {
            return SIO.DriveInfo.GetDrives();
        }

        /// <summary>
        /// Gets the Drive with the most free Space.
        /// </summary>
        /// <returns>The Drive with the most free space or null if not found.</returns>
        public static DriveInfo? GetDriveWithMostSpace()
        {
            DriveInfo mostSpaceDrive = new DriveInfo("temp");

            foreach (DriveInfo drive in GetDrives())
            {
                if (drive.AvailableFreeSpace > mostSpaceDrive.AvailableFreeSpace)
                {
                    mostSpaceDrive = drive;
                }
            }

            if (mostSpaceDrive.Name != "temp")
            {
                return mostSpaceDrive;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all files from a directory and subdirectories.
        /// </summary>
        /// <param name="pathToDirectory">Path to the parent directory.</param>
        /// <returns>All files as FileInfo Array.</returns>
        public static FileInfo[] GetAllFilesFromDirectory(string pathToDirectory)
        {
            DirectoryInfo directory = new DirectoryInfo(pathToDirectory);

            return directory.GetFiles("*", SearchOption.AllDirectories);
        }

        /// <summary>
        /// Gets a specific file or first based on the name from a directory.
        /// </summary>
        /// <param name="pathToDirectory">Path to the parent directory.</param>
        /// <param name="fileName">Name of the file to search for.</param>
        /// <returns>FileInfo of the specific file or null if not found.</returns>
        public static FileInfo? GetSpecificFileFromDirectory(string pathToDirectory, string fileName)
        {
            DirectoryInfo directory = new DirectoryInfo(pathToDirectory);

            FileInfo[] fileInfo = directory.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo file in fileInfo)
            {
                if (file.Name == fileName)
                {
                    return file;
                }
            }

            return null;
        }

        /// <summary>
        /// Recursively copies all files from one directory to another.
        /// </summary>
        /// <param name="sourceDir">The source directory.</param>
        /// <param name="destDir">The destination directory.</param>
        public static void CopyDirectory(string sourceDir, string destDir)
        {
            if (!SIO.Directory.Exists(destDir))
                SIO.Directory.CreateDirectory(destDir);

            foreach (var file in SIO.Directory.GetFiles(sourceDir))
            {
                var destFile = Path.Combine(destDir, Path.GetFileName(file));
                SIO.File.Copy(file, destFile, true);
            }

            foreach (var dir in SIO.Directory.GetDirectories(sourceDir))
            {
                var destSubDir = Path.Combine(destDir, Path.GetFileName(dir));
                CopyDirectory(dir, destSubDir);
            }
        }
    }
}
