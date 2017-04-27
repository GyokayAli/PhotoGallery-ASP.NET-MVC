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
            }
           );
        }
    }
}
