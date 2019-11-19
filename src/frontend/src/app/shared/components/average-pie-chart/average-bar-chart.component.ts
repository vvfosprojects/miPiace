import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip, SingleDataSet } from 'ng2-charts';
import { FeedbackAverageScore } from '../../interfaces/feedback-average-score';

@Component({
  selector: 'app-average-bar-chart',
  templateUrl: './average-bar-chart.component.html',
  styleUrls: [ './average-bar-chart.component.css' ]
})
export class AverageBarChartComponent implements OnChanges {

  @Input() feedbackAverageScores: FeedbackAverageScore[];
  @Input() title: string;

  public pieChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieChartLabels: Label[] = [['Download', 'Sales'], ['In', 'Store', 'Sales'], 'Mail Sales'];
  public pieChartData: SingleDataSet = [300, 500, 100];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [];

  constructor() {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
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
