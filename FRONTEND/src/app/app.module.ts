import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BarraLateralComponent } from './barra-lateral/barra-lateral.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { EmpleadoComponent } from './empleado/empleado.component';
import { ClienteComponent } from './cliente/cliente.component';
import { ProductoComponent } from './producto/producto.component';

import { MatTableModule } from '@angular/material/table';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { HttpClientModule } from '@angular/common/http';
import { APP_CONFIG, AppConfigImpl } from './app.config';
import {MatCardModule} from '@angular/material/card';
import {MatDialogModule} from '@angular/material/dialog';
import { ModalempleadoComponent } from './modalempleado/modalempleado.component';
import { ModalclienteComponent } from './modalcliente/modalcliente.component';
import { ModalproductoComponent } from './modalproducto/modalproducto.component';
import { ModalupdateempleadoComponent } from './modalupdateempleado/modalupdateempleado.component';
import { ModalupdateclienteComponent } from './modalupdatecliente/modalupdatecliente.component';
import { ModalupdateproductoComponent } from './modalupdateproducto/modalupdateproducto.component';

@NgModule({
  declarations: [
    AppComponent,
    BarraLateralComponent,
    EmpleadoComponent,
    ClienteComponent,
    ProductoComponent,
    ModalempleadoComponent,
    ModalclienteComponent,
    ModalproductoComponent,
    ModalupdateempleadoComponent,
    ModalupdateclienteComponent,
    ModalupdateproductoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatTableModule,
    FormsModule,
    MatInputModule,
    HttpClientModule,
    MatCardModule,
    MatDialogModule,
    ReactiveFormsModule
  ],
  providers: [{ provide: APP_CONFIG, useValue: AppConfigImpl },],
  bootstrap: [AppComponent]
})
export class AppModule { }
