# Node Manager Fintech

Node Manager Fintech — это API-приложение для управления древовидными структурами узлов. Поддерживает создание деревьев, добавление иерархических узлов, удаление с проверкой на дочерние элементы, а также логирование исключений в базу данных.

## Быстрый старт

1. Клонируйте репозиторий:

   ```bash
   git clone https://github.com/your-org/NodeManagerFintech.git
   ```

2. Настройте строку подключения в `appsettings.json`

   ```json
   "ConnectionStrings": {
     "NodeManager": "Host=localhost;Port=5432;Database=TreeDb;Username=your_username;Password=your_password"
   }
   ```

3. Примените миграции через консоль диспетчера пакетов и запустите приложение:

   ```bash
   Update-Database -Project PS.NodeManagerFintech.Infrastructure -StartupProject PS.NodeManagerFintech.API
   ```

4. Доступ к API осуществляется через:

   ```
   https://localhost:7150/api/trees
   https://localhost:7150/api/nodes
   ```

## Работа с API

* `POST /api/trees` — создать новое дерево
* `GET /api/trees` — получить все деревья с узлами
* `POST /api/nodes` — создать узел
* `DELETE /api/nodes/{id}` — удалить узел (при отсутствии дочерних)

## Настройка

* База данных: PostgreSQL (проверьте, что установлен PostgreSQL 13+ и доступен порт 5432)
* PgAdmin или любая другая утилита может быть использована для визуального управления БД
* Все исключения логируются в таблицу `ExceptionLogs`

## Зависимости

- ASP.NET Core 6
- Entity Framework Core 6
- Npgsql.EntityFrameworkCore.PostgreSQL
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Relational
- FluentValidation
- FluentValidation.AspNetCore
- Mapster
- Swashbuckle.AspNetCore
- Microsoft.Extensions.*

