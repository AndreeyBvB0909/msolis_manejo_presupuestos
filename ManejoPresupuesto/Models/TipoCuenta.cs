using ManejoPresupuesto.Validaciones;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:50, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe estar entre {1}y{2}")]
        [Display(Name ="Nombre del tipo cuenta")]
        //[PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Order { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Nombre != null && Nombre.Length > 0)
            {
                var primeraLetra = Nombre[0].ToString();

                if(primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe de ser mayuscula",
                        new[] { nameof(Nombre) });
                }
            }
        }
    }
}
