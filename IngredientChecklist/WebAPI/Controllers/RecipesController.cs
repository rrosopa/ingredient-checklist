using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Recipes;

namespace WebAPI.Controllers
{
	[Authorize]
	[Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
		private readonly IRecipeService _recipeService;
		public RecipesController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}

		[HttpGet("{recipeId:int}")]
		public IActionResult Get(int recipeId)
		{
			var recipe = _recipeService.GetRecipe(recipeId);
			if (recipe == null)
				return NotFound($"Recipe with id:{recipeId} does not exist.");

			return Ok(recipe);
		}

		[HttpGet("")]
		public IActionResult GetUserRecipes()
		{
			return Ok(_recipeService.GetUserRecipes());
		}

		[HttpPut("{recipeId:int}")]
		public IActionResult ResetChecklist(int recipeId)
		{
			if (_recipeService.ResetChecklist(recipeId))
				return BadRequest(false);

			return Ok(true);
		}

		[HttpPut("ingredients/{ingredientId:int}")]
		public IActionResult UpdateIngredientStatus(int ingredientId, [FromQuery]bool isChecked)
		{
			if (_recipeService.UpdateIngredientStatus(ingredientId, isChecked))
				return BadRequest(false);

			return Ok(true);
		}
	}
}