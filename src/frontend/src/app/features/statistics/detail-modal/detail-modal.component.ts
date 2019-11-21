import { Component, OnInit } from '@angular/core';
import { FeedbackI } from '../../../shared/interfaces/feedback-i';
import { Rating } from '../../../shared/enums/rating.enum';

@Component({
  selector: 'app-detail-modal',
  templateUrl: './detail-modal.component.html',
  styleUrls: ['./detail-modal.component.css']
})
export class DetailModalComponent implements OnInit {

  feedback: FeedbackI;

  constructor() {
  }

  ngOnInit() {
  }

  getImgPathByRating(rating: Rating) {
    switch (rating) {
      case Rating.Poor:
        return { src: './assets/images/poor.png', alt: 'poor smile face image' };
      case Rating.Fair:
        return { src: './assets/images/fair.png', alt: 'fair smile face image' };
      case Rating.Good:
        return { src: './assets/images/good.png', alt: 'good smile face image' };
    }
  }

}
