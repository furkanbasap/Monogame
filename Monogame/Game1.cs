using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;            //Graphics renderen
        private SpriteBatch _spriteBatch;                   //2D Graphics, visueel

        private Texture2D _heroTexture;
        private Hero hero;


        public Game1()                                      //Constructor       /1
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }



        protected override void Initialize()                //Initialiseren     /2
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            hero = new Hero(_heroTexture);
        }


        protected override void LoadContent()               //Content Opvragen  /3
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _heroTexture = Content.Load<Texture2D>("Spritesheet");

            InitializeGameObject();
        }

        private void InitializeGameObject()
        {
            hero = new Hero(_heroTexture);
        }

        protected override void Update(GameTime gameTime)   //Hart van app      /Loop tussen Update en Draw
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            hero.Update(gameTime);  


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)     //Changes tekenen   /Loop tussen Update en Draw
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);

            _spriteBatch.End();

            

            base.Draw(gameTime);
        }

        private IInputReader inputReader;
        public void ChangeInput(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }

    }
}
