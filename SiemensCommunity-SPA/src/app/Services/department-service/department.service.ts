import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IDepartment } from 'src/app/Models/IDepartment';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(private http: HttpClient) { }

  getDepartments() {
    return this.http.get<IDepartment>(this.rootUrl + '/Department/get')
  }
}
