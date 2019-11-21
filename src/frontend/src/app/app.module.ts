import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ThanksComponent } from './features/thanks/thanks.component';
import { PageNotFoundComponent } from './features/page-not-found/page-not-found.component';
import { AppRoutes } from './app.routes';
import { SendRatingComponent } from './features/send-rating/send-rating.component';
import { SendFeedbackDetailComponent } from './features/send-feedback-detail/send-feedback-detail.component';
import { NoServiceSpecifiedComponent } from './features/no-service-specified/no-service-specified.component';
import { CreateServiceComponent } from './features/create-service/create-service.component';
import { StatisticsComponent } from './features/statistics/statistics.component';
import { DesignAngularKitModule } from 'design-angular-kit';
import { SearchServiceComponent } from './shared/components/search-service/search-service.component';
import { AverageBarChartComponent } from './shared/components/average-bar-chart/average-bar-chart.component';
import { StatistichePieChartComponent } from './shared/components/statistiche-pie-chart/statistiche-pie-chart.component';
import { ClipboardModule } from 'ngx-clipboard';
import { SearchStatisticsComponent } from './shared/components/search-statistics/search-statistics.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RateComponent } from './features/statistics/rate/rate.component';
import { DetailModalComponent } from './features/statistics/detail-modal/detail-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    ThanksComponent,
    PageNotFoundComponent,
    SendRatingComponent,
    SendFeedbackDetailComponent,
    NoServiceSpecifiedComponent,
    CreateServiceComponent,
    StatisticsComponent,
    AverageBarChartComponent,
    StatistichePieChartComponent,
    SearchServiceComponent,
    SearchStatisticsComponent,
    RateComponent,
    DetailModalComponent
  ],
  imports: [
    RouterModule.forRoot(AppRoutes),
    NgbModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    DesignAngularKitModule,
    FormsModule,
    ClipboardModule,
    NgxChartsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [DetailModalComponent]
})
export class AppModule { }
