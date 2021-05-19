import { Producto } from './../services/catalog.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup ,Validators} from '@angular/forms';
import { CatalogsService} from '../services/catalog.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
@Component({
  selector: 'app-modalupdateproducto',
  templateUrl: './modalupdateproducto.component.html',
  styleUrls: ['./modalupdateproducto.component.scss']
})
export class ModalupdateproductoComponent implements OnInit {
  producto: Producto = {} as Producto;
  form: FormGroup;
  constructor(public catalog: CatalogsService, public forbuilder : FormBuilder,public dialogRef: MatDialogRef<ModalupdateproductoComponent>)
  {
    this.form = forbuilder.group({
      idNumber:[0,Validators.compose([Validators.required])],
      name : ['',Validators.compose([Validators.required])],
      price:['',Validators.compose([Validators.required])],
      stock:['',Validators.compose([Validators.required])]
    })
   }
  editarProducto(){
    const productoform = this.producto;
      console.log(productoform)
      this.catalog.updateProducto(productoform).subscribe((producto)=>{
        this.cancelar();
      })
  }
  cancelar(): void {
    this.dialogRef.close();
  }
  ngOnInit(): void {
  }
}
