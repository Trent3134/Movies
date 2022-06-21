using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

public class Mapper : Profile
    {
        public Mapper()
        {
        CreateMap<MovieEntity, MovieDetail>().ReverseMap();
        CreateMap<MovieEntity, MovieListItem>().ReverseMap();
        CreateMap<MovieCreate, MovieEntity>().ReverseMap();
        CreateMap<ShowEntity, ShowListItem>().ReverseMap();
        CreateMap<ShowEntity, ShowDetail>().ReverseMap();
       
       // CreateMap<GenreType, MovieDetail>().ReverseMap();
            
        }
    }
