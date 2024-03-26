namespace RecipeBookAPI.Models;

// Class representing a Recipe
public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public string Instructions { get; set; }
    public List<string> Categories { get; set; }
    public string ImageUrl { get; set; }
}


