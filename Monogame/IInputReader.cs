using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Monogame
{
    internal interface IInputReader
    {
        Microsoft.Xna.Framework.Vector2 ReadInput();
        public bool IsDestinationInput { get; }

    }
}
