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
    //Cada que se muestra la página, se cargan los datos, siempre se están actualizando 
    this.cargardatos();
  }
  // Método para cargar los datos de cada registro de cada tabla, se manda llamar un servicio del tipo get
  cargardatos(){
    this.catalog.getCliente().subscribe(clienteslist=>{
      console.log(clienteslist)
      this.Clientes = clienteslist;
    })
  }
  //Método para eliminar algun registro dado su id, se manda llamar un servicio del tipo delete
  eliminar(id:number){
    this.catalog.deleteCliente(id).subscribe(d=>{
      this.cargardatos();
    })
  }
  //Método que abre el modal del cliente en donde se manda a llamar el modalcliente para agregar un nuevo cliente. 
  openmodal(): void {
    const dialogRef = this.dialog.open(ModalclienteComponent, {
      width: '300px',

    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.cargardatos();
    });
  }
  //Método que abre el modal de actualizar para cada cliente, se manda llamar un servicio del tipo put.  
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
