namespace Infrastructure
{
    using AutoMapper;
    using DataAccess;
    using Common.DTO;

    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(
            cfg =>
            {
                cfg.CreateMap<User, UserDTO>()
                   .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.ID))
                   .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FIRST_NAME))
                   .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LAST_NAME))
                   .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.PASS))
                   .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.EMAIL))
                   .ReverseMap();

                cfg.CreateMap<Album, AlbumDTO>()
                   .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.ID))
                   .ForMember(dest => dest.AlbumImage, opts => opts.MapFrom(src => src.ALBUM_IMG))
                   .ForMember(dest => dest.AlbumName, opts => opts.MapFrom(src => src.ALBUM_NAME))
                   .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.USER_ID))
                   .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.CATEGORY_ID))
                   .ReverseMap();
            }
           );
        }
    }
}
