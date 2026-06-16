using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
namespace zd2_KachalinSemen
{
    class PhoneBookLoader
    {
        public static void Load(PhoneBook phoneBook, string fileName) //Сохранение из файла
        {
            phoneBook.ListBookClear();
            StreamReader file = File.OpenText(fileName);
            while(!file.EndOfStream)
            {
                string[] DataTable = file.ReadLine().Split(';');
                phoneBook.AddContact(DataTable[0], DataTable[1]);
            }
            file.Close();
        }
        public static void Save(PhoneBook phoneBook, string fileName) //Сохранение в файл
        {
            var List = phoneBook.GetListContact();
            StreamWriter file = File.CreateText(fileName);
            foreach (var item in List)
                file.WriteLine($"{item.Name};{item.Phone}");
            file.Close();
        }
    }
}
