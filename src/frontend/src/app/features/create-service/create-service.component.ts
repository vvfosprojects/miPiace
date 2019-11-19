import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Service } from '../../shared/models/service';
import { SendFeedbackService } from '../../core/services/send-feedback.service';

@Component({
  selector: 'app-create-service',
  templateUrl: './create-service.component.html',
  styleUrls: ['./create-service.component.css']
})
export class CreateServiceComponent implements OnInit {
  welcomeMessage = new FormControl('', [Validators.minLength(5), Validators.required]);
  service: Service;

  constructor(private sendFeedbackService: SendFeedbackService,
              private router: Router) { }

  ngOnInit() {
  }

  onSubmit() {
    this.sendFeedbackService
      .createService('"' + this.welcomeMessage.value + '"')
      .subscribe(service => this.service = service);
  }

  public getPublicLink(): string {
    const urlTree = this.router.parseUrl('/' + this.service.publicToken);
    const urlText = this.router.serializeUrl(urlTree);

    return urlText;
  }

  public getPrivateLink(): string {
    const urlTree = this.router.parseUrl('/statistics/' + this.service.privateToken);
    const urlText = this.router.serializeUrl(urlTree);

    return urlText;
  }
}
