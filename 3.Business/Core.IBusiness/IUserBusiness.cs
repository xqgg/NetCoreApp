using Core.Model;
using Core.ViewModel.Respons;

namespace Core.IBusiness
{
    public interface IUserBusiness : Base.IBaseBusiness<User>
    {

        public Task<User> GetByName(string name);


    }
}
