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

  getLogsByLevelAndEvent(logLevelId: number, logEventId: number){
    return this.http.get<ILog[]>(this.rootUrl + '/log/getLogsByLevelAndEvent?logLevelId='+ logLevelId+"&&logEventId=" + logEventId);
  }

  getLogsByLogEvent(logEventId: number){
    return this.http.get<ILog[]>(this.rootUrl + '/log/getByLogEvent?logEventId='+ logEventId);
  }

  getLogsByLogLevel(logLevelId: number){
    return this.http.get<ILog[]>(this.rootUrl + '/log/getByLogLevel?logLevelId='+ logLevelId);
  }
}
