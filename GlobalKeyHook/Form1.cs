using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalKeyHook
{
	public partial class Form1 : Form
	{
		MouseHookListener mouseListener;
		KeyboardHookListener keyListener;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			var hooker = new GlobalHooker();
			mouseListener = new MouseHookListener(hooker);
			mouseListener.Enabled = true;
			mouseListener.MouseDownExt += (s, ea) =>
			{
				textBox1.Text += "Click: " + ea.Button + "\r\n";
			};
			
			keyListener = new KeyboardHookListener(hooker);
			keyListener.Enabled = true;
			keyListener.KeyDown += (s, ea) =>
			{
				textBox1.Text += "KeyPress: " + ea.KeyCode + "\r\n";
			};
			this.TopMost = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			mouseListener.Enabled = false;
			keyListener.Enabled = false;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			mouseListener.Enabled = false;
			keyListener.Enabled = false;
		}
	}
}
