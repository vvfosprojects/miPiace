import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ManageFeedbackService } from '../../core/services/manage-feedback.service';
import { FeedbackScore } from '../../shared/models/feedback-score';
import { FeedbackAverageScore } from '../../shared/interfaces/feedback-average-score';
import { FacetStatistiche } from '../../shared/interfaces/facet-statistiche';
import { SendFeedbackService } from '../../core/services/send-feedback.service';
import { Rating } from '../../shared/enums/rating.enum';
import { AllFeedback } from '../../shared/models/all-feedback';
import { FeedbackI } from '../../shared/interfaces/feedback-i';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DetailModalComponent } from './detail-modal/detail-modal.component';
import { QueryService } from '../../core/services/query.service';
import { QueryI } from '../../shared/interfaces/query-i';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  privateToken: string;
  feedbackResult: boolean;
  notFound: boolean;
  title: string;
  feedbacks: FeedbackI[];
  feedbackAverageScores: FeedbackAverageScore[];
  facetStatistiche: FacetStatistiche[];

  page: number;
  pageSize: number;
  pageSizeDropdown = ['5', '10', '15', '20', '30', '40'];
  rating: string;
  ratingDropdown = [Rating.Good, Rating.Fair, Rating.Poor];
  totalItems: number;

  subscription: Subscription = new Subscription();

  constructor(private manageFeedbackService: ManageFeedbackService,
              private sendFeedbackService: SendFeedbackService,
              private route: ActivatedRoute,
              private modal: NgbModal,
              private queryService: QueryService) {
    this.getQueryParams();
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
            this.sendFeedbackService.getWelcomeMessage(feedbackScore.publicToken).subscribe(welcome => this.title = welcome);
            this.getAllFeedback();
          }
        }
      }, () => this.notFound = true);
  }

  getAllFeedback(rating?: Rating, page?: number, pageSize?: number) {
    this.manageFeedbackService.getAllFeedback(this.privateToken, rating, page, pageSize)
      .subscribe((allFeedback: AllFeedback) => {
        this.page = allFeedback.criteriDiRicerca.page;
        this.pageSize = allFeedback.criteriDiRicerca.pageSize;
        this.rating = allFeedback.criteriDiRicerca.rating ? allFeedback.criteriDiRicerca.rating : 'Tutti i voti';
        this.totalItems = allFeedback.criteriDiRicerca.totalItems;
        if (allFeedback) {
          console.log('getAllFeedback', allFeedback);
          this.feedbacks = allFeedback.allFeedback;
        }
      });
  }

  onPageChange(page: number) {
    this.queryService.setPage(page);
  }

  onPageSizeChange(pageSize: number) {
    this.queryService.setPageSize(pageSize);
  }

  onRatingChange(rating: Rating) {
    this.queryService.setRatingParam(rating);
  }

  getQueryParams() {
    this.subscription.add(
      this.queryService.queryParams.subscribe((queryParams: QueryI) => {
        if (this.feedbackResult) {
          this.getAllFeedback(queryParams.rating, queryParams.page, queryParams.pageSize);
        }
      })
    );
  }

  // getFeedback(id: string) {
  //   this.manageFeedbackService.getFeedback(this.privateToken, id)
  //     .subscribe((feedback: Feedback) => {
  //       if (feedback) {
  //         console.log('getFeedback', feedback);
  //          const modal = this.modal.open(DetailModalComponent, { centered: true });
  //          modal.componentInstance.feedback = feedback;
  //       }
  //     });
  // }

  onDetail(feedback: FeedbackI) {
    const modal = this.modal.open(DetailModalComponent);
    modal.componentInstance.feedback = feedback;
  }
}
