using Prism.Mvvm;
using System.Windows;

namespace AdamDevelopmentEnvironment.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }

        private double mVerticalSplitterLength = Properties.Settings.Default.VerticalSplitterLength;
        private double mHorizontalSplitterLength = Properties.Settings.Default.HorizontalSplitterLength;
        public GridLength VerticalSplitterLength 
        { 
            get 
            {
                if (mVerticalSplitterLength == 0)
                    return GridLength.Auto;

                return new GridLength(mVerticalSplitterLength);
            }

            set
            {
                SetProperty(ref mVerticalSplitterLength, value.Value);
                Properties.Settings.Default.VerticalSplitterLength = value.Value;
            } 
        }

        public GridLength HorizontalSplitterLength { get; private set; }
    }
}
