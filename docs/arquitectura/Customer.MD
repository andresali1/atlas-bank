Customer/
├── Customer.sln
├── Customer.Api/
├── Customer.Business/
│   └── Services/
│       └── CustomerService.cs
├── Customer.Data/
│   ├── Persistence/
│   │   └── CustomerDbContext.cs
│   └── Repositories/
│       └── CustomerRepository.cs
├── Customer.Contracts/
│   └── Interfaces/
│       └── ICustomerRepository.cs
├── Customer.Entities/
│   └── Customer.cs
└── tests/
    └── Customer.Business.Tests/
        ├── Repositories/
        │   └── FakeCustomerRepository.cs
        └── Tests/
            └── CustomerServiceTests.cs