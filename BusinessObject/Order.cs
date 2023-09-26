namespace BusinessObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    [Required]            public int      MemberId     { get; set; }
    [Required]            public DateTime OrderDate    { get; set; }
    [Required, AllowNull] public DateTime RequiredDate { get; set; }
    [Required, AllowNull] public DateTime ShippedDate  { get; set; }
    [Required]            public decimal  Freight      { get; set; }
}