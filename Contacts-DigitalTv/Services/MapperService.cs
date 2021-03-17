using Contacts_DigitalTv.Models;
using Contacts_DigitalTv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_DigitalTv.Services
{
    public  class MapperService : IMapperService
    {
        public List<ContactViewModel> MapContactModels(List<Person> people)
        {
            List<ContactViewModel> contactViewModels = new List<ContactViewModel>();
            for (int i = 0; i < people.Count; i++)
            {
                List<PhonesViewModel> phonesViewModels = new List<PhonesViewModel>();
                contactViewModels.Add(new ContactViewModel(people[i]));
                for (int j = 0; j < people[i].Phones.Count; j++)
                {
                    phonesViewModels.Add(new PhonesViewModel()
                    {
                        Number = people[i].Phones.ToList()[j].Number,
                        Type = people[i].Phones.ToList()[j].Type
                    });
                }
                contactViewModels[i].Phones = phonesViewModels;
            }
            return contactViewModels;

        }

        public Person MapPerson(ContactViewModel contactViewModel)
        {
            Person person = new Person()
            {
                Id = contactViewModel.Id,
                Name = contactViewModel.Name,
                Surename = contactViewModel.Surename,
                Gender = contactViewModel.Gender,
                Birthdate = contactViewModel.Birthdate,
                AddressLine = contactViewModel.AddressLine,
                City = contactViewModel.City

            };
            person.Phones = new List<Phone>();
            foreach (var item in contactViewModel.Phones)
            {
                person.Phones.Add(new Phone()
                {
                    Id = item.Id,
                    PersonId=item.PersonId,
                    Number = item.Number,
                    Type = item.Type,
                    Person = person
                });
            }
            return person;
        }
       

    }
}
