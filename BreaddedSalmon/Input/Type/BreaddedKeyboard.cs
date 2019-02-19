using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Input.Type
{
    class BreaddedKeyboard
    {
        protected List<BreaddedKey> keys;
        protected List<BreaddedKey> alphaKeys;
        public List<KeyCommand> commands;

        bool? Shift;
        bool? Alt;

        bool enableShift = false;
        bool enableAlt = false;

        #region Keys
        public BreaddedKey A = new BreaddedKey(Keys.A, 'a', 'A');
        public BreaddedKey B = new BreaddedKey(Keys.B, 'b', 'B');
        public BreaddedKey C = new BreaddedKey(Keys.C, 'c', 'C');
        public BreaddedKey D = new BreaddedKey(Keys.D, 'd', 'D');
        public BreaddedKey E = new BreaddedKey(Keys.E, 'e', 'E');
        public BreaddedKey F = new BreaddedKey(Keys.F, 'f', 'F');
        public BreaddedKey G = new BreaddedKey(Keys.G, 'g', 'G');
        public BreaddedKey H = new BreaddedKey(Keys.H, 'h', 'H');
        public BreaddedKey I = new BreaddedKey(Keys.I, 'i', 'I');
        public BreaddedKey J = new BreaddedKey(Keys.J, 'j', 'J');
        public BreaddedKey K = new BreaddedKey(Keys.K, 'k', 'K');
        public BreaddedKey L = new BreaddedKey(Keys.L, 'l', 'L');
        public BreaddedKey M = new BreaddedKey(Keys.M, 'm', 'M');
        public BreaddedKey N = new BreaddedKey(Keys.N, 'n', 'N');
        public BreaddedKey O = new BreaddedKey(Keys.O, 'o', 'O');
        public BreaddedKey P = new BreaddedKey(Keys.P, 'p', 'P');
        public BreaddedKey Q = new BreaddedKey(Keys.Q, 'q', 'Q');
        public BreaddedKey R = new BreaddedKey(Keys.R, 'r', 'R');
        public BreaddedKey S = new BreaddedKey(Keys.S, 's', 'S');
        public BreaddedKey T = new BreaddedKey(Keys.T, 't', 'T');
        public BreaddedKey U = new BreaddedKey(Keys.U, 'u', 'U');
        public BreaddedKey V = new BreaddedKey(Keys.V, 'v', 'V');
        public BreaddedKey W = new BreaddedKey(Keys.W, 'w', 'W');
        public BreaddedKey X = new BreaddedKey(Keys.X, 'x', 'X');
        public BreaddedKey Y = new BreaddedKey(Keys.Y, 'y', 'Y');
        public BreaddedKey Z = new BreaddedKey(Keys.Z, 'z', 'Z');
        public BreaddedKey One = new BreaddedKey(Keys.D1, '1', '!');
        public BreaddedKey Two = new BreaddedKey(Keys.D2, '2', '@');
        public BreaddedKey Three = new BreaddedKey(Keys.D3, '3', '#');
        public BreaddedKey Four = new BreaddedKey(Keys.D4, '4', '$');
        public BreaddedKey Five = new BreaddedKey(Keys.D5, '5', '%');
        public BreaddedKey Six = new BreaddedKey(Keys.D6, '6', '^');
        public BreaddedKey Seven = new BreaddedKey(Keys.D7, '7', '&');
        public BreaddedKey Eight = new BreaddedKey(Keys.D8, '8', '*');
        public BreaddedKey Nine = new BreaddedKey(Keys.D9, '9', '(');
        public BreaddedKey Zero = new BreaddedKey(Keys.D0, '0', ')');
        public BreaddedKey Tilde = new BreaddedKey(Keys.OemTilde, '`', '~');
        public BreaddedKey Subtract = new BreaddedKey(Keys.Subtract, '-', '_');
        public BreaddedKey Add = new BreaddedKey(Keys.Add, '=', '+');
        public BreaddedKey OBrace = new BreaddedKey(Keys.OemOpenBrackets, '[', '{');
        public BreaddedKey CBrace = new BreaddedKey(Keys.OemCloseBrackets, ']', '}');
        public BreaddedKey FSlash = new BreaddedKey(Keys.OemBackslash, '\\', '|');
        public BreaddedKey Colon = new BreaddedKey(Keys.OemSemicolon, ';', ':');
        public BreaddedKey Quote = new BreaddedKey(Keys.OemQuotes, '\'', '"');
        public BreaddedKey Comma = new BreaddedKey(Keys.OemComma, ',', '<');
        public BreaddedKey Period = new BreaddedKey(Keys.OemPeriod, '.', '>');
        public BreaddedKey Backslash = new BreaddedKey(Keys.OemQuestion, '/', '?');

        public BreaddedKey Backspace = new BreaddedKey(Keys.Back);
        public BreaddedKey Space = new BreaddedKey(Keys.Space);
        public BreaddedKey Enter = new BreaddedKey(Keys.Enter);
        public BreaddedKey Tab = new BreaddedKey(Keys.Tab);
        public BreaddedKey Esc = new BreaddedKey(Keys.Escape);
        public BreaddedKey Insert = new BreaddedKey(Keys.Insert);
        public BreaddedKey Delete = new BreaddedKey(Keys.Delete);
        public BreaddedKey PrintScreen = new BreaddedKey(Keys.PrintScreen);

        public BreaddedKey RightControl = new BreaddedKey(Keys.RightControl);
        public BreaddedKey RightAlt = new BreaddedKey(Keys.RightAlt);
        public BreaddedKey RightShift = new BreaddedKey(Keys.RightShift);
        public BreaddedKey LeftControl = new BreaddedKey(Keys.LeftControl);
        public BreaddedKey LeftAlt = new BreaddedKey(Keys.LeftAlt);
        public BreaddedKey LeftShift = new BreaddedKey(Keys.LeftShift);

        public BreaddedKey LeftWindows = new BreaddedKey(Keys.LeftWindows);
        public BreaddedKey RightWindows = new BreaddedKey(Keys.RightWindows);


        public BreaddedKey Left = new BreaddedKey(Keys.Left);
        public BreaddedKey Right = new BreaddedKey(Keys.Right);
        public BreaddedKey Up = new BreaddedKey(Keys.Up);
        public BreaddedKey Down = new BreaddedKey(Keys.Down);

        public BreaddedKey F1 = new BreaddedKey(Keys.F1);
        public BreaddedKey F2 = new BreaddedKey(Keys.F2);
        public BreaddedKey F3 = new BreaddedKey(Keys.F3);
        public BreaddedKey F4 = new BreaddedKey(Keys.F4);
        public BreaddedKey F5 = new BreaddedKey(Keys.F5);
        public BreaddedKey F6 = new BreaddedKey(Keys.F6);
        public BreaddedKey F7 = new BreaddedKey(Keys.F7);
        public BreaddedKey F8 = new BreaddedKey(Keys.F8);
        public BreaddedKey F9 = new BreaddedKey(Keys.F9);
        public BreaddedKey F10 = new BreaddedKey(Keys.F10);
        public BreaddedKey F11 = new BreaddedKey(Keys.F11);
        public BreaddedKey F12 = new BreaddedKey(Keys.F12);



        #endregion


        public BreaddedKeyboard()
        {
            keys = new List<BreaddedKey>();
            keys.AddRange(new List<BreaddedKey> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
                One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Zero, Tilde, Subtract, Add, OBrace, CBrace, FSlash, Colon,
                Quote, Comma, Period, Backslash, Space, Enter, Up, Down, Tab, Esc, Backspace, Insert, Delete, PrintScreen, RightAlt,
                RightControl, RightShift, RightWindows, LeftAlt, LeftControl, LeftShift, LeftWindows, F1, F2, F3, F4, F5, F6, F7,
            F8, F9, F10, F11, F12});
        }
        public void EnableShift()
        {
            enableShift = true;
        }
        public void EnableAlt()
        {
            enableAlt = true;
        }
        public void Update(GameTime gameTime)
        {
            foreach (BreaddedKey key in keys)
            {
                key.Update(gameTime);
            }

            if (enableShift)
            {
                if (LeftShift.Check() || RightShift.Check() || Console.CapsLock)
                {
                    Shift = true;
                }
            }
            else
            {
                Shift = false;
            }

            if (enableAlt)
            {
                if (RightAlt.Check() || LeftAlt.Check())
                {
                    Alt = true;
                }
            }
            else
            {
                Alt = false;
            }
        }
        public char? BasicTyping()
        {
            KeyboardState state = Keyboard.GetState();
            foreach (BreaddedKey key in keys)
            {
                if (key.isPressed) return key.Value(Shift, Alt);
            }
            return null;
        }
        public char? BasicLimitedTyping(List<BreaddedKey> smartKeys)
        {
            KeyboardState state = Keyboard.GetState();
            
            foreach (BreaddedKey key in smartKeys)
            {
                if (key.isPressed) return key.Value(Shift, Alt);
            }
            return null;
        }
    }
}
