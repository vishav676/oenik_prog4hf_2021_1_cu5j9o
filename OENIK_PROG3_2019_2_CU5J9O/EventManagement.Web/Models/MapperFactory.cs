namespace EventManagement.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;

    /// <summary>
    /// This class help to convert entity model to web model.
    /// </summary>
    public class MapperFactory
    {

        /// <summary>
        /// This method created the IMapper object from Enitity model to web model.
        /// </summary>
        /// <returns><see cref="IMapper"/>.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.Models.Guest, Web.Models.Guest>()
                .ForMember(dest => dest.ID, map => map.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email))
                .ForMember(dest => dest.Contact, map => map.MapFrom(src => src.Contact))
                .ForMember(dest => dest.City, map => map.MapFrom(src => src.City))
                .ForMember(dest => dest.Gender, map => map.MapFrom(src => src.Gender));
            });

            return config.CreateMapper();
        }
    }
}
