using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Artificial_Intelligence
{
    public class TextBox : TextLabel
    {
        #region Fields

        

        #endregion

        #region Methods

        public TextBox(SpriteFont font, Vector2 position, Vector2 size, string text, Color color, Alignment align) : base(font, position, size, text, color, align)
        {
            
        }

        public override void Update(GameTime gameTime, Vector2 offset = new Vector2())
        {
            base.Update(gameTime, offset);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 offset = new Vector2())
        {
            base.Draw(spriteBatch, offset);
        }

        #endregion
    }
}