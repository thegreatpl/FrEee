using FrEee.WinForms.Controls;

namespace FrEee.WinForms.Forms
{
	partial class GameForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.pnlHeader = new FrEee.WinForms.Controls.GamePanel();
			this.gameProgressBar1 = new FrEee.WinForms.Controls.GameProgressBar();
			this.pagResources = new FrEee.WinForms.Controls.Pager();
			this.txtGameDate = new System.Windows.Forms.Label();
			this.lblGameDate = new System.Windows.Forms.Label();
			this.picEmpireFlag = new System.Windows.Forms.PictureBox();
			this.pnlMainCommands = new FrEee.WinForms.Controls.GamePanel();
			this.btnLog = new FrEee.WinForms.Controls.GameButton();
			this.btnQueues = new FrEee.WinForms.Controls.GameButton();
			this.btnShips = new FrEee.WinForms.Controls.GameButton();
			this.btnEmpires = new FrEee.WinForms.Controls.GameButton();
			this.btnPlanets = new FrEee.WinForms.Controls.GameButton();
			this.btnDesigns = new FrEee.WinForms.Controls.GameButton();
			this.btnMenu = new FrEee.WinForms.Controls.GameButton();
			this.pnlSubCommands = new FrEee.WinForms.Controls.GamePanel();
			this.pnlSearch = new FrEee.WinForms.Controls.GamePanel();
			this.pnlSystemTabs = new FrEee.WinForms.Controls.GamePanel();
			this.pnlDetailReport = new FrEee.WinForms.Controls.GamePanel();
			this.gameShipReport1 = new FrEee.WinForms.Controls.ShipReport();
			this.pnlSystemMap = new FrEee.WinForms.Controls.GamePanel();
			this.starSystemView = new FrEee.WinForms.Controls.StarSystemView();
			this.pnlGalaxyMap = new FrEee.WinForms.Controls.GamePanel();
			this.galaxyView = new FrEee.WinForms.Controls.GalaxyView();
			this.tableLayoutPanel1.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picEmpireFlag)).BeginInit();
			this.pnlMainCommands.SuspendLayout();
			this.pnlDetailReport.SuspendLayout();
			this.pnlSystemMap.SuspendLayout();
			this.pnlGalaxyMap.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 304F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 358F));
			this.tableLayoutPanel1.Controls.Add(this.pnlHeader, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.pnlMainCommands, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.pnlSubCommands, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.pnlSearch, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.pnlSystemTabs, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.pnlDetailReport, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.pnlSystemMap, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.pnlGalaxyMap, 3, 4);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 308F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1205, 755);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// pnlHeader
			// 
			this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlHeader.BackColor = System.Drawing.Color.Black;
			this.pnlHeader.BorderColor = System.Drawing.Color.RoyalBlue;
			this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel1.SetColumnSpan(this.pnlHeader, 4);
			this.pnlHeader.Controls.Add(this.gameProgressBar1);
			this.pnlHeader.Controls.Add(this.pagResources);
			this.pnlHeader.Controls.Add(this.txtGameDate);
			this.pnlHeader.Controls.Add(this.lblGameDate);
			this.pnlHeader.Controls.Add(this.picEmpireFlag);
			this.pnlHeader.ForeColor = System.Drawing.Color.White;
			this.pnlHeader.Location = new System.Drawing.Point(4, 4);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(1197, 31);
			this.pnlHeader.TabIndex = 0;
			// 
			// gameProgressBar1
			// 
			this.gameProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gameProgressBar1.BackColor = System.Drawing.Color.Black;
			this.gameProgressBar1.BarColor = System.Drawing.Color.Magenta;
			this.gameProgressBar1.BorderColor = System.Drawing.Color.CornflowerBlue;
			this.gameProgressBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gameProgressBar1.ForeColor = System.Drawing.Color.White;
			this.gameProgressBar1.LeftText = "Ice Planet Colonization";
			this.gameProgressBar1.Location = new System.Drawing.Point(603, 3);
			this.gameProgressBar1.Margin = new System.Windows.Forms.Padding(0);
			this.gameProgressBar1.Maximum = 500000;
			this.gameProgressBar1.Name = "gameProgressBar1";
			this.gameProgressBar1.RightText = "0.2 years";
			this.gameProgressBar1.Size = new System.Drawing.Size(438, 22);
			this.gameProgressBar1.TabIndex = 9;
			this.gameProgressBar1.Value = 350000;
			// 
			// pagResources
			// 
			this.pagResources.BackColor = System.Drawing.Color.Black;
			this.pagResources.Content = null;
			this.pagResources.CurrentPage = 0;
			this.pagResources.ForeColor = System.Drawing.Color.White;
			this.pagResources.Location = new System.Drawing.Point(185, 5);
			this.pagResources.Margin = new System.Windows.Forms.Padding(0);
			this.pagResources.Name = "pagResources";
			this.pagResources.ShowPager = false;
			this.pagResources.Size = new System.Drawing.Size(416, 21);
			this.pagResources.TabIndex = 7;
			// 
			// txtGameDate
			// 
			this.txtGameDate.Location = new System.Drawing.Point(131, 5);
			this.txtGameDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.txtGameDate.Name = "txtGameDate";
			this.txtGameDate.Size = new System.Drawing.Size(51, 21);
			this.txtGameDate.TabIndex = 4;
			this.txtGameDate.Text = "2400.6";
			this.txtGameDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblGameDate
			// 
			this.lblGameDate.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.lblGameDate.Location = new System.Drawing.Point(50, 5);
			this.lblGameDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblGameDate.Name = "lblGameDate";
			this.lblGameDate.Size = new System.Drawing.Size(73, 21);
			this.lblGameDate.TabIndex = 3;
			this.lblGameDate.Text = "Game Date";
			this.lblGameDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picEmpireFlag
			// 
			this.picEmpireFlag.Location = new System.Drawing.Point(4, 5);
			this.picEmpireFlag.Margin = new System.Windows.Forms.Padding(4);
			this.picEmpireFlag.Name = "picEmpireFlag";
			this.picEmpireFlag.Size = new System.Drawing.Size(38, 21);
			this.picEmpireFlag.TabIndex = 0;
			this.picEmpireFlag.TabStop = false;
			// 
			// pnlMainCommands
			// 
			this.pnlMainCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlMainCommands.BackColor = System.Drawing.Color.Black;
			this.pnlMainCommands.BorderColor = System.Drawing.Color.RoyalBlue;
			this.pnlMainCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlMainCommands.Controls.Add(this.btnLog);
			this.pnlMainCommands.Controls.Add(this.btnQueues);
			this.pnlMainCommands.Controls.Add(this.btnShips);
			this.pnlMainCommands.Controls.Add(this.btnEmpires);
			this.pnlMainCommands.Controls.Add(this.btnPlanets);
			this.pnlMainCommands.Controls.Add(this.btnDesigns);
			this.pnlMainCommands.Controls.Add(this.btnMenu);
			this.pnlMainCommands.ForeColor = System.Drawing.Color.White;
			this.pnlMainCommands.Location = new System.Drawing.Point(4, 43);
			this.pnlMainCommands.Margin = new System.Windows.Forms.Padding(4);
			this.pnlMainCommands.Name = "pnlMainCommands";
			this.pnlMainCommands.Padding = new System.Windows.Forms.Padding(4);
			this.pnlMainCommands.Size = new System.Drawing.Size(296, 46);
			this.pnlMainCommands.TabIndex = 1;
			// 
			// btnLog
			// 
			this.btnLog.BackColor = System.Drawing.Color.Black;
			this.btnLog.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnLog.Location = new System.Drawing.Point(255, 4);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size(36, 36);
			this.btnLog.TabIndex = 6;
			this.btnLog.UseVisualStyleBackColor = false;
			// 
			// btnQueues
			// 
			this.btnQueues.BackColor = System.Drawing.Color.Black;
			this.btnQueues.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnQueues.Location = new System.Drawing.Point(213, 4);
			this.btnQueues.Name = "btnQueues";
			this.btnQueues.Size = new System.Drawing.Size(36, 36);
			this.btnQueues.TabIndex = 5;
			this.btnQueues.UseVisualStyleBackColor = false;
			this.btnQueues.Click += new System.EventHandler(this.btnQueues_Click);
			// 
			// btnShips
			// 
			this.btnShips.BackColor = System.Drawing.Color.Black;
			this.btnShips.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnShips.Location = new System.Drawing.Point(171, 4);
			this.btnShips.Name = "btnShips";
			this.btnShips.Size = new System.Drawing.Size(36, 36);
			this.btnShips.TabIndex = 4;
			this.btnShips.UseVisualStyleBackColor = false;
			// 
			// btnEmpires
			// 
			this.btnEmpires.BackColor = System.Drawing.Color.Black;
			this.btnEmpires.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnEmpires.Location = new System.Drawing.Point(129, 4);
			this.btnEmpires.Name = "btnEmpires";
			this.btnEmpires.Size = new System.Drawing.Size(36, 36);
			this.btnEmpires.TabIndex = 3;
			this.btnEmpires.UseVisualStyleBackColor = false;
			// 
			// btnPlanets
			// 
			this.btnPlanets.BackColor = System.Drawing.Color.Black;
			this.btnPlanets.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnPlanets.Location = new System.Drawing.Point(87, 4);
			this.btnPlanets.Name = "btnPlanets";
			this.btnPlanets.Size = new System.Drawing.Size(36, 36);
			this.btnPlanets.TabIndex = 0;
			this.btnPlanets.UseVisualStyleBackColor = false;
			this.btnPlanets.Click += new System.EventHandler(this.btnPlanets_Click);
			// 
			// btnDesigns
			// 
			this.btnDesigns.BackColor = System.Drawing.Color.Black;
			this.btnDesigns.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnDesigns.Location = new System.Drawing.Point(46, 4);
			this.btnDesigns.Name = "btnDesigns";
			this.btnDesigns.Size = new System.Drawing.Size(36, 36);
			this.btnDesigns.TabIndex = 2;
			this.btnDesigns.UseVisualStyleBackColor = false;
			// 
			// btnMenu
			// 
			this.btnMenu.BackColor = System.Drawing.Color.Black;
			this.btnMenu.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnMenu.Location = new System.Drawing.Point(4, 4);
			this.btnMenu.Name = "btnMenu";
			this.btnMenu.Size = new System.Drawing.Size(36, 36);
			this.btnMenu.TabIndex = 1;
			this.btnMenu.UseVisualStyleBackColor = false;
			// 
			// pnlSubCommands
			// 
			this.pnlSubCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSubCommands.BackColor = System.Drawing.Color.Black;
			this.pnlSubCommands.BorderColor = System.Drawing.Color.RoyalBlue;
			this.pnlSubCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel1.SetColumnSpan(this.pnlSubCommands, 2);
			this.pnlSubCommands.ForeColor = System.Drawing.Color.White;
			this.pnlSubCommands.Location = new System.Drawing.Point(308, 43);
			this.pnlSubCommands.Margin = new System.Windows.Forms.Padding(4);
			this.pnlSubCommands.Name = "pnlSubCommands";
			this.pnlSubCommands.Size = new System.Drawing.Size(534, 46);
			this.pnlSubCommands.TabIndex = 2;
			// 
			// pnlSearch
			// 
			this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSearch.BackColor = System.Drawing.Color.Black;
			this.pnlSearch.BorderColor = System.Drawing.Color.RoyalBlue;
			this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel1.SetColumnSpan(this.pnlSearch, 2);
			this.pnlSearch.ForeColor = System.Drawing.Color.White;
			this.pnlSearch.Location = new System.Drawing.Point(4, 97);
			this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Size = new System.Drawing.Size(567, 42);
			this.pnlSearch.TabIndex = 2;
			// 
			// pnlSystemTabs
			// 
			this.pnlSystemTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSystemTabs.BackColor = System.Drawing.Color.Black;
			this.pnlSystemTabs.BorderColor = System.Drawing.Color.RoyalBlue;
			this.pnlSystemTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlSystemTabs.ForeColor = System.Drawing.Color.White;
			this.pnlSystemTabs.Location = new System.Drawing.Point(579, 97);
			this.pnlSystemTabs.Margin = new System.Windows.Forms.Padding(4);
			this.pnlSystemTabs.Name = "pnlSystemTabs";
			this.pnlSystemTabs.Size = new System.Drawing.Size(263, 42);
			this.pnlSystemTabs.TabIndex = 3;
			// 
			// pnlDetailReport
			// 
			this.pnlDetailReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlDetailReport.BackColor = System.Drawing.Color.Black;
			this.pnlDetailReport.BorderColor = System.Drawing.Color.RoyalBlue;
			this.pnlDetailReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDetailReport.Controls.Add(this.gameShipReport1);
			this.pnlDetailReport.ForeColor = System.Drawing.Color.White;
			this.pnlDetailReport.Location = new System.Drawing.Point(850, 43);
			this.pnlDetailReport.Margin = new System.Windows.Forms.Padding(4);
			this.pnlDetailReport.Name = "pnlDetailReport";
			this.tableLayoutPanel1.SetRowSpan(this.pnlDetailReport, 3);
			this.pnlDetailReport.Size = new System.Drawing.Size(351, 379);
			this.pnlDetailReport.TabIndex = 3;
			// 
			// gameShipReport1
			// 
			this.gameShipReport1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gameShipReport1.BackColor = System.Drawing.Color.Black;
			this.gameShipReport1.ForeColor = System.Drawing.Color.White;
			this.gameShipReport1.Location = new System.Drawing.Point(4, 4);
			this.gameShipReport1.Name = "gameShipReport1";
			this.gameShipReport1.Size = new System.Drawing.Size(342, 370);
			this.gameShipReport1.TabIndex = 0;
			// 
			// pnlSystemMap
			// 
			this.pnlSystemMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSystemMap.BackColor = System.Drawing.Color.Black;
			this.pnlSystemMap.BorderColor = System.Drawing.Color.RoyalBlue;
			this.pnlSystemMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel1.SetColumnSpan(this.pnlSystemMap, 3);
			this.pnlSystemMap.Controls.Add(this.starSystemView);
			this.pnlSystemMap.ForeColor = System.Drawing.Color.White;
			this.pnlSystemMap.Location = new System.Drawing.Point(4, 147);
			this.pnlSystemMap.Margin = new System.Windows.Forms.Padding(4);
			this.pnlSystemMap.Name = "pnlSystemMap";
			this.tableLayoutPanel1.SetRowSpan(this.pnlSystemMap, 2);
			this.pnlSystemMap.Size = new System.Drawing.Size(838, 583);
			this.pnlSystemMap.TabIndex = 4;
			// 
			// starSystemView
			// 
			this.starSystemView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.starSystemView.BackColor = System.Drawing.Color.Black;
			this.starSystemView.Location = new System.Drawing.Point(4, 3);
			this.starSystemView.Name = "starSystemView";
			this.starSystemView.SelectedSector = null;
			this.starSystemView.Size = new System.Drawing.Size(678, 571);
			this.starSystemView.StarSystem = null;
			this.starSystemView.TabIndex = 0;
			this.starSystemView.SectorClicked += new FrEee.WinForms.Controls.StarSystemView.SectorSelectionDelegate(this.starSystemView_SectorClicked);
			this.starSystemView.SectorSelected += new FrEee.WinForms.Controls.StarSystemView.SectorSelectionDelegate(this.starSystemView_SectorSelected);
			// 
			// pnlGalaxyMap
			// 
			this.pnlGalaxyMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlGalaxyMap.BackColor = System.Drawing.Color.Black;
			this.pnlGalaxyMap.BorderColor = System.Drawing.Color.RoyalBlue;
			this.pnlGalaxyMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlGalaxyMap.Controls.Add(this.galaxyView);
			this.pnlGalaxyMap.ForeColor = System.Drawing.Color.White;
			this.pnlGalaxyMap.Location = new System.Drawing.Point(850, 430);
			this.pnlGalaxyMap.Margin = new System.Windows.Forms.Padding(4);
			this.pnlGalaxyMap.Name = "pnlGalaxyMap";
			this.pnlGalaxyMap.Size = new System.Drawing.Size(351, 300);
			this.pnlGalaxyMap.TabIndex = 5;
			// 
			// galaxyView
			// 
			this.galaxyView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.galaxyView.BackColor = System.Drawing.Color.Black;
			this.galaxyView.Galaxy = null;
			this.galaxyView.Location = new System.Drawing.Point(4, 3);
			this.galaxyView.Name = "galaxyView";
			this.galaxyView.SelectedStarSystem = null;
			this.galaxyView.Size = new System.Drawing.Size(342, 288);
			this.galaxyView.TabIndex = 0;
			this.galaxyView.Text = "galaxyView1";
			this.galaxyView.StarSystemClicked += new FrEee.WinForms.Controls.GalaxyView.StarSystemSelectionDelegate(this.galaxyView_StarSystemClicked);
			this.galaxyView.StarSystemSelected += new FrEee.WinForms.Controls.GalaxyView.StarSystemSelectionDelegate(this.galaxyView_StarSystemSelected);
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1229, 779);
			this.Controls.Add(this.tableLayoutPanel1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(900, 700);
			this.Name = "GameForm";
			this.Text = "FrEee";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picEmpireFlag)).EndInit();
			this.pnlMainCommands.ResumeLayout(false);
			this.pnlDetailReport.ResumeLayout(false);
			this.pnlSystemMap.ResumeLayout(false);
			this.pnlGalaxyMap.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private GamePanel pnlHeader;
		private GamePanel pnlMainCommands;
		private GamePanel pnlSubCommands;
		private GamePanel pnlSearch;
		private GamePanel pnlSystemTabs;
		private GamePanel pnlSystemMap;
		private GamePanel pnlDetailReport;
		private GamePanel pnlGalaxyMap;
		private System.Windows.Forms.PictureBox picEmpireFlag;
		private System.Windows.Forms.Label lblGameDate;
		private System.Windows.Forms.Label txtGameDate;
		private Pager pagResources;
		private GameProgressBar gameProgressBar1;
		private ShipReport gameShipReport1;
		private StarSystemView starSystemView;
		private GalaxyView galaxyView;
		private GameButton btnPlanets;
		private GameButton btnEmpires;
		private GameButton btnDesigns;
		private GameButton btnMenu;
		private GameButton btnShips;
		private GameButton btnLog;
        private GameButton btnQueues;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}

