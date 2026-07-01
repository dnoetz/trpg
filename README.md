# TRPG - A Tabletop RPG Engine

A modular, turn-based RPG system built with .NET, designed to demonstrate clean architecture, domain-driven design, and separation of concerns. The project is currently in active development, with a working combat loop and a growing test suite.

## Project Status

**Active Development.** The core combat system is functional. Current focus is on expanding the combat loop, creating campaign hosting capabilities, and building out the API layer.

## Features

- **Turn-based Combat**: Initiative rolls, hit/miss mechanics, and critical hits.
- **Class-Based Abilities**: Extensible ability system (e.g., Necromancer's "Necrosis" and "Reaper's Mark").
- **Domain-Rich Design**: Business logic is encapsulated within domain entities.
- **Testing**: Unit tests in place using xUnit and Moq.

## Tech Stack

- **.NET 10** - Core framework
- **C#** - Primary language
- **xUnit & Moq** - Testing
- **PostgreSQL** - Database (planned)
- **Entity Framework Core** - ORM (planned)
- **React** - Frontend (planned)

## Architecture

This project follows a hybrid of **Vertical Slice** and **Clean Architecture** principles:

- **RPG.Core**: Domain entities, interfaces, value objects, and core services (no external dependencies).
- **RPG.Infrastructure**: Database access and external service implementations (depends on Core).
- **RPG.API**: Web API controllers and DTOs (depends on Core and Infrastructure).
- **RPG.Tests**: Unit and integration tests.

The goal is to keep the domain logic pure, testable, and independent of infrastructure concerns.
