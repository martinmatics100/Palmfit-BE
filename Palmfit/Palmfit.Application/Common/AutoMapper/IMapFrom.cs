

using AutoMapper;

namespace Palmfit.Application.Common.AutoMapper
{
    public interface IMapFrom<T>
    {
        void Mappings(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
