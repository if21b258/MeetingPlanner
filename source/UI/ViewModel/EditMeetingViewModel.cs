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
    public class EditMeetingViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private MeetingService _meetingService;
        private MeetingListViewModel _meetingListViewModel;
        private MeetingPlannerValidation _validation = new MeetingPlannerValidation();
        private MeetingModel _selectedMeeting;
        public ICommand EditMeetingCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action<bool> CloseEvent;

        public EditMeetingViewModel(MeetingListViewModel meetingListViewModel, MeetingService meetingService)
        {
            _meetingService = meetingService;
            _meetingListViewModel = meetingListViewModel;
            _selectedMeeting = _meetingListViewModel.SelectedMeeting;
            EditMeetingCommand = new RelayCommand<object>(EditMeeting);
            CancelCommand = new RelayCommand<object>(Cancel);
            InitializeFields();
        }

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

        //validate changes and edit meeting
        private void EditMeeting(object commandParameter)
        {
            try
            {
                MeetingModel temp = new MeetingModel();
                ApplyChanges(temp);
                if (_validation.ValidateMeetingInput(temp))
                {
                    log.Info("Editing Meeting: " + _selectedMeeting.Title);

                    ApplyChanges(_selectedMeeting);
                    _meetingService.EditMeeting(_selectedMeeting);
                    _meetingListViewModel.LoadMeetings();
                    _meetingListViewModel.OnSelectedMeetingChanged();
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
                log.Warn($"Edit meeting failed: {e.Message}");
            }

        }

        private void InitializeFields()
        {
            _title = _selectedMeeting.Title;
            _from = _selectedMeeting.From;
            _to = _selectedMeeting.To;
            _agenda = _selectedMeeting.Agenda;
        }

        private void ApplyChanges(MeetingModel meeting)
        {
            meeting.Title = _title;
            meeting.From = _from;
            meeting.To = _to;
            meeting.Agenda = _agenda;
        }

        //close window
        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(true);
        }
    }
}
