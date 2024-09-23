using AutoMapper;
using shoptask.Models;
using shoptask.Models.DTO;

namespace shoptask
{
    public class MappingConf:Profile
    {
        public MappingConf()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
