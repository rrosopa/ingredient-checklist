import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LogService } from './log.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IdLabelPair } from '../models/IdLabelPair';

@Injectable({
  providedIn: 'root'
})
export class UserService {

    constructor(
		private _http: HttpClient,
		private _logService: LogService
	) { }

	getUserDictionary(): Observable<IdLabelPair[]> {
		return this._http.get<IdLabelPair[]>('/api/users/')
			.pipe(
				catchError(this._logService.handleError<IdLabelPair[]>('getUsers'))
			);
    }
}
