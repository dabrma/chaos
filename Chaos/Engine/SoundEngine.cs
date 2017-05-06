using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chaos.Model;

namespace Chaos.Engine
{
    class SoundEngine
    {
        private static SoundPlayer soundPlayer = new SoundPlayer();
        
        /// <summary>
        /// Says the name of a monster after clicking on it
        /// </summary>
        /// <param name="source">Monster that is the source of sound</param>
        public static void say(Monster source)
        {
            soundPlayer.Stream = Properties.Resources.selectionBeep;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Rate = -4;
            synth.SpeakAsync(source.Name);
        }

        /// <summary>
        /// Text-to-speech operation on the string passed to an argument
        /// </summary>
        /// <param name="source">Speakable text/param>
        public static void say(string source)
        {
            soundPlayer.Stream = Properties.Resources.selectionBeep;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Rate = -4;
            synth.SpeakAsync(source);
        }

         /*
         * TODO: Look if there is a pattern, that supports a scenarion, where we create only one method
         * and it takes care of playing sounds based on place it's used from / caller method.
         */
        public static void playStepSound()
        {
            soundPlayer.Stream = Properties.Resources.MovementSound;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
        }

        public static void playAttackSound()
        {
            soundPlayer.Stream = Properties.Resources.fighting;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
        }

        public static void playAttackMoveSound()
        {
            soundPlayer.Stream = Properties.Resources.combatMove;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
        }

        public static void playUndeadAttackSound()
        {
            soundPlayer.Stream = Properties.Resources.wrongTarget;
            soundPlayer.LoadAsync();
            soundPlayer.Play();
        }

    }
}
