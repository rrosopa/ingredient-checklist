import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { IdLabelPair } from 'src/app/models/IdLabelPair';
import { AlertService } from 'src/app/services/alert.service';
import { AppConstants } from 'src/app/constants';
import { Router } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    users: IdLabelPair[] = [];
    selectedUser: string;
    
    constructor(
        private _userService: UserService,
        private _authenticationService: AuthenticationService,
        private _alertService: AlertService,
        private _router: Router) { }

    ngOnInit() {
        this._userService.getUserDictionary().subscribe(response => {
            this.users = response;
        });
    }

    click_login(){
        var id = this.selectedUser;
        if(id == null || id == undefined || id == ''){
            return;
        }

        this._authenticationService.login(id, '').subscribe(response => {
            let token = localStorage.getItem(AppConstants.token);
            if(token == undefined || token == null || token == ''){
                this._alertService.error('A problem occured.');
                return;
            }

            this._router.navigate(['recipes']);
        })
    }
}
