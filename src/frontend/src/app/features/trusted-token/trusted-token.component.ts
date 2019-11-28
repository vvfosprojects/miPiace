import { Component } from '@angular/core';
import { SendFeedbackService } from '../../core/services/send-feedback.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ManageFeedbackService } from '../../core/services/manage-feedback.service';
import { Path } from '../../shared/enums/path.enum';

@Component({
  template: ``
})
export class TrustedTokenComponent {

  constructor(private sendFeedbackService: SendFeedbackService,
              private manageFeedbackService: ManageFeedbackService,
              private route: ActivatedRoute,
              private router: Router) {
    this.switchRoute(this.route.snapshot.paramMap.get('id'));
  }

  private switchRoute(token: string) {
    this.sendFeedbackService.getWelcomeMessage(token).subscribe(() => {
      console.log('Token Publico');
      this.router.navigate([`${Path.SendRating}/${token}`]);
    }, () => {
      this.manageFeedbackService.getServiceAverageFeedbackScore(token).subscribe(() => {
        console.log('Token Privato');
        this.router.navigate([`${Path.Statistics}/${token}`]);
      }, () => {
        this.router.navigate(['/']);
      });
    });
  }

}
