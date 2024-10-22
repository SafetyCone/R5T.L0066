using System;
using System.Runtime.InteropServices;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IOperatingSystemOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        protected Internal.IOperatingSystemOperator _Internal => Internal.OperatingSystemOperator.Instance;
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
        {
            // Implementation note: there is no RuntimeInformation.GetOSPlatform() method, so the only way to determine the OSPlatform is to test each one.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OSPlatform.Windows;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OSPlatform.OSX;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OSPlatform.Linux;
            }

            throw _Internal.Get_UnknownOSPlatformException();
        }

        public bool Is_LinuxOSPlatform(OSPlatform oSPlatform)
        {
            var output = OSPlatform.Linux == oSPlatform;
            return output;
        }

        public bool Is_OsxOSPlatform(OSPlatform oSPlatform)
        {
            var output = OSPlatform.OSX == oSPlatform;
            return output;
        }

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

        public T SwitchOn_OSPlatform_ByValue<T>(
            T windowsValue,
            T osxValue,
            T linuxValue)
        {
            var osPlatform = this.Get_OSPlatform();

            return this.SwitchOn_OSPlatform_ByValue(
                osPlatform,
                windowsValue,
                osxValue,
                linuxValue);
        }

        public T SwitchOn_OSPlatform_ByValue<T>(
            T windowsValue,
            T osxValue,
            T linuxValue,
            T unknownValue)
        {
            var osPlatform = this.Get_OSPlatform();

            return this.SwitchOn_OSPlatform_ByValue(
                osPlatform,
                windowsValue,
                osxValue,
                linuxValue,
                unknownValue);
        }

        public T SwitchOn_OSPlatform_ByValue<T>(
            OSPlatform osPlatform,
            T windowsValue,
            T osxValue,
            T linuxValue)
        {
            // Unable to use basic switch statement since OSPlatform values are not constant.
            // Unable to use relational switch statement since it is not available until C# 9.0 (net5.0).

            // Put Linux first, since this is most common in production.
            if (this.Is_LinuxOSPlatform(osPlatform))
            {
                return linuxValue;
            }

            // Put Windows second, since this is most common in development.
            if (this.Is_WindowsOSPlatform(osPlatform))
            {
                return windowsValue;
            }

            // Put OSX last, since this is least common.
            if (this.Is_OsxOSPlatform(osPlatform))
            {
                return osxValue;
            }

            throw _Internal.Get_UnknownOSPlatformException();
        }

        public T SwitchOn_OSPlatform_ByValue<T>(
            OSPlatform osPlatform,
            T windowsValue,
            T osxValue,
            T linuxValue,
            T unknownValue)
        {
            // Unable to use basic switch statement since OSPlatform values are not constant.
            // Unable to use relational switch statement since it is not available until C# 9.0 (net5.0).

            // Put Linux first, since this is most common in production.
            if (this.Is_LinuxOSPlatform(osPlatform))
            {
                return linuxValue;
            }

            // Put Windows second, since this is most common in development.
            if (this.Is_WindowsOSPlatform(osPlatform))
            {
                return windowsValue;
            }

            // Put OSX last, since this is least common.
            if (this.Is_OsxOSPlatform(osPlatform))
            {
                return osxValue;
            }

            return unknownValue;
        }
    }
}
