using HandyControl.Controls;
using HandyControl.Data;

namespace AdamDevelopmentEnvironment.Core.Notification
{
    public class Growls
    {
        public static void ErrorGrowls(string message)
        {
            GrowlInfo gf = new()
            {
                Message = message,
                StaysOpen = true,
                IsCustom = true,
                ShowCloseButton = true,
                WaitTime = 3,
                Token = "GrowlToNotifyBar",
            };

            Growl.Error(gf);

            if (NotifyBarIsExpanded)
                return;

            gf.StaysOpen = false;
            gf.Token = "GlobalGrowl";
            Growl.ErrorGlobal(gf);
        }

        public static void InformationGrowls(string message)
        {
            GrowlInfo gf = new()
            {
                Message = message,
                StaysOpen = false,
                IsCustom = true,
                ShowCloseButton = true,
                WaitTime = 3,
                Token = "GrowlToNotifyBar",
            };

            Growl.Info(gf);

            if (NotifyBarIsExpanded)
                return;

            gf.StaysOpen = false;
            gf.Token = "GlobalGrowl";
            Growl.InfoGlobal(gf);
        }

        public static void ClearNotifyBarGrowls()
        {
            Growl.Clear("GrowlToNotifyBar");
        }

        public static bool NotifyBarIsExpanded { get; set; } = false;
    }
}
