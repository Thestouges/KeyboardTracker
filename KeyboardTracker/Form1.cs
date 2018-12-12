using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace KeyboardTracker
{
    public partial class Form1 : Form
    {
        
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYUP = 0x105;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public event EventHandler<Keys> OnKeyPressed;
        public event EventHandler<Keys> OnKeyUnpressed;

        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;
        
        public void HookKeyboard()
        {
            _hookID = SetHook(_proc);
        }

        public void UnHookKeyboard()
        {
            UnhookWindowsHookEx(_hookID);
        }

        
        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                OnKeyPressed.Invoke(this, ((Keys)vkCode));
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                OnKeyUnpressed.Invoke(this, ((Keys)vkCode));
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        
        public Form1()
        {
            InitializeComponent();
            _proc = HookCallback;
            OnKeyPressed += kbh_OnKeyPressed;
            OnKeyUnpressed += kbh_OnKeyUnPressed;
            HookKeyboard();
        }

        void kbh_OnKeyPressed(object sender, Keys e)
        {
            if (e == Keys.A)
            {
                buttonA.BackColor = Color.Teal;
            }
            if (e == Keys.B)
            {
                buttonB.BackColor = Color.Teal;
            }
            if (e == Keys.C)
            {
                buttonC.BackColor = Color.Teal;
            }
            if (e == Keys.D)
            {
                buttonD.BackColor = Color.Teal;
            }
            if (e == Keys.E)
            {
                buttonE.BackColor = Color.Teal;
            }
            if (e == Keys.F)
            {
                buttonF.BackColor = Color.Teal;
            }
            if (e == Keys.G)
            {
                buttonG.BackColor = Color.Teal;
            }
            if (e == Keys.H)
            {
                buttonH.BackColor = Color.Teal;
            }
            if (e == Keys.I)
            {
                buttonI.BackColor = Color.Teal;
            }
            if (e == Keys.J)
            {
                buttonJ.BackColor = Color.Teal;
            }
            if (e == Keys.K)
            {
                buttonK.BackColor = Color.Teal;
            }
            if (e == Keys.L)
            {
                buttonL.BackColor = Color.Teal;
            }
            if (e == Keys.M)
            {
                buttonM.BackColor = Color.Teal;
            }
            if (e == Keys.N)
            {
                buttonN.BackColor = Color.Teal;
            }
            if (e == Keys.O)
            {
                buttonO.BackColor = Color.Teal;
            }
            if (e == Keys.P)
            {
                buttonP.BackColor = Color.Teal;
            }
            if (e == Keys.Q)
            {
                buttonQ.BackColor = Color.Teal;
            }
            if (e == Keys.R)
            {
                buttonR.BackColor = Color.Teal;
            }
            if (e == Keys.S)
            {
                buttonS.BackColor = Color.Teal;
            }
            if (e == Keys.T)
            {
                buttonT.BackColor = Color.Teal;
            }
            if (e == Keys.U)
            {
                buttonU.BackColor = Color.Teal;
            }
            if (e == Keys.V)
            {
                buttonV.BackColor = Color.Teal;
            }
            if (e == Keys.W)
            {
                buttonW.BackColor = Color.Teal;
            }
            if (e == Keys.X)
            {
                buttonX.BackColor = Color.Teal;
            }
            if (e == Keys.Y)
            {
                buttonY.BackColor = Color.Teal;
            }
            if (e == Keys.Z)
            {
                buttonZ.BackColor = Color.Teal;
            }

            if (e == Keys.Escape)
            {
                buttonESC.BackColor = Color.Teal;
            }
            if (e == Keys.F1)
            {
                buttonF1.BackColor = Color.Teal;
            }
            if (e == Keys.F2)
            {
                buttonF2.BackColor = Color.Teal;
            }
            if (e == Keys.F3)
            {
                buttonF3.BackColor = Color.Teal;
            }
            if (e == Keys.F4)
            {
                buttonF4.BackColor = Color.Teal;
            }
            if (e == Keys.F5)
            {
                buttonF5.BackColor = Color.Teal;
            }
            if (e == Keys.F6)
            {
                buttonF6.BackColor = Color.Teal;
            }
            if (e == Keys.F7)
            {
                buttonF7.BackColor = Color.Teal;
            }
            if (e == Keys.F8)
            {
                buttonF8.BackColor = Color.Teal;
            }
            if (e == Keys.F9)
            {
                buttonF9.BackColor = Color.Teal;
            }
            if (e == Keys.F10)
            {
                buttonF10.BackColor = Color.Teal;
            }
            if (e == Keys.F11)
            {
                buttonF11.BackColor = Color.Teal;
            }
            if (e == Keys.F12)
            {
                buttonF12.BackColor = Color.Teal;
            }

            if (e == Keys.Oemtilde)
            {
                buttonTilde.BackColor = Color.Teal;
            }
            if (e == Keys.D1)
            {
                button1.BackColor = Color.Teal;
            }
            if (e == Keys.D2)
            {
                button2.BackColor = Color.Teal;
            }
            if (e == Keys.D3)
            {
                button3.BackColor = Color.Teal;
            }
            if (e == Keys.D4)
            {
                button4.BackColor = Color.Teal;
            }
            if (e == Keys.D5)
            {
                button5.BackColor = Color.Teal;
            }
            if (e == Keys.D6)
            {
                button6.BackColor = Color.Teal;
            }
            if (e == Keys.D7)
            {
                button7.BackColor = Color.Teal;
            }
            if (e == Keys.D8)
            {
                button8.BackColor = Color.Teal;
            }
            if (e == Keys.D9)
            {
                button9.BackColor = Color.Teal;
            }
            if (e == Keys.D0)
            {
                button0.BackColor = Color.Teal;
            }

            if (e == Keys.NumPad0)
            {
                buttonNum0.BackColor = Color.Teal;
            }
            if (e == Keys.NumPad1)
            {
                buttonNum1.BackColor = Color.Teal;
            }
            if (e == Keys.NumPad2)
            {
                buttonNum2.BackColor = Color.Teal;
            }
            if (e == Keys.NumPad3)
            {
                buttonNum3.BackColor = Color.Teal;
            }
            if (e == Keys.NumPad4)
            {
                buttonNum4.BackColor = Color.Teal;
            }
            if (e == Keys.NumPad5)
            {
                buttonNum5.BackColor = Color.Teal;
            }
            if (e == Keys.NumPad6)
            {
                buttonNum6.BackColor = Color.Teal;
            }
            if (e == Keys.NumPad7)
            {
                buttonNum7.BackColor = Color.Teal;
            }
            if (e == Keys.NumPad8)
            {
                buttonNum8.BackColor = Color.Teal;
            }
            if (e == Keys.NumPad9)
            {
                buttonNum9.BackColor = Color.Teal;
            }

            if (e == Keys.Up)
            {
                buttonUp.BackColor = Color.Teal;
            }
            if (e == Keys.Down)
            {
                buttonDown.BackColor = Color.Teal;
            }
            if (e == Keys.Left)
            {
                buttonLeft.BackColor = Color.Teal;
            }
            if (e == Keys.Right)
            {
                buttonRight.BackColor = Color.Teal;
            }

            if (e == Keys.Subtract)
            {
                buttonHyphen.BackColor = Color.Teal;
            }
            if (e == Keys.Add)
            {
                buttonEqual.BackColor = Color.Teal;
            }
            if (e == Keys.Back)
            {
                buttonBackspace.BackColor = Color.Teal;
            }
            if (e == Keys.Tab)
            {
                buttonTab.BackColor = Color.Teal;
            }
            if (e == Keys.OemOpenBrackets)
            {
                buttonLeftBracket.BackColor = Color.Teal;
            }
            if (e == Keys.OemCloseBrackets)
            {
                buttonRightBracket.BackColor = Color.Teal;
            }
            if (e == Keys.Oem5)
            {
                buttonBackSlash.BackColor = Color.Teal;
            }
            if (e == Keys.CapsLock)
            {
                buttonCaps.BackColor = Color.Teal;
            }
            if (e == Keys.OemSemicolon)
            {
                buttonSemicolon.BackColor = Color.Teal;
            }
            if (e == Keys.OemQuotes)
            {
                buttonQuote.BackColor = Color.Teal;
            }
            if (e == Keys.Enter)
            {
                buttonEnter.BackColor = Color.Teal;
            }
            if (e == Keys.LShiftKey)
            {
                buttonLeftShift.BackColor = Color.Teal;
            }
            if (e == Keys.RShiftKey)
            {
                buttonRightShift.BackColor = Color.Teal;
            }
            if (e == Keys.Oemcomma)
            {
                buttonComma.BackColor = Color.Teal;
            }
            if (e == Keys.OemPeriod)
            {
                buttonPeriod.BackColor = Color.Teal;
            }
            if (e == Keys.OemQuestion)
            {
                buttonQuestion.BackColor = Color.Teal;
            }
            if (e == Keys.LControlKey)
            {
                buttonLeftCtrl.BackColor = Color.Teal;
            }
            if (e == Keys.RControlKey)
            {
                buttonRightCtrl.BackColor = Color.Teal;
            }
            if (e == Keys.LMenu)
            {
                buttonLeftAlt.BackColor = Color.Teal;
            }
            if (e == Keys.RMenu)
            {
                buttonRightAlt.BackColor = Color.Teal;
            }
            if (e == Keys.LWin)
            {
                buttonWin.BackColor = Color.Teal;
            }
            if (e == Keys.Space)
            {
                buttonSpace.BackColor = Color.Teal;
            }
        }

        void kbh_OnKeyUnPressed(object sender, Keys e)
        {
            if (e == Keys.A)
            {
                buttonA.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.B)
            {
                buttonB.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.C)
            {
                buttonC.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D)
            {
                buttonD.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.E)
            {
                buttonE.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F)
            {
                buttonF.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.G)
            {
                buttonG.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.H)
            {
                buttonH.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.I)
            {
                buttonI.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.J)
            {
                buttonJ.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.K)
            {
                buttonK.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.L)
            {
                buttonL.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.M)
            {
                buttonM.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.N)
            {
                buttonN.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.O)
            {
                buttonO.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.P)
            {
                buttonP.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Q)
            {
                buttonQ.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.R)
            {
                buttonR.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.S)
            {
                buttonS.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.T)
            {
                buttonT.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.U)
            {
                buttonU.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.V)
            {
                buttonV.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.W)
            {
                buttonW.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.X)
            {
                buttonX.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Y)
            {
                buttonY.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Z)
            {
                buttonZ.BackColor = Color.FromArgb(255, 255, 192);
            }

            if (e == Keys.Escape)
            {
                buttonESC.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F1)
            {
                buttonF1.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F2)
            {
                buttonF2.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F3)
            {
                buttonF3.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F4)
            {
                buttonF4.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F5)
            {
                buttonF5.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F6)
            {
                buttonF6.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F7)
            {
                buttonF7.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F8)
            {
                buttonF8.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F9)
            {
                buttonF9.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F10)
            {
                buttonF10.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F11)
            {
                buttonF11.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.F12)
            {
                buttonF12.BackColor = Color.FromArgb(255, 255, 192);
            }

            if (e == Keys.Oemtilde)
            {
                buttonTilde.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D1)
            {
                button1.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D2)
            {
                button2.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D3)
            {
                button3.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D4)
            {
                button4.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D5)
            {
                button5.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D6)
            {
                button6.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D7)
            {
                button7.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D8)
            {
                button8.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D9)
            {
                button9.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.D0)
            {
                button0.BackColor = Color.FromArgb(255, 255, 192);
            }

            if (e == Keys.NumPad0)
            {
                buttonNum0.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.NumPad1)
            {
                buttonNum1.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.NumPad2)
            {
                buttonNum2.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.NumPad3)
            {
                buttonNum3.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.NumPad4)
            {
                buttonNum4.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.NumPad5)
            {
                buttonNum5.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.NumPad6)
            {
                buttonNum6.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.NumPad7)
            {
                buttonNum7.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.NumPad8)
            {
                buttonNum8.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.NumPad9)
            {
                buttonNum9.BackColor = Color.FromArgb(255, 255, 192);
            }

            if (e == Keys.Up)
            {
                buttonUp.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Down)
            {
                buttonDown.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Left)
            {
                buttonLeft.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Right)
            {
                buttonRight.BackColor = Color.FromArgb(255, 255, 192);
            }

            if (e == Keys.Subtract)
            {
                buttonHyphen.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Add)
            {
                buttonEqual.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Back)
            {
                buttonBackspace.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Tab)
            {
                buttonTab.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.OemOpenBrackets)
            {
                buttonLeftBracket.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.OemCloseBrackets)
            {
                buttonRightBracket.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Oem5)
            {
                buttonBackSlash.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.CapsLock)
            {
                buttonCaps.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.OemSemicolon)
            {
                buttonSemicolon.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.OemQuotes)
            {
                buttonQuote.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Enter)
            {
                buttonEnter.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.LShiftKey)
            {
                buttonLeftShift.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.RShiftKey)
            {
                buttonRightShift.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Oemcomma)
            {
                buttonComma.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.OemPeriod)
            {
                buttonPeriod.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.OemQuestion)
            {
                buttonQuestion.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.LControlKey)
            {
                buttonLeftCtrl.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.RControlKey)
            {
                buttonRightCtrl.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.LMenu)
            {
                buttonLeftAlt.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.RMenu)
            {
                buttonRightAlt.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.LWin)
            {
                buttonWin.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (e == Keys.Space)
            {
                buttonSpace.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void Form1_FormClosing(Object sender, FormClosedEventArgs e)
        {
            UnHookKeyboard();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
