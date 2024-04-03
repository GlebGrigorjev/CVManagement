import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CreateCvService {
  url = `${environment.apiBase}/create-new`;
  constructor(private http: HttpClient) { }

 createCv(form: any) {
  return this.http.put(`${this.url}`, form);
}
}
