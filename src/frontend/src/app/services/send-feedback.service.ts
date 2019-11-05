import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { ReturnedId } from '../returned-id';
import { FeedbackDetail } from '../feedback-detail';
import { Service } from '../service';

@Injectable({
  providedIn: 'root'
})
export class SendFeedbackService {

  constructor(private http: HttpClient) { }

  public getWelcomeMessage(publicToken: string): Observable<string> {
    let url = environment.backendUrl + '/getWelcomeMessage/' + publicToken;

    return this.http.get<string>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  public sendRating(rating: string, publicToken: string): Observable<ReturnedId> {
    let url = environment.backendUrl + '/insertRating';

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };

    let body = { 
      rating: rating,
      publicToken: publicToken
    }

    return this.http.post<ReturnedId>(url, body, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  public sendFeedbackDetail(detail: FeedbackDetail): Observable<null> {
    let url = environment.backendUrl + '/appendFeedbackDetail';

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };

    return this.http.post<null>(url, detail, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  public createService(welcomeMessage: string): Observable<Service> {
    let url = environment.backendUrl + '/createNewService';

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };

    return this.http.post<Service>(url, welcomeMessage, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
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
  };
}
