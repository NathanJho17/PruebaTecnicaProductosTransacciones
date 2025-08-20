Requisitos: Disponer de Docker y Docker compose instalado en su dispositivo local
SQL Server y SQL Server management studio

• Ejecutar el comando docker compose up -d para levantar los servicios

Conectarse a la base datos:
Para productos: localhost puerto 1438
Para transacciones: localhost puerto 1439

usuario y contraseña para ambas bases de datos:
usuario: sa 
contraseña: Jhonatan.Espinoza.2025

•  Ejecutar los DDL DB_Productos en base de datos Productos
• Ejecutar Script Categorias en base de datos DB_Productos
• • Ejecutar los DDL en base de datos transacciones DB_Transacciones en SQL Server Management Studio



Api prodcutos y categorías: http://localhost:8060
Api transacciones: http://localhost:8061
Web App producto transacciones http://localhost:8062