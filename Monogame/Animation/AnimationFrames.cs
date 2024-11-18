using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Animation
{
    public class AnimationFrames
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrames(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }

    }
}
