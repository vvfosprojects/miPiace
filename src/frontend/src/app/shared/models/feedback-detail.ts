export class FeedbackDetail {
    constructor(
        public readonly feedbackId: string,
        public readonly text: string,
        public readonly user: string,
        public readonly contacts: string
        ) {}
}
