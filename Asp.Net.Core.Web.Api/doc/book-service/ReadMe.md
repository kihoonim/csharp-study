1. Asp.Net Core Web API 프로젝트 생성
  - Https 체크 안할시 UseHttpsRedirection 안됨
  - OpenAPI 체크 안하면 Swagger 안됨
2. Book Model 생성
3. Nuget 설치
  - Microsoft.EntityFrameworkCore.Sqlite
  - Microsoft.EntityFrameworkCore.Tools
4. DbContext 등록
5. StatUp에 AddDbContext 추가
5. Sqlite Extension 설치 [링크](https://marketplace.visualstudio.com/items?itemName=ErikEJ.SQLServerCompactSQLiteToolbox)
6. Connection String 수정
7. Migration 
  - Add-Migration InitialDatabaseMigration
  - Update-Database
8. AppDbInitializer 클래스 추가

10. BooksController 추가 - API/Empty
11. BooksService 추가
12. BookVM 추가
13. StartUp에 서비스 추가
  - https://aspdotnet.tistory.com/2108

14. Post 함수 추가
15. GetAllBooks 추가


CRUD
16. HttpPut
17. HttpDelete
18. HttpGet
19. HttpPost

https://github.com/serilog/serilog-settings-configuration

20. Nuget 추가
- Serilog.AspNetCore
- Serilog.Sinks.Sqlite
- Serilog.Sinks.File

21. Log Model 추가
  - https://github.com/serilog/serilog-sinks-mssqlserver/#:~:text=a%20scheduled%20basis.-,Standard%20Columns,-By%20default%20(and
22. Program.cs 수정
23. Migration 
  - Add-Migration InitialDatabaseMigration
  - Update-Database