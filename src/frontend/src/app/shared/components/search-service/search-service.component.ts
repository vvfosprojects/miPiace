import {Component} from '@angular/core';
import {Router} from '@angular/router';
import { Path } from '../../enums/path.enum';

@Component({
  selector: 'app-search-service',
  templateUrl: './search-service.component.html',
  styleUrls: ['./search-service.component.css']
})
export class SearchServiceComponent {
  public codiceServizio = '';

  constructor(private router: Router) {
  }

  goToServizio() {
    this.router.navigate([`${Path.SendRating}/${this.codiceServizio}`]);
  }

}
