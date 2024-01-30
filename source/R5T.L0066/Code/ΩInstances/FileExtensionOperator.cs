using System;


namespace R5T.L0066
{
    public class FileExtensionOperator : IFileExtensionOperator
    {
        #region Infrastructure

        public static IFileExtensionOperator Instance { get; } = new FileExtensionOperator();


        private FileExtensionOperator()
        {
        }

        #endregion
    }
}
