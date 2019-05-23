using AutoMapper;

namespace Inter.Core.App.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingsProfile>();
            });
        }
    }
}
