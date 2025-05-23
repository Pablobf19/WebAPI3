using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.DAL.Entities
{
    public class AuditBase
    {
        [Key]  //pk
        [Required] //campo obligatorio
        public virtual Guid Id {  get; set; }  //pk de todas las tablas
        public virtual DateTime? CreatedDate { get; set; }  //guardar todo registro con el date
        public virtual DateTime? ModifiedDate { get; set; }  //guardar todo registro que se modofico con su date

    }
}
