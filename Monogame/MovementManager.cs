using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Monogame
{
    internal class MovementManager
    {
        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationalInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            var afstand = direction * movable.Speed;
            var toekomstigePositie = movable.Position + afstand;
            movable.Position = toekomstigePositie;
            movable.Position += afstand;
        }

    }


}
}
