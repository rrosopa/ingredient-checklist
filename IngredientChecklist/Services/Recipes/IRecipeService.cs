using Data.Entities;
using System.Collections.Generic;

namespace Services.Recipes
{
	public interface IRecipeService
    {
		Recipe GetRecipe(int recipeId);
		List<Recipe> GetUserRecipes();

		bool UpdateIngredientStatus(int ingredientId, bool isChecked);
		bool ResetChecklist(int recipeId);
		bool AddRecipe(Recipe recipe);
	}
}
