import {Component, OnInit} from '@angular/core';
import {SendFeedbackService} from '../../core/services/send-feedback.service';
import {Router, ActivatedRoute} from '@angular/router';
import { Path } from '../../shared/enums/path.enum';

@Component({
  selector: 'app-send-rating',
  templateUrl: './send-rating.component.html',
  styleUrls: ['./send-rating.component.css']
})
export class SendRatingComponent implements OnInit {
  private publicToken: string;
  public welcomeMessage: string;
  public noMessage = false;
  public loading = false;

  constructor(private sendFeedbackService: SendFeedbackService,
              private route: ActivatedRoute,
              private router: Router) {
  }

  ngOnInit(): void {
    this.publicToken = this.route.snapshot.paramMap.get('id');

    this.sendFeedbackService
      .getWelcomeMessage(this.publicToken)
      .subscribe(msg => {
        msg ? this.welcomeMessage = msg : this.noMessage = true;
      });
  }

  public sendRating(rating: string): void {
    this.loading = true;
    this.sendFeedbackService
      .sendRating(rating, this.publicToken)
      .subscribe(id => {
        this.loading = false;
        this.router.navigate([ Path.SendFeedbackDetail, { ratingId: id.id } ]);
      });
  }

  public sendGoodRating(): void {
    this.loading = true;
    this.sendFeedbackService
      .sendRating('good', this.publicToken)
      .subscribe(() => {
        this.loading = false;
        this.router.navigate([ Path.Thanks ]);
      });
  }

}
