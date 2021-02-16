using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Middlware.Models
{
    public class StudentModel
    {
        [Required(ErrorMessage ="Required")]
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string NAME { get; set; }

        [Required(ErrorMessage = "Required")]
        public int AGE { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ADDRESS { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Please check format")]
        public string EMAIL { get; set; }
}
}
