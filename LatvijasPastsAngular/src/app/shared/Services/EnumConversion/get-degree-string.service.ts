import { Injectable } from '@angular/core';
import { Degrees } from '../../Models/Enums/Degrees';

@Injectable({
  providedIn: 'root'
})
export class GetDegreeStringService {
  degrees: Degrees[] = [
    Degrees.AssociateDegree,
    Degrees.BachelorsDegree,
    Degrees.MastersDegree,
    Degrees.DoctoralDegree,
    Degrees.HighSchool
  ];
  
  constructor() { }

  getDegreeString(value: number): string {
    switch (value) {
      case Degrees.AssociateDegree:
        return 'Associate Degree';
      case Degrees.BachelorsDegree:
        return 'Bachelors Degree';
      case Degrees.MastersDegree:
        return 'Masters Degree';
      case Degrees.DoctoralDegree:
        return 'Doctoral Degree';
      case Degrees.HighSchool:
        return 'High School';
      default:
        return '';
    }
  }
}
