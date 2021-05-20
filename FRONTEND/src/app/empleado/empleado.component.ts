import { Component, OnInit , ViewChild} from '@angular/core';
import { Empleado,CatalogsService} from '../services/catalog.service';
import { MatTable } from '@angular/material/table';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {ModalempleadoComponent} from '../modalempleado/modalempleado.component'
import { ModalupdateempleadoComponent } from '../modalupdateempleado/modalupdateempleado.component';
@Component({
  selector: 'app-empleado',
  templateUrl: './empleado.component.html',
  styleUrls: ['./empleado.component.scss']
})
export class EmpleadoComponent implements OnInit {

  columnas: string[] = ['idNumber', 'name', 'familyName','delete', 'update'];
  Empleados : Empleado [] = [];
  @ViewChild(MatTable) tabla1: MatTable<Empleado>| undefined
  constructor(public catalog: CatalogsService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.cargardatos();
  }

  cargardatos(){
    this.catalog.getEmpleados().subscribe(empleadoslist =>{
      console.log(empleadoslist)
      this.Empleados =empleadoslist;
    })
  }
  eliminar(id:number){
    this.catalog.deleteEmpleado(id).subscribe(d =>{
      this.cargardatos();

    })
  }

  openmodal(): void {
    const dialogRef = this.dialog.open(ModalempleadoComponent, {
      width: '300px',

    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.cargardatos();
    });
  }

  openmodalEditar(empleado: Empleado): void {
    const dialogRef = this.dialog.open(ModalupdateempleadoComponent, {
      width: '300px',
    });
    dialogRef.componentInstance.empleado = empleado;
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.cargardatos();
    });
  }




}
