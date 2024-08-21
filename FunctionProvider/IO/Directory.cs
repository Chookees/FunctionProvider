namespace FunctionProvider.IO
{
    using SIO = System.IO;
    public class Directory
    {
        public static DriveInfo[] GetDrives()
        {
            return SIO.DriveInfo.GetDrives();
        }
    }
}
