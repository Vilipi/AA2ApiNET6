# AA2ApiNET6

Aplicación de gestión de un centro médico con 3 entidades. PACIENTES, ESPECIALISTAS Y CITAS.
Se pueden crear pacientes que tras logearse podran pedir cita al especialista correspondiente.

Esta aplicacion cuenta con los metodos CRUD para cada uno de sus 3 entidades asi como filtros y ordenamiento.

- Algunos métodos son públicos y en otros es necesario logearse para poder usarlos.
- App desarrollada con base de datos y gestionada con EF.  Code  First
- App contenerizada. Rama feature/Docker
- App subida a Azure en dos ambientes. Rama Azure con una database igualmente en la nube. Rama CLOUD desarrollada inMemory.
- Logs añadidos tanto local como Docker.
- Gestión de métricas con azure Insights.

https://aa2apinet6.azurewebsites.net/swagger/index.html
