using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artificial_Intelligence
{
    public class MainState : GameState
    {
        public MainState() : base()
        {
            _textureNames = new string[] {
                
            };
            _fontNames = new string[] {
                
            };
            _soundEffectNames = new string[] {

            };
            _songNames = new string[] {
                
            };

            InternalManager.LoadAssets(_textureNames, _fontNames, _soundEffectNames, _songNames);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }
    }
}