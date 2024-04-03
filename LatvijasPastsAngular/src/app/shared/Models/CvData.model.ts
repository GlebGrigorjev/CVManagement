import { CurrentAddress } from "./currentAddress";
import { Education } from "./educations";
import { Language } from "./language";
import { Skill } from "./skill";
import { WorkExperience } from "./workExperience";

export class CvData { 
    id: number = 0;
    name: string = '';
    surname: string = '';
    phoneNumber: string = '';
    eMail: string = '';
    dateOfBirth: string = '';
    avatarUrl: string = '';
    colourUrl: string ='';
    currentAddress: CurrentAddress = new CurrentAddress();
    educations: Education[] = [];
    workExperiences: WorkExperience[] = [];
    languages: Language[] = [];
    skills: Skill[] = [];
}
