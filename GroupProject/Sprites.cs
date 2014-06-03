using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject
{
    class Sprites
    {
        #region Variables

        public Texture2D tex;   // Texture
        public Vector2 Position // XY Position
        {
            get;
            set;
        }
        public Vector2 velocity
        {
            get;
            set;
        }
        public float angle  // Rotation Angle
        {
            get;
            set;
        }
        public int width;
        public int height;
        public float scale = 0f;

        private KeyboardState oldState; // To improve input detection

        private MouseState oldMouse;    // To improve mouse detection
        public int MouseX;
        public int MouseY;

        #endregion

        public Sprites()
        {
        }

        public Sprites(int w, int h, float s)    // Constructor
        {
            this.width = w;
            this.height = h;
            this.scale = s;
        }

        #region Update and Draw

        public void Update()    // Update for sprite
        {
            CheckInput();
            CheckMouse();
            UpdatePosition();
        }

        public void UpdatePosition()
        {
            this.Position += this.velocity;
            this.velocity = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)  // Draw for sprite
        {
            //spriteBatch.Draw(this.tex, this.Position, new Rectangle(0,0, width, height), Color.White);  // Draw sprite
            spriteBatch.Draw(this.tex, this.Position, null, Color.White, 0f, Vector2.Zero, this.scale, SpriteEffects.None, 0f);
        }

        #endregion

        #region Input

        public void CheckInput()    // Check for user input
        {
            KeyboardState newState = Keyboard.GetState();  // Check for keyboard input

            if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.W))
            {
                this.velocity += new Vector2(0.0f, -3.0f);
            }

            if (newState.IsKeyDown(Keys.Down) || newState.IsKeyDown(Keys.S))
            {
                this.velocity += new Vector2(0.0f, 3.0f);
            }

            if (newState.IsKeyDown(Keys.Left) || newState.IsKeyDown(Keys.A))
            {
                this.velocity += new Vector2(-3.0f, 0.0f);
            }

            if (newState.IsKeyDown(Keys.Right) || newState.IsKeyDown(Keys.D))
            {
                this.velocity += new Vector2(3.0f, 0.0f);
            }

            oldState = newState;    // reassign to stop unwanted keypress

        }

        public void CheckMouse()    // Check for mouse location and input
        {
            MouseState mouseState = Mouse.GetState();   // Check for mouse input

            MouseX = mouseState.X;  // Get mouse x and y
            MouseY = mouseState.Y;

            if (mouseState.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
            {
                Console.Write("Hello " + MouseX + " " + MouseY + " " + "\n");
            }

            oldMouse = mouseState;  // reassign to stop unwanted mouse press
        }

        #endregion
    }
}
