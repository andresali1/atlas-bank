🗺️ Checklist actual de Atlas Bank
#	Microservicio -> Arquitectura -> Estado -> Experimento principal
1	Customer -> N-Layer -> Base funcional -> EF Core + MySQL + Docker + tests
2	Identity -> Clean Architecture -> Base funcional -> TDD + PostgreSQL + hashing + errores
3	Account	DDD -> DDD -> Base funcional ->	Domain model + invariantes
4	Transfer	CQRS + MediatR	⬜	Commands / Queries -> siguiente
5	Notification	Vertical Slice	⬜	Features aisladas
6	Audit	Event-driven	⬜	RabbitMQ + MongoDB
7	Reporting	Read Model / Reporting	⬜	Oracle + modelo de lectura



						 ┌──────────────┐
                         │   Angular    │
                         └──────┬───────┘
                                │
                         ┌──────▼───────┐
                         │    Gateway   │
                         └──────┬───────┘
                                │
       ┌────────────┬──────────┼──────────┬─────────────┐
       ▼            ▼          ▼          ▼             ▼
   Customer      Identity    Account    Transfer    Notification
     MySQL       PostgreSQL  SQL Server   ...          ...
                                │
                                │ events
                                ▼
                           ┌──────────┐
                           │ RabbitMQ │
                           └────┬─────┘
                                │
                         ┌──────┴───────┐
                         ▼              ▼
                       Audit         Reporting
                      MongoDB          Oracle
					  
Testing:
Servicio	TDD inicial	Motivo
Customer	🟢 Sí	Ya lo usamos para aprender N-Layer
Identity	🟢 Sí	Buen candidato por reglas de negocio y seguridad
Account	🟢 Sí	DDD es especialmente bueno para descubrir invariantes
Transfer	🟢 Sí	Hay bastante lógica y CQRS
Notification	🟡 Probablemente parcial	Mucha infraestructura/integración
Audit	🟡 Parcial	El comportamiento interesante estará en eventos/integración
Reporting	🟡/🔴 Según caso	Mucho del trabajo será queries/read model/infraestructura







Orden	Microservicio	Arquitectura / experimento
1	Customer	N-Layer
2	Identity	Clean Architecture + TDD
3	Account	DDD
4	Transfer	CQRS + MediatR
5	Notification	Vertical Slice
6	Audit	Event-driven + MongoDB
7	Reporting	Read Model + Oracle