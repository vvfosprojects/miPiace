import { Rating, RatingIt } from '../enums/rating.enum';

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
  const descriptions: [string, RatingIt][] = [
    ['good', RatingIt.Good],
    ['fair', RatingIt.Fair],
    ['poor', RatingIt.Poor]
  ];
  const mapDescriptions: Map<string, string> = new Map(descriptions);

  return mapDescriptions.get(votoDesc.toLocaleLowerCase());
}

export function stringToRating(rating: string): Rating {
  const descriptions: [RatingIt, Rating][] = [
    [RatingIt.Good, Rating.Good],
    [RatingIt.Fair, Rating.Fair],
    [RatingIt.Poor, Rating.Poor]
  ];
  const mapDescriptions: Map<string, Rating> = new Map(descriptions);

  return mapDescriptions.get(rating);
}

export function stringToRatingIt(rating: string): RatingIt {
  const descriptions: [string, RatingIt][] = [
    ['ottimo', RatingIt.Good],
    ['mediocre', RatingIt.Fair],
    ['pessimo', RatingIt.Poor]
  ];
  const mapDescriptions: Map<string, RatingIt> = new Map(descriptions);

  return mapDescriptions.get(rating.toLocaleLowerCase());
}
