import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalempleadoComponent } from './modalempleado.component';

describe('ModalempleadoComponent', () => {
  let component: ModalempleadoComponent;
  let fixture: ComponentFixture<ModalempleadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalempleadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalempleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
