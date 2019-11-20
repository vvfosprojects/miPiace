import { FeedbackI } from '../interfaces/feedback-i';
import { CriteriDiRicerca } from '../interfaces/criteri-di-ricerca';

export class AllFeedback {
  constructor(
    public readonly allFeedback: FeedbackI[],
    public readonly criteriDiRicerca: CriteriDiRicerca
  ) {}
}
