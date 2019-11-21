import { Component, Input, OnInit } from '@angular/core';
import { FeedbackI } from '../../../shared/interfaces/feedback-i';

@Component({
  selector: 'app-rate',
  templateUrl: './rate.component.html',
  styleUrls: ['./rate.component.css']
})
export class RateComponent implements OnInit {

  @Input() feedback: FeedbackI;
  hover: boolean;

  constructor() {
  }

  ngOnInit() {
  }

  getIconByRate(rate: number) {
    return;
  }

}
