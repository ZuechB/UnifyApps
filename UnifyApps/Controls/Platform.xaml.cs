using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UnifyApps.Controls
{
    public delegate void OnClickedDelegate(string url);

    /// <summary>
    /// Interaction logic for Platform.xaml
    /// </summary>
    public partial class Platform : UserControl
    {
        public event OnClickedDelegate OnClicked;

        public Platform()
        {
            InitializeComponent();

            this.MouseLeftButtonUp += Platform_MouseLeftButtonUp;
        }

        private void Platform_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (OnClicked != null)
            {
                OnClicked(Url);
            }
        }

        public string Url { get; set; }
        public string Title { get; set; }

        private ImageSource image { get; set; }
        public ImageSource Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                imgIcon.Source = image;
            }
        }
    }
    
}
