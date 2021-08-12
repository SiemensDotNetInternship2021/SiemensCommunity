import { TestBed } from '@angular/core/testing';

import { LogEventService } from './log-event.service';

describe('LogEventService', () => {
  let service: LogEventService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LogEventService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
