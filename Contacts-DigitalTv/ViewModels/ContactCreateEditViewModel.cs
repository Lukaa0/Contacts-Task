using Contacts_DigitalTv.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_DigitalTv.ViewModels
{
    public class ContactCreateEditViewModel :ContactViewModel
    {
        public ContactCreateEditViewModel()
        {

        }
        public ContactCreateEditViewModel(Person person) : base(person)
        {

        }
        public ContactCreateEditViewModel(Person person,ICollection<Phone> phones) : base(person,phones)
        {

        }
        public new IFormFile Image { get; set; }
    }
}
