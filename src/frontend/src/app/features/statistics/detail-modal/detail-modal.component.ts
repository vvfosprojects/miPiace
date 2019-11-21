import { Component, OnInit } from '@angular/core';
import { FeedbackI } from "../../../shared/interfaces/feedback-i";

@Component({
  selector: 'app-detail-modal',
  templateUrl: './detail-modal.component.html',
  styleUrls: ['./detail-modal.component.css']
})
export class DetailModalComponent implements OnInit {

  feedback: FeedbackI;

  constructor() { }

  ngOnInit() {
  }

}
