# docmatchMS# docmatchMS

## Overview
docmatchMS is a web-based application that leverages Microsoft technologies to compare file contents against a template and provide a compliance or match score using AI. 

### Key Features:
1. Accepts two types of files:
   - Template files (e.g., job descriptions).
   - Candidate files to check for compliance or match.
2. Supports `.txt`, `.docx`, `.pdf`, and `.xlsx` file formats.
3. Uses AI to calculate a match score.
4. Built entirely on Microsoft technologies.

### Technology Stack:
- **Frontend**: Blazor WebAssembly
- **Backend**: ASP.NET Core
- **AI Services**: Azure OpenAI or Azure Cognitive Services
- **Hosting**: Azure App Service
- **File Handling**: Azure Blob Storage

---

## Folder Structure

```
docmatchMS/
├── frontend/
├── backend/
├── shared/
└── README.md
```

---

## Getting Started

### Prerequisites
- Visual Studio or Visual Studio Code
- .NET SDK
- Azure subscription
- GitHub Codespaces (optional)

### Setup
1. Clone this repository:
   ```bash
   git clone https://github.com/edulorenzo/docmatchMS.git
   ```
2. Open the project in your preferred editor or GitHub Codespaces.
3. Start by building either the frontend or backend projects.

### Contribution
Contributions are welcome! Please feel free to submit issues or pull requests.