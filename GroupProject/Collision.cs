using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject
{
    class Collision
    {
        #region Variables


        #endregion

        public Collision() // Constructor
        {

        }

        #region Update and Draw

        public void Update()
        {

        }

        #endregion

        public static bool CheckCollision(Sprites s, Sprites sp)   // Check for collision
        {
            Rectangle sCol = new Rectangle((int)s.Position.X, (int)s.Position.Y, s.width, s.height);
            Rectangle spCol = new Rectangle((int)sp.Position.X, (int)sp.Position.Y, sp.width, sp.height);

            if (sCol.Intersects(spCol)) // If there is a collision
            {
                //Vector2 newPos = s.Position;


                //s.velocity = Vector2.Zero;

                //s.Position = newPos;

                return true;
            }
            return false;
        }

    }
}
