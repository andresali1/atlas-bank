🗺️ Checklist actual de Atlas Bank
#	Microservicio -> Arquitectura -> Estado -> Experimento principal
1	Customer -> N-Layer -> Base funcional -> EF Core + MySQL + Docker + tests
2	Identity -> Clean Architecture -> Base funcional -> TDD + PostgreSQL + hashing + errores
3	Account	DDD	⬜ Siguiente	Domain model + invariantes
4	Transfer	CQRS + MediatR	⬜	Commands / Queries
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