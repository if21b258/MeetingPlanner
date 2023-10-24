using Microsoft.Extensions.DependencyInjection;
using MeetingPlannerBL.Service;
using MeetingPlannerDAL;
using MeetingPlannerUI.ViewModel;

namespace MeetingPlannerUI
{
    public class IoCContainerConfig
    {
        private readonly ServiceProvider _serviceProvider;

        public IoCContainerConfig()
        {
            var services = new ServiceCollection();

            //DataAccessLayer
            services.AddTransient<MeetingPlannerDbContext>();

            //BuisnessLayer
            services.AddSingleton<MeetingService>();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MeetingListViewModel>();
            services.AddTransient<AddMeetingViewModel>();
            services.AddTransient<EditMeetingViewModel>();
            services.AddSingleton<MeetingNoteViewModel>();
            services.AddTransient<AddMeetingNoteViewModel>();
            services.AddTransient<EditMeetingNoteViewModel>();
            services.AddSingleton<MeetingInfoViewModel>();
            services.AddSingleton<MenuViewModel>();
            services.AddSingleton<SearchBarViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public MainViewModel MainViewModel
            => _serviceProvider.GetRequiredService<MainViewModel>();

        public MeetingListViewModel MeetingListViewModel
            => _serviceProvider.GetRequiredService<MeetingListViewModel>();

        public AddMeetingViewModel AddMeetingViewModel
            => _serviceProvider.GetRequiredService<AddMeetingViewModel>();

        public EditMeetingViewModel EditMeetingViewModel
            => _serviceProvider.GetRequiredService<EditMeetingViewModel>();

        public MeetingNoteViewModel MeetingNoteViewModel
            => _serviceProvider.GetRequiredService<MeetingNoteViewModel>();

        public AddMeetingNoteViewModel AddMeetingNoteViewModel
            => _serviceProvider.GetRequiredService<AddMeetingNoteViewModel>();

        public EditMeetingNoteViewModel EditMeetingNoteViewModel
            => _serviceProvider.GetRequiredService<EditMeetingNoteViewModel>();

        public MeetingInfoViewModel MeetingInfoViewModel
            => _serviceProvider.GetRequiredService<MeetingInfoViewModel>();

        public MenuViewModel MenuViewModel
            => _serviceProvider.GetRequiredService<MenuViewModel>();

        public SearchBarViewModel SearchBarViewModel
            => _serviceProvider.GetRequiredService<SearchBarViewModel>();
    }
}
