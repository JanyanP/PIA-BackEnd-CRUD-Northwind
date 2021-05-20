import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalupdateproductoComponent } from './modalupdateproducto.component';

describe('ModalupdateproductoComponent', () => {
  let component: ModalupdateproductoComponent;
  let fixture: ComponentFixture<ModalupdateproductoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalupdateproductoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalupdateproductoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
