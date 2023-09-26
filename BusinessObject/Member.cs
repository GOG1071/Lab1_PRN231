namespace BusinessObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class Member
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MemberId { get; set; }
    [Required,StringLength(20)]
    public string Email { get; set; }
    [Required,StringLength(30),AllowNull]
    public string CompanyName { get; set; }
    [Required,StringLength(15),AllowNull]
    public string City { get; set; }
    [Required,StringLength(15),AllowNull]
    public string Country { get; set; }
    [Required,StringLength(15)]
    public string Password { get; set; }
}