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
                cfg.CreateMap<Users, UserDTO>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.ID))
               .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.USERNAME))
               .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.PASS))
               .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.EMAIL))
               .ReverseMap();
            }
           );
        }
    }
}
