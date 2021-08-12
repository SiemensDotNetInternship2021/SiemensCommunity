import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILogLevel } from 'src/app/Models/ILogLevel';

@Injectable({
  providedIn: 'root'
})
export class LogLevelService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(private httpClient: HttpClient) { }

  getLogLevels(){
    return this.httpClient.get<ILogLevel[]>(this.rootUrl + '/loglevel/get')
  }

}
