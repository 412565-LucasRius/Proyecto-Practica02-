using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Practica02_.Models
  {
  public class Product
    {
    public int Id { get; set; }

    [MaxLength(50, ErrorMessage = "El campo {0}, debe tener  maximo {1} caracteres")]
    public string PName { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal Price { get; set; }

    public bool Available { get; set; }
    }
  }
