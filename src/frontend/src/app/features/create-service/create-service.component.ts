import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Service } from '../../shared/models/service';
import { ManageFeedbackService } from '../../core/services/manage-feedback.service';
import { Path } from '../../shared/enums/path.enum';


@Component({
  selector: 'app-create-service',
  templateUrl: './create-service.component.html',
  styleUrls: ['./create-service.component.css']
})
export class CreateServiceComponent implements OnInit {
  welcomeMessage = new FormControl('', [Validators.minLength(5), Validators.required]);
  service: Service;

  locationPath: string;

  constructor(private manageFeedbackService: ManageFeedbackService,
              private router: Router) {
    this.locationPath = window.location.origin;
  }

  ngOnInit() {
  }

  onSubmit() {
    this.manageFeedbackService
      .createService('"' + this.welcomeMessage.value + '"')
      .subscribe(service => this.service = service);
  }

  public getPublicLink(fullUrl?: boolean): string {
    const urlTree = this.router.parseUrl(`${this.service.publicToken}`);
    const serializedUrl = this.router.serializeUrl(urlTree);
    return fullUrl ? this.locationPath + serializedUrl : serializedUrl;
  }

  public getPrivateLink(fullUrl?: boolean): string {
    const urlTree = this.router.parseUrl(`${this.service.privateToken}`);
    const serializedUrl = this.router.serializeUrl(urlTree);
    return fullUrl ? this.locationPath + serializedUrl : serializedUrl;
  }
}
