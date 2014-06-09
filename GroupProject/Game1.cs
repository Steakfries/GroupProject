using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        bool GameRunning = true;
        bool GameLose;
        bool GameWin;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Collision collision = new Collision();

        Sprites test = new Sprites(1280, 720, 1f);  // Create new Sprite/Player

        Player player = new Player(50, 50, 1f);
        Sprites wall = new Sprites(50, 50, 1f);
        Sprites win = new Sprites(1280, 720, 1f);
        Sprites lose = new Sprites(1280, 720, 1f);
        Sprites cursor = new Sprites(11, 19, 1f);
        Text score = new Text();    // Create Text
        Grid Level = new Grid(10,10);
        AI_MainFrame[] AITest;
        Intel Intelligence = new Intel(1, 1, 1f);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            graphics.PreferredBackBufferWidth = 1280;   // Set Screen X
            graphics.PreferredBackBufferHeight = 720;   // Set Screen Y
            wall.Position = new Vector2(400, 400);
            player.Position = new Vector2(50, 50);
            Intelligence.Position = new Vector2(50, 300);

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Level.LoadGrid();
            Level.MakeSprite();
            AITest = new AI_MainFrame[3];
            AITest[0] = new AI_MainFrame(new Vector2(8,4), new Vector2(8,8), new Vector2(8,3), Level);
            AITest[1] = new AI_MainFrame(new Vector2(1,4), new Vector2(5,4), new Vector2(2,4), Level);
            AITest[2] = new AI_MainFrame(new Vector2(4, 6), new Vector2(4, 8), new Vector2(4, 7), Level);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here


            Intelligence.tex = Content.Load<Texture2D>("Sprites/Intel");
            win.tex = Content.Load<Texture2D>("Sprites/win");
            lose.tex = Content.Load<Texture2D>("Sprites/lose");

            wall.tex = Content.Load<Texture2D>("Sprites/Wsquare");
            cursor.tex = Content.Load<Texture2D>("Sprites/cursor");
            player.tex = Content.Load<Texture2D>("Sprites/Gcircle");
            player.bullet.tex = Content.Load<Texture2D>("Sprites/Gbullet");
            score.font = Content.Load<SpriteFont>("Fonts/Score"); // Use the name of your sprite font file here instead of 'Score'.
            for (int j = 0; j < 3; j++)
            {
                AITest[j].AISprite.tex = Content.Load<Texture2D>("Sprites/Rcircle");
            }
            for (int i = 0; i < Level.GridSprites.Length; i++)
            {
                Level.GridSprites[i].tex = Content.Load<Texture2D>("Sprites/Wsquare");
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            base.Update(gameTime);

            Vector2 oldPos = new Vector2(player.Position.X, player.Position.Y); // Position for the player
            for (int j = 0; j < 3; j++)
            {
                AITest[j].Patrol();
                AITest[j].AISprite.Update();
                if (Collision.CheckCollision(player, AITest[j].AISprite)) // Check collision for player and wall
                { 
                    GameRunning = false;
                    GameLose = true;
                }
            }

            player.Update(Level);
            cursor.Position = new Vector2(player.MouseX, player.MouseY);
            for (int i = 0; i < Level.GridSprites.Length; i++)
            {
                if (Collision.CheckCollision(player, Level.GridSprites[i])) // Check collision for player and wall
                {
                    player.Position = oldPos;
                }
                if (Collision.CheckCollision(player.bullet, Level.GridSprites[i]))
                {
                    player.isShot = false;
                }
            }

            if (Intelligence.IsCaptured == false)
            {
                if (Collision.CheckCollision(player, Intelligence))
                 {
                    
                    Intelligence.IsCaptured = true;                 
                    score.score++;
                    GameRunning = false;
                    GameWin = true;

                 }
            } 
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);
            KeyboardState newState = Keyboard.GetState();  // Check for keyboard input

            spriteBatch.Begin();
            if (GameRunning)
            {
                // TODO: Add your drawing code here
                
                player.Draw(spriteBatch);


                if (player.isShot)
                {
                    player.bullet.Draw(spriteBatch);
                }


                for (int j = 0; j < 3; j++)
                {
                    AITest[j].AISprite.Draw(spriteBatch);
                }

                //wall.Draw(spriteBatch);

                for (int i = 0; i < Level.GridSprites.Length; i++)
                {
                    Level.GridSprites[i].Draw(spriteBatch);
                }

                if (Intelligence.IsCaptured == false)
                {

                    Intelligence.Draw(spriteBatch);
                }


            if (Intelligence.IsCaptured == false)
            {
                Intelligence.Draw(spriteBatch);
            }

            cursor.Draw(spriteBatch);


                score.Draw(spriteBatch);

                base.Draw(gameTime);
            }
            if (GameWin)
            {
                win.Draw(spriteBatch);
                player.Position = new Vector2(50, 50);
                Intelligence.IsCaptured = false;
                score.score = 0;
                if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.Y))
                {
                    GameWin = false;
                    GameRunning = true;
                }

                if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.N))
                {
                    GameLose = false;
                    Exit();
                }
            }
            if (GameLose)
            {
                lose.Draw(spriteBatch);
                player.Position = new Vector2(50, 50);
                Intelligence.IsCaptured = false;
                score.score = 0;
                if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.Y))
                {
                    GameLose = false;
                    GameRunning = true;
                }

                if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.N))
                {
                    GameLose = false;
                    Exit();
                }
            }
            spriteBatch.End();
        }
    }
}
