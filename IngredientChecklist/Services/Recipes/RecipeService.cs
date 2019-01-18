﻿using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Auth;
using System.Collections.Generic;
using System.Linq;

namespace Services.Recipes
{
	public class RecipeService : IRecipeService
	{
		private readonly IClaimsService _claimsService;
		private readonly IAppDbContext _appDbContext;

		public RecipeService(
			IClaimsService claimsService, 
			IAppDbContext appDbContext)
		{
			_claimsService = claimsService;
			_appDbContext = appDbContext;
		}

		public Recipe GetRecipe(int recipeId)
		{
			return _appDbContext.Recipes.Include(x => x.Ingredients).SingleOrDefault(x => x.Id == recipeId && x.UserId == _claimsService.UserId);
		}

		public List<Recipe> GetUserRecipes()
		{
			return _appDbContext.Recipes.Include(x => x.Ingredients).Where(x => x.UserId == _claimsService.UserId).ToList();
		}

		// TODO: replace with proper error message if time permits
		public bool ResetChecklist(int recipeId)
		{
			var recipe = _appDbContext.Recipes.Include(x => x.Ingredients).SingleOrDefault(x => x.Id == recipeId && x.UserId == _claimsService.UserId);
			if (recipe == null)
				return false;

			recipe.Ingredients.ToList().ForEach(x => x.IsChecked = false);
			_appDbContext.SaveChanges();
			return true;
		}

		// TODO: replace with proper error message if time permits
		public bool UpdateIngredientStatus(int ingredientId, bool isChecked)
		{
			var ingredient = _appDbContext.Ingredients.SingleOrDefault(x => x.Id == ingredientId && x.UserId == _claimsService.UserId);
			if (ingredient == null)
				return false;

			ingredient.IsChecked = isChecked;
			_appDbContext.Ingredients.Update(ingredient);
			_appDbContext.SaveChanges();
			return true;
		}

		public bool AddRecipe(Recipe recipe)
		{
			if (string.IsNullOrEmpty(recipe.Name))
				return false;

			if (recipe.Ingredients?.Any() == false)
				return false;

			var currentUserId = _claimsService.UserId;
			foreach (var ingredient in recipe.Ingredients)
			{
				ingredient.UserId = currentUserId;
				if (string.IsNullOrEmpty(ingredient.Name))
					return false;
			}

			recipe.UserId = currentUserId;
			_appDbContext.Recipes.Add(recipe);
			_appDbContext.SaveChanges();
			return true;
		}
	}
}
