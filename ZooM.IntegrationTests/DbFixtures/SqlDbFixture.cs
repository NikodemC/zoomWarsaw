using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ZooM.Infrastructure.Databases.NHibernate.Entities;

namespace ZooM.IntegrationTests.DbFixtures
{
    public class SqlDbFixture : IDisposable
    {
        private readonly SqlConnection _connection;
        public SqlDbFixture()
        {
            _connection = new SqlConnection("Server=localhost; Database=BazaNikodem; User Id=sa; Password=<YourStrong!Passw0rd>");
            _connection.Open();
            CreateDatabase().GetAwaiter().GetResult();
            CreateTables().GetAwaiter().GetResult();
        }

        public async Task CreateDatabase()
        {
            await _connection.ExecuteAsync("CREATE DATABASE [ZooMTest]");
            _connection.ChangeDatabase("ZooMTest");
        }

        public async Task CreateTables()
        {
            var SqlQuery = @"CREATE TABLE [dbo].[EmployeeEntity](
	            [Id] [uniqueidentifier] NOT NULL,
	            [Avatar] [nvarchar](255) NULL,
	            [Name] [nvarchar](255) NULL,
	            [Position] [nvarchar](255) NULL,
	            [YearOfBirth] [int] NULL,
	            [IsDeleted] [char](1) NULL,
                PRIMARY KEY CLUSTERED 
                (
                	[Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]";

            await _connection.ExecuteAsync(SqlQuery);
        }

        public async Task DropDatabase()
        {
            _connection.ChangeDatabase("master");
            await _connection.ExecuteAsync("DROP DATABASE [ZooMTest]");
        }

        internal Task CreateEmployeeAsync(EmployeeEntity employeeEntity)
            => _connection.ExecuteAsync(
                @"INSERT INTO [dbo].[EmployeeEntity]([Id], [Avatar], [Name], [Position], [YearOfBirth]) VALUES (@Id, @Avatar, @Name, @Position, @YearOfBirth)", employeeEntity);

        internal Task<EmployeeEntity> GetEmployeeAsync(Guid id)
            => _connection.QueryFirstOrDefaultAsync<EmployeeEntity>(
                "SELECT e.Id, e.Avatar, e.Name, e.Position, e.YearOfBirth FROM dbo.[EmployeeEntity] e WHERE e.Id = @Id", new { Id = id });

        internal Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync()
            => _connection.QueryFirstOrDefaultAsync<IEnumerable<EmployeeEntity>>(
                "SELECT  e.Id, e.Avatar, e.Name, e.Position, e.YearOfBirth FROM dbo.[EmployeeEntity]");

        internal void ClearTable()
            => _connection.Execute(
                @"DELETE FROM [dbo].[EmployeeEntity]");

        public void Dispose()
        {
            DropDatabase().GetAwaiter().GetResult();
            _connection.Dispose();
        }
    }
}
