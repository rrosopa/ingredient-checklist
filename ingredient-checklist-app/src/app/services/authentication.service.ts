import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
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
	) { }

	login(username: string, password: string) {
		let credentials = new LoginCredentials(username, password);
        return this._httpClient.post<any>('/api/authentication', credentials)
            .pipe(
                map(response => {
                    if (response) {
                        if (response['token']) {
                            localStorage.setItem(AppConstants.Token, response['token']);
                            localStorage.setItem(AppConstants.CurrentUsername, username);

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
