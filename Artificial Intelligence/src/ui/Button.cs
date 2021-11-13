using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Artificial_Intelligence
{
    public class Button : Frame
    {
        #region Fields

        protected float _hoverDarken;
        protected float _clickDarken;
        protected bool _pressed;

        public bool Hovering;

        #endregion

        #region Methods

        public Button(List<UIObject> children, Vector2 position, Vector2 size, Color color, int cornerRadius = 0, float hoverDarken = 0.25f, float clickDarken = 0.5f) : base(children, position, size, color, cornerRadius)
        {
            _hoverDarken = hoverDarken;
            _clickDarken = clickDarken;
        }

        private bool IsHovering(Vector2 offset = new Vector2())
        {
            MouseState mouseState = Mouse.GetState();
            Rectangle hitbox = new Rectangle((int)(Position + offset).X, (int)(Position + offset).Y, (int)Size.X, (int)Size.Y);
            if (!hitbox.Contains(mouseState.X, mouseState.Y))
                return false;
            if (CornerRadius == 0)
                return true;
            return _data[(mouseState.X - (int)(Position + offset).X) + (mouseState.Y - (int)(Position + offset).Y) * (int)Size.X] == Color.White;
        }
        
        public void OnClickStart(GameTime gameTime, Vector2 offset = new Vector2())
        {
        }

        public void OnClickEnd(GameTime gameTime, Vector2 offset = new Vector2())
        {
            TweenPosition(gameTime, new Vector2(400, 50), EasingDirection.Out, EasingStyle.Linear, 0.2f);
        }

        public override void Update(GameTime gameTime, Vector2 offset = new Vector2())
        {
            MouseState mouseState = Mouse.GetState();
            if (IsHovering(offset))
            {
                Hovering = true;
                if (mouseState.LeftButton == ButtonState.Pressed && _pressed == false)
                {
                    _pressed = true;
                    OnClickStart(gameTime, offset);
                }
                else if (mouseState.LeftButton == ButtonState.Released && _pressed == true)
                {
                    _pressed = false;
                    OnClickEnd(gameTime, offset);
                }
            }
            else
            {
                Hovering = false;
            }
            base.Update(gameTime, offset);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 offset = new Vector2())
        {
            base.Draw(spriteBatch, offset);
            if (_pressed)
            {
                spriteBatch.Draw(_texture, Position, Color.Black * _clickDarken);
            }
            else if (Hovering)
            {
                spriteBatch.Draw(_texture, Position, Color.Black * _hoverDarken);
            }
        }

        #endregion
    }
}