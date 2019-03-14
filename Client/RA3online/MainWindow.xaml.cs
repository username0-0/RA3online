using System;
using System.Threading.Tasks;
using System.Windows;

//白学："大概就是在MainWindow.xaml.cs里调用这个DownloadFileByAria2，[创建一个线程]，想办法让[UI线程]和[这个task]通信得到[下载进度之类的信息]。"
namespace RA3online
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void _button_getresourcekey_Click(object sender, RoutedEventArgs e)
        {
            //ToDo : GetResource from settings
        }
        private void _button_getuuid_Click(object sender, RoutedEventArgs e)
        {
            //var url = "https://download.microsoft.com/download/E/4/1/E4173890-A24A-4936-9FC9-AF930FE3FA40/NDP461-KB3102436-x86-x64-AllOS-ENU.exe";
            //_button.Content  = HttpDownLoad.DownloadFileByAria2(url, "c:\\NDP461-KB3102436-x86-x64-AllOS-ENU.exe");
            _button_getuuid.Content = UUID.GetUUID();
        }
    }
}
