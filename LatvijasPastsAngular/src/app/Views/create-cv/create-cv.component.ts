import { Component, OnInit } from '@angular/core';
import { CvData } from '../../shared/Models/CvData.model';
import { NgForm } from '@angular/forms';
import { CvFacadeService } from '../../shared/Services/Facade/cv-facade.service';

@Component({
  selector: 'app-create-cv',
  templateUrl: './create-cv.component.html',
  styleUrls: ['./create-cv.component.css']
})
export class CreateCvComponent implements OnInit {

  cvData: CvData = new CvData()

  constructor(public cvFacadeService: CvFacadeService) { }

  ngOnInit(): void {
    this.cvFacadeService.initializeField(this.cvData);
  }

  onSubmit(form: NgForm) {
    this.cvFacadeService.createCv(form, this.cvData)
  }

  addEducation() {
    this.cvFacadeService.addEducation(this.cvData);
  }

  removeEducation() {
    this.cvFacadeService.removeEducation(this.cvData)
  }

  addWorkExperience() {
    this.cvFacadeService.addWorkExperience(this.cvData)
  }

  removeWorkExperience() {
    this.cvFacadeService.removeWorkExperience(this.cvData)
  }

  addLanguage() {
    this.cvFacadeService.addLanguage(this.cvData)
  }

  removeLanguage() {
    this.cvFacadeService.removeLanguage(this.cvData)
  }

  addSkill() {
    this.cvFacadeService.addSkill(this.cvData)
  }

  removeSkill() {
    this.cvFacadeService.removeSkill(this.cvData)
  }

  getDegreeString(value: number): string {
    return this.cvFacadeService.getDegreeString(value)
  }

  getCategoryString(value: number): string {
    return this.cvFacadeService.getCategoryString(value)
  }

  selectAvatar(avatarUrl: string) {
    return this.cvFacadeService.selectAvatar(avatarUrl, this.cvData)
  }

  selectBacground(backgroungUrl: string) {
    return this.cvFacadeService.selectBacground(backgroungUrl, this.cvData)
  }

  calculateAge(dateOfBirth: string): number {
    return this.cvFacadeService.calculateAge(dateOfBirth)
  }
}