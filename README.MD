# 🚀 Gestor de Tareas con Blazor

Una aplicación moderna de gestión de tareas desarrollada con **Blazor Server**, utilizando patrones de diseño robustos y tecnologías actuales.

## ✨ Características Principales

- **Gestión completa de tareas**: Crear, leer, actualizar y eliminar tareas
- **Diseño responsive** con Bootstrap 5
- **Autenticación con Session Storage**
- **Validación de formularios** con Data Annotations
- **Patrón Unit of Work** para manejo transaccional
- **Patrón Repository** mediante paquete NuGet personalizado
- **Patrón Service** para lógica de negocio
- **DTOS** para no exponer directamente los modelos


## 🛠️ Tecnologías Utilizadas

| Capa | Tecnología |
|------|-----------|
| **Frontend** | Blazor Server, Bootstrap, HTML/CSS |
| **Backend** | ASP.NET Core, C# |
| **Base de datos** | Entity Framework Core, SQL Server |
| **Patrones** | Unit of Work, Repository, Service |
| **Estado** | Session Storage (JavaScript Interop) |

## 🔐 Autenticación

- Implementación con **Session Storage**
- Token de sesión almacenado en `sessionStorage`
- Redirección automática a login si no autenticado