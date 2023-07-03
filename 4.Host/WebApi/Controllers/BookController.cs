using Core.Common.Filter;
using Core.IBusiness;
using Core.Models;
using Core.ViewModel.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Authorize]

    public class BookController : ControllerBase
    {
        private readonly IBookBusiness _bookBusiness;
        public BookController(IBookBusiness bookBusiness)
        {

            _bookBusiness = bookBusiness;
        }


        [HttpGet("{id}")]
        public async Task<ResultModel> GetById(int id)
        {
            ResultModel result = new ResultModel() { Code = ResultCode.SUCCESS, Info = "成功" };
            try
            {

                var book = await _bookBusiness.GetById(id);
                if (book != null)
                {
                    result.Data = book;
                }
                else
                {
                    result.Code = ResultCode.NO_DATA;
                }

            }
            catch (Exception ex)
            {
                result.Code = ResultCode.FAIL;
                result.Info = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultModel> Add(AddBookRequest viewModel)
        {
            ResultModel result = new ResultModel() { Code = ResultCode.SUCCESS, Info = "成功" };

            var model = new Book()
            {
                Title = viewModel.Title,
                Author = viewModel.Author,
                Price = viewModel.Price
            };

            try
            {
                result.Count = await _bookBusiness.Add(model);
            }
            catch (Exception ex)
            {
                result.Code = ResultCode.FAIL;
                result.Info = ex.Message;
            }
            return result;
        }



        [HttpGet]
        public async Task<ResultModel> GetPage(int pageSize, int pageNumber)
        {
            ResultModel result = new ResultModel() { Code = ResultCode.SUCCESS, Info = "成功" };

            try
            {
                var datas = await _bookBusiness.GetPage(pageSize, pageNumber);
                result.Data = datas;
                result.Count = datas.Books.Count;




            }
            catch (Exception ex)
            {
                result.Code = ResultCode.FAIL;
                result.Info = ex.Message;
            }

            return result;
        }

    }
}
