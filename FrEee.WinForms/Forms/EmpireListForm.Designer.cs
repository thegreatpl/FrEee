﻿namespace FrEee.WinForms.Forms
{
	partial class EmpireListForm
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
			this.tabs = new FrEee.WinForms.Controls.GameTabControl();
			this.tabDiplomacy = new System.Windows.Forms.TabPage();
			this.btnSend = new FrEee.WinForms.Controls.GameButton();
			this.lstMessages = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label13 = new System.Windows.Forms.Label();
			this.txtTreaty = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabIntel = new System.Windows.Forms.TabPage();
			this.report = new FrEee.WinForms.Controls.EmpireReport();
			this.tabBudget = new System.Windows.Forms.TabPage();
			this.rqdSpoiled = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.rqdStored = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.rqdNet = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.rqdTributesOut = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.rqdMaintenance = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.rqdConstruction = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.rqExpenses = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.rqdTributesIn = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.rqdTrade = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.rqdExtraction = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.rqdIncome = new FrEee.WinForms.Controls.ResourceQuantityDisplay();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnClose = new FrEee.WinForms.Controls.GameButton();
			this.gamePanel1 = new FrEee.WinForms.Controls.GamePanel();
			this.lstEmpires = new System.Windows.Forms.ListView();
			this.btnBottom = new FrEee.WinForms.Controls.GameButton();
			this.btnTop = new FrEee.WinForms.Controls.GameButton();
			this.btnDown = new FrEee.WinForms.Controls.GameButton();
			this.btnUp = new FrEee.WinForms.Controls.GameButton();
			this.btnDelIntel = new FrEee.WinForms.Controls.GameButton();
			this.btnAdd = new FrEee.WinForms.Controls.GameButton();
			this.lstIntel = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnCancel = new FrEee.WinForms.Controls.GameButton();
			this.label14 = new System.Windows.Forms.Label();
			this.btnDeleteMessage = new FrEee.WinForms.Controls.GameButton();
			this.label15 = new System.Windows.Forms.Label();
			this.ddlMessageType = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.pnlParameters = new FrEee.WinForms.Controls.GamePanel();
			this.label17 = new System.Windows.Forms.Label();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.tabs.SuspendLayout();
			this.tabDiplomacy.SuspendLayout();
			this.tabIntel.SuspendLayout();
			this.tabBudget.SuspendLayout();
			this.gamePanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabs.Controls.Add(this.tabDiplomacy);
			this.tabs.Controls.Add(this.tabIntel);
			this.tabs.Controls.Add(this.tabBudget);
			this.tabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.tabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.tabs.Location = new System.Drawing.Point(12, 188);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.SelectedTabBackColor = System.Drawing.Color.CornflowerBlue;
			this.tabs.SelectedTabForeColor = System.Drawing.Color.Black;
			this.tabs.Size = new System.Drawing.Size(710, 432);
			this.tabs.TabBackColor = System.Drawing.Color.Black;
			this.tabs.TabForeColor = System.Drawing.Color.CornflowerBlue;
			this.tabs.TabIndex = 2;
			// 
			// tabDiplomacy
			// 
			this.tabDiplomacy.BackColor = System.Drawing.Color.Black;
			this.tabDiplomacy.Controls.Add(this.txtMessage);
			this.tabDiplomacy.Controls.Add(this.label17);
			this.tabDiplomacy.Controls.Add(this.pnlParameters);
			this.tabDiplomacy.Controls.Add(this.label16);
			this.tabDiplomacy.Controls.Add(this.ddlMessageType);
			this.tabDiplomacy.Controls.Add(this.label15);
			this.tabDiplomacy.Controls.Add(this.btnDeleteMessage);
			this.tabDiplomacy.Controls.Add(this.label14);
			this.tabDiplomacy.Controls.Add(this.btnCancel);
			this.tabDiplomacy.Controls.Add(this.btnSend);
			this.tabDiplomacy.Controls.Add(this.lstMessages);
			this.tabDiplomacy.Controls.Add(this.label13);
			this.tabDiplomacy.Controls.Add(this.txtTreaty);
			this.tabDiplomacy.Controls.Add(this.label1);
			this.tabDiplomacy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.tabDiplomacy.Location = new System.Drawing.Point(4, 29);
			this.tabDiplomacy.Name = "tabDiplomacy";
			this.tabDiplomacy.Padding = new System.Windows.Forms.Padding(3);
			this.tabDiplomacy.Size = new System.Drawing.Size(702, 399);
			this.tabDiplomacy.TabIndex = 0;
			this.tabDiplomacy.Text = "Diplomacy";
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.BackColor = System.Drawing.Color.Black;
			this.btnSend.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnSend.Location = new System.Drawing.Point(596, 370);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(100, 23);
			this.btnSend.TabIndex = 7;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = false;
			// 
			// lstMessages
			// 
			this.lstMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lstMessages.BackColor = System.Drawing.Color.Black;
			this.lstMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lstMessages.ForeColor = System.Drawing.Color.White;
			this.lstMessages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lstMessages.Location = new System.Drawing.Point(9, 61);
			this.lstMessages.Name = "lstMessages";
			this.lstMessages.Size = new System.Drawing.Size(305, 332);
			this.lstMessages.TabIndex = 6;
			this.lstMessages.UseCompatibleStateImageBehavior = false;
			this.lstMessages.View = System.Windows.Forms.View.Details;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label13.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label13.Location = new System.Drawing.Point(6, 41);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(93, 17);
			this.label13.TabIndex = 5;
			this.label13.Text = "Message Log";
			// 
			// txtTreaty
			// 
			this.txtTreaty.AutoSize = true;
			this.txtTreaty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.txtTreaty.ForeColor = System.Drawing.Color.White;
			this.txtTreaty.Location = new System.Drawing.Point(109, 3);
			this.txtTreaty.Name = "txtTreaty";
			this.txtTreaty.Size = new System.Drawing.Size(66, 17);
			this.txtTreaty.TabIndex = 1;
			this.txtTreaty.Text = "Unknown";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label1.Location = new System.Drawing.Point(6, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Treaty Status:";
			// 
			// tabIntel
			// 
			this.tabIntel.BackColor = System.Drawing.Color.Black;
			this.tabIntel.Controls.Add(this.btnBottom);
			this.tabIntel.Controls.Add(this.btnTop);
			this.tabIntel.Controls.Add(this.btnDown);
			this.tabIntel.Controls.Add(this.btnUp);
			this.tabIntel.Controls.Add(this.btnDelIntel);
			this.tabIntel.Controls.Add(this.btnAdd);
			this.tabIntel.Controls.Add(this.lstIntel);
			this.tabIntel.Controls.Add(this.report);
			this.tabIntel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.tabIntel.Location = new System.Drawing.Point(4, 29);
			this.tabIntel.Name = "tabIntel";
			this.tabIntel.Padding = new System.Windows.Forms.Padding(3);
			this.tabIntel.Size = new System.Drawing.Size(702, 399);
			this.tabIntel.TabIndex = 3;
			this.tabIntel.Text = "Intel";
			// 
			// report
			// 
			this.report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.report.BackColor = System.Drawing.Color.Black;
			this.report.Empire = null;
			this.report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.report.ForeColor = System.Drawing.Color.White;
			this.report.Location = new System.Drawing.Point(320, 3);
			this.report.Name = "report";
			this.report.Size = new System.Drawing.Size(376, 390);
			this.report.TabIndex = 5;
			// 
			// tabBudget
			// 
			this.tabBudget.BackColor = System.Drawing.Color.Black;
			this.tabBudget.Controls.Add(this.rqdSpoiled);
			this.tabBudget.Controls.Add(this.rqdStored);
			this.tabBudget.Controls.Add(this.rqdNet);
			this.tabBudget.Controls.Add(this.rqdTributesOut);
			this.tabBudget.Controls.Add(this.rqdMaintenance);
			this.tabBudget.Controls.Add(this.rqdConstruction);
			this.tabBudget.Controls.Add(this.rqExpenses);
			this.tabBudget.Controls.Add(this.rqdTributesIn);
			this.tabBudget.Controls.Add(this.rqdTrade);
			this.tabBudget.Controls.Add(this.rqdExtraction);
			this.tabBudget.Controls.Add(this.rqdIncome);
			this.tabBudget.Controls.Add(this.label12);
			this.tabBudget.Controls.Add(this.label11);
			this.tabBudget.Controls.Add(this.label10);
			this.tabBudget.Controls.Add(this.label6);
			this.tabBudget.Controls.Add(this.label7);
			this.tabBudget.Controls.Add(this.label8);
			this.tabBudget.Controls.Add(this.label9);
			this.tabBudget.Controls.Add(this.label5);
			this.tabBudget.Controls.Add(this.label4);
			this.tabBudget.Controls.Add(this.label3);
			this.tabBudget.Controls.Add(this.label2);
			this.tabBudget.Location = new System.Drawing.Point(4, 29);
			this.tabBudget.Name = "tabBudget";
			this.tabBudget.Size = new System.Drawing.Size(702, 399);
			this.tabBudget.TabIndex = 2;
			this.tabBudget.Text = "Budget";
			// 
			// rqdSpoiled
			// 
			this.rqdSpoiled.BackColor = System.Drawing.Color.Black;
			this.rqdSpoiled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqdSpoiled.ForeColor = System.Drawing.Color.White;
			this.rqdSpoiled.Location = new System.Drawing.Point(177, 330);
			this.rqdSpoiled.Name = "rqdSpoiled";
			this.rqdSpoiled.ResourceQuantity = null;
			this.rqdSpoiled.Size = new System.Drawing.Size(413, 24);
			this.rqdSpoiled.TabIndex = 23;
			// 
			// rqdStored
			// 
			this.rqdStored.BackColor = System.Drawing.Color.Black;
			this.rqdStored.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqdStored.ForeColor = System.Drawing.Color.White;
			this.rqdStored.Location = new System.Drawing.Point(177, 300);
			this.rqdStored.Name = "rqdStored";
			this.rqdStored.ResourceQuantity = null;
			this.rqdStored.Size = new System.Drawing.Size(413, 24);
			this.rqdStored.TabIndex = 22;
			// 
			// rqdNet
			// 
			this.rqdNet.BackColor = System.Drawing.Color.Black;
			this.rqdNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqdNet.ForeColor = System.Drawing.Color.White;
			this.rqdNet.Location = new System.Drawing.Point(177, 270);
			this.rqdNet.Name = "rqdNet";
			this.rqdNet.ResourceQuantity = null;
			this.rqdNet.Size = new System.Drawing.Size(413, 24);
			this.rqdNet.TabIndex = 21;
			// 
			// rqdTributesOut
			// 
			this.rqdTributesOut.BackColor = System.Drawing.Color.Black;
			this.rqdTributesOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqdTributesOut.ForeColor = System.Drawing.Color.White;
			this.rqdTributesOut.Location = new System.Drawing.Point(177, 228);
			this.rqdTributesOut.Name = "rqdTributesOut";
			this.rqdTributesOut.ResourceQuantity = null;
			this.rqdTributesOut.Size = new System.Drawing.Size(413, 24);
			this.rqdTributesOut.TabIndex = 20;
			// 
			// rqdMaintenance
			// 
			this.rqdMaintenance.BackColor = System.Drawing.Color.Black;
			this.rqdMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqdMaintenance.ForeColor = System.Drawing.Color.White;
			this.rqdMaintenance.Location = new System.Drawing.Point(177, 198);
			this.rqdMaintenance.Name = "rqdMaintenance";
			this.rqdMaintenance.ResourceQuantity = null;
			this.rqdMaintenance.Size = new System.Drawing.Size(413, 24);
			this.rqdMaintenance.TabIndex = 19;
			// 
			// rqdConstruction
			// 
			this.rqdConstruction.BackColor = System.Drawing.Color.Black;
			this.rqdConstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqdConstruction.ForeColor = System.Drawing.Color.White;
			this.rqdConstruction.Location = new System.Drawing.Point(177, 168);
			this.rqdConstruction.Name = "rqdConstruction";
			this.rqdConstruction.ResourceQuantity = null;
			this.rqdConstruction.Size = new System.Drawing.Size(413, 24);
			this.rqdConstruction.TabIndex = 18;
			// 
			// rqExpenses
			// 
			this.rqExpenses.BackColor = System.Drawing.Color.Black;
			this.rqExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqExpenses.ForeColor = System.Drawing.Color.White;
			this.rqExpenses.Location = new System.Drawing.Point(177, 138);
			this.rqExpenses.Name = "rqExpenses";
			this.rqExpenses.ResourceQuantity = null;
			this.rqExpenses.Size = new System.Drawing.Size(413, 24);
			this.rqExpenses.TabIndex = 17;
			// 
			// rqdTributesIn
			// 
			this.rqdTributesIn.BackColor = System.Drawing.Color.Black;
			this.rqdTributesIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqdTributesIn.ForeColor = System.Drawing.Color.White;
			this.rqdTributesIn.Location = new System.Drawing.Point(177, 93);
			this.rqdTributesIn.Name = "rqdTributesIn";
			this.rqdTributesIn.ResourceQuantity = null;
			this.rqdTributesIn.Size = new System.Drawing.Size(413, 24);
			this.rqdTributesIn.TabIndex = 16;
			// 
			// rqdTrade
			// 
			this.rqdTrade.BackColor = System.Drawing.Color.Black;
			this.rqdTrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqdTrade.ForeColor = System.Drawing.Color.White;
			this.rqdTrade.Location = new System.Drawing.Point(177, 63);
			this.rqdTrade.Name = "rqdTrade";
			this.rqdTrade.ResourceQuantity = null;
			this.rqdTrade.Size = new System.Drawing.Size(413, 24);
			this.rqdTrade.TabIndex = 15;
			// 
			// rqdExtraction
			// 
			this.rqdExtraction.BackColor = System.Drawing.Color.Black;
			this.rqdExtraction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqdExtraction.ForeColor = System.Drawing.Color.White;
			this.rqdExtraction.Location = new System.Drawing.Point(177, 33);
			this.rqdExtraction.Name = "rqdExtraction";
			this.rqdExtraction.ResourceQuantity = null;
			this.rqdExtraction.Size = new System.Drawing.Size(413, 24);
			this.rqdExtraction.TabIndex = 14;
			// 
			// rqdIncome
			// 
			this.rqdIncome.BackColor = System.Drawing.Color.Black;
			this.rqdIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rqdIncome.ForeColor = System.Drawing.Color.White;
			this.rqdIncome.Location = new System.Drawing.Point(177, 3);
			this.rqdIncome.Name = "rqdIncome";
			this.rqdIncome.ResourceQuantity = null;
			this.rqdIncome.Size = new System.Drawing.Size(413, 24);
			this.rqdIncome.TabIndex = 12;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label12.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label12.Location = new System.Drawing.Point(3, 330);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(127, 17);
			this.label12.TabIndex = 11;
			this.label12.Text = "Spoiled Resources";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label11.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label11.Location = new System.Drawing.Point(3, 300);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(122, 17);
			this.label11.TabIndex = 10;
			this.label11.Text = "Stored Resources";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label10.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label10.Location = new System.Drawing.Point(3, 270);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(79, 17);
			this.label10.TabIndex = 9;
			this.label10.Text = "Net Income";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label6.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label6.Location = new System.Drawing.Point(18, 228);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(60, 17);
			this.label6.TabIndex = 8;
			this.label6.Text = "Tributes";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label7.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label7.Location = new System.Drawing.Point(18, 198);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(89, 17);
			this.label7.TabIndex = 7;
			this.label7.Text = "Maintenance";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label8.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label8.Location = new System.Drawing.Point(18, 168);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(87, 17);
			this.label8.TabIndex = 6;
			this.label8.Text = "Construction";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label9.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label9.Location = new System.Drawing.Point(3, 138);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(69, 17);
			this.label9.TabIndex = 5;
			this.label9.Text = "Expenses";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label5.Location = new System.Drawing.Point(18, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "Tributes";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label4.Location = new System.Drawing.Point(18, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Trade";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label3.Location = new System.Drawing.Point(18, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(135, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Resource Extraction";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label2.Location = new System.Drawing.Point(3, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Income";
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.BackColor = System.Drawing.Color.Black;
			this.btnClose.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnClose.Location = new System.Drawing.Point(647, 626);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// gamePanel1
			// 
			this.gamePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gamePanel1.BackColor = System.Drawing.Color.Black;
			this.gamePanel1.BorderColor = System.Drawing.Color.CornflowerBlue;
			this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gamePanel1.Controls.Add(this.lstEmpires);
			this.gamePanel1.ForeColor = System.Drawing.Color.White;
			this.gamePanel1.Location = new System.Drawing.Point(12, 12);
			this.gamePanel1.Name = "gamePanel1";
			this.gamePanel1.Padding = new System.Windows.Forms.Padding(3);
			this.gamePanel1.Size = new System.Drawing.Size(710, 169);
			this.gamePanel1.TabIndex = 1;
			// 
			// lstEmpires
			// 
			this.lstEmpires.BackColor = System.Drawing.Color.Black;
			this.lstEmpires.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstEmpires.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstEmpires.ForeColor = System.Drawing.Color.White;
			this.lstEmpires.HideSelection = false;
			this.lstEmpires.Location = new System.Drawing.Point(3, 3);
			this.lstEmpires.Name = "lstEmpires";
			this.lstEmpires.Size = new System.Drawing.Size(702, 161);
			this.lstEmpires.TabIndex = 1;
			this.lstEmpires.UseCompatibleStateImageBehavior = false;
			this.lstEmpires.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstEmpires_ItemSelectionChanged);
			// 
			// btnBottom
			// 
			this.btnBottom.BackColor = System.Drawing.Color.Black;
			this.btnBottom.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnBottom.Location = new System.Drawing.Point(261, 64);
			this.btnBottom.Name = "btnBottom";
			this.btnBottom.Size = new System.Drawing.Size(53, 23);
			this.btnBottom.TabIndex = 22;
			this.btnBottom.Text = "Bottom";
			this.btnBottom.UseVisualStyleBackColor = false;
			// 
			// btnTop
			// 
			this.btnTop.BackColor = System.Drawing.Color.Black;
			this.btnTop.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnTop.Location = new System.Drawing.Point(202, 64);
			this.btnTop.Name = "btnTop";
			this.btnTop.Size = new System.Drawing.Size(53, 23);
			this.btnTop.TabIndex = 21;
			this.btnTop.Text = "Top";
			this.btnTop.UseVisualStyleBackColor = false;
			// 
			// btnDown
			// 
			this.btnDown.BackColor = System.Drawing.Color.Black;
			this.btnDown.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnDown.Location = new System.Drawing.Point(261, 35);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(53, 23);
			this.btnDown.TabIndex = 20;
			this.btnDown.Text = "Down";
			this.btnDown.UseVisualStyleBackColor = false;
			// 
			// btnUp
			// 
			this.btnUp.BackColor = System.Drawing.Color.Black;
			this.btnUp.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnUp.Location = new System.Drawing.Point(202, 35);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(53, 23);
			this.btnUp.TabIndex = 19;
			this.btnUp.Text = "Up";
			this.btnUp.UseVisualStyleBackColor = false;
			// 
			// btnDelIntel
			// 
			this.btnDelIntel.BackColor = System.Drawing.Color.Black;
			this.btnDelIntel.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnDelIntel.Location = new System.Drawing.Point(261, 6);
			this.btnDelIntel.Name = "btnDelIntel";
			this.btnDelIntel.Size = new System.Drawing.Size(53, 23);
			this.btnDelIntel.TabIndex = 18;
			this.btnDelIntel.Text = "Del";
			this.btnDelIntel.UseVisualStyleBackColor = false;
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.Black;
			this.btnAdd.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnAdd.Location = new System.Drawing.Point(202, 6);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(53, 23);
			this.btnAdd.TabIndex = 17;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = false;
			// 
			// lstIntel
			// 
			this.lstIntel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lstIntel.BackColor = System.Drawing.Color.Black;
			this.lstIntel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstIntel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
			this.lstIntel.ForeColor = System.Drawing.Color.White;
			this.lstIntel.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lstIntel.Location = new System.Drawing.Point(3, 6);
			this.lstIntel.Name = "lstIntel";
			this.lstIntel.Size = new System.Drawing.Size(193, 390);
			this.lstIntel.TabIndex = 16;
			this.lstIntel.UseCompatibleStateImageBehavior = false;
			this.lstIntel.View = System.Windows.Forms.View.Details;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.Black;
			this.btnCancel.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnCancel.Location = new System.Drawing.Point(490, 370);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 23);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label14.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label14.Location = new System.Drawing.Point(320, 41);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(67, 17);
			this.label14.TabIndex = 9;
			this.label14.Text = "Compose";
			// 
			// btnDeleteMessage
			// 
			this.btnDeleteMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteMessage.BackColor = System.Drawing.Color.Black;
			this.btnDeleteMessage.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnDeleteMessage.Location = new System.Drawing.Point(384, 370);
			this.btnDeleteMessage.Name = "btnDeleteMessage";
			this.btnDeleteMessage.Size = new System.Drawing.Size(100, 23);
			this.btnDeleteMessage.TabIndex = 10;
			this.btnDeleteMessage.Text = "Delete";
			this.btnDeleteMessage.UseVisualStyleBackColor = false;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label15.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label15.Location = new System.Drawing.Point(336, 61);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(101, 17);
			this.label15.TabIndex = 11;
			this.label15.Text = "Message Type";
			// 
			// ddlMessageType
			// 
			this.ddlMessageType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlMessageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlMessageType.FormattingEnabled = true;
			this.ddlMessageType.Location = new System.Drawing.Point(443, 58);
			this.ddlMessageType.Name = "ddlMessageType";
			this.ddlMessageType.Size = new System.Drawing.Size(253, 24);
			this.ddlMessageType.TabIndex = 12;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label16.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label16.Location = new System.Drawing.Point(336, 85);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(81, 17);
			this.label16.TabIndex = 13;
			this.label16.Text = "Parameters";
			// 
			// pnlParameters
			// 
			this.pnlParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlParameters.BackColor = System.Drawing.Color.Black;
			this.pnlParameters.BorderColor = System.Drawing.Color.CornflowerBlue;
			this.pnlParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlParameters.ForeColor = System.Drawing.Color.White;
			this.pnlParameters.Location = new System.Drawing.Point(339, 106);
			this.pnlParameters.Name = "pnlParameters";
			this.pnlParameters.Padding = new System.Windows.Forms.Padding(3);
			this.pnlParameters.Size = new System.Drawing.Size(357, 144);
			this.pnlParameters.TabIndex = 14;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label17.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label17.Location = new System.Drawing.Point(336, 253);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(35, 17);
			this.label17.TabIndex = 15;
			this.label17.Text = "Text";
			// 
			// txtMessage
			// 
			this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessage.Location = new System.Drawing.Point(339, 274);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(357, 90);
			this.txtMessage.TabIndex = 16;
			// 
			// EmpireListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(734, 661);
			this.Controls.Add(this.tabs);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.gamePanel1);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "EmpireListForm";
			this.Text = "Empires";
			this.tabs.ResumeLayout(false);
			this.tabDiplomacy.ResumeLayout(false);
			this.tabDiplomacy.PerformLayout();
			this.tabIntel.ResumeLayout(false);
			this.tabBudget.ResumeLayout(false);
			this.tabBudget.PerformLayout();
			this.gamePanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.GamePanel gamePanel1;
		private System.Windows.Forms.ListView lstEmpires;
		private Controls.GameButton btnClose;
		private System.Windows.Forms.TabPage tabDiplomacy;
		private Controls.GameTabControl tabs;
		private System.Windows.Forms.TabPage tabBudget;
		private System.Windows.Forms.Label txtTreaty;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private Controls.ResourceQuantityDisplay rqdIncome;
		private Controls.ResourceQuantityDisplay rqdStored;
		private Controls.ResourceQuantityDisplay rqdNet;
		private Controls.ResourceQuantityDisplay rqdTributesOut;
		private Controls.ResourceQuantityDisplay rqdMaintenance;
		private Controls.ResourceQuantityDisplay rqdConstruction;
		private Controls.ResourceQuantityDisplay rqExpenses;
		private Controls.ResourceQuantityDisplay rqdTributesIn;
		private Controls.ResourceQuantityDisplay rqdTrade;
		private Controls.ResourceQuantityDisplay rqdExtraction;
		private Controls.ResourceQuantityDisplay rqdSpoiled;
		private System.Windows.Forms.ListView lstMessages;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private Controls.GameButton btnSend;
		private System.Windows.Forms.TabPage tabIntel;
		private Controls.EmpireReport report;
		private Controls.GameButton btnBottom;
		private Controls.GameButton btnTop;
		private Controls.GameButton btnDown;
		private Controls.GameButton btnUp;
		private Controls.GameButton btnDelIntel;
		private Controls.GameButton btnAdd;
		private System.Windows.Forms.ListView lstIntel;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private Controls.GameButton btnCancel;
		private System.Windows.Forms.Label label14;
		private Controls.GameButton btnDeleteMessage;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox ddlMessageType;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Label label17;
		private Controls.GamePanel pnlParameters;
	}
}