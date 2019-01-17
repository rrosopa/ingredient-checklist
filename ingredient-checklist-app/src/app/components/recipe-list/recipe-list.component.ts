import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/models/recipe';
import { RecipeService } from 'src/app/services/recipe.service';
import { AlertService } from 'src/app/services/alert.service';
import { Ingredient } from 'src/app/models/ingredient';

@Component({
    selector: 'app-recipe-list',
    templateUrl: './recipe-list.component.html',
    styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit {
    recipes: Recipe[];
    constructor(
        private _recipeService: RecipeService,
        private _alertService: AlertService
    ) { }

    ngOnInit() {
        this._recipeService.getCurrentUserRecipes().subscribe(response =>{
            if(response != null && response != undefined) {
                this.recipes = response;
            }
            else{
                this._alertService.error('A problem occured.');
            }
        });
    }

    change_updateIngredientStatus(ingredient: Ingredient) {
        this._recipeService.updateIngredientStatus(ingredient.id, ingredient.isChecked)
            .subscribe(response =>{
                if(!response){
                    this._alertService.error("A problem occured.");
                }
            });
    }
    
    click_clearChecklist(recipe: Recipe) {
        this._recipeService.resetChecklist(recipe.id).subscribe(response => {
            if(!response){
                this._alertService.error("A problem occured.");
            }
            else{
                recipe.ingredients.forEach(x => x.isChecked = false);
            }
        });
    }
}
