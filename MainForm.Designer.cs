﻿/*
 * Erstellt mit SharpDevelop.
 * Benutzer: copyboy
 * Datum: 19.06.2010
 * Zeit: 20:33
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace INVedit
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.btnNew = new System.Windows.Forms.ToolStripButton();
			this.btnOpen = new System.Windows.Forms.ToolStripButton();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.btnAbout = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnReload = new System.Windows.Forms.ToolStripButton();
			this.btnCloseTab = new System.Windows.Forms.ToolStripButton();
			this.btnUpdate = new System.Windows.Forms.ToolStripButton();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.boxItems = new System.Windows.Forms.ListView();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btnNew,
									this.btnOpen,
									this.btnSave,
									this.btnAbout,
									this.toolStripSeparator2,
									this.btnReload,
									this.btnCloseTab,
									this.btnUpdate});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(672, 25);
			this.toolStrip.TabIndex = 4;
			// 
			// btnNew
			// 
			this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
			this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(23, 22);
			this.btnNew.Text = "New";
			this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
			// 
			// btnOpen
			// 
			this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
			this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(32, 22);
			this.btnOpen.Text = "Open";
			this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// btnSave
			// 
			this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSave.Enabled = false;
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(32, 22);
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// btnAbout
			// 
			this.btnAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
			this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(23, 22);
			this.btnAbout.Text = "About";
			this.btnAbout.Click += new System.EventHandler(this.BtnAboutClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btnReload
			// 
			this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnReload.Enabled = false;
			this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
			this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(23, 22);
			this.btnReload.Text = "Reload";
			this.btnReload.Click += new System.EventHandler(this.BtnReloadClick);
			// 
			// btnCloseTab
			// 
			this.btnCloseTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnCloseTab.Enabled = false;
			this.btnCloseTab.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseTab.Image")));
			this.btnCloseTab.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCloseTab.Name = "btnCloseTab";
			this.btnCloseTab.Size = new System.Drawing.Size(23, 22);
			this.btnCloseTab.Text = "Close tab";
			this.btnCloseTab.Click += new System.EventHandler(this.BtnCloseTabClick);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Enabled = false;
			this.btnUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
			this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(115, 22);
			this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			// 
			// tabControl
			// 
			this.tabControl.AllowDrop = true;
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Location = new System.Drawing.Point(5, 29);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(481, 323);
			this.tabControl.TabIndex = 6;
			this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlSelected);
			this.tabControl.DragOver += new System.Windows.Forms.DragEventHandler(this.TabControlDragOver);
			// 
			// boxItems
			// 
			this.boxItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.boxItems.Location = new System.Drawing.Point(518, 29);
			this.boxItems.MultiSelect = false;
			this.boxItems.Name = "boxItems";
			this.boxItems.Size = new System.Drawing.Size(150, 322);
			this.boxItems.TabIndex = 5;
			this.boxItems.TileSize = new System.Drawing.Size(120, 19);
			this.boxItems.UseCompatibleStateImageBehavior = false;
			this.boxItems.View = System.Windows.Forms.View.Tile;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "inv";
			this.saveFileDialog.Filter = "All supported files|*.mclevel;*.inv|Minecraft files (*.mclevel)|*.mclevel|Inventory files (*." +
			"inv)|*.inv|All files (*.*)|*.*";
			this.saveFileDialog.Title = "Save inventory";
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "inv";
			this.openFileDialog.Filter = "All supported files|*.mclevel;*.inv|Minecraft files (*.mclevel)|*.mclevel|Inventory files (*." +
			"inv)|*.inv|All files (*.*)|*.*";
			this.openFileDialog.Title = "Open inventory";
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(672, 356);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.boxItems);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "INVedit - Minecraft Inventory Editor";
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripButton btnUpdate;
		private System.Windows.Forms.ToolStripButton btnReload;
		private System.Windows.Forms.ToolStripButton btnCloseTab;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.ToolStripButton btnAbout;
		private System.Windows.Forms.ListView boxItems;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton btnOpen;
		private System.Windows.Forms.ToolStripButton btnNew;
	}
}
