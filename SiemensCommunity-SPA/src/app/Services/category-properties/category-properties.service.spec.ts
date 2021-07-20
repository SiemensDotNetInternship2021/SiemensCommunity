import { TestBed } from '@angular/core/testing';

import { CategoryPropertiesService } from './category-properties.service';

describe('CategoryPropertiesService', () => {
  let service: CategoryPropertiesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoryPropertiesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
