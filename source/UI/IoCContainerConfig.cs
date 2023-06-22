using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TourPlannerUI.ViewModel;
using TourPlannerDAL;
using TourPlannerBL;

namespace TourPlannerUI
{
    public class IoCContainerConfig
    {
        private readonly ServiceProvider _serviceProvider;

        public IoCContainerConfig()
        {
            var services = new ServiceCollection();

            //DataAccessLayer
            services.AddTransient<TourPlannerDbContext>();

            //BuisnessLayer
            services.AddSingleton<TourService>();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<TourListViewModel>();
            services.AddTransient<AddTourViewModel>();
            services.AddTransient<EditTourViewModel>();
            services.AddSingleton<TourLogViewModel>();
            services.AddTransient<AddTourLogViewModel>();
            services.AddTransient<EditTourLogViewModel>();
            services.AddSingleton<TourRouteViewModel>();
            services.AddSingleton<TourInfoViewModel>();
            services.AddSingleton<MenuViewModel>();
            services.AddSingleton<SearchBarViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public MainViewModel MainViewModel
            => _serviceProvider.GetRequiredService<MainViewModel>();

        public TourListViewModel TourListViewModel
            => _serviceProvider.GetRequiredService<TourListViewModel>();

        public AddTourViewModel AddTourViewModel
            => _serviceProvider.GetRequiredService<AddTourViewModel>();

        public EditTourViewModel EditTourViewModel
            => _serviceProvider.GetRequiredService<EditTourViewModel>();

        public TourLogViewModel TourLogViewModel
            => _serviceProvider.GetRequiredService<TourLogViewModel>();

        public AddTourLogViewModel AddTourLogViewModel
            => _serviceProvider.GetRequiredService<AddTourLogViewModel>();

        public EditTourLogViewModel EditTourLogViewModel
            => _serviceProvider.GetRequiredService<EditTourLogViewModel>();

        public TourRouteViewModel TourRouteViewModel
            => _serviceProvider.GetRequiredService<TourRouteViewModel>();

        public TourInfoViewModel TourInfoViewModel
            => _serviceProvider.GetRequiredService<TourInfoViewModel>();

        public MenuViewModel MenuViewModel
            => _serviceProvider.GetRequiredService<MenuViewModel>();

        public SearchBarViewModel SearchBarViewModel
            => _serviceProvider.GetRequiredService<SearchBarViewModel>();
    }
}
