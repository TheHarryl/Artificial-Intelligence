using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Artificial_Intelligence
{
    public class TextBox : InteractableTextLabel
    {
        #region Fields

        protected bool _tick;
        protected KeyboardState _lastState;
        protected int _currentLineStart;

        protected readonly Dictionary<Keys, string> KEYS;
        protected Dictionary<Keys, KeyValuePair<bool, double>> _inputDebounce;

        protected string _placeholderText;
        protected Color _placeholderColor;

        public override string Text
        {
            get {
                if (_text.Length == 0 && !_selected)
                    return _placeholderText;
                else
                    return _text;
            }
            set {
                _text = value;
            }
        }

        #endregion

        #region Methods

        public TextBox(SpriteFont font, Vector2 position, Vector2 size, string text, string placeholderText, Color textColor, Color placeholderColor, Color highlightColor, Alignment align, bool overrideCursor = false, bool wordWrap = true) : base(font, position, size, text, textColor, highlightColor, align, overrideCursor, wordWrap)
        {
            KEYS = new Dictionary<Keys, string>()
            {
                { Keys.A, "a" },
                { Keys.B, "b" },
                { Keys.C, "c" },
                { Keys.D, "d" },
                { Keys.E, "e" },
                { Keys.F, "f" },
                { Keys.G, "g" },
                { Keys.H, "h" },
                { Keys.I, "i" },
                { Keys.J, "j" },
                { Keys.K, "k" },
                { Keys.L, "l" },
                { Keys.M, "m" },
                { Keys.N, "n" },
                { Keys.O, "o" },
                { Keys.P, "p" },
                { Keys.Q, "q" },
                { Keys.R, "r" },
                { Keys.S, "s" },
                { Keys.T, "t" },
                { Keys.U, "u" },
                { Keys.V, "v" },
                { Keys.W, "w" },
                { Keys.X, "x" },
                { Keys.Y, "y" },
                { Keys.Z, "z" },
                { Keys.Space, " " },
                { Keys.Enter, "\n" },
                { Keys.OemBackslash, "\\" },
                { Keys.OemQuestion, "?" },
                { Keys.OemPeriod, "." },
                { Keys.OemSemicolon, ";" },
                { Keys.OemMinus, "-" },
            };
            _inputDebounce = new Dictionary<Keys, KeyValuePair<bool, double>>();
            _placeholderText = placeholderText;
            _placeholderColor = placeholderColor;
        }

        public override void Update(GameTime gameTime, Vector2 offset = new Vector2())
        {
            base.Update(gameTime, offset);

            if (_highlightStartIndex > _text.Length || _highlightEndIndex > _text.Length)
            {
                _highlightStartIndex = _text.Length;
                _highlightEndIndex = _text.Length;
            }

            _tick = (int)(_lastClick - gameTime.TotalGameTime.TotalSeconds) % 2 == 0;

            if (_selected)
            {
                int min = Math.Min(_highlightStartIndex, _highlightEndIndex);
                min = min >= 0 ? min : 0;
                int max = Math.Max(_highlightStartIndex, _highlightEndIndex);
                int length = Math.Abs(_highlightStartIndex - _highlightEndIndex);
                KeyboardState state = Keyboard.GetState();
                if ((state.IsKeyDown(Keys.LeftControl) || state.IsKeyDown(Keys.RightControl)) && state.IsKeyDown(Keys.V)
                    && !((_lastState.IsKeyDown(Keys.LeftControl) || _lastState.IsKeyDown(Keys.RightControl)) && _lastState.IsKeyDown(Keys.V)))
                {
                    if (_highlightStartIndex != _highlightEndIndex)
                        _text = _text.Remove(min, length);
                    _text = _text.Insert(min, Clipboard.GetText().Normalize());
                    _highlightStartIndex = min + Clipboard.GetText().Normalize().Length;
                    _highlightEndIndex = min + Clipboard.GetText().Normalize().Length;
                } else if ((state.IsKeyDown(Keys.LeftControl) || state.IsKeyDown(Keys.RightControl)) && state.IsKeyDown(Keys.X)
                    && !((_lastState.IsKeyDown(Keys.LeftControl) || _lastState.IsKeyDown(Keys.RightControl)) && _lastState.IsKeyDown(Keys.X))
                    && _highlightStartIndex != _highlightEndIndex)
                {
                    Clipboard.SetText(_text.Substring(min, length));
                    _text = _text.Remove(min, length);
                    _highlightStartIndex = min;
                    _highlightEndIndex = min;
                }

                Keys[] pressedKeys = state.GetPressedKeys();
                foreach (KeyValuePair<Keys, KeyValuePair<bool, double>> key in _inputDebounce)
                {
                    if (!state.IsKeyDown(key.Key))
                        _inputDebounce.Remove(key.Key);
                }
                if (!state.IsKeyDown(Keys.LeftControl))
                {
                    for (int i = 0; i < pressedKeys.Length; i++)
                    {
                        if (!_inputDebounce.ContainsKey(pressedKeys[i]))
                        {
                            _inputDebounce.Add(pressedKeys[i], new KeyValuePair<bool, double>(false, gameTime.TotalGameTime.TotalSeconds));
                        }
                        else if (!_inputDebounce[pressedKeys[i]].Key && gameTime.TotalGameTime.TotalSeconds - _inputDebounce[pressedKeys[i]].Value < 1.0 / 2.0)
                        {
                            continue;
                        }
                        else if (_inputDebounce[pressedKeys[i]].Key && gameTime.TotalGameTime.TotalSeconds - _inputDebounce[pressedKeys[i]].Value < 1.0 / 30.0)
                        {
                            continue;
                        }
                        else
                        {
                            _inputDebounce[pressedKeys[i]] = new KeyValuePair<bool, double>(true, gameTime.TotalGameTime.TotalSeconds);
                        }
                        if (KEYS.ContainsKey(pressedKeys[i]))
                        {
                            _text = _text.Insert(min, state.IsKeyDown(Keys.LeftShift) || state.IsKeyDown(Keys.RightShift) ? KEYS[pressedKeys[i]].ToUpper() : KEYS[pressedKeys[i]].ToLower());
                            _highlightStartIndex += KEYS[pressedKeys[i]].Length;
                            _highlightEndIndex += KEYS[pressedKeys[i]].Length;
                            _lastClick = gameTime.TotalGameTime.TotalSeconds;
                        }
                        else if (pressedKeys[i] == Keys.Back)
                        {
                            if (_highlightStartIndex != _highlightEndIndex)
                            {
                                _text = _text.Remove(min, length);
                                _highlightStartIndex = min;
                                _highlightEndIndex = min;
                            }
                            else if (min > 0)
                            {
                                _text = _text.Remove(min - 1, 1);
                                _highlightStartIndex--;
                                _highlightEndIndex--;
                            }
                            _lastClick = gameTime.TotalGameTime.TotalSeconds;
                        }
                        else if (pressedKeys[i] == Keys.Left)
                        {
                            if (_highlightStartIndex != _highlightEndIndex)
                            {
                                _highlightStartIndex = min;
                                _highlightEndIndex = min;
                            }
                            else if (max > 0)
                            {
                                _highlightStartIndex = max - 1;
                                _highlightEndIndex = _highlightStartIndex;
                            }
                            _lastClick = gameTime.TotalGameTime.TotalSeconds;
                        }
                        else if (pressedKeys[i] == Keys.Right)
                        {
                            if (_highlightStartIndex != _highlightEndIndex)
                            {
                                _highlightStartIndex = max;
                                _highlightEndIndex = max;
                            }
                            else if (max < _text.Length - 1)
                            {
                                _highlightStartIndex = max + 1;
                                _highlightEndIndex = _highlightStartIndex;
                            }
                            _lastClick = gameTime.TotalGameTime.TotalSeconds;
                        }
                        else
                        {

                        }
                    }
                }
                _lastState = state;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 offset = new Vector2())
        {
            base.Draw(spriteBatch, offset);
            if (_selected && _tick && _highlightStartIndex == _highlightEndIndex)
            {
                _currentLineStart = 0;
                for (int i = 0; i < _highlightStartIndex && i < _text.Length; i++)
                {
                    if (_text[i] == '\n')
                        _currentLineStart = i;
                }
                Vector2 insertionPointX = Position + offset + _font.MeasureString(_text.Substring(_currentLineStart, _highlightStartIndex - _currentLineStart));
                Vector2 insertionPointY = Position + offset + _font.MeasureString(_text.Substring(0, _highlightStartIndex));
                spriteBatch.Draw(InternalManager.LoadedTextures["rectangle"], new Rectangle((int)insertionPointX.X, (int)insertionPointY.Y - (int)(_highlightStartIndex > 0 ? _fontSize : 0), 2, (int)_fontSize), _color);
            }
        }

        #endregion
    }
}