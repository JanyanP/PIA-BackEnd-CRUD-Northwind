# Producto Integrador de Aprendizaje

**Ester Abigail Celada López 1863549**
**Janyan Aridaí Rodríguez Puente 1941544**
**Alberto Carlos Almaguer Rodríguez 1877448**
**Destiny Yareli de la Fuente Aguilar 1855184**
**Eduardo Alan Hernandez Villasana 1941416**

**TECNOLOGÍAS INVOLUCRADAS**

- [C#]: Lenguaje predominante en el desarrollo Back-End
- [TypeScript]: Lenguaje predominante en el desarrollo del Front-End
- [HTML]: Utilizado para estructurar la interfaz de la aplicación CRUD
- [JavaScript]: Interactuar con los datos de la aplicación
- [SCSS]: Encargado de dar formato a la interfaz visual de la aplicación.
- [MySQL]: Almacenamiento de datos
- [JSON]: Tipo de archivo que retorna nuestras peticiones

**REQUISITOS**

Estos requisitos fueron determinados basándonos en los softwares involucrados en el desarrollo de la aplicación:

**REQUISITOS DE HARDWARE**

- 2 GB de RAM. 4 GB recomendados
- 6 GB de espacio mínimo en disco duro
- Velocidad del procesador mínima: 1.6 GHz. 2GHz recomendados

**REQUISITOS DE SOFTWARE**

- Sistema Operativo: Windows 10, Windows Server 2016 o más recientes
- .NET framework

**SOFTWARE NECESARIO**
SQL Server y SQL Management Studio: Almacenamiento de la base de datos.
Visual Studio: Desarrollo de la estructura de la aplicación. Back-End y Front-End
Postman: Usado durante el desarrollo para hacer pruebas de requests.

**INSTALACIÓN DE SOFTWARE**

**SQL Server Express y SQL Server Management Studio**

1. Descargar instalador: <https://www.microsoft.com/es-mx/sql-server/sql-server-downloads>
2.	Empezar instalación seleccionando clic derecho sobre el archivo “Ejecutar como administrador”.
3.	Seleccionar “Básica” como tipo de instalación.
4.	Aceptar advertencias de idiomas.
5.	Aceptar contrato de licencia para el uso de SQL Server
6.	Elegir el directorio de instalación o aceptar el default
7.	Esperar por la finalización de la instalación. Si la instalación es exitosa se indicará en un mensaje y se pedirá por instalar SSMS.
8.	Seleccionar “Instalar SSMS” para descargar el instalador de SQL Server Management Studio
9. Seremos redirigidos a la página: <https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15> , donde descargaremos el instalador:
10.	Procedemos a ejecutar el archivo descargado
11.	Seleccionar directorio de instalación o aceptar el default. Y seleccionar “Install”
12.	Si la instalación fue completada exitosamente se mostrará un mensaje y seremos capaces de encontrar SSMS entre nuestras aplicaciones
13.	Instalación completa. Software listo para usar.

**VISUAL STUDIO**

1. Ingresar a <https://visualstudio.microsoft.com/es/downloads/> y descargar instalador de Visual Studio Community
2.	Ejecutar el archivo .exe descargado para empezar la instalación. Aceptar cambios en el sistema.
3.	Seleccionar los componentes con los que se quiera trabajar. La aplicación está desarrollada con componentes .NET/ASP.NET). Elegir idioma
4.	Al finalizar las configuraciones, determinamos el tipo de instalación como “Descargar todo y volver a instalar”. Seleccionar “Instalar”. Esperar a la descarga e instalación de los componentes.
5.	Iniciar sesión si se cuenta con una cuenta Microsoft u omitir
6.	A continuación elegir tema de la aplicación y entorno de desarrollo para empezar. Selecciona “Iniciar”.
7.	La instalación ha terminado. Listo para empezar a desarrollar.

**POSTMAN**
1. Descargar instalador de la página: <https://www.postman.com/downloads/>
2.	Ejecutar instalador .exe para iniciar con la instalación.
3.	Fin de la instalación. 

## Estructura del proyecto

La aplicación se divide tajantemente en Front-End y Back-End. 
Debido a que la aplicación se enfoca de manera especial en la correcta aplicación de las operaciones básicas CRUD, se le prestará más atención a la descripción del Back-End. El Front-End será explicado enfocándonos en su función.

**TABLAS POR TRABAJAR, MODELOS**

En la base de datos NORTHWIND se tienen registros de un negocio, entre ellos se encuentran tablas que describen los datos de distribuidores y órdenes de productos. En esta aplicación se trabajarán tres de sus tablas: Employees, Customers y Products.

ra manejar los datos de los registros desde la aplicación se crearon clases/objetos (uno por tabla) llamados modelos, cuyas variables representan los datos que manejan dichas tablas y tienen propiedades get y set.
Estos modelos serán posteriormente usados por los Controllers y clases donde se definan las funciones que tendrán (archivos SC.cs).
Los archivos que definen los modelos se encuentran en la ruta: BACKEND/DatabaseFirstDWB/DatabaseFirstDWB/ Models

