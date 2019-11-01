import { Routes } from '@angular/router';
import { ThanksComponent } from './thanks/thanks.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { SendRatingComponent } from './send-rating/send-rating.component';
import { SendFeedbackDetailComponent } from './send-feedback-detail/send-feedback-detail.component';
import { NoServiceSpecifiedComponent } from './no-service-specified/no-service-specified.component';

export const appRoutes: Routes = [
    { path: 'thanks', component: ThanksComponent },
    { path: 'sendRating/:id', component: SendRatingComponent },
    { path: 'sendFeedbackDetail', component: SendFeedbackDetailComponent },
    { path: ':id',
      redirectTo: '/sendRating/:id',
      pathMatch: 'full'
    },
    { path: '', component: NoServiceSpecifiedComponent },
    { path: '**', component: PageNotFoundComponent }
  ];