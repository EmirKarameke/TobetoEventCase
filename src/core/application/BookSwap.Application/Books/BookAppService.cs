using AutoMapper;
using BookSwap.Application.Contract.Books;
using BookSwap.Application.Contract.Books.Dtos;
using BookSwap.Application.Contract.ServiceTypes;
using BookSwap.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSwap.Application.Books
{
    public class BookAppService : IBookAppService
    {
        IBookRepository bookRepository;
        IMapper mapper;
        public BookAppService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;

        }
        public async Task<ServiceResponse<bool>> AddBookAsync(AddBookDto addBookDto)
        {
            var result = new ServiceResponse<bool>();
            var book = mapper.Map<Book>(addBookDto);
            try
            {
                var addedBook = await bookRepository.AddAsync(book);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResponse<List<Book>>> GetBookListAsync()
        {
            var result = new ServiceResponse<List<Book>>();
            try
            {
            var bookList = await bookRepository.GetAllAsync();
            var books = mapper.Map<List<Book>>(bookList);
            result.Success = true;
            result.Data = books;
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
