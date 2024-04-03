import { Injectable } from '@angular/core';
import { FieldService } from '../InputFields/field.service';
import { CreateCvService } from '../create-cv.service';
import { Router } from '@angular/router';
import { GetDegreeStringService } from '../EnumConversion/get-degree-string.service';
import { GetCategoryStringService } from '../EnumConversion/get-category-string.service';
import { AvatarSelectorService } from '../Media/avatar-selector.service';
import { BackgroundSelectorServiceService } from '../Media/background-selector-service.service';
import { InitializeModelService } from '../InputFields/initialize-model.service';
import { CalculateAgeService } from '../Calculations/calculate-age.service';
import { CvData } from '../../Models/CvData.model';
import { NgForm } from '@angular/forms';
import { GetCvListService } from '../get-cv-list-service';
import { Observable } from 'rxjs';
import { DeleteCvService } from '../delete-cv.service';
import { GetCvByIdService } from '../get-cv-by-id.service';
import { EditCvDataService } from '../edit-cv-data.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class CvFacadeService {
  cvData: CvData = new CvData();
  formSubmitted: boolean = false;

  constructor(
    private fieldService: FieldService,
    public createCvService: CreateCvService,
    private router: Router,
    public degreeEnumService: GetDegreeStringService,
    public categoryEnumService: GetCategoryStringService,
    public avatarService: AvatarSelectorService,
    public backgroundService: BackgroundSelectorServiceService,
    private cvInitialize: InitializeModelService,
    private ageCalculationService: CalculateAgeService,
    public getCvListService: GetCvListService,
    public deleteCvService: DeleteCvService,
    public getService: GetCvByIdService,
    private editService: EditCvDataService,
    private toastr: ToastrService
  ) { }

  initializeField(cvData: CvData): void {
    this.cvInitialize.initializeCvData(cvData)
    this.formSubmitted = false
  }

  getCvList(): void {
    this.getCvListService.getCVList();
  }

  createCv(form: NgForm, cvData: CvData): void {
    this.formSubmitted = true
    if (form.valid) {
      this.createCvService.createCv(cvData).subscribe({
        next: res => {
          this.router.navigate(['/']);
          this.toastr.success('Created Successefully')
        },
        error: err => {
          console.log('Error editing CV:', err);
          this.toastr.error(err.error, 'Error creating CV')
        }
      });
    }
  }

  populateForm(selectedRecord: CvData): void {
    this.getCvListService.list[0] = Object.assign({}, selectedRecord)
  }

  deleteCv(id: number): Observable<void> {
    return this.deleteCvService.deleteCv(id);
  }

  editCv(id: any, cvData: CvData, form: NgForm): void {
    if (form.valid) {
      this.editService.editCv(id, cvData).subscribe({
        next: res => {
          this.router.navigate(['/']);
          this.toastr.success('CV Edited Successefully')
        },
        error: err => {
          this.toastr.error(err.error, 'Error editing CV')
        }
      });
    }
    this.formSubmitted = true
  }

  addEducation(cvData: CvData) {
    this.fieldService.addEducationFields(cvData);
  }

  removeEducation(cvData: CvData) {
    this.fieldService.removeEducationFields(cvData)
  }

  addWorkExperience(cvData: CvData) {
    this.fieldService.addWorkExperienceFields(cvData)
  }

  removeWorkExperience(cvData: CvData) {
    this.fieldService.removeWorkExperienceFields(cvData)
  }

  addLanguage(cvData: CvData) {
    this.fieldService.addLanguageFields(cvData)
  }

  removeLanguage(cvData: CvData) {
    this.fieldService.removeLanguageFields(cvData)
  }

  addSkill(cvData: CvData) {
    this.fieldService.addSkillFields(cvData)
  }

  removeSkill(cvData: CvData) {
    cvData?.skills.pop();
  }

  getDegreeString(value: number): string {
    return this.degreeEnumService.getDegreeString(value)
  }

  getCategoryString(value: number): string {
    return this.categoryEnumService.getCategoryString(value)
  }

  calculateAge(dateOfBirth: string): number {
    return this.ageCalculationService.calculateAge(dateOfBirth) 
  }

  selectAvatar(avatarUrl: string, cvData: CvData) {
    this.avatarService.selectedAvatarUrl = avatarUrl;
    cvData.avatarUrl = avatarUrl;
  }

  getSelectedAvatar(): Observable<string> {
    return this.avatarService.selectedAvatar$;
  }
  
  selectBacground(backgroungUrl: string, cvData: CvData) {
    this.backgroundService.selectedBackgroundUrl = backgroungUrl;
    cvData.colourUrl = backgroungUrl;
  }

  getSelectedBackground(): Observable<string> {
    return this.backgroundService.selectedBackground$;
  }
  
}
