import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FeedbackDetail } from '../feedback-detail';
import { SendFeedbackService } from '../send-feedback.service';

@Component({
  selector: 'app-send-feedback-detail',
  templateUrl: './send-feedback-detail.component.html',
  styleUrls: ['./send-feedback-detail.component.css']
})
export class SendFeedbackDetailComponent implements OnInit {
  private ratingId: string;
  public feedbackDetailForm = new FormGroup({
    text: new FormControl('', Validators.required),
    username: new FormControl(''),
    contacts: new FormControl('')
  });

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private sendFeedbackService: SendFeedbackService) { }

  ngOnInit() {
    this.ratingId = this.route.snapshot.paramMap.get('ratingId');
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    const feedbackDetail = new FeedbackDetail(
      this.ratingId,
      this.feedbackDetailForm.get('text').value,
      this.feedbackDetailForm.get('username').value,
      this.feedbackDetailForm.get('contacts').value,
    )

    this.sendFeedbackService
      .sendFeedbackDetail(feedbackDetail)
      .subscribe(r => this.router.navigate(['thanks']));
  }
}
