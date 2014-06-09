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

        public Sprites bullet = new Sprites(10, 10, 1f);
        public float bulletSpeed = 1f;
        public bool isShot = false;

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

        public void Update(Grid a_Grid)
        {
            CheckInput(a_Grid);
            CheckMouse();
            this.UpdatePosition();
            this.bullet.Update();

            if (isShot)
            {
                ifBulletAlive();
            }
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

            if (newState.IsKeyDown(Keys.W))
            {
                //this.velocity += new Vector2(0.0f, -3.0f);
                Seek(a_Grid, "UP");
            }

            if (newState.IsKeyDown(Keys.S))
            {
                //this.velocity += new Vector2(0.0f, 3.0f);
                Seek(a_Grid, "DOWN");
            }

            if (newState.IsKeyDown(Keys.A))
            {
                //this.velocity += new Vector2(-3.0f, 0.0f);
                Seek(a_Grid, "LEFT");
            }

            if (newState.IsKeyDown(Keys.D))
            {
                //this.velocity += new Vector2(3.0f, 0.0f);
                Seek(a_Grid, "RIGHT");
            }

            if (isShot == false)
            {
                if (newState.IsKeyDown(Keys.Up))
                {
                    shoot("UP");
                }

                if (newState.IsKeyDown(Keys.Down))
                {
                    shoot("DOWN");
                }

                if (newState.IsKeyDown(Keys.Left))
                {
                    shoot("LEFT");
                }

                if (newState.IsKeyDown(Keys.Right))
                {
                    shoot("RIGHT");
                }
            }

            oldState = newState;    // reassign to stop unwanted keypress

        }

        public void CheckMouse()    // Check for mouse location and input
        {
            MouseState mouseState = Mouse.GetState();   // Check for mouse input

            MouseX = mouseState.X;  // Get mouse x and y
            MouseY = mouseState.Y;

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

        public void shoot(string key)
        {
            bullet.Position = new Vector2(this.Position.X + 22, this.Position.Y +25);
            isShot = true;
            if (key == "RIGHT")
            {
                bullet.velocity = new Vector2(2, 0);
            }
            if (key == "LEFT")
            {
                bullet.velocity = new Vector2(-2, 0);
            }
            if (key == "UP")
            {
                bullet.velocity = new Vector2(0, -2);
            }
            if (key == "DOWN")
            {
                bullet.velocity = new Vector2(0, 2);
            }
        }

        public void ifBulletAlive()
        {
            bullet.Position += bullet.velocity * bulletSpeed;
        }
    }
}
