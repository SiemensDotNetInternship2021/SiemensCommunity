import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILog } from 'src/app/Models/ILog';

@Injectable({
  providedIn: 'root'
})
export class LogsService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(private http: HttpClient) { }

  getAllLogs() {
    return this.http.get<ILog[]>(this.rootUrl + '/log/get');
  }

}
