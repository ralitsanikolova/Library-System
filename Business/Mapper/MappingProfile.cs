using AutoMapper;
using DataAccess.Data;
using ModelsDTO;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Section, SectionDTO>().ReverseMap();
            CreateMap<LibraryUnit, LibraryUnitDTO>().ReverseMap();
            CreateMap<BookImage, BookImageDTO>().ReverseMap();
            CreateMap<MovementOfUnit, MovementOfUnitDTO>().ReverseMap();
        }
    }
}