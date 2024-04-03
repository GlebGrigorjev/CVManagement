import { Injectable } from '@angular/core';
import { CvData } from '../../Models/CvData.model';

@Injectable({
  providedIn: 'root'
})
export class FieldService {

  constructor() { }

  addEducationFields(data?: CvData) {
    data?.educations.push({
      school: '',
      faculty: '',
      degree: 0,
      graduationDate: '',
      city: ''
    });
  }

  addWorkExperienceFields(data?: CvData) {
    data?.workExperiences.push({
      employer: '',
      jobTitle: '',
      startDate: '',
      endDate: '',
      city: ''
    });
  }

  addLanguageFields(data?: CvData) {
    data?.languages.push({
      language: '',
      speaking: 0,
      listening: 0,
      writing: 0
    });
  }

  addSkillFields(data?: CvData) {
    data?.skills.push({
      skill: ''
    });
  }
  removeEducationFields(data?: CvData) {
    if (data?.educations && data?.educations.length > 1) {
      data?.educations.pop();
    }
  }

  removeWorkExperienceFields(data?: CvData) {
    if (data?.workExperiences && data?.workExperiences.length > 1) {
      data?.workExperiences.pop(); // Use optional chaining here
    }
  }

  removeLanguageFields(data?: CvData) {
    if (data?.languages && data?.languages.length > 1) {
      data?.languages.pop();
    }
  }
}
