﻿using FrEee.Game.Objects.Civilization;
using FrEee.Game.Objects.Space;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrEee.WinForms.Utility.Extensions;
using FrEee.Utility;
using FrEee.Utility.Extensions;
using System.IO;

namespace FrEee.WinForms.Forms
{
	public partial class ConstructionQueueListForm : Form
	{
		public ConstructionQueueListForm()
		{
			InitializeComponent();

			try {this.Icon = new Icon(FrEee.WinForms.Properties.Resources.FrEeeIcon);} catch {}

			RateMinerals.DefaultCellStyle.ForeColor = Resource.Minerals.Color;
			RateOrganics.DefaultCellStyle.ForeColor = Resource.Organics.Color;
			RateRadioactives.DefaultCellStyle.ForeColor = Resource.Radioactives.Color;

			// TODO - galaxy view background image can depend on galaxy template?
			galaxyView.BackgroundImage = Pictures.GetModImage(Path.Combine("Pictures", "UI", "Map", "quadrant"));
		}

		private void BindQueueList()
		{
			constructionQueueBindingSource.DataSource = Empire.Current.ConstructionQueues.ToArray();
		}

		private void ConstructionQueueListForm_Load(object sender, EventArgs e)
		{
			BindQueueList();
		}

		private void gridQueues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				var queue = (ConstructionQueue)gridQueues.Rows[e.RowIndex].DataBoundItem;
				var form = new ConstructionQueueForm(queue);
				this.ShowChildForm(form);
				if (form.DialogResult == DialogResult.OK)
					BindQueueList();
			}
		}

		private void gridQueues_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			if (e.StateChanged == DataGridViewElementStates.Selected)
			{
				var queue = (ConstructionQueue)e.Row.DataBoundItem;
				var sys = queue.Container.StarSystem;
				galaxyView.SelectedStarSystem = sys;
				starSystemView.StarSystem = sys;
				starSystemView.SelectedSpaceObject = queue.Container;
				starSystemView.SelectedSector = queue.Container.Sector;
			}
		}

		private void gridQueues_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == gridQueues.Columns.IndexOf(FirstItemEta) || e.ColumnIndex == gridQueues.Columns.IndexOf(Eta))
			{
				if (e.Value != null && (double)e.Value <= 1.0)
					e.CellStyle.BackColor = Color.DarkGreen;
			}

			if (e.ColumnIndex == gridQueues.Columns.IndexOf(CargoStorageFree) || 
				e.ColumnIndex == gridQueues.Columns.IndexOf(CargoStorageFreeInSector))
			{
				e.Value = ((int)e.Value).Kilotons();
			}
			else if (e.ColumnIndex == gridQueues.Columns.IndexOf(Eta) ||
				e.ColumnIndex == gridQueues.Columns.IndexOf(FirstItemEta))
			{
				if (e.Value != null)
					e.Value = ((double)e.Value).ToString("f1");
			}
		}

		private void gridQueues_SelectionChanged(object sender, EventArgs e)
		{
			gridQueues.ClearSelection();
		}
	}
}
