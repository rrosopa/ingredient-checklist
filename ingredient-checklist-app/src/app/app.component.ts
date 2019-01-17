import { Component } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';
import { Router } from '@angular/router';
import { AppConstants } from './constants';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    showNavigation: boolean = false;
    usersName: string = '';
    
    constructor(
        private _authenticationService: AuthenticationService,
        private _router: Router
        ){}

    ngOnInit(){
        this._authenticationService.isLoggedIn.subscribe(
			isLoggedIn => {
                this.showNavigation = isLoggedIn;
                
                if(this.showNavigation){
                    this.usersName = localStorage.getItem(AppConstants.currentUsername) + '\'s';
                }
                else{
                    this.usersName = '';
                }
			}
		)
    }

    click_logout() {
        this._router.navigate(['login']);
        this._authenticationService.logout();
    }
}
