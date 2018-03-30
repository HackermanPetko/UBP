import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApiTestComponent } from './apitest.component';

describe('ApitestComponent', () => {
  let component: ApiTestComponent;
  let fixture: ComponentFixture<ApiTestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApiTestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApiTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
