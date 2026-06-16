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
        public void UpdDataGrid() //Обновление дата грид для показа всех контактов
        {
            datagrid1.ItemsSource = null;
            datagrid1.Items.Clear();
            datagrid1.ItemsSource = Book.GetListContact(); 

        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Загрузка из файла
        {

            PhoneBookLoader.Load(Book, $"contacts.csv");
            UpdDataGrid();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Сохранение в файл
        {

            PhoneBookLoader.Save(Book, $"contacts.csv");
            UpdDataGrid();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Показывает все именна через поиск по именам
        {
            datagrid1.ItemsSource = null;
            datagrid1.ItemsSource = Book.SearchContactName(SearchName.Text);
            
        }
        private void ExitButton_Click_3(object sender, RoutedEventArgs e) //Выйти из программы
        {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //Удаление пользователей
        {
            
            if(NameAdded.Text.Length == 0 || PhoneAdded.Text.Length == 0)
            {
                if (datagrid1.SelectedIndex == -1)
                {
                    MessageBox.Show("Строка с именем или телефоном пуста и индекс для удаления не выбран");
                    return;
                }
                else
                {
                    var books = Book.GetListContact();
                    Book.DeleteContact(books[datagrid1.SelectedIndex]);
                    UpdDataGrid();
                    datagrid1.SelectedIndex = -1;
                }
            }
            Book.DeleteContact(NameAdded.Text, PhoneAdded.Text);
            UpdDataGrid();
            NameAdded.Text = "";
            PhoneAdded.Text = "";
            datagrid1.SelectedIndex = -1;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //Добавление пользователей
        {
            if (NameAdded.Text.Length == 0 || PhoneAdded.Text.Length == 0)
            {
                MessageBox.Show("Строка с именем или телефоном пуста");
                return;
            }
            var FalseChaars = PhoneAdded.Text.ToCharArray().ToList().Where(T => !Char.IsDigit(T) && T != ')' && T != '(' && T != '-').ToList();
            if(FalseChaars.Count > 0)
            {
                MessageBox.Show("Номер телефона может иметь только цифры и ),(,-");
                return;
            }
            var FalseChaars2 = NameAdded.Text.ToCharArray().ToList().Where(T => !Char.IsLetter(T) && T != ' ').ToList();
            if (FalseChaars2.Count > 0)
            {
                MessageBox.Show("Имя не может иметь цифры");
                return;
            }
            if(Book.GetListContact().Where(g => g.Name == NameAdded.Text && g.Phone == PhoneAdded.Text).ToList().Count > 0)
            {
                MessageBox.Show("Такие данные уже есть");
                return;
            }
            Book.AddContact(NameAdded.Text, PhoneAdded.Text);
            UpdDataGrid();
            NameAdded.Text = "";
            PhoneAdded.Text = "";
            datagrid1.SelectedIndex = -1;
        }
        private void Button_Click_32(object sender, RoutedEventArgs e) //Удаление пользователей
        {

            if (NameAdded.Text.Length == 0 || PhoneAdded.Text.Length == 0)
            {
                if (datagrid1.SelectedIndex == -1)
                {
                    MessageBox.Show("Строка с именем или телефоном пуста и индекс для удаления не выбран");
                    return;
                }
                else
                {
                    var books = Book.GetListContact();
                    Book.DeleteContact(books[datagrid1.SelectedIndex]);
                    UpdDataGrid();
                    datagrid1.SelectedIndex = -1;
                }
            }
            Contact newnum = new Contact();
            newnum.Name = NameAdded.Text;
            newnum.Phone = PhoneAdded.Text;
            Book.DeleteContact(newnum);
            UpdDataGrid();
            NameAdded.Text = "";
            PhoneAdded.Text = "";
            datagrid1.SelectedIndex = -1;
        }

        private void Button_Click_42(object sender, RoutedEventArgs e) //Добавление пользователей
        {
            if (NameAdded.Text.Length == 0 || PhoneAdded.Text.Length == 0)
            {
                MessageBox.Show("Строка с именем или телефоном пуста");
                return;
            }
            var FalseChaars = PhoneAdded.Text.ToCharArray().ToList().Where(T => !Char.IsDigit(T) && T != ')' && T != '(' && T != '-').ToList();
            if (FalseChaars.Count > 0)
            {
                MessageBox.Show("Номер телефона может иметь только цифры и ),(,-");
                return;
            }
            var FalseChaars2 = NameAdded.Text.ToCharArray().ToList().Where(T => !Char.IsLetter(T) && T != ' ').ToList();
            if (FalseChaars2.Count > 0)
            {
                MessageBox.Show("Имя не может иметь цифры");
                return;
            }
            if (Book.GetListContact().Where(g => g.Name == NameAdded.Text && g.Phone == PhoneAdded.Text).ToList().Count > 0)
            {
                MessageBox.Show("Такие данные уже есть");
                return;
            }
            Contact newnum = new Contact();
            newnum.Name = NameAdded.Text;
            newnum.Phone = PhoneAdded.Text;
            Book.AddContact(newnum);
            UpdDataGrid();
            NameAdded.Text = "";
            PhoneAdded.Text = "";
            datagrid1.SelectedIndex = -1;
        }
    }
}
