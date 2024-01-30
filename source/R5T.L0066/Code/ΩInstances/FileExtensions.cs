using System;


namespace R5T.L0066
{
    public class FileExtensions : IFileExtensions
    {
        #region Infrastructure

        public static IFileExtensions Instance { get; } = new FileExtensions();


        private FileExtensions()
        {
        }

        #endregion
    }
}
