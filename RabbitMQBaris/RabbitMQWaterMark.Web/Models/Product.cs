using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabbitMQWaterMark.Web.Models;

public class Product
{
    [Key]
    public int Id {get; set;}
    [StringLength (100)]
    public string Name {get; set; }
    [Column (TypeName ="decimal(18,2" )]//18 chars before digit 2 chars after digits
    public decimal Price { get; set; }
    [Range(1,100)]
    public int Stock { get; set; }
    [StringLength(100)]
    public string ImageName { get; set; }
}
