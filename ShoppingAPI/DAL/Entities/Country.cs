using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "pais")]  //identiicar nombre
        [MaxLength(50, ErrorMessage = "campo {0} debe tener max {1} caracteres")] //longitud max
        [Required(ErrorMessage ="campo {0} es obligatorio")] //campo obligatorio
        public string Name { get; set; }
    }
}
