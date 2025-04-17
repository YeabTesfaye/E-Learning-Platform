# E-Learning Platform

A robust, feature-rich E-Learning platform built with ASP.NET Core, implementing clean architecture principles and modern development practices.

## 🚀 Features

- **Course Management**
  - Structured course creation and organization
  - Module-based content organization
  - Lesson management
  - Quiz and assessment system

- **User Management**
  - Secure user authentication using JWT
  - Role-based authorization
  - Student enrollment tracking
  - Progress monitoring

- **Assessment System**
  - Quiz creation and management
  - Multiple question types support
  - Student attempt tracking
  - Progress analytics

- **Security Features**
  - JWT-based authentication
  - API rate limiting
  - CORS protection
  - Secure headers configuration

## 🏗️ Architecture

The project follows Clean/Onion Architecture with the following structure:

```
Server/
├── api/                    # API entry point and configuration
├── E-Learning.Presentation/# Controllers and presentation logic
├── Contracts/             # Interfaces and contracts
├── Entities/              # Domain models
├── Service/               # Business logic implementation
├── Repository/            # Data access layer
└── Shared/               # Common utilities
```

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core
- **Database**: SQL Server
- **Authentication**: JWT (JSON Web Tokens)
- **Documentation**: Swagger/OpenAPI
- **Containerization**: Docker
- **API Testing**: Postman collections included
- **Frontend**:
  - Next.js 14 with TypeScript
  - shadcn/ui components
  - Tailwind CSS
  - React Query for state management
  - React Hook Form for form handling
  - Zod for schema validation

## 🏗️ Project Structure

```
E-Learning-Platform/
├── Server/                 # Backend API
│   ├── api/               # API entry point and configuration
│   ├── E-Learning.Presentation/
│   ├── Contracts/
│   ├── Entities/
│   ├── Service/
│   ├── Repository/
│   └── Shared/
│
├── client/                # Frontend Application
│   ├── app/              # Next.js app directory
│   ├── components/       # Reusable UI components
│   │   ├── ui/          # shadcn components
│   │   └── custom/      # Custom components
│   ├── lib/             # Utility functions
│   ├── hooks/           # Custom React hooks
│   ├── types/           # TypeScript definitions
│   ├── styles/          # Global styles
│   └── features/        # Feature-based components
│       ├── auth/        # Authentication
│       ├── courses/     # Course management
│       ├── lessons/     # Lesson components
│       └── quiz/        # Quiz components
│
└── postman/             # API documentation
```

## 🚦 Getting Started

### Prerequisites

- .NET 6.0 or later
- Docker (optional)
- SQL Server
- Visual Studio/VS Code

### Installation

1. Clone the repository:
```bash
git clone [repository-url]
```

2. Navigate to the Server directory:
```bash
cd Server
```

3. Run using Docker:
```bash
docker-compose up
```

Or run locally:
```bash
dotnet restore
dotnet run --project api
```

### Configuration

1. Update the connection string in `appsettings.json`
2. Configure JWT settings in configuration
3. Set up CORS policies as needed

## 📚 API Documentation

API documentation is available through Swagger UI when running the application:
- Local: `https://localhost:[port]/swagger`

## 🔒 Security

- JWT authentication for secure API access
- Rate limiting to prevent abuse
- CORS policies configured
- Proper security headers

## 🧪 Testing

- Postman collections available in the `/postman` directory
- Unit tests (TBD)
- Integration tests (TBD)

## 🛠️ Development

### Key Components

1. **Entities**
   - Course
   - Module
   - Lesson
   - Quiz
   - Student
   - User
   - Enrollment

2. **Features**
   - Course management
   - Student enrollment
   - Progress tracking
   - Quiz assessment
   - User authentication

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Open a Pull Request

## 📄 License

[License Type] - See LICENSE.md for details

## 📞 Support

[Contact Information or Support Instructions]

## Frontend Setup

1. Navigate to the client directory:
```bash
cd client
```

2. Install dependencies:
```bash
npm install
```

3. Set up shadcn/ui:
```bash
npx shadcn-ui@latest init
```

4. Start the development server:
```bash
npm run dev
```

### Key Frontend Features

- **Modern UI Components**
  - Responsive design
  - Dark/Light mode
  - Accessible components
  - Custom animations

- **Authentication**
  - JWT-based auth flow
  - Protected routes
  - Persistent sessions

- **Course Experience**
  - Interactive lesson viewer
  - Progress tracking
  - Real-time quiz taking
  - Course navigation

- **State Management**
  - React Query for server state
  - Context for global state
  - Optimistic updates

- **Performance**
  - Server-side rendering
  - Image optimization
  - Code splitting
  - Lazy loading

### Environment Setup

Create a `.env.local` file in the client directory:
```env
NEXT_PUBLIC_API_URL=http://localhost:5000
NEXT_PUBLIC_AUTH_URL=http://localhost:5000/auth
```
