using Contacts_DigitalTv.Models;
using Contacts_DigitalTv.ViewModels;
using System.Collections.Generic;

namespace Contacts_DigitalTv.Services
{
    public interface IMapperService
    {
        public Person MapPerson(ContactViewModel contactViewModel);
        public List<ContactViewModel> MapContactModels(List<Person> people);

    }
}