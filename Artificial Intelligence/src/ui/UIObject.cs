using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence
{
    public class UIObject : GameObject
    {
        #region Fields

        protected Vector2 _size;

        private Tween _sizeTween;
        private Tween _positionTween;

        #endregion

        #region Methods

        public UIObject(Vector2 position = new Vector2(), Vector2 size = new Vector2()) : base(position)
        {
            _size = size;
        }

        public override void Update(GameTime gameTime, Vector2 offset = default)
        {
            if (_positionTween != null)
            {
                _position = _positionTween.Now(gameTime);
            }
            if (_sizeTween != null)
            {
                _size = _sizeTween.Now(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 offset = default)
        {
            
        }

        public void TweenPosition(GameTime gameTime, Vector2 endPosition, EasingDirection easingDirection = EasingDirection.Out, EasingStyle easingStyle = EasingStyle.Quad, float time = 1f)
        {
            _positionTween = new Tween(_position, endPosition, gameTime, time, easingDirection, easingStyle);
        }

        public void TweenSize(GameTime gameTime, Vector2 endSize, EasingDirection easingDirection = EasingDirection.Out, EasingStyle easingStyle = EasingStyle.Quad, float time = 1f)
        {
            _sizeTween = new Tween(_size, endSize, gameTime, time, easingDirection, easingStyle);
        }

        public void TweenSizeAndPosition(GameTime gameTime, Vector2 endSize, Vector2 endPosition, EasingDirection easingDirection = EasingDirection.Out, EasingStyle easingStyle = EasingStyle.Quad, float time = 1f)
        {
            TweenSize(gameTime, endSize, EasingDirection.Out, EasingStyle.Quad, 1f);
            TweenPosition(gameTime, endPosition, EasingDirection.Out, EasingStyle.Quad, 1f);
        }

        #endregion
    }
}