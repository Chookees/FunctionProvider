namespace FunctionProvider.IO
{
    using System.Runtime.CompilerServices;
    using SIO = System.IO;
    public class Directory
    {
        public static DriveInfo[] GetDrives()
        {
            return SIO.DriveInfo.GetDrives();
        }

        public static DriveInfo GetDriveWithMostSpace()
        {
            DriveInfo mostSpaceDrive = new DriveInfo("temp");

            foreach (DriveInfo drive in GetDrives())
            {
                if (drive.AvailableFreeSpace > mostSpaceDrive.AvailableFreeSpace)
                {
                    mostSpaceDrive = drive;
                }
            }

            return mostSpaceDrive;
        }

        public static FileInfo[] GetAllFilesFromDirectory(string pathToDirectory)
        {
            DirectoryInfo directory = new DirectoryInfo(pathToDirectory);

            return directory.GetFiles("*", SearchOption.AllDirectories);
        }

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
    }
}
