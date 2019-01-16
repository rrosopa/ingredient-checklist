import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

    constructor(
		private _router: Router,
		private _authenticationService: AuthenticationService
	) 
		{ }

	public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
		// if (!this._authenticationService.isTokenExpired()) {
		// 	return true;
		// }

		// // not logged in so redirect to login page with the return url
        // this._router.navigate([`${APP_ROUTES.login}`], { queryParams: { 'returnUrl': state.url } });
        
        //implement here
		return true;
	}
}
