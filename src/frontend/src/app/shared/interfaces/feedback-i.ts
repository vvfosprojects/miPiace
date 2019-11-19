import { Rating } from '../enums/rating.enum';

export interface FeedbackI {
  id: string;
  rating: Rating;
  instantUtc: string;
  host: string;
  user: string;
  feedbackText: string;
  userContacts: string;
  publicToken: string;
}
