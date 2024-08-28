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

        public FileMode Get_FileMode_Overwrite()
            => this.Get_FileMode(true);

        public FileMode Get_FileMode_DoNotOverwrite()
            => this.Get_FileMode(false);
    }
}
