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
    }
}
