import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMarkedCaseComponent } from './add-marked-case.component';

describe('AddMarkedCaseComponent', () => {
  let component: AddMarkedCaseComponent;
  let fixture: ComponentFixture<AddMarkedCaseComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddMarkedCaseComponent]
    });
    fixture = TestBed.createComponent(AddMarkedCaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
