using AutoMapper;
using MahalaxmiFuniture.DTOs;
using MahalaxmiFuniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Mapping
{
    public class ModelToDTO : Profile
    {
        public ModelToDTO()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<AccountHead, AccHeadDto>().ReverseMap();
            CreateMap<AccountControl, AccountControlDto>().ReverseMap();
            CreateMap<AccountSubControl, AccountSubControlDto>().ReverseMap();
            CreateMap<FinancialYear, FinancialYearDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
        }
    }
}
