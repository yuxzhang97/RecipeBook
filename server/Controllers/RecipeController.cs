using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Services;


namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            Console.WriteLine(recipes);
            return Ok(recipes);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Recipe>> GetRecipeById(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult> addNewRecipe(Recipe recipe)
        {
            try
            {
                await _recipeService.AddRecipeAsync(recipe);
                return Ok(recipe);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> updateRecipe(int id, Recipe recipe)
        {
            try
            {
                await _recipeService.UpdateRecipeAsync(id, recipe);
                return Ok(recipe);
            }
            catch
            {
                return BadRequest();
            }


        }
    }
}
