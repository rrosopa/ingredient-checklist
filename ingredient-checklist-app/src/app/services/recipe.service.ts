import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LogService } from './log.service';
import { Observable } from 'rxjs';
import { Recipe } from '../models/recipe';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

    constructor(
		private _http: HttpClient,
		private _logService: LogService
	) { }

	getRecipe(recipeId: number): Observable<Recipe> {
		return this._http.get<Recipe>(`/api/recipes/${recipeId}`)
			.pipe(
				catchError(this._logService.handleError<Recipe>('getRecipe'))
			);
    }
    
    getCurrentUserRecipes(): Observable<Recipe[]> {
		return this._http.get<Recipe[]>('/api/recipes')
			.pipe(
				catchError(this._logService.handleError<Recipe[]>('getCurrentUserRecipes'))
			);
    }
    
    resetChecklist(recipeId: number): Observable<boolean> {
		return this._http.put<boolean>(`/api/recipes/${recipeId}`, null)
			.pipe(
				catchError(this._logService.handleError<boolean>('resetChecklist'))
			);
    }
    
    updateIngredientStatus(ingredientId: number, status: boolean): Observable<boolean> {
		return this._http.put<boolean>(`/api/recipes/ingredients/${ingredientId}`, JSON.stringify(`isChecked: ${status}`))
			.pipe(
				catchError(this._logService.handleError<boolean>('updateIngredientStatus'))
			);
	}
}
