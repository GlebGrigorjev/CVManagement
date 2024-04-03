import { Injectable } from '@angular/core';
import { CvData } from '../../Models/CvData.model';
import { CurrentAddress } from '../../Models/currentAddress';
import { Education } from '../../Models/educations';
import { WorkExperience } from '../../Models/workExperience';
import { Language } from '../../Models/language';
import { Skill } from '../../Models/skill';

@Injectable({
  providedIn: 'root'
})
export class InitializeModelService {
cvData: CvData = new CvData()

  constructor() { }

  initializeCvData(cvData: CvData): void {
    cvData.name = '';
    cvData.surname = '';
    cvData.phoneNumber = '';
    cvData.eMail = '';
    cvData.dateOfBirth = '';
    cvData.avatarUrl = '';
    cvData.colourUrl = ''; 
    cvData.currentAddress = new CurrentAddress();
    cvData.currentAddress.country = '';
    cvData.currentAddress.city = '';
    cvData.currentAddress.postalIndex = '';
    cvData.currentAddress.street = '';
    cvData.educations = [new Education()];
    cvData.workExperiences = [new WorkExperience()];
    cvData.languages = [new Language()];
    cvData.skills = [new Skill()];
  }
}
