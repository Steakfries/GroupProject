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
            UpdatePosition();
        }

        public void UpdatePosition()
        {
            this.Position += this.velocity;
            //this.velocity = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)  // Draw for sprite
        {
            //spriteBatch.Draw(this.tex, this.Position, new Rectangle(0,0, width, height), Color.White);  // Draw sprite
            spriteBatch.Draw(this.tex, this.Position, null, Color.White, 0f, Vector2.Zero, this.scale, SpriteEffects.None, 0f);
        }

        #endregion
    }
}
