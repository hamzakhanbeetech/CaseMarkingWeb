import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourtsComponent } from './courts.component';

describe('CourtsComponent', () => {
  let component: CourtsComponent;
  let fixture: ComponentFixture<CourtsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CourtsComponent]
    });
    fixture = TestBed.createComponent(CourtsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
