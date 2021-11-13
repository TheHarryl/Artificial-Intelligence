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
        Frame frame;
        Button button1;
        Button button2;
        Button button3;

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

            frame = new Frame(new List<UIObject>()
            {

            }, new Vector2(50, 50), new Vector2(200, 50), Color.Gray, 10);
            button1 = new Button(new List<UIObject>()
            {

            }, new Vector2(50, 150), new Vector2(200, 50), Color.White, 10);
            button2 = new Button(new List<UIObject>()
            {

            }, new Vector2(50, 250), new Vector2(50, 50), Color.White, 25);
            button3 = new Button(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, -5), new Vector2(200, 50), "test", Color.Gray, Alignment.Center)
            }, new Vector2(50, 350), new Vector2(200, 50), Color.White, 10);
        }

        public override void Update(GameTime gameTime)
        {
            frame.Update(gameTime);
            button1.Update(gameTime);
            button2.Update(gameTime);
            button3.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawString(InternalManager.LoadedFonts["Arial"], "hundauphd", new Vector2(), Color.White);
            frame.Draw(spriteBatch);
            button1.Draw(spriteBatch);
            button2.Draw(spriteBatch);
            button3.Draw(spriteBatch);
        }
    }
}