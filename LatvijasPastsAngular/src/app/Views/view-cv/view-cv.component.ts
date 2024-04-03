import { Component, OnInit } from '@angular/core';
import { GetCvByIdService } from '../../shared/Services/get-cv-by-id.service';
import { ActivatedRoute } from '@angular/router';
import { CvData } from '../../shared/Models/CvData.model';
import { CvFacadeService } from '../../shared/Services/Facade/cv-facade.service';

@Component({
  selector: 'app-view-cv',
  templateUrl: './view-cv.component.html',
  styleUrls : ['./view-cv.component.css']
})
export class ViewCvComponent implements OnInit {
  id: any
  cvData: CvData = new CvData();

  constructor(
    private route: ActivatedRoute,
    public getService: GetCvByIdService,
    public cvFacade: CvFacadeService
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    console.log(this.id);
    
    this.getService.getCvById(this.id).subscribe({
      next: (response) => {
        this.cvData = response;
      },
      error: (error) => {
        console.error('Error fetching CV data:', error);
      }
    });
  }

  getDegreeString(value: number): string {
    return this.cvFacade.getDegreeString(value)
  }

  getCategoryString(value: number): string {
    return this.cvFacade.getCategoryString(value)
  }

  selectAvatar(avatarUrl: string) {
    this.cvFacade.selectAvatar(avatarUrl, this.cvData)
  }
}
