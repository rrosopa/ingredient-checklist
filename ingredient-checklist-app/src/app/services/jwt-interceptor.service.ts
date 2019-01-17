import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppConstants } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class JwtInterceptorService implements HttpInterceptor {

	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		//adds authorization header with jwt token if available
		let token = localStorage.getItem(AppConstants.token);
		if (token) {
			request = request.clone({
				setHeaders: {
					authorization: `Bearer ${token}`,
					'content-type': `application/json`
				}
			});
		}

		return next.handle(request);
	}

}
