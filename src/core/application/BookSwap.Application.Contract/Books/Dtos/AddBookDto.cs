using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSwap.Application.Contract.Books.Dtos;

public class AddBookDto
{
    public string ISBNNo { get; set; }
    public string BookName { get; set; }
    public string Summary { get; set; }
    public string Writer { get; set; }
    public string imageUrl { get; set; }
    public int NumberOfCopies { get; set; }
    public int NumberOfPages { get; set; }
    public decimal UnitPrice { get; set; }
    public string Category { get; set; }
}
