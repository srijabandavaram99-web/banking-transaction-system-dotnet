# Banking Transaction System

A beginner-friendly Banking Transaction Management System built using .NET Web API.  
This project demonstrates core backend development concepts such as REST APIs, account management, money transfers, transaction history, audit logs, statements, dashboard APIs, Swagger documentation, and global exception handling.

## Project Overview

The Banking Transaction System is a simple backend API project that simulates basic banking operations. It allows users to view customer accounts, perform money transfers, view transaction history, generate account statements, view dashboard data, and track audit logs.

This project is designed to demonstrate practical .NET Web API development skills for a banking domain use case.

## Technologies Used

- .NET Web API
- C#
- ASP.NET Core
- Swagger / OpenAPI
- REST API
- Global Exception Middleware
- Visual Studio Code
- Git and GitHub

## Features

### Accounts API

- View all accounts
- View account by account number
- Create a new account

### Money Transfer API

- Transfer money from one account to another
- Validate sender account
- Validate receiver account
- Validate available balance
- Prevent invalid transfer amount
- Update account balances after transfer

### Transaction History API

- View all money transfer transactions
- Track sender account, receiver account, amount, date, and status

### Dashboard API

- View project dashboard data
- Display total accounts
- Display total transactions
- Display total bank balance
- Display highest balance account

### Audit Logs API

- View audit logs
- Add audit log entries
- View audit log by ID

### Statement API

- Generate sample bank statement by account number
- Display customer information
- Display current balance
- Display sample transactions

### Global Exception Middleware

- Handles unexpected errors in one common place
- Returns a clean JSON error response
- Improves API reliability and maintainability

## API Endpoints

### Accounts

```http
GET /api/Accounts
GET /api/Accounts/{accountNumber}
POST /api/Accounts
POST /api/Accounts/transfer
GET /api/Accounts/transactions