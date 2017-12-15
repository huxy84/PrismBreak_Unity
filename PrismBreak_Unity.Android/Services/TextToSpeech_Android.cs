using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Views;
using Android.Widget;
using PrismBreak_Unity.Droid.Services;
using PrismBreak_Unity.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeech_Android))]
namespace PrismBreak_Unity.Droid.Services
{
    public class TextToSpeech_Android : Java.Lang.Object, PrismBreak_Unity.Services.ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech speaker;
        private string toSpeak;

        void TextToSpeech.IOnInitListener.OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }

        public void Speak(string text)
        {
            var c = Forms.Context;

            toSpeak = text;

            if (speaker == null)
            {
                speaker = new TextToSpeech(c, this);
            }
            else
            {
                speaker.Speak(text, QueueMode.Flush, null, null);
            }
        }
    }
}