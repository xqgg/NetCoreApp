using Core.Common.Filter;
using Core.IBusiness;
using Core.Models;
using Core.ViewModel.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness userBusiness;


        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ResultModel> GetById(int id)
        {
            string jwtv = User.FindFirst("jwtv")?.Value;


            ResultModel result = new ResultModel() { Code = ResultCode.SUCCESS, Info = "成功" };
            try
            {
                var user = await userBusiness.GetById(id);
            }
            catch (Exception ex)
            {
                result.Code = ResultCode.FAIL;
                result.Info = ex.Message;
            }
            return result;
        }


        [HttpPost]
        public async Task<ResultModel> Add([FromBody] AddUserRequest addUser)
        {
            ResultModel result = new ResultModel() { Code = ResultCode.SUCCESS, Info = "成功" };

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                result.Count = errors.Count();
                result.Data = errors;

                return result;
                foreach (var error in errors)
                {
                    // 处理错误信息
                    Console.WriteLine(error.ErrorMessage);

                }
            }




            if (await userBusiness.GetByName(addUser.Name) != null)
            {
                result.Code = ResultCode.REPEAT_DATA;
                result.Info = "用户名已存在";
                return result;
            }
            User user = new User()
            {
                Name = addUser.Name,
                Email = addUser.Email,
                Password = addUser.Password,
                PhoneNumber = addUser.PhoneNumber
            };
            int count = await userBusiness.Add(user);
            if (count > 0)
            {
                result.Count = count;
            };

            return result;
        }

    }
}
