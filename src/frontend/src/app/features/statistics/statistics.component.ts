import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ManageFeedbackService } from '../../core/services/manage-feedback.service';
import { FeedbackScore } from '../../shared/models/feedback-score';
import { FeedbackAverageScore } from '../../shared/interfaces/feedback-average-score';
import { FacetStatistiche } from '../../shared/interfaces/facet-statistiche';
import { SendFeedbackService } from '../../core/services/send-feedback.service';
import { Rating } from '../../shared/enums/rating.enum';
import { AllFeedback } from '../../shared/models/all-feedback';
import { FeedbackI } from '../../shared/interfaces/feedback-i';
import { Feedback } from '../../shared/models/feedback';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  privateToken: string;
  feedbackResult: boolean;

  feedbackAverageScores: FeedbackAverageScore[];
  facetStatistiche: FacetStatistiche[];
  title: string;

  feedbacks: FeedbackI[];

  constructor(private manageFeedbackService: ManageFeedbackService,
              private sendFeedbackService: SendFeedbackService,
              private route: ActivatedRoute,
              private router: Router) {
  }

  ngOnInit() {
    this.privateToken = this.route.snapshot.paramMap.get('id');
    this.manageFeedbackService
      .getServiceAverageFeedbackScore(this.privateToken)
      .subscribe((feedbackScore: FeedbackScore) => {
        if (feedbackScore) {
          this.feedbackResult = !!feedbackScore;
          console.log('getServiceAverageFeedbackScore', feedbackScore);
          this.facetStatistiche = feedbackScore.facetStatistiche;
          this.feedbackAverageScores = feedbackScore.feedbackAverageScores;
          if (feedbackScore.publicToken) {
            console.log('test');
            this.sendFeedbackService.getWelcomeMessage(feedbackScore.publicToken).subscribe(welcome => this.title = welcome);
            this.getAllFeedback();
          }
        }
      }, () => this.goToSearchStatistiche());
  }

  getAllFeedback(rating?: Rating, page?: number, pageSize?: number) {
    this.manageFeedbackService.getAllFeedback(this.privateToken, rating, page, pageSize)
      .subscribe((allFeedback: AllFeedback) => {
        if (allFeedback) {
          console.log('getAllFeedback', allFeedback);
          this.feedbacks = allFeedback.allFeedback;
        }
      });
  }

  getFeedback(id: string) {
    this.manageFeedbackService.getFeedback(this.privateToken, id)
      .subscribe((feedback: Feedback) => {
        if (feedback) {
          console.log('getFeedback', feedback);
          // Todo: Apertura modale
        }
      });
  }

  goToSearchStatistiche() {
    this.router.navigate([ 'statistics' ]);
  }

}
