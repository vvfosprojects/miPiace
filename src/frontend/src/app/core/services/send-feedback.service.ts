import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { ReturnedId } from '../../shared/models/returned-id';
import { FeedbackDetail } from '../../shared/models/feedback-detail';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class SendFeedbackService {

  constructor(private http: HttpClient) {
  }

  private static handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  }

  public getWelcomeMessage(publicToken: string): Observable<string> {
    const url = environment.backendUrl + '/getWelcomeMessage/' + publicToken;

    return this.http.get<string>(url)
      .pipe(
        catchError(SendFeedbackService.handleError)
      );
  }

  public sendRating(rating: string, publicToken: string): Observable<ReturnedId> {
    const url = environment.backendUrl + '/insertRating';

    const body = {
      rating,
      publicToken
    };

    return this.http.post<ReturnedId>(url, body, httpOptions)
      .pipe(
        catchError(SendFeedbackService.handleError)
      );
  }

  public sendFeedbackDetail(detail: FeedbackDetail): Observable<null> {
    const url = environment.backendUrl + '/appendFeedbackDetail';

    return this.http.post<null>(url, detail, httpOptions)
      .pipe(
        catchError(SendFeedbackService.handleError)
      );
  }

}
