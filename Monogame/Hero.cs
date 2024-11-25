using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
    public class Hero : IGameObject, IMovable
    {
        private Texture2D heroTexture;
        private Rectangle _deelRectangle;
        private int schuifOp_X = 0;
        private Animations animatie;


        private Vector2 position;
        public Vector2 Position
        { set { this.position = Position; } get { return this.position; } }


        private Vector2 speed;
        public Vector2 Speed
        { set{this.speed = Speed;} get{return this.speed;} }

        private IInputReader inputReader;
        public IInputReader InputReader
        { set { this.inputReader = InputReader; } get { return this.inputReader; } }


        public Hero(Texture2D texture)
        {
            this.heroTexture = texture;
            animatie = new Animations();
            animatie.GetFramesFromTextureProperties
           (texture.Width, texture.Height, 5, 2);


        }

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;
            this.inputReader = inputReader;
            animatie = new Animations();
            position = new Vector2(1, 1);
            speed = new Vector2(2, 2);
            versnelling = new Vector2(0.1f, 0.1f);
        }


        public void Update(GameTime gameTime)
        {

            Move();
            //MovewithMouse();
            animatie.Update(gameTime);


        }


        private Vector2 versnelling = new Vector2(0.1f, 0.1f);


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position, animatie.CurrentFrame.SourceRectangle, Color.White);

        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        MovementManager movementManager = new MovementManager();

        private void Move()
        {
            //positie += snelheid;
            //snelheid += versnelling;
            //float maximaleSnelheid = 10;
            //snelheid = Limit(snelheid, maximaleSnelheid);
            //if (positie.X > 800 - 130
            //    || positie.X < 0)
            //{
            //    snelheid.X *= -1;
            //    //snelheid = new Vector2(snelheid.X < 0 ? 1 : -1, snelheid.Y);
            //    versnelling.X *= -1;
            //}
            //if (positie.Y > 480 - 100
            //    || positie.Y < 0)
            //{
            //    snelheid.Y *= -1;
            //    //snelheid = new Vector2(snelheid.X, snelheid.Y < 0 ? 1 : -1);
            //    versnelling.Y *= -1;
            //}



            movementManager.Move(this);


        }


        private void MoveWithMouse()
        {
            MouseState state = Mouse.GetState();
            Vector2 mouseVector = new Vector2(state.X, state.Y);

            var richting = mouseVector - Position;
            richting.Normalize();
            richting = Vector2.Multiply(richting, 0.1f);
            Speed += richting;
            Speed = Limit(Speed, 10);
            Position += Speed;

        }

        public void ChangeInput(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }


        public Vector2 ReadInput()
        {
            throw new NotImplementedException();
        }


        public bool IsDestinationInput => throw new NotImplementedException();

        
    }
}
