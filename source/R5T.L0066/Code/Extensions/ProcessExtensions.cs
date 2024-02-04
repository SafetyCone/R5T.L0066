using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace R5T.L0066.Extensions
{
    public static class ProcessExtensions
    {
        public static Task WaitForExitAsync(this Process process)
        {
            return Task.Run(() =>
            {
                process.WaitForExit();
            });
        }
    }
}
