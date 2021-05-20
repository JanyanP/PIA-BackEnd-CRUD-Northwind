import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { FormBuilder, FormGroup ,Validators} from '@angular/forms';
import { CatalogsService} from '../services/catalog.service';

@Component({
  selector: 'app-modalproducto',
  templateUrl: './modalproducto.component.html',
  styleUrls: ['./modalproducto.component.scss']
})
export class ModalproductoComponent implements OnInit {
  form: FormGroup; 
  constructor(public catalog: CatalogsService, public forbuilder : FormBuilder,public dialogRef: MatDialogRef<ModalproductoComponent>)
  {
    // Se crea una forma en donde guarda la información de cada producto
    this.form = forbuilder.group({
      idNumber:[0,Validators.compose([Validators.required])],
      name : ['',Validators.compose([Validators.required])],
      price:['',Validators.compose([Validators.required])],
      stock:['',Validators.compose([Validators.required])]
    })
   }

  ngOnInit(): void {
  }
  cancelar(): void {
    this.dialogRef.close();
  }
  //Método para agregar un nuevo producto, se manda a llamar a un servicio post
  agregarProducto(){
    const producto = this.form.value;
    this.catalog.addProducto(producto).subscribe(c=> {
      console.log(c);
      this.cancelar();
    }
    )
  }
}
