using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2_KachalinSemen
{
    class PhoneBook
    {
        List<Contact> ListContact = new List<Contact>();
        public List<Contact> SearchContactName(string Name)
        {
            var contanct = ListContact.Where(t => t.Name.Contains(Name)).ToList();
            return contanct;
        }
        public List<Contact> SearchContactPhone(string Phone)
        {
            var contanct = ListContact.Where(t => t.Phone == Phone).ToList();
            return contanct;
        }
        public void AddContact(Contact contact)
        {
            ListContact.Add(contact);
        }
        public void AddContact(string name, string phone)
        {
            Contact num1 = new Contact();
            num1.Name = name;
            num1.Phone = phone;
            ListContact.Add(num1);
        }
        public void DeleteContact(string name)
        {
            var contanct = ListContact.Where(t => t.Name == name).ToList();
            if (contanct.Count > 0)
                ListContact.Remove(contanct[0]);
        }
        public void DeleteContact(string name,string phone)
        {
            var contanct = ListContact.Where(t => t.Name == name && t.Phone == phone).ToList();
            if(contanct.Count > 0)
                ListContact.Remove(contanct[0]);
        }
        public void DeleteContact(Contact num)
        {
            ListContact.Remove(num);
        }
        public List<Contact> GetListContact()
        {
            return ListContact;
        }
        public void ListBookClear()
        {
            ListContact.Clear();
        }
    }
}
