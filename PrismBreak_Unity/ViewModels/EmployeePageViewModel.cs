using Prism.Mvvm;
using Prism.Navigation;

namespace PrismBreak_Unity.ViewModels
{
    public class EmployeePageViewModel : ViewModelBase
    {
        public EmployeePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Dialog Employees";
        }
    }
}