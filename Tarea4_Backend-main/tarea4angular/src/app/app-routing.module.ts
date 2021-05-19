import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ClienteComponent} from './cliente/cliente.component';
import {EmpleadoComponent} from './empleado/empleado.component';
import {ProductoComponent} from './producto/producto.component';

const routes: Routes = [
  {
    path:'Cliente',
    component:ClienteComponent, 

  },
  {
    path:'Empleado',
    component:EmpleadoComponent, 

  },
  {
    path:'Producto',
    component:ProductoComponent, 

  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
