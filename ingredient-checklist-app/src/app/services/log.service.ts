import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AlertService } from './alert.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LogService {

    constructor(
		private _router: Router,
		private _alertService: AlertService
	) { }

	///https://angular.io/tutorial/toh-pt6
	handleError<T>(operation = 'operation', result?: T) {
		return (errorResponse: any): Observable<T> => {
			// TODO: send the error to remote logging infrastructure
			console.log(`error encountered on ${operation}`);
			console.log(`errorDetails => (${errorResponse.status})"${errorResponse.statusText}" @${errorResponse.url}`)

			if (errorResponse.status == '401') {
                // UNAUTHORIZE ACCCESS
                // throw to login page
				return;
            }
            
            if (errorResponse.status == '403') {
                // FORBIDDEN ACCCESS
                //display alert message
				return;
            }
            
			// Let the app keep running by returning an empty result.
			if (result == undefined) {
				return of(errorResponse.error as T);
			}

			return of(result as T);
		};
	}
}
