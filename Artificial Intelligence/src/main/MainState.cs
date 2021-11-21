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
        private List<UIObject> _ui;

        public MainState() : base()
        {
            _textureNames = new string[] {
                "rectangle"
            };
            _fontNames = new string[] {
                "Arial"
            };
            _soundEffectNames = new string[] {

            };
            _songNames = new string[] {
                
            };

            InternalManager.LoadAssets(_textureNames, _fontNames, _soundEffectNames, _songNames);

            _ui = new List<UIObject>()
            {
                new Frame(new List<UIObject>(){
                    new Frame(new List<UIObject> ()
                    {
                        new TextBox(InternalManager.LoadedFonts["Arial"], new Vector2(5, 5), new Vector2(770, 50), "", "Enter a message", new Color(200, 200, 200), new Color(150, 150, 150), new Color(100, 100, 100), Alignment.Left | Alignment.Top, true, true)
                    }, new Vector2(10, 410), new Vector2(780, 60), new Color(30, 30, 30), 10)
                }, new Vector2(0, 0), new Vector2(800, 480), new Color(47, 47, 47)),
            };
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < _ui.Count; i++)
            {
                _ui[i].Update(gameTime);
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _ui.Count; i++)
            {
                _ui[i].Draw(spriteBatch);
            }
        }
    }
}