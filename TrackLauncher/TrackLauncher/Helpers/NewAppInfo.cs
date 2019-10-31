using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackLauncher.Helpers
{
    public static class NewAppInfo
    {
        public static string appName;
        public static string appPath;

        public static void ResetValues()
        {
            appName = null;
            appPath = null;
        }
    }
}
