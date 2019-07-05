using System;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace TimeSpeaker
{
    static class Program    
    {
        [STAThread]
        static void Main()
        {
            speakTimeNow();
            Application.Run();
        }
        public static void speakTimeNow()
        {
            new TimeSpeaker().speak(DateTime.Now.ToString("'The time is' hh:mm tt"));
            System.Environment.Exit(0b0);
        }
        public class TimeSpeaker
        {
            public SpeechSynthesizer synth { get; set; }
            public TimeSpeaker()
            {
                synth = new SpeechSynthesizer();
                int random = new Random().Next(synth.GetInstalledVoices().Count);
                VoiceInfo voice = synth.GetInstalledVoices()[random].VoiceInfo;
                synth.SelectVoice(voice.Name);
                synth.Volume = 100;
                synth.Rate = 0;
            }
            public void speak(String text)
            {
                synth.Speak(text);
            }
        }
    }
}
