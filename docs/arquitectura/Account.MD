Account/
├── Account.sln
│
├── Account.Api/
│
├── Account.Application/
│   └── Interfaces/
│       └── IAccountRepository.cs
│
├── Account.Domain/
│   ├── Account.cs
│   └── Enums/
│
├── Account.Infrastructure/
│   ├── Persistence/
│   │   └── AccountDbContext.cs
│   └── Repositories/
│
└── tests/
    ├── Account.Domain.Tests/
    ├── Account.Application.Tests/
    └── Account.Infrastructure.Tests/