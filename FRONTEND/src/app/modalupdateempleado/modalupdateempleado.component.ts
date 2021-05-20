import { Empleado } from './../services/catalog.service';
import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { FormBuilder, FormGroup ,Validators} from '@angular/forms';
import { CatalogsService} from '../services/catalog.service';

@Component({
  selector: 'app-modalupdateempleado',
  templateUrl: './modalupdateempleado.component.html',
  styleUrls: ['./modalupdateempleado.component.scss']
})
export class ModalupdateempleadoComponent implements OnInit {
  empleado: Empleado = {} as Empleado;
  form: FormGroup;
  constructor(public dialogRef: MatDialogRef<ModalupdateempleadoComponent>,
    public formBuilder: FormBuilder , public catalog: CatalogsService) {
      this.form = formBuilder.group({
        idNumber :[0,Validators.compose([Validators.required])],
        name: ['',Validators.compose([Validators.required])],
        familyName: ['',Validators.compose([Validators.required])]

      })
    }

  editarEmpleado(){
    const empleadoform = this.empleado;
      console.log(empleadoform)
      this.catalog.updateEmpleado(empleadoform).subscribe((empleado)=>{
        this.cancelar();
      })
  }
  cancelar(): void {
    this.dialogRef.close();
  }
  ngOnInit(): void {
  }

}
