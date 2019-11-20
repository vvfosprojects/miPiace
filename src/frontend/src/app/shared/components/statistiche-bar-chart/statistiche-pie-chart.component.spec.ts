import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatistichePieChartComponent } from './statistiche-pie-chart.component';

describe('StatisticheBarChartComponent', () => {
  let component: StatistichePieChartComponent;
  let fixture: ComponentFixture<StatistichePieChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatistichePieChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatistichePieChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
