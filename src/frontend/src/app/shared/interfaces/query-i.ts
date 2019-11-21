import { Rating } from '../enums/rating.enum';

export interface QueryI {
  rating: Rating;
  page: number;
  pageSize: number;
}
