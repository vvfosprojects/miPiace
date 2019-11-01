import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ThanksComponent } from './thanks/thanks.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { appRoutes } from './routes';
import { SendRatingComponent } from './send-rating/send-rating.component';
import { SendFeedbackDetailComponent } from './send-feedback-detail/send-feedback-detail.component';
import { NoServiceSpecifiedComponent } from './no-service-specified/no-service-specified.component';

@NgModule({
  declarations: [
    AppComponent,
    ThanksComponent,
    PageNotFoundComponent,
    SendRatingComponent,
    SendFeedbackDetailComponent,
    NoServiceSpecifiedComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    NgbModule,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
