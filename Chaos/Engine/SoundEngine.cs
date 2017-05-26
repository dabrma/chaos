using System.Media;
using System.Speech.Synthesis;
using Chaos.Model;
using Chaos.Properties;

namespace Chaos.Engine
{
    public class SoundEngine
    {
        private static readonly SoundPlayer soundPlayer = new SoundPlayer();

        /// <summary>
        ///     Text-to-speech operation on a Monster passed to an argument
        /// </summary>
        /// <param name="source">Monster that is the source of sound</param>
        public static void Speak(Monster source)
        {
            soundPlayer.Stream = Resources.selectionBeep;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
            var synth = new SpeechSynthesizer();
            synth.Rate = -4;
            synth.SpeakAsync(source.Name);
        }

        public static void PlayerName(Player currentPlayer)
        {
            var synth = new SpeechSynthesizer();
            synth.Rate = -4;
            synth.SpeakAsync(currentPlayer.Name);
        }

        public static void SpellAndPlayerName(Player source)
        {
            var synth = new SpeechSynthesizer();
            synth.Rate = -4;
            synth.SpeakAsync(source.Name + "   " + source.SelectedSpell.Caption);
        }

        /// <summary>
        ///     Gets the audio resource by string passed to a parameter and plays it.
        /// </summary>
        /// <param name="sound">
        ///     String with name of an audio resource
        /// </param>
        public static void PlaySound(string sound, bool async = true)
        {
            soundPlayer.Stream = Resources.ResourceManager.GetStream(sound);
            soundPlayer.LoadAsync();
            soundPlayer.Play();
        }
    }
}