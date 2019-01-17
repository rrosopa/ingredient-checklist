import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';

@Injectable({
    providedIn: 'root'
})
export class AlertService {

    constructor(private _snackbar: MatSnackBar) { }

    error(message: string){
        this.showSnackBar(message, ['alert-error']);
    }

    success(message: string){
        this.showSnackBar(message, ['alert-success']);
    }

    showSnackBar(message: string, panelClass: string[]){
        this._snackbar.open(message, null, {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
            panelClass: panelClass
        });
    }
}
