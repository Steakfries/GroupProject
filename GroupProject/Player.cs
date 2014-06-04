using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject
{
    class Player : Sprites
    {
        #region Variables

        public bool isDead = false;
        private KeyboardState oldState; // To improve input detection

        private MouseState oldMouse;    // To improve mouse detection

        #endregion

        public Player(int w, int h, float s)
        {
            this.width = w;
            this.height = h;
            this.scale = s;
        }

        #region Draw and Update

        public new void Update()
        {
            CheckInput();
            CheckMouse();
            this.UpdatePosition();
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
