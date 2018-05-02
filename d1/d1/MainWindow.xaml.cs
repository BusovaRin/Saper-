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

namespace d1
{

    public partial class MainWindow : Window
    {
        BitmapImage mine = new BitmapImage(new Uri(@"pack://application:,,,/kartinochki/9150.png",
UriKind.Absolute));


        public MainWindow()

        {
            Random bomb = new Random();
            InitializeComponent();

            //указыается количество строк и столбцов в сетке
            ugr.Rows = 5;
            ugr.Columns = 5;
            //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
            ugr.Width = 5 * (30 + 4);
            ugr.Height = 5 * (30 + 4);
            //толщина границ сетки
            ugr.Margin = new Thickness(5, 5, 5, 5);

            for (int i = 0; i < 5 * 5; i++)
            {
                //создание кнопки
                BtnBomb btn = new BtnBomb();
                //запись номера кнопки
                btn.Tag = i;
                //установка размеров кнопки
                btn.Width = 50;
                btn.Height = 50;
                //текст на кнопке
                btn.Content = " ";

                if (bomb.Next(0, 25) < 15)
                {
                    btn.isBomb = true;
                }

                btn.Margin = new Thickness(2);
                //при нажатии кнопки, будет вызываться метод Btn_Click
                btn.Click += Btn_Click;
                //добавление кнопки в сетку
                ugr.Children.Add(btn);
            }

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            BtnBomb btn = (BtnBomb)sender;

            if (btn.isBomb)
            {
                //создание контейнера для хранения изображения
                Image img = new Image();

                //запись картинки с миной в контейнер
                img.Source = mine;
                //создание компонента для отображения изображения
                StackPanel stackPnl = new StackPanel();
                //установка толщины границ компонента
                stackPnl.Margin = new Thickness(1);
                //добавление контейнера с картинкой в компонент
                stackPnl.Children.Add(img);
                //запись компонента в кнопку
                ((Button)sender).Content = stackPnl;

                MessageBox.Show("YOU DIED");

            }
            else
            {

            }
        }

    }
    
    class BtnBomb: Button
    {
        public bool isBomb;
    }
}
