using HandyControl.Controls;
using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            gf.StaysOpen = false;
            gf.Token = "GlobalGrowl";
            Growl.InfoGlobal(gf);
        }
    }
}
