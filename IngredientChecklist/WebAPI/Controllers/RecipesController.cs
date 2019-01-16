using Microsoft.AspNetCore.Mvc;
using Services.Recipes;

namespace WebAPI.Controllers
{
	[Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
		private readonly IRecipeService _recipeService;
		public RecipesController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}

		[HttpGet("{recipeId}")]
		public IActionResult Get(int recipeId)
		{
			var recipe = _recipeService.GetRecipe(recipeId);
			if (recipe == null)
				return NotFound($"Recipe with id:${recipeId} does not exist.");

			return Ok(recipe);
		}

		[HttpGet("")]
		public IActionResult GetUserRecipes()
		{
			return Ok(_recipeService.GetUserRecipes());
		}

		[HttpPut("{recipeId}")]
		public IActionResult ResetChecklist(int recipeId)
		{
			if (_recipeService.ResetChecklist(recipeId))
				return BadRequest();

			return Ok();
		}

		[HttpPut("ingredients/{ingredientId}")]
		public IActionResult UpdateIngredientStatus(int ingredientId, [FromQuery]bool isChecked)
		{
			if (_recipeService.UpdateIngredientStatus(ingredientId, isChecked))
				return BadRequest();

			return Ok();
		}
	}
}