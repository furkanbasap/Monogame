using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame.Animation;
using Monogame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace Monogame
{
    public class Hero:IGameObject
    {
        Texture2D heroTexture;
        private Rectangle _deelRectangle;
        private int schuifop_X = 0;
        Animation animatie;


        public Hero(Texture2D texture)
        {
            heroTexture = texture;
            _deelRectangle = new Rectangle(schuifop_X, 0, 180, 247);
            animatie = new Animation();
            animatie.AddFrame(new AnimationFrames(new Rectangle(0, 0, 280, 385)));
            animatie.AddFrame(new AnimationFrames(new Rectangle(280, 0, 280, 385)));
            animatie.AddFrame(new AnimationFrames(new Rectangle(560, 0, 280, 385)));
            animatie.AddFrame(new AnimationFrames(new Rectangle(840, 0, 280, 385)));
            animatie.AddFrame(new AnimationFrames(new Rectangle(1120, 0, 280, 385)));


        }

        public void Update()
        {
            animatie.Update();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, new Vector2(10, 10), animatie.CurrentFrame.SourceRectangle, Color.White);
        }
    }

}
