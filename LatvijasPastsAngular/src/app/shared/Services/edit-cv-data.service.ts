import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EditCvDataService {
 url = `${environment.apiBase}/edit-cv`;

  constructor(private http: HttpClient) { }

 editCv(id: number, form: any) {
  return this.http.put(`${this.url}/${id}`, form);
}

}
