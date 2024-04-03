import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DeleteCvService {
  url = `${environment.apiBase}/delete-cv`;
  
  constructor(
    private http: HttpClient
    ) { }

    deleteCv(id:number): Observable<any> {
      return this.http.delete(`${this.url}/${id}`);
    }
}
