import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Path } from '../../enums/path.enum';

@Component({
  selector: 'app-search-statistics',
  templateUrl: './search-statistics.component.html',
  styleUrls: [ './search-statistics.component.css' ]
})
export class SearchStatisticsComponent {

  privateToken = '';

  Path = Path;

  constructor(private router: Router) {
  }

  goToStatistiche() {
    this.router.navigate([ `${Path.Statistics}/${this.privateToken}` ]);
  }

}
