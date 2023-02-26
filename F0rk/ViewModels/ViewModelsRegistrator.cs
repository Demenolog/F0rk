using Microsoft.Extensions.DependencyInjection;

namespace F0rk.ViewModels
{
    internal static class ViewModelsRegistrator
    {
        public static IServiceCollection AddViewModel(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>();
    }
}