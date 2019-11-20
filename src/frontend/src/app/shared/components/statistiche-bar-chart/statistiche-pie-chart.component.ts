import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FacetStatistiche } from '../../interfaces/facet-statistiche';
import { ChartDataSets, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-statistiche-pie-chart',
  templateUrl: './statistiche-pie-chart.component.html',
  styleUrls: [ './statistiche-pie-chart.component.css' ]
})
export class StatistichePieChartComponent implements OnChanges {

  @Input() facetStatistiche: FacetStatistiche[];
  @Input() title: string;

  public barChartType: ChartType = 'bar';
  public barChartLabels: Label[] = [];
  public barChartData: ChartDataSets[];

  constructor() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.facetStatistiche && changes.facetStatistiche.currentValue) {
      const facet: FacetStatistiche[] = changes.facetStatistiche.currentValue;
      if (facet) {
        console.log(facet);
        this.barChartData = [
          {
            data: [ facet[0].percentuale * 100 ],
            label: facet[0].voto,
            backgroundColor: '#33cc33',
            hoverBackgroundColor: '#33cc33'
          },
          {
            data: [ facet[1].percentuale * 100 ],
            label: facet[1].voto,
            backgroundColor: '#ffff00',
            hoverBackgroundColor: '#ffff00'
          },
          {
            data: [ facet[2].percentuale * 100 ],
            label: facet[2].voto,
            backgroundColor: '#ff0000',
            hoverBackgroundColor: '#ff0000'
          }
        ];
      }
    }
    if (changes.title && changes.title.currentValue) {
      const title: string = changes.title.currentValue;
      if (title) {
        this.barChartLabels = [ title ];
      }
    }
  }

  // events
  public chartClicked(id): void {
    console.log(id.active);
  }
}
