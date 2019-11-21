import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FacetStatistiche } from '../../interfaces/facet-statistiche';

@Component({
  selector: 'app-statistiche-pie-chart',
  templateUrl: './statistiche-pie-chart.component.html',
  styleUrls: [ './statistiche-pie-chart.component.css' ]
})
export class StatistichePieChartComponent implements OnChanges {

  @Input() facetStatistiche: FacetStatistiche[];
  @Input() title: string;

  constructor() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.facetStatistiche && changes.facetStatistiche.currentValue) {
      const facet: FacetStatistiche[] = changes.facetStatistiche.currentValue;
      if (facet) {
        console.log(facet);
      }
    }
    if (changes.title && changes.title.currentValue) {
      const title: string = changes.title.currentValue;
      if (title) {
      }
    }
  }

}
