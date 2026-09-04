# ReservasApp

Aplicación WPF en .NET 8 para consultar aulas y gestionar reservas mediante SQL Server.

## Requisitos

- Visual Studio con la carga de trabajo de escritorio de .NET
- .NET 8 Desktop Runtime/SDK
- SQL Server Express

## Base de datos incluida

El respaldo completo está en `Database/ReservasDB.bak` y fue generado con `CHECKSUM` y validado con `RESTORE VERIFYONLY`.

Para restaurarlo en SQL Server Management Studio:

1. Haz clic derecho en **Bases de datos**.
2. Selecciona **Restaurar base de datos...**.
3. Elige **Dispositivo** y agrega `Database/ReservasDB.bak`.
4. Restaura la base con el nombre `ReservasDB`.

La conexión actual se configura en `ReservasApp/Data/ConexionDB.cs` y apunta a `LOLA\SQLEXPRESS` mediante autenticación de Windows. Si el servidor de destino tiene otro nombre, actualiza `Server` en esa cadena de conexión.

## Ejecutar

Abre `ReservasApp.slnx` en Visual Studio, restaura los paquetes NuGet y ejecuta el proyecto `ReservasApp`.

