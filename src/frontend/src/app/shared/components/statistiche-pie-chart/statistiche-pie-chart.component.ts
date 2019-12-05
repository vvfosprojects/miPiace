import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { FacetStatistiche } from '../../interfaces/facet-statistiche';
import { refreshVotoDesc } from '../../helpers/functions';
import { Rating } from '../../enums/rating.enum';

@Component({
  selector: 'app-statistiche-pie-chart',
  templateUrl: './statistiche-pie-chart.component.html',
  styleUrls: [ './statistiche-pie-chart.component.css' ]
})
export class StatistichePieChartComponent implements OnChanges {

  @Input() facetStatistiche: FacetStatistiche[];
  @Input() title: string;

  @Output() selectedRate = new EventEmitter<Rating>();

  data: any[] = [];
  view: any[] = [ 600, 150 ];

  colorScheme = {
    domain: [ '#28ea42', '#e9ff39', '#e00000' ]
  };

  constructor() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.facetStatistiche && changes.facetStatistiche.currentValue) {
      const facet: FacetStatistiche[] = changes.facetStatistiche.currentValue;
      if (facet) {
        this.data = facet.map(value => {
          return {
            name: refreshVotoDesc(value.voto),
            value: value.totalItems,
          };
        });
      }
    }
  }

}
