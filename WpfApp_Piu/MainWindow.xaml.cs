using SqlSugar;
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
using WpfApp_Piu.SqlSugar;
using System.Windows.Forms;
using System.IO;
using WpfApp_Piu.SqlSugar.Models;

namespace WpfApp_Piu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Multiselect = true,
                    Filter = "Image(*.jpg;*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png"
                };
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var file = dialog.FileNames;
                    List<Piu> fileBytes = new List<Piu>();
                    foreach (var item in file)
                    {
                        byte[] fileByte = ImageToByte(item);
                        if (fileByte!=null)
                        {
                            fileBytes.Add(new Piu() { Path= fileByte });
                        }
                    }
                    SqlSugarConfig.DbClient.Insertable(fileBytes).ExecuteCommandAsync();


                    //var getAll = SqlSugarConfig.DbClient.Queryable<Piu>().ToList();//查询所有
                    //img.Source = ByteArrayToBitmapImage(getAll.First().Path);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static BitmapImage ByteArrayToBitmapImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
        /// 图片转换为byte[]类型
        /// </summary>
        /// <returns></returns>
        public byte[] ImageToByte(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] pic_byte = new byte[fs.Length];
            fs.Read(pic_byte, 0, pic_byte.Length);
            fs.Close();
            return pic_byte;
        }
    }


}