** SERVICE COMPONENT **
En los archivos SC.cs se definen las funciones que los modelos de Employee, Customer y Order usarán para obtener, añadir, actualizar o eliminar registros correctamente.
BaseSC es la base de los demás archivos SC.cs, esto para que los demás heredaran de BaseSC la clase DbContext, la cual se encarga de interactuar con la base de datos. Por lo que los demás archivos contienen una clase del tipo BaseScC.

ProductSC, CustomerSC y EmployeeSC tienen funciones para:

- Obtener: todos los registros, registro por ID, todas las ordenes, ordenes por ID, detalles de órdenes, detalles de órdenes por ID
- Eliminar: donde el registro a eliminar se elimina por ID. Si tiene datos compartidos con alguna otra tabla, primero se borran los datos y despues el registro.
- Actualizar: Se busca el registro con el ID correspondiente y se reemplazan los datos del registro por los nuevamente ingresados. Los nuevos datos se manejan por medio de un modelo
- Agregar: Se crea un nuevo modelo y se le asignan los datos ingresados para posteriormente añadirlos a la base de datos.

Despues de la operación realizada confirmamos a la base de datos los cambios hechos por medio de: dbContext.SaveChanges().

A diferencia de Product, Customer y Employee, OrderSC.cs solo tiene dos funciones: Obtener órdenes por ID y obtener todas las órdenes.

**CONTROLLERS**

Los controllers se encargan de manejar las peticiones HTTP (GET, POST, PUT, DELETE). Los controllers no son de la clase ApiController, si no de ControllerBase, de donde se obtiene la estructura básica de las funciones, sin embargo, el funcionamiento de estas está determinado por el desarrollador.

Los controllers utilizan los Service Components y modelos para manejar los datos solicitados en las peticiones (haciendo uso de las funciones/propiedades que poseen).

Hay dos API's definidas para GET, la diferencia entre ambas es que una obtiene la lista completa de los registros, mientras la otra obtiene el registro cuya ID coincide con el buscado.

El HTTP que obtiene la lista completa no tiene necesidad de solicitar ningún parámetro, mientras que el otro está en necesidad de recibir el ID del registro buscado.

Las API’s para POST, PUT y DELETE se limitan a hacer uso de las funciones declaradas en los Service Components.

POST recibe como parámetro un objeto del tipo Model. PUT necesita recibir un ID, y un objeto Model. Mientras que DELETE necesita recibir solo el ID.

Controllers, Cors y el esquema de autenticación JWT son agregados o inicializados en el método ConfigureServices del archivo Startup.cs

**LOGIN CONTROLLER**

LoginController es el controlador de un JWT, el cual se encarga de autenticar el inicio de sesión de los usuarios. Para lograr esto hacemos uso de cuatro métodos.

1. LoginController: Recibiendo una variable del tipo IConfiguration, funciona como constructor para _config, variable que usaremos en los demás métodos.
2.	AuthenticateUser: recibe como parámetro un LoginModel y revisa que los datos del modelo coincidan con los del usuario que tiene acceso a la aplicación, si coinciden, LoginModel pasa por un proceso de decodificación, en éste se decide si se cargan los datos del inicio de sesión o no. 
3.	GenerateJSONWebToken: Recibe un LoginModel y se crea un nuevo Token con expiración de dos horas.
4.	Login: En Login se implementan los métodos anteriores. Recibe un LoginModel y lo pasa por AuthenticateUser, el LoginModel que regresa es pasado como parámetro a GenerateJSONWebToken (si no es nulo) para generar un nuevo Token y se inicia la sesión

## Frontend
La interfaz del cliente, es decir el front end de la aplicación, se hizo utilizando el framework de Angular. Para iniciar el proyecto nos ubicamos en la carpeta donde guardamos el proyecto en una consola y hacemos la instalación de los paquetes de Angular utilizando el comando npm install

Después ejecutamos el comando ng serve para tener el proyecto andando en nuestro servidor local por default.

Consta de 11 componentes que trabajando en conjunto hacen posible la interfaz visual

Los componentes empleados, cliente y producto cuentan con métodos que agregan, editan o eliminan datos. Estos a su vez, mandan a llamar a un modal correspondiente que aquí es donde esta la lógica de guardar la información o mandar a llamar un servicio POST. Es decir, la lógica del modal se manda a llamar cuando se va a agregar a un cliente, empleado o producto, y además, si se va a actualizar su información. Por la parte del .ts del componente, este se suscribe a la respuesta del modal para esperar su respuesta de la acción.
En caso de que no se ocupe el modal, también se encuentra la función para eliminar algún registro, que se hace por medio de su ID.
En la parte del html de los componentes está el diseño de las tablas donde se va almacenar la información.


El archivo de routing tiene configuraciones para que al dar clic en las diferentes pestañas nos lleve a las diferentes vistas. 

Cada uno de los empleados, clientes y productos cuentan con sus tablas y su respectiva información. 
Para detener la aplicación, abrimos la consola y presionamos CTRL+C, escribimos Y y se detendrá. Si se desea volver a correr, escribimos de nuevo ng serve.













