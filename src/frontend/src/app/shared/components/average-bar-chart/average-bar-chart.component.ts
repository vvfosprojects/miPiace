import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FeedbackAverageScore } from '../../interfaces/feedback-average-score';

@Component({
  selector: 'app-average-bar-chart',
  templateUrl: './average-bar-chart.component.html',
  styleUrls: [ './average-bar-chart.component.css' ]
})
export class AverageBarChartComponent implements OnChanges {

  @Input() feedbackAverageScores: FeedbackAverageScore[];
  @Input() title: string;

  constructor() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.feedbackAverageScores && changes.feedbackAverageScores.currentValue) {
      const averageScores: FeedbackAverageScore[] = changes.feedbackAverageScores.currentValue;
      if (averageScores) {
        console.log(averageScores);
        // this.pieChartData = [];
      }
    }
    if (changes.title && changes.title.currentValue) {
      const title: string = changes.title.currentValue;
      if (title) {
        console.log(title);
        // this.pieChartLabels = [title];
      }
    }
  }

}
