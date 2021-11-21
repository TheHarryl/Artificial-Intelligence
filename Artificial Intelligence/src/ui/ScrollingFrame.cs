using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence
{
    public class ChatWindow : ScrollingFrame
    {
        #region Fields



        #endregion

        #region Methods

        public ChatWindow(List<UIObject> children, Vector2 position, Vector2 frameSize, Vector2 scrollSize, Color color, float scrollBarSize, Color scrollBarColor, bool scrollBarAlwaysVisible = true,  EasingStyle scrollAnimation = EasingStyle.Quad, int cornerRadius = 0) : base(children, position, frameSize, scrollSize, color, scrollBarSize, scrollBarColor, scrollBarAlwaysVisible, scrollAnimation, cornerRadius)
        {
            
        }

        public override void Update(GameTime gameTime, Vector2 offset = new Vector2())
        {
            base.Update(gameTime, offset);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 offset = new Vector2())
        {
            
        }

        #endregion
    }
}