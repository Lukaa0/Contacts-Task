using Contacts_DigitalTv.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_DigitalTv.ViewModels
{
    public class ContactViewModel
    {
        private void Init(Person person)
        {
            Id = person.Id;
            Name = person.Name;
            Surename = person.Surename;
            Birthdate = person.Birthdate;
            Gender = person.Gender;
            Image = person.Image;
            IsFavorite = person.IsFavorite;
            City = person.City;
            AddressLine = person.AddressLine;
        }
        public ContactViewModel(Person person)
        {
            Init(person);
        }
        public ContactViewModel(Person person,ICollection<Phone> phones)
        {
            this.Init(person);
            foreach (var item in phones)
            {
                Phones.Add(new PhonesViewModel()
                {
                    Id = item.Id,
                    PersonId = item.PersonId,
                    Number = item.Number,
                    Type = item.Type
                });
            }
        }
        public ContactViewModel()
        {
        
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "სავალდებულო ველია")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "სავალდებულო ველია")]
        [StringLength(50)]
        public string Surename { get; set; }
        [Required(ErrorMessage = "სავალდებულო ველია")]
        [StringLength(10)]
        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public byte[] Image { get; set; }

        [Required(ErrorMessage = "სავალდებულო ველია")]
        [StringLength(50)]
        public string AddressLine { get; set; }
        [Required(ErrorMessage = "სავალდებულო ველია")]
        [StringLength(50)]
        public string City { get; set; }
        public List<PhonesViewModel> Phones { get; set; } = new List<PhonesViewModel>();

        public bool IsFavorite { get; set; }

    }
}
