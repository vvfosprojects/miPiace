import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { SendFeedbackService } from '../services/send-feedback.service';
import { Service } from '../service';
import { RouterModule, Routes, Router } from '@angular/router';

@Component({
  selector: 'app-create-service',
  templateUrl: './create-service.component.html',
  styleUrls: ['./create-service.component.css']
})
export class CreateServiceComponent implements OnInit {
  welcomeMessage = new FormControl('', [Validators.minLength(5), Validators.required]);
  service: Service = null;

  constructor(private sendFeedbackService: SendFeedbackService,
    private router: Router) { }

  ngOnInit() {
  }

  onSubmit() {
    this.sendFeedbackService
      .createService("\"" + this.welcomeMessage.value + "\"")
      .subscribe(service => this.service = service);
  }

  public getPublicLink(): string {
    let urlTree = this.router.parseUrl("/" + this.service.publicToken);
    let urlText = this.router.serializeUrl(urlTree);

    return urlText;
  }

  public getPrivateLink(): string {
    let urlTree = this.router.parseUrl("/statistics/" + this.service.privateToken);
    let urlText = this.router.serializeUrl(urlTree);

    return urlText;
  }
}
