import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { environment } from '../../../environments/environment.development';
import { CvData } from '../Models/CvData.model';

@Injectable({
  providedIn: 'root'
})
export class GetCvListService {

  url:string = environment.apiBase + '/get-list'
  list:CvData[]=[]

  constructor(private http: HttpClient) { }

  getCVList() {
  this.http.get<CvData[]>(this.url)
  .subscribe({
    next: res => {
      this.list = res; 
    },
    error: err => {
      console.log(err);      
    }
  });
}

}
