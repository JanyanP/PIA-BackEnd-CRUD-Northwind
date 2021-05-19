import { Cliente } from './../services/catalog.service';
import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { FormBuilder, FormGroup ,Validators} from '@angular/forms';
import { CatalogsService} from '../services/catalog.service';

@Component({
  selector: 'app-modalupdatecliente',
  templateUrl: './modalupdatecliente.component.html',
  styleUrls: ['./modalupdatecliente.component.scss']
})
export class ModalupdateclienteComponent implements OnInit {
  cliente: Cliente = {} as Cliente;
  form: FormGroup;
  constructor(public catalog: CatalogsService, public forbuilder : FormBuilder,public dialogRef: MatDialogRef<ModalclienteComponent>)
  {
    this.form = forbuilder.group({
      name : ['',Validators.compose([Validators.required])],
      cityName:['',Validators.compose([Validators.required])],
      phoneNumber:['',Validators.compose([Validators.required])]
    })
   }

  ngOnInit(): void {
  }
  cancelar(): void {
    this.dialogRef.close();
  }
  editarCliente(){
    const cliente = this.cliente;
    this.catalog.updateCliente(cliente).subscribe((cliente)=> {
      this.cancelar();
    }
    )
  }

}
