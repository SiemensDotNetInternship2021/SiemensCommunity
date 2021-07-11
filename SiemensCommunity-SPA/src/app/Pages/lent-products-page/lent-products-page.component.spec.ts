import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LentProductsPageComponent } from './lent-products-page.component';

describe('LentProductsPageComponent', () => {
  let component: LentProductsPageComponent;
  let fixture: ComponentFixture<LentProductsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LentProductsPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LentProductsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
