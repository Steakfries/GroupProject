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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Collision collision = new Collision();
        Sprites test = new Sprites(1280, 720, 1f);  // Create new Sprite/Player
        Player player = new Player(50, 50, 1f);
        Sprites wall = new Sprites(50, 50, 1f);
        Sprites cursor = new Sprites(20, 20, 1f);
        Text score = new Text();    // Create Text
        Grid Level = new Grid(10,10);
        AI_MainFrame[] AITest;

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
            test.tex = Content.Load<Texture2D>("Sprites/back"); // Load Sprite image
            wall.tex = Content.Load<Texture2D>("Sprites/Wsquare");
            cursor.tex = Content.Load<Texture2D>("Sprites/cursor");
            player.tex = Content.Load<Texture2D>("Sprites/Gcircle");
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
            }
            
            player.Update();
            cursor.Position = new Vector2(player.MouseX, player.MouseY);

            if (Collision.CheckCollision(player, wall)) // Check collision for player and wall
            {
                player.Position = oldPos;
            }
            if (Collision.CheckCollision(player, AITest.AISprite)) // Check collision for player and wall
            {
                player.isDead = true;
                
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            test.Draw(spriteBatch); // Call sprites own draw function

            player.Draw(spriteBatch);

            for (int j = 0; j < 3; j++)
            {
                AITest[j].AISprite.Draw(spriteBatch);
            }

            //wall.Draw(spriteBatch);

            for (int i = 0; i < Level.GridSprites.Length; i++)
            {
                Level.GridSprites[i].Draw(spriteBatch);
            }

            cursor.Draw(spriteBatch);

            score.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
