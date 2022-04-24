using System.ComponentModel.DataAnnotations;

namespace Data.DTOs
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        [Display(Name = "Nombre completo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        [Display(Name = "Nombre de Correspondencia")]
        public string CorrespondenceAddress { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Telefono")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Maximo de libros registrados")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a cero")]
        public int MaximumBooksRegistered { get; set; }
    }
}
