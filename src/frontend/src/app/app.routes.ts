import { Routes } from '@angular/router';
import { ThanksComponent } from './features/thanks/thanks.component';
import { PageNotFoundComponent } from './features/page-not-found/page-not-found.component';
import { SendRatingComponent } from './features/send-rating/send-rating.component';
import { SendFeedbackDetailComponent } from './features/send-feedback-detail/send-feedback-detail.component';
import { NoServiceSpecifiedComponent } from './features/no-service-specified/no-service-specified.component';

export const AppRoutes: Routes = [
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
