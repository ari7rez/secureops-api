📌 SecureOps Platform

A full-stack cyber security operations platform for managing incidents and risks, built using ASP.NET Core and Blazor.

⸻

🚀 Overview

SecureOps is a lightweight security management system designed to simulate real-world cyber security workflows. It allows users to:
	•	Track security incidents
	•	Manage organisational risks
	•	Monitor key metrics through a dashboard
	•	Create and update records via a web interface

This project demonstrates full-stack development skills with a focus on clean architecture and practical system design.

⸻

🏗️ Architecture

project/
├── api/   → ASP.NET Core Web API (backend)
├── ui/    → Blazor Server (frontend)

Backend (API)
	•	ASP.NET Core Web API
	•	Entity Framework Core
	•	SQLite database
	•	RESTful endpoints

Frontend (UI)
	•	Blazor Server
	•	Razor Components
	•	HTTPClient integration with API

⸻

⚙️ Features

🔐 Incident Management
	•	Create, view and track incidents
	•	Severity and status tracking
	•	Linked to risks

⚠️ Risk Register
	•	Create and manage risks
	•	Assign ownership
	•	Track mitigation status

📊 Dashboard
	•	Total incidents
	•	Open incidents
	•	Total risks
	•	High/Critical risks

🧩 Full Integration
	•	Frontend communicates with backend via REST API
	•	Real-time UI updates using Blazor

⸻

🛠️ Tech Stack
	•	C# (.NET 10)
	•	ASP.NET Core Web API
	•	Blazor Server
	•	Entity Framework Core
	•	SQLite
	•	Git & GitHub

⸻

▶️ How to Run

1. Run API

cd project
dotnet run

API runs on:

http://localhost:5258


⸻

2. Run UI

cd project/ui
dotnet run

UI runs on:

http://localhost:5134


⸻

3. Open in browser

http://localhost:5134/


⸻

📡 API Endpoints

Method	Endpoint	Description
GET	/api/incidents	Get all incidents
POST	/api/incidents	Create incident
GET	/api/risks	Get all risks
POST	/api/risks	Create risk

Swagger available at:

http://localhost:5258/swagger


⸻

📚 What I Learned
	•	Designing REST APIs using ASP.NET Core
	•	Building full-stack applications with Blazor
	•	Structuring projects into backend and frontend
	•	Using Entity Framework Core for data persistence
	•	Implementing client-server communication
	•	Managing state and UI interactions in Blazor
	•	Debugging real-world integration issues

⸻

🎯 Future Improvements
	•	Authentication and authorisation (JWT)
	•	Role-based access control
	•	Cloud deployment (Azure)
	•	Improved UI/UX design
	•	Filtering and search functionality

⸻

👨‍💻 Author

Mohammad Ali Rezaei
Cyber Security Student | University of Adelaide

