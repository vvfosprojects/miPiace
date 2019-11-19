import { TestBed } from '@angular/core/testing';

import { SendFeedbackService } from './send-feedback.service';

describe('SendFeedbackService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SendFeedbackService = TestBed.get(SendFeedbackService);
    expect(service).toBeTruthy();
  });
});
