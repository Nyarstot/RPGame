using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace RPGame
{
    public class AddSound
    {
        public string SoundName = "";

        public AddSound(string SoundName)
        {
            SoundPlayer Sound = new SoundPlayer("Sound\\"+SoundName);

            Sound.Play();
        }
    }
}
