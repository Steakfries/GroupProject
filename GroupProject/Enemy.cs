using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupProject
{
    class Enemy : Sprites
    {
        #region Variables

        public bool isDead;

        #endregion

        public Enemy(int w, int h, float s)
        {
            this.width = w;
            this.height = h;
            this.scale = s;
        }

        #region Draw and Update

        public new void Update()
        {
            this.UpdatePosition();
        }

        #endregion
    }
}
