# Genderize

# 🧙 Backend Wizards API - Stage 0

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![API Status](https://img.shields.io/badge/API-Live-success)](https://your-api-url.com)
[![Framework](https://img.shields.io/badge/Framework-ASP.NET%20Core%208.0-blue)](https://dotnet.microsoft.com)

## 📌 Project Overview

This API serves as the **Stage 0 assessment** for the Backend Wizards program. It demonstrates proficiency in:

- 🔗 **External API Integration** (Genderize.io)
- 🛡️ **Robust Error Handling** (400, 422, 500, 502)
- 🧮 **Data Processing** (confidence scoring logic)
- 🌐 **CORS Implementation** (cross-origin requests)
- ⚡ **Performance Optimization** (<500ms response time)

## 🎯 Endpoint

### `GET /api/classify`

Predicts gender probability for a given name using the Genderize.io database.

#### Query Parameters
| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `name` | string | ✅ Yes | The name to classify (case-insensitive) |

#### Success Response (200 OK)
```json
{
  "status": "success",
  "data": {
    "name": "alex",
    "gender": "male",
    "probability": 0.95,
    "sample_size": 5432,
    "is_confident": true,
    "processed_at": "2026-04-13T14:30:00Z"
  }
}