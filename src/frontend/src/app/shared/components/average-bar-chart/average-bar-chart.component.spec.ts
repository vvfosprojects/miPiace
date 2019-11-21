import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AverageBarChartComponent } from './average-bar-chart.component';

describe('AveragePieChartComponent', () => {
  let component: AverageBarChartComponent;
  let fixture: ComponentFixture<AverageBarChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AverageBarChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AverageBarChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
