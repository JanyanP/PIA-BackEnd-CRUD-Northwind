import { Component, OnInit,ViewChild } from '@angular/core';
import { Cliente,CatalogsService} from '../services/catalog.service';
import { MatTable } from '@angular/material/table';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {ModalclienteComponent} from '../modalcliente/modalcliente.component';
import { ModalupdateclienteComponent } from './../modalupdatecliente/modalupdatecliente.component';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {
  Clientes : Cliente [] = [];
  columnas: string[] = ['idString', 'name', 'cityName','phoneNumber','delete', 'update'];
  @ViewChild(MatTable) tabla1: MatTable<Cliente>| undefined
  constructor(public catalog : CatalogsService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.cargardatos();
  }

  cargardatos(){
    this.catalog.getCliente().subscribe(clienteslist=>{
      console.log(clienteslist)
      this.Clientes = clienteslist;
    })
  }

  eliminar(id:number){
    this.catalog.deleteCliente(id).subscribe(d=>{
      this.cargardatos();
    })
  }
  openmodal(): void {
    const dialogRef = this.dialog.open(ModalclienteComponent, {
      width: '300px',

    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.cargardatos();
    });
  }

  openmodalEditar(cliente: Cliente): void {
    const dialogRef = this.dialog.open(ModalupdateclienteComponent, {
      width: '300px',
    });
    dialogRef.componentInstance.cliente = cliente;
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.cargardatos();
    });
  }
}
