export class Service {
  constructor(
    public readonly id: string,
    public readonly publicToken: string,
    public readonly privateToken: string,
    public readonly welcomeMessage: string
  ) {
  }
}
