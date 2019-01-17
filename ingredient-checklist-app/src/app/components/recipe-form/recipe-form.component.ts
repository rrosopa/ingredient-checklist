import { Component, OnInit } from '@angular/core';
import { RecipeService } from 'src/app/services/recipe.service';
import { AlertService } from 'src/app/services/alert.service';
import { Recipe } from 'src/app/models/recipe';
import { Ingredient } from 'src/app/models/ingredient';
import { Router } from '@angular/router';

@Component({
    selector: 'app-recipe-form',
    templateUrl: './recipe-form.component.html',
    styleUrls: ['./recipe-form.component.css']
})
export class RecipeFormComponent implements OnInit {
    recipe: Recipe;

    constructor(
        private _recipeService: RecipeService,
        private _alertService: AlertService,
        private _router: Router
    ) { }

    ngOnInit() {
        this.recipe = new Recipe();
        this.recipe.ingredients = [];
        this.recipe.ingredients.push(new Ingredient());
    }

    click_addRecipe(){
        if(this.recipe.name == '' || this.recipe.ingredients == null || this.recipe.ingredients == undefined) {
            this._alertService.error('Fill out all required fields.');
            return;
        }
        
        if(this.recipe.ingredients.length == 0){
            this._alertService.error('Fill out all required fields.');
            return;
        }

        this.recipe.ingredients.forEach(x => {
            if(x.name == '' || x.name == null || x.name == undefined){
                this._alertService.error('Fill out all required fields.');
                return;
            }
        });

        this._recipeService.addRecipe(this.recipe).subscribe(response => {
            if(response == undefined || response == null){
                this._alertService.error('Unable to add recipe.');
            }
            else{
                this._alertService.success('New recipe is added.');
                this._router.navigate(['recipes']);
            }
        })
    }

    click_addIngredient(){
        this.recipe.ingredients.push(new Ingredient());
    }

    click_removeIngredient(index: number){
        this.recipe.ingredients.splice(index, 1);
    }
}
