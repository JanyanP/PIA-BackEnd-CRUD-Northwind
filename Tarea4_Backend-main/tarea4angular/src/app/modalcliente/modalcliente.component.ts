import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { FormBuilder, FormGroup ,Validators} from '@angular/forms';
import { CatalogsService} from '../services/catalog.service';

@Component({
  selector: 'app-modalcliente',
  templateUrl: './modalcliente.component.html',
  styleUrls: ['./modalcliente.component.scss']
})
export class ModalclienteComponent implements OnInit {
  form: FormGroup; 
  constructor(public catalog: CatalogsService, public forbuilder : FormBuilder,public dialogRef: MatDialogRef<ModalclienteComponent>) 
  {
    this.form = forbuilder.group({
      idString:['',Validators.compose([Validators.required])],
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
  agregarCliente(){
    const cliente = this.form.value;
    this.catalog.addCliente(cliente).subscribe(c=> {
      console.log(c);
      this.cancelar();
    }
    )
  }

}
