import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalupdateempleadoComponent } from './modalupdateempleado.component';

describe('ModalupdateempleadoComponent', () => {
  let component: ModalupdateempleadoComponent;
  let fixture: ComponentFixture<ModalupdateempleadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalupdateempleadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalupdateempleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
