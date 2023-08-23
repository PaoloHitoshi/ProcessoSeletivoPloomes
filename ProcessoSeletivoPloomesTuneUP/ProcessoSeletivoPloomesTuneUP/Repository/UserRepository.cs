using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoPloomesTuneUP.Data;
using ProcessoSeletivoPloomesTuneUP.Models;
using ProcessoSeletivoPloomesTuneUP.Repository.Interfaces;

namespace ProcessoSeletivoPloomesTuneUP.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TuneUPDBContext _dbContext;

        public UserRepository(TuneUPDBContext tuneUPDBContext) 
        { 
            _dbContext = tuneUPDBContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<List<UserModel>> GetAllAdultUsers()
        {
            var query = "SELECT * FROM Users WHERE DATEDIFF(YEAR, Date_Of_Birth, GETDATE()) >= 18";

            var listOfUsers = _dbContext.Users.FromSqlRaw(query).ToList<UserModel>();

            return listOfUsers;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> PostUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> PutUser(UserModel user, int id)
        {
            UserModel updateUser = await GetUserById(id);

            if (updateUser == null)
            {
                throw new Exception($"User ID: {id} not found on database.");
            }

            updateUser.Name = user.Name;
            updateUser.Email = user.Email;
            updateUser.Gender = user.Gender;
            updateUser.Password = user.Password;
            updateUser.Date_Of_Birth = user.Date_Of_Birth;

            _dbContext.Users.Update(updateUser);
            await _dbContext.SaveChangesAsync();

            return updateUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel removeUser = await GetUserById(id);

            if (removeUser == null)
            {
                throw new Exception($"User ID: {id} not found on database.");
            }

            _dbContext.Users.Remove(removeUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
