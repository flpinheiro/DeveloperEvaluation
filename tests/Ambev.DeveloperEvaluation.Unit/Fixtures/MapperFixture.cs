using AutoMapper;

namespace Ambev.DeveloperEvaluation.Unit.Fixtures;

internal static class MapperFixture
{
    public static IMapper CreateMapper(params Profile[] profiles)
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            profiles.ToList().ForEach(profile => cfg.AddProfile(profile));
        });
        return configuration.CreateMapper();
    }
}
