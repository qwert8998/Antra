using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public class MovieShopMappingProfile : Profile
    {
        public MovieShopMappingProfile()
        {
            // Request Models to Db Entities Mappings
            CreateMap<PurchaseRequestModel, Purchase>();
        }
    }
}
