import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { ThanksComponent } from './features/thanks/thanks.component';
import { PageNotFoundComponent } from './features/page-not-found/page-not-found.component';
import { AppRoutes } from './app.routes';
import { SendRatingComponent } from './features/send-rating/send-rating.component';
import { SendFeedbackDetailComponent } from './features/send-feedback-detail/send-feedback-detail.component';
import { NoServiceSpecifiedComponent } from './features/no-service-specified/no-service-specified.component';
import { CreateServiceComponent } from './features/create-service/create-service.component';
import { StatisticsComponent } from './features/statistics/statistics.component';
import {DesignAngularKitModule} from 'design-angular-kit';

@NgModule({
  declarations: [
    AppComponent,
    ThanksComponent,
    PageNotFoundComponent,
    SendRatingComponent,
    SendFeedbackDetailComponent,
    NoServiceSpecifiedComponent,
    CreateServiceComponent,
    StatisticsComponent
  ],
  imports: [
    RouterModule.forRoot(AppRoutes),
    NgbModule,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    DesignAngularKitModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
