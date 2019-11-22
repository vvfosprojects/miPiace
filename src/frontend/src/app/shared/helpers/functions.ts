export function refreshAverageDesc(averageDesc: string): string {
  const descriptions: [string, string][] = [
    ['averageScoreFeedbacksLastHour', 'Ultima ora'],
    ['averageScoreFeedbacksLastDay', 'Oggi'],
    ['averageScoreFeedbacksLastWeek', 'Settimana'],
    ['averageScoreFeedbacksLastMonth', 'Mese'],
    ['averageScoreFeedbacksLastYear', 'Anno'],
    ['averageScoreFeedbacksAllTime', 'Da sempre']
  ];
  const mapDescriptions: Map<string, string> = new Map(descriptions);

  return mapDescriptions.get(averageDesc);
}

export function refreshVotoDesc(votoDesc: string): string {
  const descriptions: [string, string][] = [
    ['good', 'Ottimo'],
    ['fair', 'Mediocre'],
    ['poor', 'Pessimo']
  ];
  const mapDescriptions: Map<string, string> = new Map(descriptions);

  return mapDescriptions.get(votoDesc);
}
