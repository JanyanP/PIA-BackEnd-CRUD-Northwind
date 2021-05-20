import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalupdateclienteComponent } from './modalupdatecliente.component';

describe('ModalupdateclienteComponent', () => {
  let component: ModalupdateclienteComponent;
  let fixture: ComponentFixture<ModalupdateclienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalupdateclienteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalupdateclienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
