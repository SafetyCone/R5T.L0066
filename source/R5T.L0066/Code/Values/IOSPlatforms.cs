using System;
using System.Runtime.InteropServices;

using R5T.T0131;


namespace R5T.L0066
{
    [ValuesMarker]
    public partial interface IOSPlatforms : IValuesMarker
    {
        public OSPlatform Environment => Instances.OperatingSystemOperator.Get_OSPlatform();

        public OSPlatform Linux => OSPlatform.Linux;
        public OSPlatform OSX => OSPlatform.OSX;
        public OSPlatform Winows => OSPlatform.Windows;
    }
}
