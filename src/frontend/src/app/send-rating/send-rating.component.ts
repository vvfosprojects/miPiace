import { Component, OnInit } from '@angular/core';
import { SendFeedbackService } from '../send-feedback.service';
import { Router } from "@angular/router";

@Component({
  selector: 'app-send-rating',
  templateUrl: './send-rating.component.html',
  styleUrls: ['./send-rating.component.css']
})
export class SendRatingComponent implements OnInit {
  constructor(private sendFeedbackService: SendFeedbackService,
    private router: Router) {
  }

  ngOnInit(): void {
  }

  public sendRating(rating: string): void {
    this.sendFeedbackService
      .sendRating(rating)
      .subscribe(id => this.router.navigate(['/sendFeedbackDetail', { ratingId: id.id } ]));
  }

  public sendGoodRating(): void {
    this.sendFeedbackService
      .sendRating("good")
      .subscribe(id => this.router.navigate(['thanks']));
  }

}
