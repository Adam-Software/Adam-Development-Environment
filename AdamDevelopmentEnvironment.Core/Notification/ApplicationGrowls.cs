using HandyControl.Controls;
using HandyControl.Data;

namespace AdamDevelopmentEnvironment.Core.Notification
{
    public class ApplicationGrowls : IApplicationGrowls
    {
        public void ErrorGrowls(string message)
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

            if (NotShowClobalGrowl)
                return;

            gf.StaysOpen = false;
            gf.Token = "GlobalGrowl";
            Growl.ErrorGlobal(gf);
        }

        public void InformationGrowls(string message)
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

            if (NotShowClobalGrowl)
                return;

            gf.StaysOpen = false;
            gf.Token = "GlobalGrowl";
            Growl.InfoGlobal(gf);
        }

        public void ClearNotifyBarGrowls()
        {
            Growl.Clear("GrowlToNotifyBar");
        }

        public void ClearClobalGrowls()
        {
            Growl.ClearGlobal();
        }

        /// <summary>
        /// If true don`t show Global growl
        /// </summary>
        public bool NotShowClobalGrowl { get; set; } = false;
    }
}
