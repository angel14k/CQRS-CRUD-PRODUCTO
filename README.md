# CQRS-CRUD-PRODUCTO
CRUD DE UNA TABLA PRODUCTO APLICANDO LA ARQUITECTURA DE CQRS

                                              CQRS y MediatR

                                Diferencias y relación entre CQRS y MediatR

* CQRS(Command Query Responsibility Segregation) es un patrón arquitectónico que separa las operaciones
de lectura y escritura. Puedes implementarlo sin MediatR, usando simplemente servicios separados para Commands y Queries.

* MediatR es una librería que ayuda a imlementar el patrón Mediador, desacoplando la lógica de negocio y 
eliminando dependencias directas entre clases. Se usa para manejar Commands y Queries de una forma más
ordenada, pero no es obligatorio para CQRS.


¿Cuándo usar CQRS con MediatR?
- Si quieres un código más modular y desacoplado.
- Si trabajas con arquitecturas escalables o microservicios.
- Si quieres manejar eventos de dominio y notificaciones de forma eficiente.
¿Cuándo NO es necesario MediatR en CQRS?
- Si tu aplicación es pequeña, y agregar MediatR solo aumenta la complejidad
- Si ya tienes una arquitectura clara con servicios bien organizados sin necesidad de una mediador.

      Beneficios de usar CQRS con MediatR en una API
* Código más limpio y modular.
* Facilita la escalabilidad y el mantenimiento.
* Separa responsabilidades, evitando acoplamientos innecesarios.
* Permite implementar patrones avanzados como Event Sourcing o Microservicios.
