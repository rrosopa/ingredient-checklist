import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { LoginCredentials } from '../models/login-credentials';
import { map } from 'rxjs/operators';
import { AppConstants } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
    isLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    
    constructor(
		private _httpClient: HttpClient
    ) { 
        
        let token = localStorage.getItem(AppConstants.token);
        if(token == undefined || token == null || token == ''){
            return;
        }

        this.isLoggedIn.next(true);
    }

	login(username: string, password: string) { //did'nt remove password for future edits
		let credentials = new LoginCredentials(username, password);
        return this._httpClient.post<any>('/api/authentication', credentials)
            .pipe(
                map(response => {
                    if (response) {
                        if (response['token']) {
                            localStorage.setItem(AppConstants.token, response['token']);
                            localStorage.setItem(AppConstants.currentUsername, response['name']);

                            this.isLoggedIn.next(true);
                        }
                    }
    
                    return response;
                })
            );
	}

	logout() {
		localStorage.clear();
        this.isLoggedIn.next(false);
        
    }
}
