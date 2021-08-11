import { Component, OnInit, ViewChild } from '@angular/core';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { ILog } from 'src/app/Models/ILog';
import { LogsService } from 'src/app/Services/logs-service/logs.service';

@Component({
  selector: 'app-logs-page',
  templateUrl: './logs-page.component.html',
  styleUrls: ['./logs-page.component.css']
})
export class LogsPageComponent implements OnInit {

  public rows: ILog[] = [];
  constructor(private logService: LogsService) {
   }

  ngOnInit(): void {
    this.getAllLogs();
  }

  getAllLogs(){
    this.logService.getAllLogs().subscribe((logs) => {
      this.rows= logs;
    });
  }

}
