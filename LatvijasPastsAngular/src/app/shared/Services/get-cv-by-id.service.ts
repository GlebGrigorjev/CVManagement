import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { CvData } from '../Models/CvData.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetCvByIdService {
  list:CvData[]=[]
  formSubmitted: boolean = false;

  constructor(private http: HttpClient) { }

  getCvById(id: number): Observable<any> { 
    const url = `${environment.apiBase}/get-cv/${id}`;    
    return this.http.get<any>(url); 
  }
}
