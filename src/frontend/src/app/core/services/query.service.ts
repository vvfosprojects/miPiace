import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { QueryI } from '../../shared/interfaces/query-i';
import { Rating } from '../../shared/enums/rating.enum';

@Injectable({
  providedIn: 'root'
})
export class QueryService {

  queryParams: BehaviorSubject<QueryI> = new BehaviorSubject<QueryI>({
    rating: null,
    page: null,
    pageSize: null
  });

  constructor() {
  }

  setRatingParam(rating: Rating) {
    const query = this.queryParams.value;
    query.rating = rating;
    this.queryParams.next(query);
  }

  setPage(page: number) {
    const query = this.queryParams.value;
    query.page = page;
    this.queryParams.next(query);
  }

  setPageSize(pageSize: number) {
    const query = this.queryParams.value;
    query.pageSize = pageSize;
    this.queryParams.next(query);
  }

  getQueryParams() {
    return this.queryParams.asObservable();
  }
}
