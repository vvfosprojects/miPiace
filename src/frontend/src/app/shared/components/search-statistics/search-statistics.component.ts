import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-statistics',
  templateUrl: './search-statistics.component.html',
  styleUrls: [ './search-statistics.component.css' ]
})
export class SearchStatisticsComponent implements OnInit {

  privateToken = '';

  constructor(private router: Router) {
  }

  ngOnInit() {
  }

  goToStatistiche() {
    this.router.navigate([ 'statistics/' + this.privateToken ]);
  }

}
