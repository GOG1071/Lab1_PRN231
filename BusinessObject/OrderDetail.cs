namespace BusinessObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderDetail
{
    [Required] public int     OrderId   { get; set; }
    [Required] public int     ProductId { get; set; }
    [Required] public decimal UnitPrice { get; set; }
    [Required] public int     Quantity  { get; set; }
    [Required] public float   Discount  { get; set; }
}