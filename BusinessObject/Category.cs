namespace BusinessObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class Category
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }
    [Required, StringLength(50),AllowNull]
    public string CategoryName { get; set; }
}