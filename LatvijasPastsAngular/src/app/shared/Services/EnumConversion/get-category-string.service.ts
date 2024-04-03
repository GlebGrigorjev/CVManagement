import { Injectable } from '@angular/core';
import { Categories } from '../../Models/Enums/CategoryEnum';

@Injectable({
  providedIn: 'root'
})
export class GetCategoryStringService {
  categories: Categories[] = [
    Categories.A1,
    Categories.A2,
    Categories.B1,
    Categories.B2,
    Categories.C1,
    Categories.C2,
    Categories.NativeLanguage
  ]
  constructor() { }

  getCategoryString(value: number): string {
    switch (value) {
      case Categories.A1:
        return 'A1';
      case Categories.A2:
        return 'A2';
      case Categories.B1:
        return 'B1';
      case Categories.B2:
        return 'B2';
      case Categories.C1:
        return 'C1';
      case Categories.C2:
        return 'C2';
      case Categories.NativeLanguage:
        return 'Native User';
      default:
        return '';
    }
  }
}
