import { Component, OnInit, ViewChild } from '@angular/core';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { ILog } from 'src/app/Models/ILog';
import { ILogEvent } from 'src/app/Models/ILogEvent';
import { ILogLevel } from 'src/app/Models/ILogLevel';
import { LogEventService } from 'src/app/Services/log-event-service/log-event.service';
import { LogLevelService } from 'src/app/Services/log-level-service/log-level.service';
import { LogsService } from 'src/app/Services/logs-service/logs.service';

@Component({
  selector: 'app-logs-page',
  templateUrl: './logs-page.component.html',
  styleUrls: ['./logs-page.component.css']
})
export class LogsPageComponent implements OnInit {

  public logs: ILog[] = [];

  logEvents: ILogEvent[] = [];
  logLevels: ILogLevel[] = [];
  mySelectedLogEvent: number = 0;
  mySelectedLogLevel: number = 0;

  constructor(private logService: LogsService,
    private logEventService: LogEventService,
    private logLevelService: LogLevelService) {
  }

  ngOnInit(): void {
    this.getAllLogs();
    this.getLogEvents();
    this.getLogLevels();
  }

  getAllLogs() {
    this.logService.getAllLogs().subscribe((logs) => {
      this.logs = logs;
    });
  }


  getLogEvents() {
    this.logEventService.getLogEvents().subscribe(logEvents => {
      this.logEvents = [];
      logEvents.forEach(logEvent => this.logEvents.push(logEvent))
    });
  }


  getLogLevels() {
    this.logLevelService.getLogLevels().subscribe(logLevels => {
      this.logLevels = [];
      logLevels.forEach(logLevel => this.logLevels.push(logLevel))
      console.log(this.logLevels);
    });
  }
  getElements() {
    if (this.mySelectedLogEvent != 0 && this.mySelectedLogLevel != 0) {
      this.logService.getLogsByLevelAndEvent(this.mySelectedLogLevel, this.mySelectedLogEvent).subscribe(logs => {
        this.logs = [];
        logs.forEach(log => this.logs.push(log))
      });
    } else if (this.mySelectedLogEvent != 0 && this.mySelectedLogLevel == 0) {
      this.logService.getLogsByLogEvent(this.mySelectedLogEvent).subscribe(logs => {
        this.logs = [];
        logs.forEach(log => this.logs.push(log))
      });
    } else if (this.mySelectedLogEvent == 0 && this.mySelectedLogLevel != 0) {
      this.logService.getLogsByLogLevel(this.mySelectedLogLevel).subscribe(logs => {
        this.logs = [];
        logs.forEach(log => this.logs.push(log))
      });
    } else {
      this.logService.getAllLogs().subscribe(logs => {
        this.logs = [];
        logs.forEach(log => this.logs.push(log))
      });
    }
  }

}
