import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ManageFeedbackService } from '../../core/services/manage-feedback.service';
import { FeedbackScore } from '../../shared/models/feedback-score';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  private privateToken: string;

  constructor(private manageFeedbackService: ManageFeedbackService,
              private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.privateToken = this.route.snapshot.paramMap.get('id');

    this.manageFeedbackService
      .getServiceAverageFeedbackScore(this.privateToken)
      .subscribe((feedbackScore: FeedbackScore) => console.log(feedbackScore));
  }

}
