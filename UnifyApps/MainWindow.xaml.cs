using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UnifyApps.Controls;
using UnifyApps.Services;

namespace UnifyApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Init();
            InitializeComponent();

            Browser.JavascriptMessageReceived += OnBrowserJavascriptMessageReceived;
            Browser.DownloadHandler = new DownloadHandler();
        }

        private void OnBrowserJavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            //Complext objects are initially expresses as IDicionary
            //You can use dynamic to access properties (the IDicionary is an ExpandoObject)
            //dynamic msg = e.Message;
            //Alternatively you can use the built in Model Binder to convert to a custom model
            var msg = e.ConvertMessageTo<dynamic>();
            var callback = msg.Callback;
            var type = msg.Type;
            var property = msg.Data.Property;

            //Call a javascript function with your response data
            callback.ExecuteAsync(type);
        }

        public static void Init()
        {
            var settings = new CefSettings();

            // Increase the log severity so CEF outputs detailed information, useful for debugging
            settings.LogSeverity = LogSeverity.Verbose;
            // By default CEF uses an in memory cache, to save cached data e.g. to persist cookies you need to specify a cache path
            // NOTE: The executing user must have sufficient privileges to write to this folder.
            settings.CachePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache");

            Cef.Initialize(settings);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var platform = new Platform();
            //platform.OnClicked += Platform_OnClicked;
            //platform.imgIcon.Source = new BitmapImage(new Uri("https://user-images.githubusercontent.com/819186/51553744-4130b580-1e7c-11e9-889e-486937b69475.png"));
            //platform.Title = "Slack";
            //platform.Url = "https://app.slack.com/client/";
            //spItems.Children.Add(platform);

            var platform2 = new Platform();
            platform2.OnClicked += Platform_OnClicked;
            platform2.imgIcon.Source = new BitmapImage(new Uri("https://shotatlife.org/wp-content/uploads/2018/07/google-calendar-icon-png.png"));
            platform2.Title = "Google Calendar";
            platform2.Url = "https://calendar.google.com";
            spItems.Children.Add(platform2);

            var platform3 = new Platform();
            platform3.OnClicked += Platform_OnClicked;
            platform3.imgIcon.Source = new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/commons/4/4e/Gmail_Icon.png"));
            platform3.Title = "Gmail";
            platform3.Url = "https://gmail.com";
            spItems.Children.Add(platform3);

            var platform4 = new Platform();
            platform4.OnClicked += Platform_OnClicked;
            platform4.imgIcon.Source = new BitmapImage(new Uri("http://2.bp.blogspot.com/-rQC9kM8xKGI/VSaSgfK-jyI/AAAAAAAAAJY/Yt4bo_NXT9U/s1600/Google-Drive-icon.png"));
            platform4.Title = "Google Drive";
            platform4.Url = "https://drive.google.com/drive";
            spItems.Children.Add(platform4);

            var platform5 = new Platform();
            platform5.OnClicked += Platform_OnClicked;
            platform5.imgIcon.Source = new BitmapImage(new Uri("https://store-images.s-microsoft.com/image/apps.56560.fd6cc851-feab-42bf-8fc7-0caabb6dd238.cdfdf62d-493c-44b7-97a8-a4f5f6f6b957.a89f355d-c851-4e58-944e-81c1aa19e038.png"));
            platform5.Title = "Hello Raye";
            platform5.Url = "https://app.clickup.com/";
            spItems.Children.Add(platform5);

            var platform6 = new Platform();
            platform6.OnClicked += Platform_OnClicked;
            platform6.imgIcon.Source = new BitmapImage(new Uri("https://www.electronjs.org/images/apps/github-desktop-icon.png"));
            platform6.Title = "Github";
            platform6.Url = "https://github.com";
            spItems.Children.Add(platform6);

            var platform7 = new Platform();
            platform7.OnClicked += Platform_OnClicked;
            platform7.imgIcon.Source = new BitmapImage(new Uri("https://helloraye.com/static/icons/logo.png"));
            platform7.Title = "Hello Raye Reports";
            platform7.Url = "https://hellorayereport.azurewebsites.net";
            spItems.Children.Add(platform7);
        }

        private void Platform_OnClicked(string url)
        {
            Browser.Load(url);
        }
    }
}