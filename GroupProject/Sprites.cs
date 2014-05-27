using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GroupProject
{
    class Sprites
    {
        #region Variables

        public Texture2D tex;
        public Vector2 Position
        {
            get;
            set;
        }
        public float angle
        {
            get;
            set;
        }
        public int width;
        public int height;

        #endregion

        public Sprites(int w, int h)
        {
            this.width = w;
            this.height = h;
        }
    }
}
