using System;
using System.Runtime.InteropServices;

using R5T.T0132;

using F10Y.T0011;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IOperatingSystemOperator : IFunctionalityMarker,
        F10Y.L0000.IOperatingSystemOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IOperatingSystemOperator _F10Y_L0000 => F10Y.L0000.OperatingSystemOperator.Instance;

        [Ignore]
        public new Internal.IOperatingSystemOperator _Internal => Internal.OperatingSystemOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public OSPlatform[] Get_CanonicalOperatingSystems()
        {
            var output = new[]
            {
                OSPlatform.Linux,
                OSPlatform.OSX,
                OSPlatform.Windows,
            };

            return output;
        }

        /// <summary>
        /// Get the operating system platform on which code is currently running.
        /// </summary>
        // Prior work: R5T.D0024.Default.OSPlatformProvider
        public OSPlatform Get_OSPlatform()
            => this.Get_CurrentOperatingSystemPlatform();

        public bool Is_LinuxOSPlatform(OSPlatform oSPlatform)
        {
            var output = OSPlatform.Linux == oSPlatform;
            return output;
        }

        public bool Is_OsxOSPlatform(OSPlatform oSPlatform)
            => this.Is_OSX_OperatingSystemPlatform(oSPlatform);

        public bool Is_WindowsOSPlatform(OSPlatform oSPlatform)
        {
            var output = OSPlatform.Windows == oSPlatform;
            return output;
        }

        public bool Is_Windows()
        {
            var output = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            return output;
        }
    }
}
