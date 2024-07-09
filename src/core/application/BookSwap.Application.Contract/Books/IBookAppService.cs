using BookSwap.Application.Contract.Books.Dtos;
using BookSwap.Application.Contract.ServiceTypes;
using BookSwap.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSwap.Application.Contract.Books
{
    public interface IBookAppService
    {
        Task<ServiceResponse<bool>> AddBookAsync(AddBookDto addBookDto);
        Task<ServiceResponse<List<Book>>> GetBookListAsync();
    }
}
