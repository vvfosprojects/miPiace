import { Component } from '@angular/core';
import { Path } from '../../shared/enums/path.enum';

@Component({
  selector: 'app-no-service-specified',
  templateUrl: './no-service-specified.component.html',
  styleUrls: ['./no-service-specified.component.css']
})
export class NoServiceSpecifiedComponent {

  Path = Path;

}
