import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class SnackbarService {
  baseUrl: string;

  constructor(public matSnackbar: MatSnackBar) {}

  error(message: string) {
    this.matSnackbar.open(message, 'Dismiss', {
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: 'error-snackbar',
    });
  }

  success(message: string) {
    this.matSnackbar.open(message, 'Dismiss', {
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: 'success-snackbar',
    });
  }
}
