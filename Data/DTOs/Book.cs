using System.ComponentModel.DataAnnotations;

namespace Data.DTOs
{
	public class Book
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[StringLength(100, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
		[Display(Name = "Año de publicación")]
		public string Year { get; set; }

		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[StringLength(100, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
		[Display(Name = "Título")]
		public string Title { get; set; }

		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[StringLength(100, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
		[Display(Name = "Genero")]
		public string Gender { get; set; }

		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[Display(Name = "Número de paginas")]
		[Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a cero")]
		public int NumberOfPages { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "El campo {0} es obligatorio")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[Display(Name = "Editorial")]
		public int PublisherId { get; set; }

		public Publisher Publisher { get; set; }

		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[Display(Name = "Autor")]
		[Range(1, int.MaxValue,ErrorMessage = "El campo {0} es obligatorio")]
		public int AuthorId { get; set; }

		public Author Author { get; set; }
	}
}
