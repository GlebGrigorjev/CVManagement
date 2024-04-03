import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalculateAgeService {

  constructor() { }

  calculateAge(dateOfBirth: string): number {
    if (!dateOfBirth) return 0;

    const dob = new Date(dateOfBirth);
    const diff = Date.now() - dob.getTime();
    const ageDate = new Date(diff);
  
    const calculatedAge = Math.abs(ageDate.getUTCFullYear() - 1970);
  
    return calculatedAge;
    
  }
}
