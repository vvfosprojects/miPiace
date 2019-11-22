import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FeedbackI } from '../../../shared/interfaces/feedback-i';
import { Rating } from '../../../shared/enums/rating.enum';

@Component({
  selector: 'app-rate',
  templateUrl: './rate.component.html',
  styleUrls: ['./rate.component.css']
})
export class RateComponent implements OnInit {

  @Input() feedback: FeedbackI;
  hover: boolean;
  rating = Rating;

  @Output() detailEmitter: EventEmitter<FeedbackI> = new EventEmitter<FeedbackI>();

  constructor() {
  }

  ngOnInit() {
  }

  getImgPathByRating(rating: Rating) {
    switch (rating) {
      case Rating.Poor:
        return { src: './assets/images/small-smile/poor.png', alt: 'poor smile face image' };
      case Rating.Fair:
        return { src: './assets/images/small-smile/fair.png', alt: 'fair smile face image' };
      case Rating.Good:
        return { src: './assets/images/small-smile/good.png', alt: 'good smile face image' };
    }
  }

  onDetail() {
    this.detailEmitter.emit(this.feedback);
  }
}
