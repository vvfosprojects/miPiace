export function refreshAverageDesc(averageDesc: string): string {
  const descriptions: [string, string][] = [
    ['averageScoreFeedbacksLastHour', 'Ora'],
    ['averageScoreFeedbacksLastDay', 'Giorno'],
    ['averageScoreFeedbacksLastWeek', 'Settimana'],
    ['averageScoreFeedbacksLastMonth', 'Mese'],
    ['averageScoreFeedbacksLastYear', 'Anno'],
    ['averageScoreFeedbacksAllTime', 'Da sempre']
  ];
  const mapDescriptions: Map<string, string> = new Map(descriptions);

  return mapDescriptions.get(averageDesc);
}
