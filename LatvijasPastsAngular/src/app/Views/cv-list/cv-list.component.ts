import { Component, OnInit } from '@angular/core';
import { CvData } from '../../shared/Models/CvData.model';
import { CvFacadeService } from '../../shared/Services/Facade/cv-facade.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cv-list',
  templateUrl: './cv-list.component.html',
  styleUrls : ['./cv-list.component.css']
})
export class CvListComponent implements OnInit {
  selectedAvatar: string = '';
  selectedBackground: string = '';

  constructor(public cvFacade: CvFacadeService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.cvFacade.getCvList();
    this.cvFacade.getSelectedAvatar().subscribe(avatarUrl => {
      this.selectedAvatar = avatarUrl;
    });
    this.cvFacade.getSelectedBackground().subscribe(backgroundUrl => {
      this.selectedBackground = backgroundUrl;
    });
  }

  populateForm(selectedRecord: CvData) {
    this.cvFacade.populateForm(selectedRecord);
  }

  deleteCv(id: number) {
    if(confirm('Are you sure you want to delete this CV?')) {
    this.cvFacade.deleteCv(id)
      .subscribe(() => {
        this.cvFacade.getCvList();
        this.toastr.error('CV Deleted')
      });
    }
  }
}
