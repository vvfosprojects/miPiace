import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SendFeedbackDetailComponent } from './send-feedback-detail.component';

describe('SendFeedbackDetailComponent', () => {
  let component: SendFeedbackDetailComponent;
  let fixture: ComponentFixture<SendFeedbackDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SendFeedbackDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SendFeedbackDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
