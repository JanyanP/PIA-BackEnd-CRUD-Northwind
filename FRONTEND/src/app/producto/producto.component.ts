import { Component, OnInit , ViewChild} from '@angular/core';
import { Producto,CatalogsService} from '../services/catalog.service';
import { MatTable } from '@angular/material/table';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import{ModalproductoComponent} from '../modalproducto/modalproducto.component'
import { ModalupdateproductoComponent } from '../modalupdateproducto/modalupdateproducto.component';


@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.scss']
})
export class ProductoComponent implements OnInit {
  columnas: string[] = ['idNumber', 'name', 'price','stock','delete', 'update'];
  Productos : Producto [] = [];
  @ViewChild(MatTable) tabla1: MatTable<Producto>| undefined
  constructor(public catalog:CatalogsService, public dialog: MatDialog)
  {

  }

  ngOnInit(): void {
    //Cada que se muestra la página, se cargan los datos, siempre se están actualizando 
    this.cargardatos();
  }
 // Método para cargar los datos de cada registro de cada tabla, se manda llamar un servicio del tipo get
  cargardatos(){
    this.catalog.getProducto().subscribe(productoslist=>{
      console.log(productoslist);
      this.Productos= productoslist;
    })
  }
  //Método para eliminar algun registro dado su id, se manda llamar un servicio del tipo delete
  eliminar(id:number){
    this.catalog.deleteproducto(id).subscribe(d =>{
      this.cargardatos();

    })
  }
  //Método que abre el modal del producto en donde se manda a llamar el modalproducto para agregar un nuevo producto. 
  openmodal(): void {
    const dialogRef = this.dialog.open(ModalproductoComponent, {
      width: '300px',

    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.cargardatos();
    });
  }
//Método que abre el modal de actualizar para cada producto, se manda llamar un servicio del tipo put.
  openmodalEditar(producto: Producto): void {
    const dialogRef = this.dialog.open(ModalupdateproductoComponent, {
      width: '300px',
    });
    dialogRef.componentInstance.producto = producto;
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.cargardatos();
    });
  }
}
