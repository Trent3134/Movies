using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;


    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ShowEntity, ShowDetail>();
            CreateMap<ShowEntity, ShowListItem>().ReverseMap();

            CreateMap<ShowCreate, ShowEntity>().ReverseMap();
            
        }
    }
