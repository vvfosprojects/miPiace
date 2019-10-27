import { Routes } from '@angular/router';
import { ThanksComponent } from './thanks/thanks.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { SendRatingComponent } from './send-rating/send-rating.component';
import { SendFeedbackDetailComponent } from './send-feedback-detail/send-feedback-detail.component';

export const appRoutes: Routes = [
    { path: 'thanks', component: ThanksComponent },
    { path: 'sendRating', component: SendRatingComponent },
    { path: 'sendFeedbackDetail', component: SendFeedbackDetailComponent },
    { path: '',
      redirectTo: '/sendRating',
      pathMatch: 'full'
    },
    { path: '**', component: PageNotFoundComponent }
  ];