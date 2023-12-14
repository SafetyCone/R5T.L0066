using System;
using System.IO;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IFileModeOperator : IFunctionalityMarker
    {
        public FileMode Get_FileMode(bool overwrite)
        {
            var output = overwrite
                ? FileMode.Create
                : FileMode.CreateNew
                ;

            return output;
        }
    }
}
