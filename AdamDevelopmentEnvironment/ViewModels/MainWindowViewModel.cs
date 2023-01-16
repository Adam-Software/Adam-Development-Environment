using Prism.Mvvm;
using System.Windows;

namespace AdamDevelopmentEnvironment.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string mTitle = "Prism Application";
        private double mBlocklyWidthRegion = Properties.Settings.Default.BlocklyWidthRegion;
        private double mSourceEditorHeight = Properties.Settings.Default.SourceEditorHeight;

        public string Title
        {
            get { return mTitle; }
            set { SetProperty(ref mTitle, value); }
        }

        public MainWindowViewModel()
        {

        }

        /// <summary>
        /// The fields determine the position of the splitters relative to the 
        /// left/top element and save it in the settings.
        /// If there are no saved settings, then the fields return a division by *.
        /// </summary>
        #region Position of splitters

        public GridLength BlocklyWidthRegion 
        { 
            get 
            {
                if (mBlocklyWidthRegion == 0)
                    return new GridLength(1, GridUnitType.Star);

                return new GridLength(mBlocklyWidthRegion);
            }

            set
            {
                SetProperty(ref mBlocklyWidthRegion, value.Value);
                Properties.Settings.Default.BlocklyWidthRegion = value.Value;
            } 
        }

        public GridLength SourceEditorHeight 
        {
            get
            {
                if (mSourceEditorHeight == 0)
                    return new GridLength(1, GridUnitType.Star);

                return new GridLength(mSourceEditorHeight);
            }

            set
            {
                SetProperty(ref mSourceEditorHeight, value.Value);
                Properties.Settings.Default.SourceEditorHeight = value.Value;
            } 
        }

        #endregion
    }
}
