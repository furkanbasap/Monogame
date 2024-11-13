using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Animation
{
    public class Animation
    {
        public AnimationFrames CurrentFrame { get; set; }

        private List<AnimationFrames> frames;

        private int counter;

        public Animation()
        {
            frames = new List<AnimationFrames>();
        }

        public void AddFrame(AnimationFrames animationFrames)
        {
            frames.Add(animationFrames);
            CurrentFrame = frames[0];        }

        public void Update()
        {
            CurrentFrame = frames[counter];
            counter++;

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
    }
}
