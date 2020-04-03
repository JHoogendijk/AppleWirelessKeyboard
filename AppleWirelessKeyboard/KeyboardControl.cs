using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput.Native;
using System.Windows;

namespace AppleWirelessKeyboard
{
    public static class KeyboardControl
    {
        const int VK_SNAPSHOT = 44;
        const int VK_DELETE = 46;
        const int VK_MEDIA_NEXT_TRACK = 176;
        const int VK_MEDIA_PREV_TRACK = 177;
        const int VK_MEDIA_STOP = 178;
        const int VK_MEDIA_PLAY_PAUSE = 179;
        const int VK_END = 0x23;
        const int VK_HOME = 0x24;
        const int VK_PAGEUP = 0x21;
        const int VK_PAGEDOWN = 0x22;
        const int VK_F3 = 117;
        const int VK_INSERT = 45;
        const int VK_VOLUME_MUTE = 0xAD;
        const int VK_VOLUME_DOWN = 0xAE;
        const int VK_VOLUME_UP = 0xAF;


        public static void Send(int VKey, KeyboardEvent e = KeyboardEvent.Both)
        {
            switch (e)
            {
                case KeyboardEvent.Both:
                    {
                        keybd_event((byte)VKey, 0, 0, 0);
                        keybd_event((byte)VKey, 0, 2, 0);
                    }
                    break;
                case KeyboardEvent.Down:
                    keybd_event((byte)VKey, 0, 0, 0);
                    break;
                case KeyboardEvent.Up:
                    keybd_event((byte)VKey, 0, 2, 0);
                    break;
            }
        }

        public static void SendInsert()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_INSERT);
            });
        }

        public static void SendDelete()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_DELETE);
            });
        }

        internal static void BrightnessDown()
        {
            Task.Factory.StartNew(() =>
            {
                BrightnessManager bm = new BrightnessManager();
                bm.LowerBrightness();
                //NotificationCenter.NotifyBrightnessLevel(Convert.ToInt32(bm.GetBrightness()));
            });
        }

        public static void SendPlayPause()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_MEDIA_PLAY_PAUSE);
            });
        }

        internal static void BrightnessUp()
        {
            Task.Factory.StartNew(() =>
            {
                BrightnessManager bm = new BrightnessManager();
                bm.UpBrightness();
                //NotificationCenter.NotifyBrightnessLevel(Convert.ToInt32(bm.GetBrightness()));
            });
        }

        internal static void ToggleTaskView()
        {
            Task.Factory.StartNew(() =>
            {
                WindowsInput.InputSimulator kb = new WindowsInput.InputSimulator();
                kb.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.TAB);
            });
        }

        public static void SendNextTrack()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_MEDIA_NEXT_TRACK);
            });
        }

        internal static void ToggleNotificationCenter()
        {
            Task.Factory.StartNew(() =>
            {
                WindowsInput.InputSimulator kb = new WindowsInput.InputSimulator();
                kb.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_A);
            });
        }

        public static void SendPreviousTrack()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_MEDIA_PREV_TRACK);
            });
        }

        #region PInvoke
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public enum KeyboardEvent
        {
            Down = 0, Up = 2, Both
        }
        #endregion

        internal static void VolumeDown()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_VOLUME_DOWN);
            });
        }

        internal static void ToggleMute()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_VOLUME_MUTE);
            });
        }

        internal static void VolumeUp()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_VOLUME_UP);
            });
        }

        public static void SendPageUp()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_PAGEUP);
            });
        }
        public static void SendPageDown()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_PAGEDOWN);
            });
        }
        public static void SendHome()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_HOME);
            });
        }
        public static void SendEnd()
        {
            Task.Factory.StartNew(() =>
            {
                Send(VK_END);
            });
        }

    }
}
