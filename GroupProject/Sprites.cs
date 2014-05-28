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
        public float angle  // Rotation Angle
        {
            get;
            set;
        }
        public int width;
        public int height;

        private KeyboardState oldState; // To improve input detection

        private MouseState oldMouse;    // To improve mouse detection
        public int MouseX;
        public int MouseY;

        #endregion

        public Sprites(int w, int h)    // Constructor
        {
            this.width = w;
            this.height = h;
        }

        public void CheckInput()    // Check for user input
        {
            KeyboardState newState = Keyboard.GetState();  // Check for keyboard input

            if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.W))
            {
                this.Position += new Vector2(0.0f, -3.0f);
            }

            if (newState.IsKeyDown(Keys.Down) || newState.IsKeyDown(Keys.S))
            {
                this.Position += new Vector2(0.0f, 3.0f);
            }

            if (newState.IsKeyDown(Keys.Left) || newState.IsKeyDown(Keys.A))
            {
                this.Position += new Vector2(-3.0f, 0.0f);
            }

            if (newState.IsKeyDown(Keys.Right) || newState.IsKeyDown(Keys.D))
            {
                this.Position += new Vector2(3.0f, 0.0f);
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
    }
}
