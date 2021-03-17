using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Contacts_DigitalTv.Models
{
    [Table("Person")]
    public partial class Person
    {
        public Person()
        {
            Phones = new HashSet<Phone>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surename { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }
        public byte[] Image { get; set; }
        [Required]
        [StringLength(50)]
        public string AddressLine { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        public bool IsFavorite { get; set; }

        [InverseProperty(nameof(Phone.Person))]
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
