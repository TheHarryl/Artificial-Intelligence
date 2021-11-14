using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Artificial_Intelligence
{
    public class TextBox : InteractableTextLabel
    {
        #region Fields

        

        #endregion

        #region Methods

        public TextBox(SpriteFont font, Vector2 position, Vector2 size, string text, Color textColor, Color highlightColor, Alignment align, bool overrideCursor = false, bool wordWrap = true) : base(font, position, size, text, textColor, highlightColor, align, overrideCursor, wordWrap)
        {
            
        }

        public override void Update(GameTime gameTime, Vector2 offset = new Vector2())
        {
            base.Update(gameTime, offset);

            if (_selected)
            {
                KeyboardState state = Keyboard.GetState();
                if ((state.IsKeyDown(Keys.LeftControl) || state.IsKeyDown(Keys.RightControl)) && state.IsKeyDown(Keys.V))
                {
                    int min = Math.Min(_highlightStartIndex, _highlightEndIndex);
                    int max = Math.Max(_highlightStartIndex, _highlightEndIndex);
                    int length = Math.Abs(_highlightStartIndex - _highlightEndIndex);
                    if (_highlightStartIndex != _highlightEndIndex)
                        _text = _text.Remove(min >= 0 ? min : 0, Math.Abs(_highlightStartIndex - _highlightEndIndex));
                    _text.Insert(min >= 0 ? min : 0, Clipboard.GetText().Normalize());
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 offset = new Vector2())
        {
            base.Draw(spriteBatch, offset);
        }

        #endregion
    }
}