using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TourPlannerUI.ViewModel;
using TourPlannerDAL;

namespace TourPlannerUI
{
    public class IoCContainerConfig
    {
        private readonly ServiceProvider _serviceProvider;

        public IoCContainerConfig()
        {
            var services = new ServiceCollection();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<TourListViewModel>();
            services.AddTransient<AddTourViewModel>();
            services.AddTransient<EditTourViewModel>();
            services.AddSingleton<TourLogViewModel>();
            services.AddTransient<AddTourLogViewModel>();
            services.AddTransient<EditTourLogViewModel>();
            services.AddSingleton<SearchBarViewModel>();

            //DAL
            services.AddSingleton<DatabaseService>();

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

        public SearchBarViewModel SearchBarViewModel
            => _serviceProvider.GetRequiredService<SearchBarViewModel>();

        public DatabaseService DatabaseService
            => _serviceProvider.GetRequiredService<DatabaseService>();
    }
}
