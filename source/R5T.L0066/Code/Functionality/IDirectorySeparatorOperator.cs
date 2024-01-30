using System;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IDirectorySeparatorOperator : IFunctionalityMarker
    {
        /// <summary>
		/// Given the Windows directory separator, get the non-Windows directory separator and vice-versa.
		/// Note: will throw an exception if the input <paramref name="directorySeparator"/> is not either the Windows or non-Windows directory separator.
		/// </summary>
		public char Get_AlternateDirectorySeparator(char directorySeparator)
        {
            this.Verify_IsDirectorySeparator(directorySeparator);

            // At this point, the input is either the Windows or non-Windows directory separator.
            var isWindows = this.Is_WindowsDirectorySeparator(directorySeparator);

            var output = isWindows
                ? Instances.DirectorySeparators.NonWindows
                : Instances.DirectorySeparators.Windows
                ;

            return output;
        }

        public char Get_CurrentPlatformDirectorySeparator()
        {
            var output = Path.DirectorySeparatorChar;
            return output;
        }

        public char Get_CurrentPlatformAlternateDirectorySeparator()
        {
            var output = Path.AltDirectorySeparatorChar;
            return output;
        }

        public bool Is_DirectorySeparator(char character)
        {
            var directorySeparators = Instances.DirectorySeparators.Both;

            var output = directorySeparators.Contains(character);
            return output;
        }

        public bool Is_NonWindowsDirectorySeparator(char character)
        {
            var output = character == Instances.DirectorySeparators.NonWindows;
            return output;
        }

        public bool Is_WindowsDirectorySeparator(char character)
        {
            var output = character == Instances.DirectorySeparators.Windows;
            return output;
        }

        public void Verify_IsDirectorySeparator(char directorySeparator)
        {
            var isDirectorySeparator = this.Is_DirectorySeparator(directorySeparator);
            if (!isDirectorySeparator)
            {
                throw new ArgumentException($"The input directory separator ('{directorySeparator}') was not recognized as either the Windows ('\\') or non-Windows ('/') directory separator.", nameof(directorySeparator));
            }
        }
    }
}
