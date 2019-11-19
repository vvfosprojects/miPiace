import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoServiceSpecifiedComponent } from './no-service-specified.component';

describe('NoServiceSpecifiedComponent', () => {
  let component: NoServiceSpecifiedComponent;
  let fixture: ComponentFixture<NoServiceSpecifiedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoServiceSpecifiedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoServiceSpecifiedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
