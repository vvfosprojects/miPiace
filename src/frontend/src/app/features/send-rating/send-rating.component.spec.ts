import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SendRatingComponent } from './send-rating.component';

describe('SendRatingComponent', () => {
  let component: SendRatingComponent;
  let fixture: ComponentFixture<SendRatingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SendRatingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SendRatingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
