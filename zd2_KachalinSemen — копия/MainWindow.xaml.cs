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
using System.IO;
namespace zd2_KachalinSemen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PhoneBook Book = new PhoneBook();
        public void UpdDataGrid()
        {
            datagrid1.ItemsSource = null;
            datagrid1.Items.Clear();
            datagrid1.ItemsSource = Book.GetListContact(); 

        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            PhoneBookLoader.Load(Book, $"contacts.csv");
            UpdDataGrid();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            PhoneBookLoader.Save(Book, $"contacts.csv");
            UpdDataGrid();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            datagrid1.ItemsSource = null;
            datagrid1.ItemsSource = Book.SearchContactName(SearchName.Text);
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(NameAdded.Text.Length == 0 || PhoneAdded.Text.Length == 0)
            {
                MessageBox.Show("Строка с именем или телефоном пуста");
                return;
            }
            Book.DeleteContact(NameAdded.Text, PhoneAdded.Text);
            UpdDataGrid();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (NameAdded.Text.Length == 0 || PhoneAdded.Text.Length == 0)
            {
                MessageBox.Show("Строка с именем или телефоном пуста");
                return;
            }
            var FalseChaars = PhoneAdded.Text.ToCharArray().ToList().Where(T => !Char.IsDigit(T)).ToList();
            if(FalseChaars.Count > 0)
            {
                MessageBox.Show("Номер телефона может иметь только цифры");
                return;
            }
            Book.AddContact(NameAdded.Text, PhoneAdded.Text);
            UpdDataGrid();
        }
    }
}
