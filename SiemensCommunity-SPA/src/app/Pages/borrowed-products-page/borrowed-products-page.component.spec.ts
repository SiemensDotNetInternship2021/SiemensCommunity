import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BorrowedProductsPageComponent } from './borrowed-products-page.component';

describe('BorrowedProductsPageComponent', () => {
  let component: BorrowedProductsPageComponent;
  let fixture: ComponentFixture<BorrowedProductsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BorrowedProductsPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BorrowedProductsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
