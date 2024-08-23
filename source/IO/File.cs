namespace FunctionProvider.IO
{
    using SIO = System.IO;

    public sealed class File
    {
        #region Lazy initialization

        private static readonly Lazy<File> lazy = new Lazy<File>(() => new File());

        public static File Task { get { return lazy.Value; } }

        private File() { }

        #endregion

        private string extForFile = ".txt";
        private string nameForFile = "temp";
        private string pathForFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\temp.txt");

        /// <summary>
        /// Creates a file and fills it with content.
        /// </summary>
        /// <param name="fullPath">Full path to File with Directory,Name and Extension.</param>
        /// <param name="content">Content of file.</param>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes CreateFile(string fullPath, string[] content)
        {
            ReturnCodes returnCode = ReturnCodes.Undefined;

            try
            {
                SIO.File.WriteAllLines(fullPath, content);

                returnCode = ReturnCodes.Success;
            }
            catch (Exception)
            {
                returnCode = ReturnCodes.FileCreationFailed;
            }

            return returnCode; 
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="fullPath">Full path to file.</param>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes DeleteFile(string fullPath)
        {
            ReturnCodes returnCode = ReturnCodes.Undefined;

            try
            {
                if (SIO.File.Exists(fullPath))
                {
                    SIO.File.Delete(fullPath);

                    if (!SIO.File.Exists(fullPath))
                    {
                        returnCode = ReturnCodes.Success;
                    }
                    else
                    {
                        returnCode = ReturnCodes.UnableToDelete;
                    }
                }
                else
                {
                    returnCode = ReturnCodes.PathIsInvalid;
                }
            }
            catch (Exception)
            {
                returnCode = ReturnCodes.UnableToDelete;
            }

            return returnCode;
        }

        /// <summary>
        /// Copies a file.
        /// </summary>
        /// <param name="sourcePath">Source file path.</param>
        /// <param name="destinationPath">Target file path.</param>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes CopyFile(string sourcePath, string destinationPath)
        {
            try
            {
                if (SIO.File.Exists(sourcePath))
                {
                    SIO.File.Copy(sourcePath, destinationPath, true);
                    return ReturnCodes.Success;
                }
                return ReturnCodes.ParameterInvalid;
            }
            catch (Exception)
            {
                return ReturnCodes.CopyFailed;
            }
        }

        /// <summary>
        /// Call this first.
        /// Creates a new writer to dynamically create and fill the file.
        /// </summary>
        /// <param name="path">Path to the directory of the file.</param>
        /// <param name="name">Name of the file.</param>
        /// <param name="extension">Extension of the file e.g. .txt/.ini/.cfg/.log..</param>
        /// <returns>ReturnCode based on result.</returns>
        public ReturnCodes CreateWriter(string path, string name, string extension)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) || !string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(extension))
                {
                    string fullPath = MergePath(path, name, extension);

                    if (fullPath != null)
                    {
                        if (IsValid(path, name, extension))
                        {
                            pathForFile = path;
                            nameForFile = name;
                            extForFile = extension;
                            writer = new StreamWriter(fullPath);

                            return ReturnCodes.Success;
                        }

                        return ReturnCodes.PathIsInvalid;
                    }

                    return ReturnCodes.PathIsInvalid;
                }

                return ReturnCodes.ParameterInvalid;
            }
            catch (Exception)
            {
                return ReturnCodes.CreatingWriterFailed;
            }
        }

        /// <summary>
        /// Changes the Directory of the File.
        /// </summary>
        /// <param name="path">Path to new directory.</param>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes ChangeDir(string path)
        {
            if (Path.Exists(path))
            {
                try
                {
                    if (IsValid(path, nameForFile, extForFile))
                    {
                        string fullpath = MergePath(path, nameForFile, extForFile);
                        
                        if (fullpath != null)
                        {
                            writer.Flush();
                            writer.Close();

                            pathForFile = path;
                            writer = new StreamWriter(fullpath);
                        }
                        
                        return ReturnCodes.Success;
                    }
                    else
                    {
                        return ReturnCodes.PathIsInvalid;
                    }
                }
                catch (IOException)
                {

                    return ReturnCodes.Undefined;
                }
            }
            else
            {
                return ReturnCodes.PathIsInvalid;
            }
        }

        /// <summary>
        /// Changes the Name of the File you are writing to.
        /// </summary>
        /// <param name="newName">New Name for the file.</param>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes ChangeFileName(string newName)
        {
            try
            {
                string newFullPath = MergePath(pathForFile, newName, extForFile);
                
                if (newFullPath == null)
                {
                    return ReturnCodes.ParameterInvalid;
                }

                writer.Flush();
                writer.Close();
                nameForFile = newName;
                
                writer = new StreamWriter(newFullPath);

                return ReturnCodes.Success;
            }
            catch (IOException)
            {
                return ReturnCodes.Undefined;
            }
        }

        /// <summary>
        /// Changes the extension of the file.
        /// </summary>
        /// <param name="newExtension">New Extension like '.txt' or '.ini'</param>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes ChangeExtenstion(string newExtension)
        {
            ReturnCodes returnCode = ReturnCodes.Undefined;

            try
            {
                if (newExtension != null && newExtension.Contains("."))
                {
                    string fullPath = MergePath(pathForFile, nameForFile, newExtension);

                    if (fullPath != null && IsValid(pathForFile, nameForFile, newExtension))
                    {
                        writer.Flush();
                        writer.Close();

                        writer = new StreamWriter(fullPath);

                        return ReturnCodes.Success;
                    }
                }
                else
                {
                    returnCode = ReturnCodes.ParameterInvalid;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return returnCode;
        }

        /// <summary>
        /// Writes an Array of strings to the file.
        /// </summary>
        /// <param name="texts">Array of strings</param>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes WriteAll(string[] texts)
        {
            try
            {
                foreach (string item in texts)
                {
                    writer.WriteLine(item);
                }

                writer.FlushAsync();
                return ReturnCodes.Success;
            }
            catch (Exception)
            {
                return ReturnCodes.WriteAllFailed;
            }            
        }

        /// <summary>
        /// Writes a new line to the file.
        /// </summary>
        /// <param name="text">Line of text.</param>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes WriteLine(string text)
        {
            try
            {
                writer.WriteLine(text);
                writer.FlushAsync();

                return ReturnCodes.Success;
            }
            catch (Exception)
            {
                return ReturnCodes.WriteLineFailed;
            }
        }

        /// <summary>
        /// Writes text in line to the file.
        /// </summary>
        /// <param name="text">Text to write in line.</param>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes Write(string text)
        {
            try
            {
                writer.Write(text);
                writer.FlushAsync();

                return ReturnCodes.Success;
            }
            catch (Exception)
            {
                return ReturnCodes.WriteFailed;
            }
        }

        /// <summary>
        /// Forces a save to the file.
        /// </summary>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes ForceSave()
        {
            ReturnCodes returnCode = ReturnCodes.Undefined;

            try
            {
                writer.Flush();
                writer.Close();
                writer = new StreamWriter(MergePath(pathForFile, nameForFile, extForFile), true);

                returnCode = ReturnCodes.Success;
            }
            catch (Exception)
            {
                returnCode = ReturnCodes.SaveFileFailed;
            }

            return returnCode;
        }

        /// <summary>
        /// Reads a file and returns the content as string.
        /// </summary>
        /// <param name="path">Path to the file that should be read.</param>
        /// <returns>Content as string / string.Empty when exception occured.</returns>
        public string ReadFile(string path)
        {
            try
            {
                SIO.StreamReader streamReader = new SIO.StreamReader(path);
                
                return streamReader.ReadToEnd();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Reads the Writers file and returns the content as string.
        /// </summary>
        /// <returns>Content as string / string.Empty when exception occured.</returns>
        public string ReadFile()
        {
            string result = string.Empty;
            try
            {
                string fullPath = MergePath(pathForFile, nameForFile, extForFile);

                if (fullPath != null)
                {
                    if (IsValid(pathForFile, nameForFile, extForFile))
                    {
                        writer.Flush();
                        writer.Close();

                        SIO.StreamReader streamReader = new SIO.StreamReader(fullPath);

                        result = streamReader.ReadToEnd();

                        streamReader.Close();

                        writer = new StreamWriter(fullPath);
                    }
                    else
                    {
                        result = string.Empty;
                    }
                }
                else
                {
                    result = string.Empty;
                }
            }
            catch (Exception)
            {
                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// Closes the File. Saving to the file happen here if ForceSave() was not called.
        /// </summary>
        /// <returns>Returncode based on result.</returns>
        public ReturnCodes Close()
        {
            ReturnCodes returnCode = ReturnCodes.Undefined;

            try
            {
                writer.Flush();
                writer.Close();

                returnCode = ReturnCodes.Success;
            }
            catch (Exception)
            {
                returnCode = ReturnCodes.SaveFileFailed;
            }

            return returnCode;
        }

        #region privates
        private bool IsValid(string path, string name, string ext)
        {
            if (Path.Exists(path))
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (ext.Contains("."))
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }

            return false;
        }

        private string? MergePath(string path, string name, string extension)
        {
            if ((path != null) && (name != null) && (extension != null))
            {
                return path + "\\" + name + extension;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}