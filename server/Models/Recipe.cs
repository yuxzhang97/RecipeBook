using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class Recipe
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    public string Instructions { get; set; }
    public string Categories { get; set; }
    public string ImageUrl { get; set; }

}
