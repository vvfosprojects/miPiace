import { TestBed } from '@angular/core/testing';

import { ManageFeedbackService } from './manage-feedback.service';

describe('ManageFeedbackService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ManageFeedbackService = TestBed.get(ManageFeedbackService);
    expect(service).toBeTruthy();
  });
});
