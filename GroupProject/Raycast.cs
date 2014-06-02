using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject
{
    class Raycast
    {
        #region Variables

        Ray forward;

        #endregion

        public Raycast(Sprites s)
        {
            this.forward = new Ray(new Vector3(s.Position, 0f), new Vector3(1f, 0f, 0f));
        }
    }
}
