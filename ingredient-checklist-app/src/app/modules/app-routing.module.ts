import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '../components/login/login.component';
import { RecipeListComponent } from '../components/recipe-list/recipe-list.component';
import { AuthGuardService } from '../services/auth-guard.service';
import { RecipeFormComponent } from '../components/recipe-form/recipe-form.component';
 
var routes: Routes = [
  { path: '', redirectTo: 'recipes', pathMatch: 'full'},
  { path: 'login', component: LoginComponent},
  { path: 'recipes', component: RecipeListComponent, pathMatch: 'full', canActivate: [AuthGuardService], runGuardsAndResolvers: 'always' },
  { path: 'recipes/new', component: RecipeFormComponent, pathMatch: 'full', canActivate: [AuthGuardService], runGuardsAndResolvers: 'always' },
  { path: '**', redirectTo: 'recipes'}
];

@NgModule({
  imports: [ RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' }) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}