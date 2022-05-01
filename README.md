# TestNexos
>Technical Test Nexos

Prueba de Conocimiento Desarrollador .Net <br>
Prueba Técnica para Ingeniero Desarrollador .Net <br>
Lenguaje: C#, JavaScript y/o TypeScript <br>
Base de datos: Sql Server <br>
Back-End: ASP NET CORE ó NET 5 <br>
Front-End: Angular 6 o mayor <br>
ORM: Entity Framework 2.2.x <br>

Proyecto 1:
Se requiere un API RESTFul en .NET Core o NET 5 que permita: <br>
> Registrar los datos de un libro: Titulo, Año, Genero, Número de páginas, Editorial, Autor. <br>
> Registrar los datos de los autores: Nombre completo, Fecha de nacimiento, Ciudad de procedencia, Correo electrónico. <br>
> Registrar los datos de las editoriales: Nombre, Dirección de Correspondencia, Teléfono, Correo electrónico, Máximo de libros registrados. <br>

Reglas de negocio:
> Todos los datos marcados con asterisco son obligatorios. <br>
> Se debe garantizar la integridad de la información. <br>
> Las editoriales pueden tener un máximo de libros registrados, en caso de no existir límite, se indica -1. <br>
> Si al intentar registrar un libro se supera el máximo permitido, debe generarse una excepción y responder con el mensaje: “No es posible registrar el libro, se alcanzó el máximo permitido.”.<br>

> Si al intentar registrar un libro y no existe: <br>
> > Autor: Responder con el mensaje: “El autor no está registrado”. <br>
> > Editorial: Responder con el mensaje: “La editorial no está registrada”. <br>

Aspectos Técnicos:
> Tener en cuenta la estructura de paquetes <br>
> > Entidades. <br>
> > DTOs. <br>
> > Interfaces. <br>
> > Servicios (implementación). <br>
> > Controladores. <br>
> > Excepciones. <br>

> Inyección de dependencias, uso de modelos, código legible son aspectos que serán tomados en cuenta. <br>
> Todas las buenas prácticas de desarrollo serán tomadas en cuenta. <br>
> Prueba de Conocimiento Desarrollador .Net <br>

Proyecto 2:
> Se requiere un frontend en Angular para buscar los libros registrados en el sistema. <br>
> El sistema debe permitir buscar por palabras clave como el autor, titulo, año. <br>
> Aspectos Técnicos:<br>
> > Usar Angular 6 o mayor versión. <br>
> > Usar componentes, servicios, observadores, bootstrap (o cualquier librería UI). <br>
> > Una buena organización y estructura del proyecto serán tomadas en cuenta. <br>
> > Una buena maquetación de templates serán tomadas en cuenta. <br>

