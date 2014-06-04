using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject
{
    class Text
    {
        #region Variables

        public SpriteFont font;

        #endregion

        public Text()
        {

        }

        #region Update and Draw

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, "Intel: 0/0", new Vector2(550, 0), Color.White);
        }

        #endregion


    }
}
