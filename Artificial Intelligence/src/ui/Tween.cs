using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence
{
    public enum EasingStyle
    {
        Linear = 0,
        Sine = 1,
        Back = 2,
        Quad = 3,
        Quart = 4,
        Quint = 5,
        Bounce = 6,
        Elastic = 7,
        Exponential = 8,
        Circular = 9,
        Cubic = 10
    }

    public enum EasingDirection
    {
        In = 0,
        Out = 1,
        InOut = 2
    }

    public class Tween
    {
        #region Fields

        public Vector2 Start;
        public Vector2 End;
        private EasingDirection _easingDirection;
        private EasingStyle _easingStyle;
        private float _duration;
        private double _startTimestamp;

        #endregion

        #region Methods

        public Tween(Vector2 start, Vector2 end, double timestampInSeconds, float duration, EasingDirection easingDirection, EasingStyle easingStyle)
        {
            Start = start;
            End = end;
            _easingDirection = easingDirection;
            _easingStyle = easingStyle;
            _duration = duration;
            _startTimestamp = timestampInSeconds;
        }

        public Vector2 Now(GameTime gameTime)
        {
            if (!Active(gameTime))
                return End;
            if (_easingStyle == EasingStyle.Linear)
            {
                return Vector2.Lerp(Start, End, (float)(gameTime.TotalGameTime.TotalSeconds - _startTimestamp) / _duration);
            }
            return Start;
        }

        public bool Active(GameTime gameTime)
        {
            return gameTime.TotalGameTime.TotalSeconds - _startTimestamp < _duration;
        }

        #endregion
    }
}