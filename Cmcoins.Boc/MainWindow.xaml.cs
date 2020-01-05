using Microsoft.Win32;
using mshtml;
using NOPItest;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Navigation;

namespace Cmcoins.Boc
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHTMLElementManager _ihtmlManager = new IHTMLElementManager();
        private UserInfoManager _InfoManager = new UserInfoManager();

        public MainWindow()
        {
            InitializeComponent();

            LoadWebBrowserContext(UriFactory.GetUri());
        }



        private void LoadWebBrowserContext(Uri uri)
        {
            this.MainWebBrowser.Source = uri;

            this.MainWebBrowser.LoadCompleted -= MainWebBrowser_LoadCompleted;
            this.MainWebBrowser.LoadCompleted += MainWebBrowser_LoadCompleted;

            this.TextBox_Url.Text = uri.ToString();
        }


        private void MainWebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }


        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            int time = 0;
            while (this._ihtmlManager.IsNeedInit() == true && time < 5)
            {
                IHTMLDocument2 doc2 = (IHTMLDocument2)this.MainWebBrowser.Document;
                this._ihtmlManager.Init(doc2);

                time++;
                Thread.Sleep(200);
            }

            if (this._ihtmlManager.IsNeedInit() == true)
            {
                HandyControl.Controls.MessageBox.Show($"初始化失败，请刷新!");
            }

            UserInfo userInfo = _InfoManager.GetNextUserInfo();

            this._ihtmlManager.AddInfo(userInfo);

            userInfo.IsPrint = true;
        }



        private void Button_Refash_Click(object sender, RoutedEventArgs e)
        {
            string url = this.TextBox_Url.Text;
            if (string.IsNullOrEmpty(this.TextBox_Url.Text) == true)
            {
                return;
            }
            LoadWebBrowserContext(new Uri(url));

        }

        private void Button_LoadExcel_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择导入表格";
            openFileDialog.Filter = "Excel文件|*.xlsx";
            openFileDialog.FileName = string.Empty;
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }
            string excelName = openFileDialog.SafeFileName;


            string path = openFileDialog.FileName;

            List<UserInfoDTO> userInfoDTO = UserInfoExcelHelper.InitUserInfoDTO(path);
            if (userInfoDTO == null || userInfoDTO.Count == 0)
            {
                return;
            }
            this._InfoManager.InitAllUserInfo(userInfoDTO);

            List<UserInfo> userInfos = _InfoManager.GetAllUserInfo();

            this.DataGrid_UserInfos.AutoGenerateColumns = false;
            this.DataGrid_UserInfos.ItemsSource = userInfos;

            this.TextBox_ExcelPath.Text = path;

            HandyControl.Controls.MessageBox.Show($"表格{excelName}导入成功!");
        }
    }
}
