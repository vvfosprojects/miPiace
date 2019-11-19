import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-no-service-specified',
  templateUrl: './no-service-specified.component.html',
  styleUrls: ['./no-service-specified.component.css']
})
export class NoServiceSpecifiedComponent implements OnInit {

  codiceServizio = '';

  constructor(private router: Router) {
  }

  ngOnInit() {
  }

  goToServizio() {
    this.router.navigate(['sendRating/' + this.codiceServizio]);
  }
}
