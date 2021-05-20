import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalclienteComponent } from './modalcliente.component';

describe('ModalclienteComponent', () => {
  let component: ModalclienteComponent;
  let fixture: ComponentFixture<ModalclienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalclienteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalclienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
