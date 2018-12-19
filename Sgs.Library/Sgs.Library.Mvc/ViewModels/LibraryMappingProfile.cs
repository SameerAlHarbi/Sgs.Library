using AutoMapper;
using Sgs.Library.Model;

namespace Sgs.Library.Mvc.ViewModels
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}
