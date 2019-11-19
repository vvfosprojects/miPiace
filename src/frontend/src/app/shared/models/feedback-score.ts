import { FeedbackAverageScore } from '../interfaces/feedback-average-score';
import { FacetStatistiche } from '../interfaces/facet-statistiche';

export class FeedbackScore {
  constructor(
    public readonly feedbackAverageScores: FeedbackAverageScore[],
    public readonly facetStatistiche: FacetStatistiche[],
    public readonly publicToken: string
  ) {
  }
}
