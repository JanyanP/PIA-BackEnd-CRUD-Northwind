import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APP_CONFIG, AppConfig } from "../app.config";


@Injectable({
  providedIn: 'root'
})
export class CatalogsService {
  constructor(public http: HttpClient,
    @Inject(APP_CONFIG) private config: AppConfig,
  ) {}
    //Se declaran los metodos que brindaran el servicio a cada una de las funciones necesarias para cada requerimiento,
    //como lo son get, para mostrar los datos de cada tabla, delete para borrar algun registro de cada tabla, 
    // post para agregar un nuevo registro en cada tabla y put para actualizar algun registro. 
    getEmpleados() {
        return this.http.get<Empleado[]>(`${this.config.apiEndpoint}/api/Employee` );
    }
    deleteEmpleado(id: number){
        return this.http.delete(`${this.config.apiEndpoint}/api/Employee/${id}`);
    }
    addEmpleado(empleado : Empleado){
        return this.http.post(`${this.config.apiEndpoint}/api/Employee`,empleado);
    }
    updateEmpleado(empleado: Empleado){
         return this.http.put(`${this.config.apiEndpoint}/api/Employee/${empleado.idNumber}`,empleado);
    }



    getCliente(){
        return this.http.get<Cliente[]>(`${this.config.apiEndpoint}/api/Customer` );
    }
    deleteCliente(id:number){
        return this.http.delete(`${this.config.apiEndpoint}/api/Customer/${id}`);
    }
    addCliente(cliente : Cliente){
        return this.http.post(`${this.config.apiEndpoint}/api/Customer`,cliente);
    }
    updateCliente(cliente : Cliente){
         return this.http.put(`${this.config.apiEndpoint}/api/Customer/${cliente.idString}`,cliente);
  }


    getProducto(){
        return this.http.get<Producto[]>(`${this.config.apiEndpoint}/api/Product` );
    }
    deleteproducto(id: number){
        return this.http.delete(`${this.config.apiEndpoint}/api/Product/${id}`);
    }
    addProducto(Producto : Producto){
        return this.http.post(`${this.config.apiEndpoint}/api/Product`,Producto);
    }
    updateProducto(Producto : Producto){
      return this.http.put(`${this.config.apiEndpoint}/api/Product/${Producto.idNumber}`,Producto);
  }
}

export interface Empleado{
    idNumber: number;
    name: string;
    familyName: string;
}

export interface Cliente{
    idString: string;
    name: string;
    cityName: string;
    phoneNumber:string;

}

export interface Producto{
    idNumber: number;
    name:string;
    price: number;
    stock: number;
}
