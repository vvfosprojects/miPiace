import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { Service } from '../../shared/models/service';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { FeedbackScore } from '../../shared/models/feedback-score';
import { Feedback } from '../../shared/models/feedback';
import { Rating } from '../../shared/enums/rating.enum';
import { AllFeedback } from '../../shared/models/all-feedback';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class ManageFeedbackService {

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

  public createService(welcomeMessage: string): Observable<Service> {
    const url = environment.backendUrl + '/createNewService/';

    return this.http.post<Service>(url, welcomeMessage, httpOptions)
      .pipe(
        catchError(ManageFeedbackService.handleError)
      );
  }

  public getAllFeedback(privateToken: string, rating: Rating, page?: string, pageSize?: string): Observable<AllFeedback> {
    let queryParams = `?PrivateToken=${privateToken}&Rating=${rating}&`;
    queryParams += page ? `Page=${page}&` : ``;
    queryParams += pageSize ? `PageSize=${pageSize}&` : ``;
    const url = environment.backendUrl + '/getAllFeedback' + queryParams;

    return this.http.get<AllFeedback>(url)
      .pipe(
        catchError(ManageFeedbackService.handleError)
      );
  }

  public getFeedback(privateToken: string, id: string): Observable<Feedback> {
    const queryParams = `?Id=${id}&PrivateToken=${privateToken}`;
    const url = environment.backendUrl + '/getFeedback' + queryParams;

    return this.http.get<Feedback>(url)
      .pipe(
        catchError(ManageFeedbackService.handleError)
      );
  }

  public getServiceAverageFeedbackScore(privateToken: string): Observable<FeedbackScore> {
    const url = environment.backendUrl + '/getServiceAverageFeedbackScore?privateToken=' + privateToken;

    return this.http.get<FeedbackScore>(url)
      .pipe(
        catchError(ManageFeedbackService.handleError)
      );
  }
}
