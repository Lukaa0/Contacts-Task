using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_DigitalTv.ViewModels
{
    public class PhonesViewModel
    {
        [RegularExpression("([0-9]+)",ErrorMessage ="შეიყვანეთ ნომერი")]

        public string Number { get; set; }
        [Required(ErrorMessage ="სავალდებულო ველია")]
        [StringLength(10)]
        public string Type { get; set; }
        public int Id { get; set; }
        public int PersonId { get; set; }

    }
}
