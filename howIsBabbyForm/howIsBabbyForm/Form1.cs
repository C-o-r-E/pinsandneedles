using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace howIsBabbyForm
{
    public partial class Form1 : Form
    {
        const string dllPath = "..\\..\\..\\..\\dLib\\Debug\\dLib.dll";
        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int setNum(
            int iNum);
        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getNum();

        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int setStr(
            [MarshalAs(UnmanagedType.LPWStr)]
            string s);

        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int getStr(StringBuilder strb);

        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void regCbA(cbDelegate cbd);

        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void regCbB(cbDelegate cbd);

        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cbEvent(int num);

        public delegate void cbDelegate();

        public void cbA()
        {
            textOut.AppendText("\nA called");
        }

        public void cbB()
        {
            textOut.AppendText("\nB called");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbDelegate fnA = new cbDelegate(cbA);
            cbDelegate fnB = new cbDelegate(cbB);

            StringBuilder bob = new StringBuilder(64);
            int iTest = 1;
            textOut.AppendText("iTest = " + iTest);

            iTest = setNum(42);
            textOut.AppendText("\niTest = " + iTest);

            iTest = getNum();
            textOut.AppendText("\niTest = " + iTest);

            iTest = setStr("Derp");
            textOut.AppendText("\niTest = " + iTest);

            iTest = getStr(bob);
            bob.Length = iTest;
            textOut.AppendText("\n" + iTest + "\n" + bob);

            regCbA(fnA);
            regCbB(fnB);

            cbEvent(0);
            cbEvent(42);
            cbEvent(2);

            textOut.AppendText("\n\n");

        }
    }
}
