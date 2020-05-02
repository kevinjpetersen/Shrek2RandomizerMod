using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shrek2RandomizerMod
{
    public class Shrek2KeyboardForeground
    {
        private const string GameProcessName = "game";
        private Process GameProcess { get; set; }

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr zeroOnly, string lpWindowName);

        private Process GetGameProcess()
        {
            Process[] gameProcess = Process.GetProcessesByName(GameProcessName);
            if (gameProcess.Length == 0)
            {
                return null;
            }
            return gameProcess[0];
        }

        public bool Initialize()
        {
            GameProcess = GetGameProcess();
            return GameProcess != null;
        }

        public void SendCommand(string command)
        {
            PressKey(VirtualKeys.Tab);
            Write(command);
            PressKey(VirtualKeys.Return);
        }

        public void PressKey(VirtualKeys key)
        {
            if (GameProcess != null && !GameProcess.HasExited)
            {
                SetForegroundWindow(GameProcess.MainWindowHandle);
                keybd_event((byte)key, 0, 0x0001, 0);
                keybd_event((byte)key, 0, 0x0002, 0);
            }
        }

        class KeyStroke
        {
            public byte Key { get; set; }
            public bool IsUppercase { get; set; }
            public bool IsUnderscore { get; set; }

            public KeyStroke(byte Key, bool IsUppercase, bool IsUnderscore = false)
            {
                this.Key = Key;
                this.IsUppercase = IsUppercase;
                this.IsUnderscore = IsUnderscore;
            }
        }

        public void Write(string text)
        {
            if (GameProcess != null && !GameProcess.HasExited)
            {
                List<KeyStroke> keystrokes = new List<KeyStroke>();
                foreach (var character in text)
                {
                    switch (char.ToUpper(character))
                    {
                        case 'A': keystrokes.Add(new KeyStroke((byte)VirtualKeys.A, char.IsUpper(character))); break;
                        case 'B': keystrokes.Add(new KeyStroke((byte)VirtualKeys.B, char.IsUpper(character))); break;
                        case 'C': keystrokes.Add(new KeyStroke((byte)VirtualKeys.C, char.IsUpper(character))); break;
                        case 'D': keystrokes.Add(new KeyStroke((byte)VirtualKeys.D, char.IsUpper(character))); break;
                        case 'E': keystrokes.Add(new KeyStroke((byte)VirtualKeys.E, char.IsUpper(character))); break;
                        case 'F': keystrokes.Add(new KeyStroke((byte)VirtualKeys.F, char.IsUpper(character))); break;
                        case 'G': keystrokes.Add(new KeyStroke((byte)VirtualKeys.G, char.IsUpper(character))); break;
                        case 'H': keystrokes.Add(new KeyStroke((byte)VirtualKeys.H, char.IsUpper(character))); break;
                        case 'I': keystrokes.Add(new KeyStroke((byte)VirtualKeys.I, char.IsUpper(character))); break;
                        case 'J': keystrokes.Add(new KeyStroke((byte)VirtualKeys.J, char.IsUpper(character))); break;
                        case 'K': keystrokes.Add(new KeyStroke((byte)VirtualKeys.K, char.IsUpper(character))); break;
                        case 'L': keystrokes.Add(new KeyStroke((byte)VirtualKeys.L, char.IsUpper(character))); break;
                        case 'M': keystrokes.Add(new KeyStroke((byte)VirtualKeys.M, char.IsUpper(character))); break;
                        case 'N': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N, char.IsUpper(character))); break;
                        case 'O': keystrokes.Add(new KeyStroke((byte)VirtualKeys.O, char.IsUpper(character))); break;
                        case 'P': keystrokes.Add(new KeyStroke((byte)VirtualKeys.P, char.IsUpper(character))); break;
                        case 'Q': keystrokes.Add(new KeyStroke((byte)VirtualKeys.Q, char.IsUpper(character))); break;
                        case 'R': keystrokes.Add(new KeyStroke((byte)VirtualKeys.R, char.IsUpper(character))); break;
                        case 'S': keystrokes.Add(new KeyStroke((byte)VirtualKeys.S, char.IsUpper(character))); break;
                        case 'T': keystrokes.Add(new KeyStroke((byte)VirtualKeys.T, char.IsUpper(character))); break;
                        case 'U': keystrokes.Add(new KeyStroke((byte)VirtualKeys.U, char.IsUpper(character))); break;
                        case 'V': keystrokes.Add(new KeyStroke((byte)VirtualKeys.V, char.IsUpper(character))); break;
                        case 'W': keystrokes.Add(new KeyStroke((byte)VirtualKeys.W, char.IsUpper(character))); break;
                        case 'X': keystrokes.Add(new KeyStroke((byte)VirtualKeys.X, char.IsUpper(character))); break;
                        case 'Y': keystrokes.Add(new KeyStroke((byte)VirtualKeys.Y, char.IsUpper(character))); break;
                        case 'Z': keystrokes.Add(new KeyStroke((byte)VirtualKeys.Z, char.IsUpper(character))); break;
                        case '0': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N0, char.IsUpper(character))); break;
                        case '1': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N1, char.IsUpper(character))); break;
                        case '2': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N2, char.IsUpper(character))); break;
                        case '3': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N3, char.IsUpper(character))); break;
                        case '4': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N4, char.IsUpper(character))); break;
                        case '5': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N5, char.IsUpper(character))); break;
                        case '6': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N6, char.IsUpper(character))); break;
                        case '7': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N7, char.IsUpper(character))); break;
                        case '8': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N8, char.IsUpper(character))); break;
                        case '9': keystrokes.Add(new KeyStroke((byte)VirtualKeys.N9, char.IsUpper(character))); break;
                        case '.': keystrokes.Add(new KeyStroke((byte)VirtualKeys.OEMPeriod, char.IsUpper(character))); break;
                        case '-': keystrokes.Add(new KeyStroke((byte)VirtualKeys.OEMMinus, char.IsUpper(character))); break;
                        case '_': keystrokes.Add(new KeyStroke((byte)VirtualKeys.OEMMinus, false, true)); break;
                    }
                    if (char.IsWhiteSpace(character)) keystrokes.Add(new KeyStroke((byte)VirtualKeys.Space, char.IsUpper(character)));
                }

                SetForegroundWindow(GameProcess.MainWindowHandle);

                foreach (var keystroke in keystrokes)
                {
                    if (keystroke.IsUnderscore)
                    {
                        keybd_event((byte)VirtualKeys.Shift, 0, 0, 0);
                        keybd_event((byte)VirtualKeys.OEMMinus, 0, 0x0001 | 0, 0);
                        keybd_event((byte)VirtualKeys.Shift, 0, 0x0002, 0);
                        continue;
                    }

                    if (keystroke.IsUppercase)
                    {
                        keybd_event((byte)VirtualKeys.Shift, 0, 0, 0);
                        keybd_event(keystroke.Key, 0, 0x0001, 0);
                        keybd_event(keystroke.Key, 0, 0x0002, 0);
                        keybd_event((byte)VirtualKeys.Shift, 0, 0x0002, 0);
                    }
                    else
                    {
                        keybd_event(keystroke.Key, 0, 0x0001, 0);
                        keybd_event(keystroke.Key, 0, 0x0002, 0);
                    }
                }
            }
        }
    }
}
