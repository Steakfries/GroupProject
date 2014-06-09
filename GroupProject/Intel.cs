using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupProject
{
    class Intel : Sprites
    {
        #region Variables

        public bool IsCaptured;

        #endregion

        public Intel(int w, int h, float s)
        {
            this.width = w;
            this.height = h;
            this.scale = s;
            IsCaptured = false;
        }

        #region Draw and Update

        public new void Update()
        {
            this.UpdatePosition();
        }

        #endregion
    }
}
