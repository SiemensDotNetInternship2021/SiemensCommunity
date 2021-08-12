import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILogEvent } from 'src/app/Models/ILogEvent';

@Injectable({
  providedIn: 'root'
})
export class LogEventService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(private httpClient: HttpClient) { }

  getLogEvents(){
    return this.httpClient.get<ILogEvent[]>(this.rootUrl + '/logevent/get')
  }

}
