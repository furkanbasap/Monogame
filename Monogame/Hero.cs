using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame.Animation;
using Monogame.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;



namespace Monogame
{
    public class Hero : IGameObject
    {
        private Texture2D heroTexture;
        private Rectangle _deelRectangle;
        private int schuifOp_X = 0;
        private Animations animatie;


        public Hero(Texture2D texture)
        {
            this.heroTexture = texture;
            animatie = new Animations();
            animatie.GetFramesFromTextureProperties
           (texture.Width, texture.Height, 5, 2);


        }

        public void Update(GameTime gameTime)
        {
            animatie.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, new Vector2(10, 10), animatie.CurrentFrame.SourceRectangle, Color.White);
        }
    }

}
