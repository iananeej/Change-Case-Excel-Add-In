using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Change_Case_Excel_Add_In_v3.Properties;

namespace Change_Case_Excel_Add_In_v3
{
    internal static class KbHook
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        private delegate int LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static readonly LowLevelKeyboardProc Proc = HookCallback;
        private static IntPtr _hookId = IntPtr.Zero;

        //declare the mouse hook constant.
        //For other hook types, you can obtain these values from Winuser.h in the Microsoft SDK.

        private const int WhKeyboard = 2; // mouse
        private const int HcAction = 0;

        public static void SetHook()
        {
            // Ignore this compiler warning, as SetWindowsHookEx doesn't work with ManagedThreadId
#pragma warning disable 618
            _hookId = SetWindowsHookEx(WhKeyboard, Proc, IntPtr.Zero, (uint) AppDomain.GetCurrentThreadId());
#pragma warning restore 618

        }

        public static void ReleaseHook()
        {
            UnhookWindowsHookEx(_hookId);
        }

        //Note that the custom code goes in this method the rest of the class stays the same.
        //It will trap if BOTH keys are pressed down.
        private static int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return (int) CallNextHookEx(_hookId, nCode, wParam, lParam);
            }
            if (nCode != HcAction) return (int) CallNextHookEx(_hookId, nCode, wParam, lParam);
            var keyData = (Keys) wParam;
            var keyDataString = keyData.ToString();
            var shortCutList = new List<string>
            {
                Settings.Default.ScUpperCase,
                Settings.Default.ScLowerCase,
                Settings.Default.ScProperCase,
                Settings.Default.ScSentenceCase,
                Settings.Default.ScToggleCase,
                Settings.Default.ScAlternateCase
            };
            if (!shortCutList.Contains(keyData.ToString())) return (int) CallNextHookEx(_hookId, nCode, wParam, lParam);
            if (!BindingFunctions.IsKeyDown(Keys.ControlKey) || !BindingFunctions.IsKeyDown(Keys.ShiftKey) ||
                !BindingFunctions.IsKeyDown(keyData)) return (int) CallNextHookEx(_hookId, nCode, wParam, lParam);
            if (keyDataString == Settings.Default.ScUpperCase)
                ChangeCase.Cc(AppStrings.UpperCase);
            else if (keyDataString == Settings.Default.ScLowerCase)
                ChangeCase.Cc(AppStrings.LowerCase);
            else if (keyDataString == Settings.Default.ScSentenceCase)
                ChangeCase.Cc(AppStrings.SentenceCase);
            else if (keyDataString == Settings.Default.ScProperCase)
                ChangeCase.Cc(AppStrings.ProperCase);
            else if (keyDataString == Settings.Default.ScToggleCase)
                ChangeCase.Cc(AppStrings.ToggelCase);
            else if (keyDataString == Settings.Default.ScAlternateCase)
                ChangeCase.Cc(AppStrings.AlternateCase);
            return (int) CallNextHookEx(_hookId, nCode, wParam, lParam);
        }
    }

    public class BindingFunctions
    {
        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        public static bool IsKeyDown(Keys keys)
        {
            return (GetKeyState((int) keys) & 0x8000) == 0x8000;
        }
    }

}