using System;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.System;

namespace My
{
    static class MyProtocolClientHelper
    {
        public static async Task<LaunchUriResult> LaunchAsync(ValueSet data)
        {
            var uri = new Uri("test-app2app:");

            var options = new LauncherOptions
            {
                TargetApplicationPackageFamilyName = "093809b5-3c54-493c-afae-511e536696e0_2b8nt83wged5r"
            };

            return await Launcher.LaunchUriForResultsAsync(uri, options, data);
        }
    }
}