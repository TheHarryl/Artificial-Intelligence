using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Artificial_Intelligence
{
    public class Image : UIObject
    {
        #region Fields

        protected Texture2D _texture;
        protected Texture2D _roundedTexture;
        protected Color[] _data;

        private Color _color;
        private int _cornerRadius;

        private float _scale;
        public float Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                GenerateTexture();
            }
        }

        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                if (_cornerRadius > _texture.Width / 2)
                    _cornerRadius = (int)(_texture.Width / 2);
                if (_cornerRadius > _texture.Height / 2)
                    _cornerRadius = (int)(_texture.Height / 2);
                GenerateTexture();
            }
        }

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }
        #endregion

        #region Methods

        public Image(Texture2D texture, Vector2 position, float scale, Color color, int cornerRadius = 0) : base(position)
        {
            _texture = texture;
            _color = color;
            Scale = scale;
            CornerRadius = cornerRadius;
        }

        public override void Update(GameTime gameTime, Vector2 offset = new Vector2())
        {
            base.Update(gameTime, offset);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 offset = new Vector2())
        {
            spriteBatch.Draw(_roundedTexture, _position + offset, null, _color, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }

        protected void GenerateTexture()
        {
            _data = new Color[(int)(_texture.Width * Scale) * (int)(_texture.Height * Scale)];
            _texture.GetData<Color>(_data);
            _roundedTexture = InternalManager.CreateTexture((int)(_texture.Width * Scale), (int)(_texture.Height * Scale));
            if (CornerRadius != 0)
            {
                for (int y = 0; y < CornerRadius; y++)
                {
                    for (int x = 0; x < CornerRadius; x++)
                    {
                        double distanceFromCorner = Math.Pow(Math.Pow(CornerRadius - y, 2) + Math.Pow(CornerRadius - x, 2), 0.5) - CornerRadius;
                        if (Math.Abs(distanceFromCorner) <= 1)
                        {
                            _data[x + y * (int)(_texture.Width * Scale)] *= (1f - (float)distanceFromCorner);
                            _data[((int)(_texture.Width * Scale) - x) + y * (int)(_texture.Width * Scale) - 1] *= (1f - (float)distanceFromCorner);
                            _data[x + ((int)(_texture.Height * Scale) - y - 1) * (int)(_texture.Width * Scale)] *= (1f - (float)distanceFromCorner);
                            _data[((int)(_texture.Width * Scale) - x) + ((int)(_texture.Height * Scale) - y - 1) * (int)(_texture.Width * Scale) - 1] *= (1f - (float)distanceFromCorner);
                        } else if (distanceFromCorner > 0)
                        {
                            _data[x + y * (int)(_texture.Width * Scale)] *= 0f;
                            _data[((int)(_texture.Width * Scale) - x) + y * (int)(_texture.Width * Scale) - 1] *= 0f;
                            _data[x + ((int)(_texture.Height * Scale) - y - 1) * (int)(_texture.Width * Scale)] *= 0f;
                            _data[((int)(_texture.Width * Scale) - x) + ((int)(_texture.Height * Scale) - y - 1) * (int)(_texture.Width * Scale) - 1] *= 0f;
                        }
                    }
                }
            }
            _roundedTexture.SetData(_data);
        }

        #endregion
    }
}