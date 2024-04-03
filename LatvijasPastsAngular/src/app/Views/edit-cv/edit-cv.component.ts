import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CvData } from '../../shared/Models/CvData.model';
import { NgForm } from '@angular/forms';
import { CvFacadeService } from '../../shared/Services/Facade/cv-facade.service';
import { GetCvByIdService } from '../../shared/Services/get-cv-by-id.service';

@Component({
  selector: 'app-edit-cv',
  templateUrl: './edit-cv.component.html',
  styleUrls : ['./edit-cv.component.css']
})

export class EditCvComponent implements OnInit {
  id: any;
  cvData: CvData = new CvData();
  error: any
  constructor(
    private route: ActivatedRoute,
    public cvFacade: CvFacadeService,
    public getService: GetCvByIdService,
    ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.getService.getCvById(this.id).subscribe({
      next: (response) => {
         this.cvData = response;
      },
      error: (error) => {
        console.error('Error fetching CV data:', error);
        this.error = error;
      }
    });   
  }

  onSubmit(form: NgForm) {
    this.cvFacade.editCv(this.id, this.cvData, form);
  }

  addEducation() {
    this.cvFacade.addEducation(this.cvData);
  }

  removeEducation() {
    this.cvFacade.removeEducation(this.cvData)
  }

  addWorkExperience() {
    this.cvFacade.addWorkExperience(this.cvData)
  }

  removeWorkExperience() {
    this.cvFacade.removeWorkExperience(this.cvData)
  }

  addLanguage() {
    this.cvFacade.addLanguage(this.cvData)
  }

  removeLanguage() {
    this.cvFacade.removeLanguage(this.cvData)
  }

  addSkill() {
    this.cvFacade.addSkill(this.cvData)
  }

  removeSkill() {
    this.cvFacade.removeSkill(this.cvData);
  }

  getDegreeString(value: number): string {
    return  this.cvFacade.getDegreeString(value)
  }

  getCategoryString(value: number): string {
    return  this.cvFacade.getCategoryString(value)
  }

  selectAvatar(avatarUrl: string) {
    this.cvFacade.selectAvatar(avatarUrl, this.cvData);
  }
  
  selectBackground(backgroungUrl: string) {
    this.cvFacade.selectBacground(backgroungUrl, this.cvData)
  }

  calculateAge(dateOfBirth: string): number {
    return this.cvFacade.calculateAge(dateOfBirth); 
  }
}