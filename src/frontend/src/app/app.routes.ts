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
import { Path } from './shared/enums/path.enum';

export const AppRoutes: Routes = [
  { path: Path.Thanks, component: ThanksComponent },
  { path: Path.SendRating, component: NoServiceSpecifiedComponent },
  { path: Path.SendRating + '/:id', component: SendRatingComponent },
  { path: Path.Statistics, component: SearchStatisticsComponent },
  { path: Path.Statistics + '/:id', component: StatisticsComponent },
  { path: Path.SendFeedbackDetail, component: SendFeedbackDetailComponent },
  { path: Path.Trusted, component: NoServiceSpecifiedComponent },
  { path: Path.Trusted + '/:id', component: TrustedTokenComponent },
  { path: Path.CreateService, component: CreateServiceComponent },
  { path: Path.NotFound, component: PageNotFoundComponent },
  {
    path: ':id',
    redirectTo: Path.Trusted + '/:id',
    pathMatch: 'full'
  },
  { path: '', component: NoServiceSpecifiedComponent },
  { path: '**', redirectTo: Path.NotFound }
];
