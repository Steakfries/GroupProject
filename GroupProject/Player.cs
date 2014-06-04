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

        public int MouseX;
        public int MouseY;

        #endregion

        public Player(int w, int h, float s)
        {
            this.width = w;
            this.height = h;
            this.scale = s;
        }

        #region Draw and Update

        new void UpdatePosition()
        {
            this.Position += this.velocity;
        }

        public new void Update(Grid a_Grid)
        {
            CheckInput(a_Grid);
            CheckMouse();
            this.UpdatePosition();
            if (isDead)
            {
                Console.Write("Dead \n");
                isDead = false;
            }
        }

        #endregion

        #region Input

        public void CheckInput(Grid a_Grid)    // Check for user input
        {
            KeyboardState newState = Keyboard.GetState();  // Check for keyboard input

            if (a_Grid.GetSquare(Position.X, Position.Y) == a_Grid.GetSquare((int)Position.X, (int)Position.Y))
            {
                Position = new Vector2((int)Position.X, (int)Position.Y);
                velocity = Vector2.Zero;
            }

            if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.W))
            {
                //this.velocity += new Vector2(0.0f, -3.0f);
                Seek(a_Grid, "UP");
            }

            if (newState.IsKeyDown(Keys.Down) || newState.IsKeyDown(Keys.S))
            {
                //this.velocity += new Vector2(0.0f, 3.0f);
                Seek(a_Grid, "DOWN");
            }

            if (newState.IsKeyDown(Keys.Left) || newState.IsKeyDown(Keys.A))
            {
                //this.velocity += new Vector2(-3.0f, 0.0f);
                Seek(a_Grid, "LEFT");
            }

            if (newState.IsKeyDown(Keys.Right) || newState.IsKeyDown(Keys.D))
            {
                //this.velocity += new Vector2(3.0f, 0.0f);
                Seek(a_Grid, "RIGHT");
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

        void Seek(Grid a_Grid, string a_Direction)
        {
             if (a_Grid.GetSquare(Position.X, Position.Y) == a_Grid.GetSquare((int)Position.X, (int)Position.Y))
              {
                if(a_Direction == "RIGHT")
                {
                    velocity = new Vector2(2, 0);
                }
                if (a_Direction == "LEFT")
                {
                    velocity = new Vector2(-2, 0);
                }
                if (a_Direction == "UP")
                {
                    velocity = new Vector2(0, -2);
                }
                if (a_Direction == "DOWN")
                {
                    velocity = new Vector2(0, 2);
                }
             }
        }

        #endregion
    }
}
