using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.API.Model;
using AutoMapper;

namespace Advertise.API.Services
{
    public class AdvertProfile:Profile
    {
        public AdvertProfile()
        {
            CreateMap<AdvertModel, AdvertDBModel>();
        }
       
    }
}
