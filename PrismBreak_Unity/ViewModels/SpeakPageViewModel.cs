using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismBreak_Unity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PrismBreak_Unity.ViewModels
{
    public class SpeakPageViewModel : ViewModelBase
    {
        private ITextToSpeech _textToSpeech;

        private string _textToSay = "Let's make a break from our current MVVM Framework for PRISM!";
        public string TextToSay
        {
            get { return _textToSay; }
            set { SetProperty(ref _textToSay, value); }
        }

        public DelegateCommand SpeakCommand { get; set; }

        public SpeakPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _textToSpeech = DependencyService.Get<ITextToSpeech>();
            SpeakCommand = new DelegateCommand(() => _textToSpeech.Speak(TextToSay));
        }
    }
}