using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MeetingPlannerBL.Logging;
using MeetingPlannerBL.Service;
using MeetingPlannerBL.Util;
using MeetingPlannerModel;

namespace MeetingPlannerUI.ViewModel
{
    public class AddMeetingViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private MeetingListViewModel _meetingListViewModel;
        private MeetingService _meetingService;
        private MeetingPlannerValidation _validation = new MeetingPlannerValidation();

        public ICommand AddMeetingCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action<bool> CloseEvent;

        public AddMeetingViewModel(MeetingListViewModel meetingListViewModel, MeetingService meetingService)
        {
            _meetingListViewModel = meetingListViewModel;
            _meetingService = meetingService;
            AddMeetingCommand = new RelayCommand<object>(AddMeeting);
            CancelCommand = new RelayCommand<object>(Cancel);
        }

        //Title
        private string _title = "";
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }

        //From
        private DateTime _from = DateTime.Now;
        public DateTime From
        {
            get { return _from; }
            set
            {
                _from = value;
            }
        }

        //To
        private DateTime _to = DateTime.Now;
        public DateTime To
        {
            get { return _to; }
            set
            {
                _to = value;
            }
        }

        //Agenda
        private string _agenda = "";
        public string Agenda
        {
            get { return _agenda; }
            set
            {
                _agenda = value;
            }
        }

        //validated meeting and added it to the list of meetings
        private void AddMeeting(object commandParameter)
        {
            try
            {
                MeetingModel meeting = new MeetingModel(_title, _from, _to, _agenda);


                if (_validation.ValidateMeetingInput(meeting))
                {
                    log.Info("Adding Meeting: " + meeting.Title);

                    _meetingService.AddMeeting(meeting);
                    _meetingListViewModel.LoadMeetings();
                    CloseEvent?.Invoke(true);
                }

                else
                {
                    MessageBox.Show("Your input was invalid");
                    throw new ArgumentException("Invalid input");
                }
            }
            catch (Exception e)
            {
                log.Warn($"Add meeting failed: {e.Message}");
            }
        }

        //close the window
        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(false);
        }

    }
}
