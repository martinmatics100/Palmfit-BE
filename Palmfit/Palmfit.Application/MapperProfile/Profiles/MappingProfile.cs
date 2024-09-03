using AutoMapper;
using System.Reflection;
using System.Linq;

namespace Palmfit.Application.MapperProfile.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        }

        public static void RegisterProfiles(IMapperConfigurationExpression config)
        {
            var profiles = Assembly.GetExecutingAssembly().GetExportedTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .ToList();

            foreach (var profile in profiles)
            {
                config.AddProfile((Profile)Activator.CreateInstance(profile)!);
            }
        }
    }
}
