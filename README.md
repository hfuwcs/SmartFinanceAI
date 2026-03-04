# SmartFinanceAI

## Overview
SmartFinanceAI is a comprehensive, AI-enhanced personal finance and wealth management platform. The system is designed to automate transaction categorization, manage multi-currency accounts, and provide intelligent financial insights using Retrieval-Augmented Generation (RAG). 

The repository is structured as a monorepo, containing both a modern React-based frontend and a robust, highly scalable .NET backend implementing Clean Architecture and CQRS principles.

## System Architecture & Tech Stack

### Backend
*   **Framework:** .NET 8/9, ASP.NET Core Web API
*   **Architecture:** Clean Architecture, CQRS (Command Query Responsibility Segregation) pattern utilizing MediatR
*   **Data Access:** Entity Framework Core (Code-First)
*   **Authentication:** ASP.NET Core Identity, JWT (JSON Web Tokens), Google OAuth 2.0
*   **AI Integration:** Semantic Kernel / LangChain .NET for LLM orchestration

### Frontend
*   **Framework:** Next.js (React), Server-Side Rendering (SSR)
*   **Styling:** Tailwind CSS, Shadcn/ui
*   **Data Fetching:** TanStack Query

### Infrastructure & Database
*   **Database:** PostgreSQL
*   **Vector Search:** `pgvector` extension for storing and querying transaction embeddings
*   **Containerization:** Docker, Docker Compose
*   **CI/CD:** GitHub Actions (Planned)

## Project Scope & Core Features

1.  **Authentication & Authorization**
    *   Stateless authentication using JWT.
    *   Local credential login (hashed via PBKDF2) and Google OAuth2 integration.
2.  **Core Financial Domain**
    *   **Multi-currency Support:** System-wide base currency with historical exchange rate tracking.
    *   **Transaction Management:** Granular transaction logging with support for "Split Categories" (e.g., dividing a single receipt into groceries and household items).
3.  **Data Ingestion Pipeline**
    *   Asynchronous background workers for parsing bank statements (CSV/PDF).
    *   Pattern recognition and rule-based auto-categorization of raw transaction data.
4.  **AI-Powered Assistant (RAG)**
    *   Vectorization of user transaction history stored in `pgvector`.
    *   Natural language querying (e.g., "How much did I spend on dining last month compared to my budget?").
    *   Integration with external LLMs (OpenAI/Gemini) to generate actionable financial advice based on retrieved contextual data.

## Repository Structure

```text
SmartFinanceAI-Fullstack/
├── .github/workflows/          # CI/CD pipelines
├── backend/                    # .NET Solution
│   ├── src/
│   │   ├── SmartFinanceAI.Domain/         # Enterprise logic and core entities
│   │   ├── SmartFinanceAI.Application/    # Use cases, CQRS Handlers, DTOs
│   │   ├── SmartFinanceAI.Infrastructure/ # EF Core, Identity, External Services
│   │   └── SmartFinanceAI.Api/            # REST Controllers, Middleware
│   └── tests/                  # Unit and Integration tests
├── frontend/                   # Next.js web application
└── docker-compose.yml          # Local development infrastructure
```

## Getting Started

### Prerequisites
*   [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later
*   [Node.js](https://nodejs.org/) (v20+ recommended)
*   [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Local Development Setup

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/yourusername/SmartFinanceAI.git
    cd SmartFinanceAI-Fullstack
    ```

2.  **Start the infrastructure (PostgreSQL):**
    ```bash
    docker-compose up -d
    ```

3.  **Configure Backend:**
    *   Navigate to `backend/src/SmartFinanceAI.Api/appsettings.json`.
    *   Update the `ConnectionStrings:DefaultConnection` with your local PostgreSQL credentials (matching the `docker-compose.yml`).
    *   Insert your Google OAuth Client ID and a secure JWT Key.
    
4.  **Run Database Migrations:**
    ```bash
    cd backend
    dotnet ef database update --project src/SmartFinanceAI.Infrastructure --startup-project src/SmartFinanceAI.Api
    ```

5.  **Start the Web API:**
    ```bash
    dotnet run --project src/SmartFinanceAI.Api
    ```

6.  **Start the Frontend:**
    ```bash
    cd ../frontend
    npm install
    npm run dev
    ```

## Roadmap
*   [x] Project initialization and Clean Architecture setup.
*[x] Database schema design (Multi-currency, Split categories).
*   [x] Identity and Authentication (JWT, Google Login).
*   [ ] Implementation of CQRS handlers for Core Domain.
*   [ ] Next.js dashboard UI implementation.
*   [ ] Background service for CSV/PDF statement ingestion.
*   [ ] `pgvector` integration and RAG pipeline setup.
*   [ ] Dockerization of application layers and CI/CD deployment.
