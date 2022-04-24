using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Data.DTOs
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        [Display(Name = "Nombre completo")]
        public string FullName { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha de nacimiento")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Cuidad de origen")]
        public string CityOfOrigin { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime ModificationDate { get; set; }
    }
}
