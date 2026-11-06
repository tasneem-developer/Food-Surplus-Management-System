# Food Surplus Management System (FSMS)

A Desktop Application for Managing Restaurant Food Donations

## Overview

The **Food Surplus Management System (FSMS)** is a desktop application designed to facilitate the donation of surplus food from restaurants to people in need.

The system provides a structured way to manage food donations, volunteer requests, and the distribution process. It helps reduce food waste while making surplus food more accessible to communities in need.

## Project Objectives

- Reduce food waste by organizing surplus food donations.
- Connect restaurants with volunteers.
- Simplify the process of requesting and managing donations.
- Improve coordination and tracking of food distribution.
- Support efficient administration through a centralized system.

## User Roles

The system includes three main user roles:

### 1. Admin
- Manage restaurants and volunteers.
- Monitor food donations and requests.
- Review and approve or reject volunteer requests.
- Monitor system activities and reports.

### 2. Restaurant
- Manage restaurant information.
- Add and manage food donations.
- View donation details and related requests.
- Track donation statuses.

### 3. Volunteer
- View available food donations.
- Submit requests for available donations.
- Track request statuses.
- Collect approved donations and deliver them to people in need.

## Main Features

- User authentication and role-based access.
- Restaurant management.
- Volunteer management.
- Food donation management.
- Donation request management.
- Request approval and status tracking.
- Dashboard and statistics.
- Reports and data export.

## Technologies Used

| Technology | Purpose |
|---|---|
| C# | Application programming language |
| Windows Forms | Desktop user interface |
| .NET Framework | Application framework |
| SQL Server | Database management |
| ADO.NET | Database connectivity |
| Guna.UI2 | User interface components |
| FontAwesome.Sharp | Icons |
| ClosedXML | Excel file handling |

## System Architecture

The project follows a layered organization to separate the user interface from database operations.

- **Forms:** Handles the desktop user interface.
- **DataAccess (DAL):** Contains data access operations and database queries.
- **Models:** Represents the application's data entities.
- **Helper:** Contains reusable helper classes.
- **Database:** Stores database-related project resources.

## Database

The application uses Microsoft SQL Server to manage its data.

The main entities include:

- Users
- Restaurants
- Volunteers
- Food Donations
- Requests

## Application Type

- Platform: Windows Desktop
- Development Environment: Visual Studio
- Database: Microsoft SQL Server

## Project Status

Developed as a Software Engineering university project at Al-Nasser University.

## Author

**Tasneem Al-Hamidi**

---

*FSMS — Turning Surplus Food into an Opportunity to Help Others.*