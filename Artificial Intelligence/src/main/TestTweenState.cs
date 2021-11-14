using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artificial_Intelligence
{
    public class TestTweenState : GameState
    {
        Frame frame1;
        Frame frame2;
        Frame frame3;
        Frame frame4;
        Frame frame5;
        Frame frame6;
        Frame frame7;
        Frame frame8;
        Frame frame9;
        Frame frame10;
        Frame frame11;

        public TestTweenState() : base()
        {
            _textureNames = new string[] {
                "rectangle",
                "square"
            };
            _fontNames = new string[] {
                "Arial"
            };
            _soundEffectNames = new string[] {

            };
            _songNames = new string[] {
                
            };

            InternalManager.LoadAssets(_textureNames, _fontNames, _soundEffectNames, _songNames);

            frame1 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Linear", Color.Gray, Alignment.Center)
            }, new Vector2(50, 50), new Vector2(200, 40), Color.White, 10);
            frame2 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Sine", Color.Gray, Alignment.Center)
            }, new Vector2(50, 100), new Vector2(200, 40), Color.White, 10);
            frame3 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Back", Color.Gray, Alignment.Center)
            }, new Vector2(50, 150), new Vector2(200, 40), Color.White, 10);
            frame4 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Quad", Color.Gray, Alignment.Center)
            }, new Vector2(50, 200), new Vector2(200, 40), Color.White, 10);
            frame5 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Quart", Color.Gray, Alignment.Center)
            }, new Vector2(50, 250), new Vector2(200, 40), Color.White, 10);
            frame6 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Quint", Color.Gray, Alignment.Center)
            }, new Vector2(50, 300), new Vector2(200, 40), Color.White, 10);
            frame7 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Bounce", Color.Gray, Alignment.Center)
            }, new Vector2(50, 350), new Vector2(200, 40), Color.White, 10);
            frame8 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Elastic", Color.Gray, Alignment.Center)
            }, new Vector2(50, 400), new Vector2(200, 40), Color.White, 10);
            frame9 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Exponential", Color.Gray, Alignment.Center)
            }, new Vector2(50, 450), new Vector2(200, 40), Color.White, 10);
            frame10 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Circular", Color.Gray, Alignment.Center)
            }, new Vector2(50, 500), new Vector2(200, 40), Color.White, 10);
            frame11 = new Frame(new List<UIObject>()
            {
                new TextLabel(InternalManager.LoadedFonts["Arial"], new Vector2(0, 0), new Vector2(200, 40), "Cubic", Color.Gray, Alignment.Center)
            }, new Vector2(50, 550), new Vector2(200, 40), Color.White, 10);

            frame1.TweenPosition(2.0, new Vector2(400, 50), EasingDirection.In, EasingStyle.Linear, 3);
            frame2.TweenPosition(2.0, new Vector2(400, 100), EasingDirection.In, EasingStyle.Sine, 3);
            frame3.TweenPosition(2.0, new Vector2(400, 150), EasingDirection.In, EasingStyle.Back, 3);
            frame4.TweenPosition(2.0, new Vector2(400, 200), EasingDirection.In, EasingStyle.Quad, 3);
            frame5.TweenPosition(2.0, new Vector2(400, 250), EasingDirection.In, EasingStyle.Quart, 3);
            frame6.TweenPosition(2.0, new Vector2(400, 300), EasingDirection.In, EasingStyle.Quint, 3);
            frame7.TweenPosition(2.0, new Vector2(400, 350), EasingDirection.In, EasingStyle.Bounce, 3);
            frame8.TweenPosition(2.0, new Vector2(400, 400), EasingDirection.In, EasingStyle.Elastic, 3);
            frame9.TweenPosition(2.0, new Vector2(400, 450), EasingDirection.In, EasingStyle.Exponential, 3);
            frame10.TweenPosition(2.0, new Vector2(400, 500), EasingDirection.In, EasingStyle.Circular, 3);
            frame11.TweenPosition(2.0, new Vector2(400, 550), EasingDirection.In, EasingStyle.Cubic, 3);
        }

        public override void Update(GameTime gameTime)
        {
            frame1.Update(gameTime);
            frame2.Update(gameTime);
            frame3.Update(gameTime);
            frame4.Update(gameTime);
            frame5.Update(gameTime);
            frame6.Update(gameTime);
            frame7.Update(gameTime);
            frame8.Update(gameTime);
            frame9.Update(gameTime);
            frame10.Update(gameTime);
            frame11.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            frame1.Draw(spriteBatch);
            frame2.Draw(spriteBatch);
            frame3.Draw(spriteBatch);
            frame4.Draw(spriteBatch);
            frame5.Draw(spriteBatch);
            frame6.Draw(spriteBatch);
            frame7.Draw(spriteBatch);
            frame8.Draw(spriteBatch);
            frame9.Draw(spriteBatch);
            frame10.Draw(spriteBatch);
            frame11.Draw(spriteBatch);
        }
    }
}