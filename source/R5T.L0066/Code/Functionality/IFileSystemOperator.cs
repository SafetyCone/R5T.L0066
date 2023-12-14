using System;
using System.IO;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Creates a directory idempotently (meaning there is no problem with issuing the command multiple times). 
        /// Note: The system method <see cref="Directory.CreateDirectory(string)"/> does not throw an exception if you create a directory that already exists. However, it's hard to remember this fact. Thus, this method name makes that fact explicit.
        /// </summary>
        public void Create_Directory_OkIfAlreadyExists(string directoryPath)
        {
            // Does not throw an exception if a directory already exists.
            // See proof at: https://github.com/MinexAutomation/Public/blob/a8c302415b56fb8903c751436cbeef3eae8e1692/Source/Experiments/CSharp/ExaminingCSharp/ExaminingCSharp/Code/Experiments/IOExperiments.cs#L24
            Directory.CreateDirectory(directoryPath);
        }

        public void Ensure_DirectoryExists_ForFilePath(string filePath)
        {
            var directoryPath = PathOperator.Instance.Get_ParentDirectoryPath_ForFile(filePath);

            this.Create_Directory_OkIfAlreadyExists(directoryPath);
        }
    }
}
