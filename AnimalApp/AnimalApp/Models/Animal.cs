using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AnimalDataAPI.Models;

public class Animal
{ 
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Category { get; set; }
    
    [Required]
    public string Area { get; set; }
}