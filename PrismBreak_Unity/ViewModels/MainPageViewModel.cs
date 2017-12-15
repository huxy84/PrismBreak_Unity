using Plugin.DeviceInfo;
using Plugin.DeviceInfo.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismBreak_Unity.Models;
using PrismBreak_Unity.Services;

namespace PrismBreak_Unity.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        INavigationService _navigationService;
        IPageDialogService _dialogService;
        ILocationService _locationService;

        public Device DeviceInfo { get; set; }

        public Coordinate CurrentPosition { get; set; }

        public DelegateCommand NavigateEmployeeCommand => new DelegateCommand(async () => { await _navigationService.NavigateAsync("EmployeePage"); });
        public DelegateCommand NavigateToSpeakPageCommand => new DelegateCommand(async () => { await _navigationService.NavigateAsync("SpeakPage"); });
        public DelegateCommand AlertUserCommand => new DelegateCommand(async () => { await _dialogService.DisplayAlertAsync("Alert", "You have been alerted", "OK"); });

        public DelegateCommand AksAQuestionCommand => new DelegateCommand(async () =>
        {
            var answer = await _dialogService.DisplayAlertAsync("Question", "Does Xamarin Forms Rock?", "Yes", "No");

            var clickedAnswer = answer ? "Yes" : "No";

            await _dialogService.DisplayAlertAsync("Answer", "You clicked " + clickedAnswer, "OK");
        });

        public DelegateCommand DisplayActionSheetCommand => new DelegateCommand(async () =>
        {
            var movie = await _dialogService.DisplayActionSheetAsync("What Movie Shall I Play?", "Cancel", null, "Rocky", "Rocky 2", "Rocky 3", "Rocky 4", "Rocky 5", "Rocky 6", "Creed");

            var response = movie == "Rocky 5" ? "Not the best but a good story nonetheless" : "Great Choice!!!!";

            await _dialogService.DisplayAlertAsync(movie, response, "Ok");
        });

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            
            _navigationService = navigationService;

            CurrentPosition = new Coordinate();

            _locationService = Xamarin.Forms.DependencyService.Get<ILocationService>();

            if(_locationService!= null)
            {
                _locationService.MyLocation += _locationService_MyLocation;

                _locationService.GetMyLocation();
            }

            Title = "PRISM Break";

            DeviceInfo = new Device();
        }

        private void _locationService_MyLocation(object sender, ILocationCoordinates e)
        {
            CurrentPosition.Latitude = e.Latitude;
            CurrentPosition.Longitude = e.Longitude;
        }
    }
}