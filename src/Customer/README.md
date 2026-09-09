# Customer Microservice

## Responsabilidad

El microservicio Customer gestiona la información básica de los clientes
de Atlas Bank.

Actualmente permite crear clientes y consultar un cliente por su identificador.

---

## Arquitectura

Este microservicio utiliza una arquitectura N-Layer como ejercicio práctico
para separar las responsabilidades de API, lógica de negocio y acceso a datos.

```text
Customer.Api
    ↓
Customer.Business
    ↓
ICustomerRepository
    ↑
Customer.Data
    ↓
MySQL
```

## Estructura
Customer.Api
    API REST y DTOs HTTP

Customer.Business
    Lógica y validaciones de negocio

Customer.Contracts
    Interfaces utilizadas entre capas

Customer.Data
    EF Core, DbContext y repositorios

Customer.Entities
    Entidades del dominio

tests/
    Customer.Business.Tests
    Customer.Data.Tests
	
## Flujo de una petición
POST /customers
      ↓
CustomerController
      ↓
CustomerService
      ↓
ICustomerRepository
      ↓
CustomerRepository
      ↓
CustomerDbContext
      ↓
MySQL

GET /customers/{id}
	  ↓
CustomerController
      ↓
CustomerService
      ↓
ICustomerRepository
      ↓
CustomerRepository
      ↓
CustomerDbContext
      ↓
MySQL

## Persistencia
La persistencia utiliza:

Entity Framework Core
Pomelo.EntityFrameworkCore.MySql
MySQL 8.4

La tabla Customers utiliza Id como clave primaria y Email tiene
una restricción UNIQUE.

La base de datos se ejecuta mediante Docker Compose y utiliza un volumen
para conservar los datos entre recreaciones del contenedor.

## API
Crear cliente
POST /customers
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@mail.com"
}
Respuesta correcta:
201 Created

Obtener cliente
GET /customers/{id}
Respuesta correcta:
200 OK
Si el cliente no existe:
404 Not Found
Los errores inesperados son gestionados mediante middleware global y
devuelven:
500 Internal Server Error

## Testing
Se utilizan tests unitarios e integración.

Unit tests

Customer.Business.Tests verifica las principales reglas de negocio,
incluyendo:

nombre obligatorio
apellido obligatorio
email obligatorio
email duplicado
creación válida
Integration tests

Customer.Data.Tests utiliza una instancia real de MySQL ejecutándose
en Docker para comprobar la persistencia mediante EF Core.

## Docker
El entorno local utiliza Docker Compose para ejecutar MySQL y,
opcionalmente, la API.

Desde el host, MySQL está disponible en:

localhost:3307

Desde otros contenedores de Docker:

mysqldb:3306

Se utiliza un volumen Docker para mantener los datos.

## Decisiones y trade-offs
Se eligió N-Layer deliberadamente para este microservicio como ejercicio
de aprendizaje.

No se utiliza una arquitectura Clean Architecture porque será explorada
posteriormente en otro microservicio.

La interfaz ICustomerRepository se mantiene en Customer.Contracts
para evitar que la capa Business dependa de la implementación concreta
de acceso a datos.

No se utiliza Generic Repository porque actualmente no aporta valor
suficiente para el alcance del microservicio.

## Fuera de alcance
Este microservicio actualmente no gestiona:

autenticación
autorización
cuentas bancarias
transferencias
productos financieros
notificaciones

Estas responsabilidades pertenecen a otros microservicios de Atlas Bank.