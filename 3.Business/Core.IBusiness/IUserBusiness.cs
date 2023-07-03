using Core.Models;
using Core.ViewModel.Respons;

namespace Core.IBusiness
{
    public interface IUserBusiness : Base.IBaseBusiness<User>
    {

        public Task<User> GetByName(string name);

        public Task<Authority_User> Login(string email, string password);

        public Task<List<string>> GetUserRoles(int id);
    }
}
