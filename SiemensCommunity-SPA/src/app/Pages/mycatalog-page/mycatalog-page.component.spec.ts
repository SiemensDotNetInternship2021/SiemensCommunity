import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MycatalogPageComponent } from './mycatalog-page.component';

describe('MycatalogPageComponent', () => {
  let component: MycatalogPageComponent;
  let fixture: ComponentFixture<MycatalogPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MycatalogPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MycatalogPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
