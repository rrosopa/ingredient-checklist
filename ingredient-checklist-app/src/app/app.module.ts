import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './modules/app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

//services
import { AuthGuardService } from './services/auth-guard.service';
import { AuthenticationService } from './services/authentication.service';
import { JwtInterceptorService } from './services/jwt-interceptor.service';
import { AlertService } from './services/alert.service';
import { LogService } from './services/log.service';
import { RecipeService } from './services/recipe.service';
import { UserService } from './services/user.service';

//
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginComponent } from './components/login/login.component';

//angular material
import { MatToolbarModule, MatCheckboxModule, MatListModule, MatButtonModule, MatSnackBarModule, MatInputModule, MatCardModule, MatSelectModule, 
        MatFormFieldModule, MatIconModule, MatExpansionModule, MatDividerModule } from '@angular/material';
import { RecipeListComponent } from './components/recipe-list/recipe-list.component';
import { ErrorPageNotFoundComponent } from './components/error-page-not-found/error-page-not-found.component';
import { RecipeFormComponent } from './components/recipe-form/recipe-form.component'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RecipeListComponent,
    ErrorPageNotFoundComponent,
    RecipeFormComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule ,
    AppRoutingModule,
    FormsModule,
    MatToolbarModule,
    MatCheckboxModule,
    MatListModule,
    MatButtonModule,
    MatSnackBarModule,
    MatInputModule,
    MatCardModule,
    MatSelectModule,
    MatFormFieldModule,
    MatIconModule,
    MatExpansionModule,
    MatDividerModule
  ],
  providers: [
    AuthGuardService,
    AuthenticationService,
    JwtInterceptorService,
    AlertService,
    LogService,
    RecipeService,
    UserService,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: JwtInterceptorService,
        multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
