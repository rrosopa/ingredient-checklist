import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

//services
import { AuthGuardService } from './services/auth-guard.service';
import { AuthenticationService } from './services/authentication.service';
import { JwtInterceptorService } from './services/jwt-interceptor.service';
import { AlertService } from './services/alert.service';
import { LogService } from './services/log.service';
import { RecipeService } from './services/recipe.service';

//
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    AuthGuardService,
    AuthenticationService,
    JwtInterceptorService,
    AlertService,
    LogService,
    RecipeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
