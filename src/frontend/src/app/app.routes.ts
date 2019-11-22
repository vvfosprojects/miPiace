import { Routes } from '@angular/router';
import { ThanksComponent } from './features/thanks/thanks.component';
import { PageNotFoundComponent } from './features/page-not-found/page-not-found.component';
import { SendRatingComponent } from './features/send-rating/send-rating.component';
import { SendFeedbackDetailComponent } from './features/send-feedback-detail/send-feedback-detail.component';
import { NoServiceSpecifiedComponent } from './features/no-service-specified/no-service-specified.component';
import { CreateServiceComponent } from './features/create-service/create-service.component';
import { StatisticsComponent } from './features/statistics/statistics.component';
import { SearchStatisticsComponent } from './shared/components/search-statistics/search-statistics.component';
import { TrustedTokenComponent } from './features/trusted-token/trusted-token.component';

export const AppRoutes: Routes = [
  { path: 'thanks', component: ThanksComponent },
  { path: 'sendRating', component: NoServiceSpecifiedComponent },
  { path: 'sendRating/:id', component: SendRatingComponent },
  { path: 'statistics', component: SearchStatisticsComponent },
  { path: 'statistics/:id', component: StatisticsComponent },
  { path: 'sendFeedbackDetail', component: SendFeedbackDetailComponent },
  { path: 'trusted', component: NoServiceSpecifiedComponent },
  { path: 'trusted/:id', component: TrustedTokenComponent },
  { path: 'createService', component: CreateServiceComponent },
  {
    path: ':id',
    redirectTo: '/trusted/:id',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent }
];
