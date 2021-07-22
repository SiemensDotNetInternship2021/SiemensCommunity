import { TestBed } from '@angular/core/testing';

import { BorrowedItemsServiceService } from './borrowed-items-service.service';

describe('BorrowedItemsServiceService', () => {
  let service: BorrowedItemsServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BorrowedItemsServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
