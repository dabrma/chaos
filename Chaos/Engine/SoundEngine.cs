using System.Media;
using System.Speech.Synthesis;
using Chaos.Model;
using Chaos.Properties;

namespace Chaos.Engine
{
    internal class SoundEngine
    {
        private static readonly SoundPlayer soundPlayer = new SoundPlayer();

        /// <summary>
        ///     Says the name of a monster after clicking on it
        /// </summary>
        /// <param name="source">Monster that is the source of sound</param>
        public static void say(Monster source)
        {
            soundPlayer.Stream = Resources.selectionBeep;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
            var synth = new SpeechSynthesizer();
            synth.Rate = -4;
            synth.SpeakAsync(source.Name);
        }


        /// <summary>
        ///     Text-to-speech operation on the string passed to an argument
        /// </summary>
        /// <param name="source">Speakable text/param>
        public static void say(string source)
        {
            soundPlayer.Stream = Resources.selectionBeep;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
            var synth = new SpeechSynthesizer();
            synth.Rate = -4;
            synth.SpeakAsync(source);
        }

        /*
         * TODO: Look if there is a pattern, that supports a scenarion, where we create only one method
         * and it takes care of playing sounds based on place it's used from / caller method.
         */
        public static void playStepSound()
        {
            soundPlayer.Stream = Resources.MovementSound;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
        }

        public static void playAttackSound()
        {
            soundPlayer.Stream = Resources.fighting;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
        }

        public static void playAttackMoveSound()
        {
            soundPlayer.Stream = Resources.combatMove;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
        }

        public static void playUndeadAttackSound()
        {
            soundPlayer.Stream = Resources.wrongTarget;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
        }
    }
}