# Genderize

# 🧙 Backend Wizards API - Stage 0

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![API Status](https://img.shields.io/badge/API-Live-success)](https://genderize.fly.dev)
[![Framework](https://img.shields.io/badge/Framework-ASP.NET%20Core%208.0-blue)](https://dotnet.microsoft.com)

## 🚀 Live Demo

The API is live and ready to test:

- **Base URL**: `https://genderize.fly.dev/api`
- **Sample Request**: [Click to test with name 'john'](https://genderize.fly.dev/api/classify?name=john)
- **Sample Request**: `curl https://genderize.fly.dev/api/classify?name=jane`

### Quick Test Commands

```bash
# Test with a common name
curl "https://genderize.fly.dev/api/classify?name=john"

# Test with a female name
curl "https://genderize.fly.dev/api/classify?name=sarah"

# Test error handling (missing name)
curl "https://genderize.fly.dev/api/classify"

# Test unknown name (should return 422)
curl "https://genderize.fly.dev/api/classify?name=xyzabc123"

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