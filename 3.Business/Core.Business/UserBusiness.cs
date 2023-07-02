using Core.Enum;
using Core.IBusiness;
using Core.IBusiness.Base;
using Core.Model;
using Core.Service.Context;
using Core.ViewModel.Respons;
using Microsoft.EntityFrameworkCore;

namespace Core.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly NCDbContext context;

        public UserBusiness(NCDbContext dbContext)
        {

            context = dbContext;

        }

        public async Task<int> Add(params User[] items)
        {

            await context.Users.AddRangeAsync(items);
            return await context.SaveChangesAsync();
        }

        public Task<bool> Delete(params int[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Enable(int id, EnumEnable enable)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int id)
        {
            var user = await context.Users.SingleAsync(u => u.ID == id);
            return user;
        }

        public async Task<User> GetByName(string name)
        {

            var user = await context.Users.SingleOrDefaultAsync(u => u.Name == name);

            return user;
        }

        public async Task<List<string>> GetUserRoles(int id)
        {
            var user = await GetById(id);

            return user.Roles.Split(",").ToList();
        }

        public async Task<Authority_User> Login(string email, string password)
        {

            try
            {
                User user = await context.Users.SingleAsync(u => u.Email == email && u.Password == password);

                Authority_User authority_User = new Authority_User()
                {
                    ID = user.ID,
                    Account = user.Email,
                    Password = password
                };

                return authority_User;
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        public Task<bool> Update(params User[] items)
        {
            throw new NotImplementedException();
        }
    }
}
