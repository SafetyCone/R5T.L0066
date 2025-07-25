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

        public T SwitchOn_OSPlatform<T>(
            Func<T> windowsFunction,
            Func<T> nonWindowsFunction)
        {
            var output = this.SwitchOn_OSPlatform(
                windowsFunction,
                nonWindowsFunction,
                nonWindowsFunction);

            return output;
        }

        public T SwitchOn_OSPlatform<T>(
            Func<T> windowsFunction,
            Func<T> osxFunction,
            Func<T> linuxFunction)
        {
            var osPlatform = this.Get_OSPlatform();

            var output = this.SwitchOn_OSPlatform(
                osPlatform,
                windowsFunction,
                osxFunction,
                linuxFunction);

            return output;
        }

        public T SwitchOn_OSPlatform<T>(
            OSPlatform osPlatform,
            Func<T> windowsFunction,
            Func<T> osxFunction,
            Func<T> linuxFunction)
        {
            var function = this.SwitchOn_OSPlatform_ByValue(
                osPlatform,
                windowsFunction,
                osxFunction,
                linuxFunction);

            var output = function();
            return output;
        }

        public T SwitchOn_OSPlatform<T>(
            T windowsValue,
            T nonWindowsValue)
        {
            return this.SwitchOn_OSPlatform_ByValue(
                windowsValue,
                nonWindowsValue,
                nonWindowsValue);
        }

        public T SwitchOn_OSPlatform<T>(
            T windowsValue,
            T osxValue,
            T linuxValue)
        {
            return this.SwitchOn_OSPlatform_ByValue(
                windowsValue,
                osxValue,
                linuxValue);
        }

        // Prior work: R5T.D0025.Default.OSPlatformSwitch and R5T.D0025.Base.IOSPlatformSwitchExtensions.
        public T SwitchOn_OSPlatform<T>(
            OSPlatform osPlatform,
            T windowsValue,
            T osxValue,
            T linuxValue)
        {
            return this.SwitchOn_OSPlatform_ByValue(
                osPlatform,
                windowsValue,
                osxValue,
                linuxValue);
        }  
    }
}
