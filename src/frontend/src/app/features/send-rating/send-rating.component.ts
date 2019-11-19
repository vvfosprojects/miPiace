import { Component, OnInit } from '@angular/core';
import { SendFeedbackService } from '../../core/services/send-feedback.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-send-rating',
  templateUrl: './send-rating.component.html',
  styleUrls: ['./send-rating.component.css']
})
export class SendRatingComponent implements OnInit {
  private publicToken: string;
  public welcomeMessage: string = null;

  constructor(private sendFeedbackService: SendFeedbackService,
              private route: ActivatedRoute,
              private router: Router) {
  }

  ngOnInit(): void {
    this.publicToken = this.route.snapshot.paramMap.get('id');

    this.sendFeedbackService
      .getWelcomeMessage(this.publicToken)
      .subscribe(msg => this.welcomeMessage = msg);
  }

  public sendRating(rating: string): void {
    this.sendFeedbackService
      .sendRating(rating, this.publicToken)
      .subscribe(id => this.router.navigate(['/sendFeedbackDetail', { ratingId: id.id } ]));
  }

  public sendGoodRating(): void {
    this.sendFeedbackService
      .sendRating('good', this.publicToken)
      .subscribe(id => this.router.navigate(['thanks']));
  }

}
