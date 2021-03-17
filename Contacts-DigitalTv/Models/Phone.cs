using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Contacts_DigitalTv.Models
{
    [Table("Phone")]
    public partial class Phone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Number { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        public int PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        [InverseProperty("Phones")]
        public virtual Person Person { get; set; }
    }
}
