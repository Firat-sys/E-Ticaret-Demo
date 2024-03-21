import { ComponentFixture, TestBed } from '@angular/core/testing';

import { listcomponent } from './list.component';

describe('listcomponent', () => {
  let component: listcomponent;
  let fixture: ComponentFixture<listcomponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [listcomponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(listcomponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
