using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task UpdateRecipeAsync(int id, Recipe updatedRecipe)
        {
            var existingRecipe = await _context.Recipes.FindAsync(id);
            if (existingRecipe == null)
            {
                throw new KeyNotFoundException($"Recipe with ID {id} not found");
            }

            existingRecipe.Title = updatedRecipe.Title;
            existingRecipe.Description = updatedRecipe.Description;
            existingRecipe.Instructions = updatedRecipe.Instructions;
            existingRecipe.ImageUrl = updatedRecipe.ImageUrl;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipeToDelete = await _context.Recipes.FindAsync(id);
            if (recipeToDelete == null)
            {
                throw new KeyNotFoundException($"Recipe with ID {id} not found");
            }

            _context.Recipes.Remove(recipeToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
