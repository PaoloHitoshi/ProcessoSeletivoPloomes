using ProcessoSeletivoPloomesTuneUP.Models;

namespace ProcessoSeletivoPloomesTuneUP.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> PostUser(UserModel user);
        Task<UserModel> PutUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
    }
}
