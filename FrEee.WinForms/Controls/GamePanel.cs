using System;
using System.Drawing;
using System.Windows.Forms;

namespace FrEee.WinForms.Controls
{
	public partial class GamePanel : Panel
	{
		public GamePanel()
		{
			InitializeComponent();
			this.SizeChanged += GamePanel_SizeChanged;
			BackColor = Color.Black;
			ForeColor = Color.White;
			BorderColor = Color.CornflowerBlue;
			DoubleBuffered = true;
			Padding = new Padding(3);
			BorderStyle = BorderStyle.FixedSingle;
		}

		void GamePanel_SizeChanged(object sender, EventArgs e)
		{
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			if (BorderStyle == BorderStyle.FixedSingle)
				ControlPaint.DrawBorder(pe.Graphics, ClientRectangle, BorderColor, ButtonBorderStyle.Solid);
		}

		private Color borderColor;

		/// <summary>
		/// Color of the border for BorderStyle.FixedSingle mode.
		/// </summary>
		public Color BorderColor
		{
			get { return borderColor; }
			set
			{
				borderColor = value;
				Invalidate();
			}
		}
	}
}
