using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Net;
using System.ComponentModel;
using System.Diagnostics;

using NBT;

namespace INVedit
{
	public partial class MainForm : Form
	{
		static string appdata;
		static MainForm() {
			if (Platform.Current == Platform.Windows) {
				appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"/.minecraft";
			} else if (Platform.Current == Platform.Mac) {
				appdata = Environment.ExpandEnvironmentVariables("HOME")+"/Library/Application Support/minecraft";
			} else {
				appdata = Environment.ExpandEnvironmentVariables("HOME")+"/.minecraft";
			}
		}
		
		bool update = true;
		List<CheckBox> groups = new List<CheckBox>();
		
		public MainForm(string[] files)
		{
			InitializeComponent();
			
			Data.Init("items.txt");
			
			boxItems.LargeImageList = Data.list;
			boxItems.ItemDrag += ItemDrag;
			
			foreach (Data.Group group in Data.groups.Values) {
				CheckBox box = new CheckBox();
				box.Size = new Size(26, 26);
				box.Location = new Point(Width-189, 30 + groups.Count*27);
				box.ImageList = Data.list;
				box.ImageIndex = group.imageIndex;
				box.Appearance = Appearance.Button;
				box.Anchor = AnchorStyles.Top | AnchorStyles.Right;
				box.Checked = true;
				box.Tag = group;
				box.CheckedChanged += ItemChecked;
				box.MouseDown += ItemMouseDown;
				Controls.Add(box);
				groups.Add(box);
			}
			
			UpdateItems();
			
			foreach (string file in files)
				if (File.Exists(file)) Open(file);
		}
		
		void Open(string file)
		{
			Page page = new Page();
			Open(page,file);
			tabControl.TabPages.Add(page);
			tabControl.SelectedTab = page;
		}
		
		void Open(Page page, string file)
		{
			try {
				FileInfo info = new FileInfo(file);
				page.file = info.FullName;
				page.Text = info.Name;
				Tag tag = NBT.Tag.Load(file);
				if (tag.Type==TagType.Compound && tag.Contains("MinecraftLevel")) { tag = tag["MinecraftLevel"]; }
				if (tag.Type==TagType.Compound && tag.Contains("Entities")) { tag = tag["Entities"]; }
				Inventory.Load(tag, page.slots);
				Text = "INVedit - "+page.Text;
				btnSave.Enabled = true;
				btnCloseTab.Enabled = true;
				btnReload.Enabled = true;
			} catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		
		void Save(Page page, string file)
		{
			try {
				FileInfo info = new FileInfo(file);
				page.file = info.FullName;
				Tag root,tag;
				if (info.Exists) {
					root = NBT.Tag.Load(page.file);
					tag = root;
				} else {
					if (info.Extension.ToLower() == ".mclevel") {
						MessageBox.Show("You can't create a new Minecraft file. Select an existing one instead.",
						                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					} root = NBT.Tag.Create("Inventory");
					Tag entities = root.AddList("Entities", TagType.Compound);
					Tag compound = entities.AddCompound();
					compound.Add("id", "LocalPlayer");
					tag = root;
				} if (tag.Type==TagType.Compound && tag.Contains("MinecraftLevel")) { tag = tag["MinecraftLevel"]; }
				if (tag.Type==TagType.Compound && tag.Contains("Entities")) { tag = tag["Entities"]; }
				Inventory.Save(tag, page.slots);
				root.Save(page.file);
				page.Text = info.Name;
				Text = "INVedit - "+page.Text;
				btnReload.Enabled = true;
			} catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		
		protected override void OnDragEnter(DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] files = ((string[])e.Data.GetData(DataFormats.FileDrop));
				foreach (string file in files) {
					FileInfo info = new FileInfo(file);
					if (info.Extension.ToLower() == ".inv" || info.Extension.ToLower() == ".mclevel")
						e.Effect = DragDropEffects.Copy;
				}
			}
		}
		protected override void OnDragDrop(DragEventArgs e) {
			OnDragEnter(e);
			BringToFront();
			if (e.Effect == DragDropEffects.None) return;
			string[] files = ((string[])e.Data.GetData(DataFormats.FileDrop));
			foreach (string file in files)
				if (File.Exists(file)) Open(file);
		}
		
		void UpdateItems()
		{
			boxItems.BeginUpdate();
			boxItems.Clear();
			foreach (CheckBox box in groups) if (box.Checked)
				foreach (Data.Item i in ((Data.Group)box.Tag).items)
					boxItems.Items.Add(new ListViewItem(i.name, i.imageIndex){ Tag = i });
			boxItems.EndUpdate();
		}
		
		void ItemChecked(object sender, EventArgs e)
		{
			if (update) UpdateItems();
		}
		
		void ItemMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right) return;
			update = false;
			bool changed = false;
			CheckBox self = (CheckBox)sender;
			foreach (CheckBox box in groups) if (box.Checked == (self!=box)) {
				changed = true;
				box.Checked = (self==box);
			}
			self.Select();
			update = true;
			if (changed) UpdateItems();
		}
		
		void ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			ListViewItem item = (ListViewItem)e.Item;
			Item i = new Item(((Data.Item)item.Tag).id);
			DoDragDrop(i, DragDropEffects.Copy | DragDropEffects.Move);
		}
		
		void BtnNewClick(object sender, EventArgs e)
		{
			Page page = new Page();
			page.Text = "unnamed.inv";
			Text = "INVedit - unnamed.inv";
			tabControl.TabPages.Add(page);
			tabControl.SelectedTab = page;
			btnSave.Enabled = true;
			btnCloseTab.Enabled = true;
			btnReload.Enabled = false;
		}
		
		void BtnOpenClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				Open(openFileDialog.FileName);
			}
		}
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			Page page = (Page)tabControl.SelectedTab;
			saveFileDialog.FileName = page.file;
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				Save(page, saveFileDialog.FileName);
			}
		}
		
		void BtnCloseTabClick(object sender, EventArgs e)
		{
			tabControl.TabPages.Remove(tabControl.SelectedTab);
			if (tabControl.TabPages.Count == 0) {
				btnSave.Enabled = false;
				btnCloseTab.Enabled = false;
			}
		}
		
		void BtnAboutClick(object sender, EventArgs e)
		{
			new AboutForm().ShowDialog();
		}
		
		void TabControlDragOver(object sender, DragEventArgs e)
		{
			Point point = tabControl.PointToClient(new Point(e.X, e.Y));
			TabPage hover = null;
			for (int i = 0; i < tabControl.TabPages.Count; ++i)
				if (tabControl.GetTabRect(i).Contains(point)) {
				hover = tabControl.TabPages[i]; break;
			}
			if (hover == null) return;
			if (!e.Data.GetDataPresent(typeof(Item))) return;
			tabControl.SelectedTab = hover;
		}
		
		void TabControlSelected(object sender, TabControlEventArgs e)
		{
			if (e.TabPage != null) {
				Text = "INVedit - "+e.TabPage.Text;
				btnReload.Enabled = (((Page)e.TabPage).file != null);
			} else {
				Text = "INVedit - Minecraft Inventory Editor";
				btnReload.Enabled = false;
			}
			
		}
		
		void BtnReloadClick(object sender, EventArgs e)
		{
			try {
				Page page = (Page)tabControl.SelectedTab;
				Open(page, page.file);
			} catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
	}
}
