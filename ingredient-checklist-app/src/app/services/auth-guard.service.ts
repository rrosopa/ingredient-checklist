import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from './authentication.service';
import { AppConstants } from '../constants';
import { AlertService } from './alert.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

    constructor(
        private _router: Router,
        private _alert: AlertService
	) { }

	public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        let token = localStorage.getItem(AppConstants.token);
        if (token != null && token != undefined && token != '') {
			return true;
		}

        // not logged in so redirect to login page with the return url
        this._alert.error('You\'re not logged in.');
        this._router.navigate(['login'], { queryParams: { 'returnUrl': state.url } });
		return false;
	}
}
