using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Animation
{
    public class Animations
    {
        public AnimationFrames CurrentFrame { get; set; }

        private List<AnimationFrames> frames;

        private int counter;

        public Animations()
        {
            frames = new List<AnimationFrames>();
        }

        public void AddFrame(AnimationFrames animationFrames)
        {
            frames.Add(animationFrames);
            CurrentFrame = frames[0];        
        }

        private double secondCounter = 0;

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 15;
            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;
            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    frames.Add(new AnimationFrames(
                   new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
        }
    }
}
