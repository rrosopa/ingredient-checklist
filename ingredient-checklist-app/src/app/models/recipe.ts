import { Ingredient } from "./ingredient";

export class Recipe {
    id: number;
    name: string;
    userId: number;
    ingredients: Ingredient[];
}