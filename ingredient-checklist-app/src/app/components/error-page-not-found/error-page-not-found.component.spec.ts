import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ErrorPageNotFoundComponent } from './error-page-not-found.component';

describe('ErrorPageNotFoundComponent', () => {
  let component: ErrorPageNotFoundComponent;
  let fixture: ComponentFixture<ErrorPageNotFoundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ErrorPageNotFoundComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ErrorPageNotFoundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
