import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-search-service',
  templateUrl: './search-service.component.html',
  styleUrls: ['./search-service.component.css']
})
export class SearchServiceComponent implements OnInit {
  public codiceServizio = '';

  constructor(private router: Router) {
  }

  ngOnInit() {
  }

  goToServizio() {
    this.router.navigate(['sendRating/' + this.codiceServizio]);
  }

}
