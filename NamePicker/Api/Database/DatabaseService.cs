using Microsoft.EntityFrameworkCore;
using NamePicker.Entities;

namespace NamePicker.Api.Database
{
    public class DatabaseService
    {
        private readonly ApplicationDbContext? _dbContext;

        public DatabaseService(ApplicationDbContext? database)
        {
            _dbContext = database;
        }

        //public void GetUsers()
        //{
        //    _dbContext!.Database.ExecuteSqlRaw("EXEC GetNames");
        //    var result = _dbContext.GetUsers.;
        //    _dbContext.SaveChanges();
        //}

        public async Task<List<User>> GetUsersAsync()
        {
            var userList = new List<User>();

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "GetNames";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                _dbContext.Database.OpenConnection();

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (await result.ReadAsync())
                    {
                        var user = new User
                        {
                            Id = result.GetInt32(0),
                            UserId = result.GetInt32(1),
                            FullName = result.GetString(2),
                            JiraDashboardUrl = result.GetString(3)
                        };
                        userList.Add(user);
                    }
                }
                _dbContext.Database.CloseConnection();
            }

            return userList;
        }
    }
}