using AutoMapper;
using BookSwap.Application.Contract.Books.Dtos;
using BookSwap.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSwap.Application.Books.MapProfiles
{
    public class BookMapProfile : Profile
    {
        public BookMapProfile()
        { 
            CreateMap<AddBookDto,Book>().ReverseMap();
        }
    }
}
