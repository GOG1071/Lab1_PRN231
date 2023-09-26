namespace BusinessObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required] public int CategoryId { get; set; }

    [Required, StringLength(50), AllowNull]
    public string ProductName { get; set; }

    [Required]            public float   Weight       { get; set; }
    [Required]            public decimal UnitPrice    { get; set; }
    [Required, AllowNull] public int     UnitsInStock { get; set; }
}