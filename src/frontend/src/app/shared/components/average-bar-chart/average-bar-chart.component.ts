import { Component, Input, OnChanges, SimpleChanges, ViewEncapsulation } from '@angular/core';
import { FeedbackAverageScore } from '../../interfaces/feedback-average-score';
import { refreshAverageDesc } from '../../helpers/functions';

@Component({
  selector: 'app-average-bar-chart',
  templateUrl: './average-bar-chart.component.html',
  styleUrls: [ './average-bar-chart.component.css' ],
  encapsulation: ViewEncapsulation.None
})
export class AverageBarChartComponent implements OnChanges {

  @Input() feedbackAverageScores: FeedbackAverageScore[];
  @Input() title: string;

  data: any[] = [];

  view: any[] = [ 600, 250 ];

  showYAxis = true;
  gradient = false;
  showLegend = true;
  showYAxisLabel = true;
  legendLabel = 'Voto medio per arco temporale';
  colorScheme = {
    domain: [ '#63ADF2', '#0D5C63', '#2081C3', '#304D6D', '#0D1F2D', '#022B3A' ]
  };

  constructor() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.feedbackAverageScores && changes.feedbackAverageScores.currentValue) {
      const averageScores: FeedbackAverageScore[] = changes.feedbackAverageScores.currentValue;
      if (averageScores) {
        console.log(averageScores);
        this.data = averageScores.map(value => {
          return {
            name: refreshAverageDesc(value.intervallo),
            value: isNaN(value.average) ? 0 : Math.round(value.average * 100) / 100,
          };
        });
      }
    }
    if (changes.title && changes.title.currentValue) {
      const title: string = changes.title.currentValue;
      if (title) {
        console.log(title);
      }
    }
  }

  onSelect(event) {
    console.log(event);
  }

}
