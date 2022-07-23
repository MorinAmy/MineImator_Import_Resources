namespace MineImator_Import_Resources.Forms
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "空空如也"}, -1, System.Drawing.SystemColors.ScrollBar, System.Drawing.Color.Empty, new System.Drawing.Font("微软雅黑", 20F));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.LoadMIProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.打开工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空选项卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.备份文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minecraft资源导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.源码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectIcon = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.工程栏位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ProjectsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProjectsFiles = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.imageListLink = new System.Windows.Forms.ImageList(this.components);
            this.MenuStrip.SuspendLayout();
            this.ProjectContextMenuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadMIProgram,
            this.打开工程ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.备份文件夹ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.生成ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.MenuStrip.Size = new System.Drawing.Size(844, 27);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // LoadMIProgram
            // 
            this.LoadMIProgram.Name = "LoadMIProgram";
            this.LoadMIProgram.Size = new System.Drawing.Size(44, 21);
            this.LoadMIProgram.Text = "加载";
            this.LoadMIProgram.Click += new System.EventHandler(this.LoadMIProgram_Menu);
            // 
            // 打开工程ToolStripMenuItem
            // 
            this.打开工程ToolStripMenuItem.Name = "打开工程ToolStripMenuItem";
            this.打开工程ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.打开工程ToolStripMenuItem.Text = "打开工程";
            this.打开工程ToolStripMenuItem.Click += new System.EventHandler(this.OprenSingleProject_Menu);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空选项卡ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 清空选项卡ToolStripMenuItem
            // 
            this.清空选项卡ToolStripMenuItem.Name = "清空选项卡ToolStripMenuItem";
            this.清空选项卡ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.清空选项卡ToolStripMenuItem.Text = "清空选项卡";
            this.清空选项卡ToolStripMenuItem.Click += new System.EventHandler(this.TabControl_Menu_DisposeAll);
            // 
            // 备份文件夹ToolStripMenuItem
            // 
            this.备份文件夹ToolStripMenuItem.Name = "备份文件夹ToolStripMenuItem";
            this.备份文件夹ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.备份文件夹ToolStripMenuItem.Text = "备份文件夹";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minecraft资源导出ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // minecraft资源导出ToolStripMenuItem
            // 
            this.minecraft资源导出ToolStripMenuItem.Name = "minecraft资源导出ToolStripMenuItem";
            this.minecraft资源导出ToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.minecraft资源导出ToolStripMenuItem.Text = "Minecraft资源导出";
            this.minecraft资源导出ToolStripMenuItem.Click += new System.EventHandler(this.Minecraft_Assets_Menu_Open);
            // 
            // 生成ToolStripMenuItem
            // 
            this.生成ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.当前项ToolStripMenuItem,
            this.全部项ToolStripMenuItem});
            this.生成ToolStripMenuItem.Name = "生成ToolStripMenuItem";
            this.生成ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.生成ToolStripMenuItem.Text = "生成";
            // 
            // 当前项ToolStripMenuItem
            // 
            this.当前项ToolStripMenuItem.Name = "当前项ToolStripMenuItem";
            this.当前项ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.当前项ToolStripMenuItem.Text = "当前项";
            this.当前项ToolStripMenuItem.Click += new System.EventHandler(this.TabControl_SelectedTabPage_Generate);
            // 
            // 全部项ToolStripMenuItem
            // 
            this.全部项ToolStripMenuItem.Name = "全部项ToolStripMenuItem";
            this.全部项ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.全部项ToolStripMenuItem.Text = "全部项";
            this.全部项ToolStripMenuItem.Click += new System.EventHandler(this.TabControl_AllTabPage_Generate);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.源码ToolStripMenuItem,
            this.关于ToolStripMenuItem1});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "帮助";
            // 
            // 源码ToolStripMenuItem
            // 
            this.源码ToolStripMenuItem.Name = "源码ToolStripMenuItem";
            this.源码ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.源码ToolStripMenuItem.Text = "源码";
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem1.Text = "关于";
            // 
            // ProjectContextMenuStrip
            // 
            this.ProjectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.属性ToolStripMenuItem});
            this.ProjectContextMenuStrip.Name = "ProjectContextMenuStrip";
            this.ProjectContextMenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.ProjectListView_RightClickMenu_Open);
            // 
            // 属性ToolStripMenuItem
            // 
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.属性ToolStripMenuItem.Text = "属性";
            this.属性ToolStripMenuItem.Click += new System.EventHandler(this.ProjectListView_RightClickMenu_Attribute);
            // 
            // ProjectIcon
            // 
            this.ProjectIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.ProjectIcon.ImageSize = new System.Drawing.Size(110, 58);
            this.ProjectIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工程栏位置ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.contextMenuStrip.Name = "ProjectContextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(137, 48);
            // 
            // 工程栏位置ToolStripMenuItem
            // 
            this.工程栏位置ToolStripMenuItem.Name = "工程栏位置ToolStripMenuItem";
            this.工程栏位置ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.工程栏位置ToolStripMenuItem.Text = "工程栏位置";
            this.工程栏位置ToolStripMenuItem.Click += new System.EventHandler(this.ProjectBarPosition_RightClickMenu_Position);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "关闭选项卡";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.TabControl_RightClickMenu_Dispose);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(844, 456);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.AccessibleName = "";
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(8, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(828, 448);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.ProjectsList, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(155, 443);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // ProjectsList
            // 
            this.ProjectsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProjectsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ProjectsList.ContextMenuStrip = this.ProjectContextMenuStrip;
            this.ProjectsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectsList.GridLines = true;
            this.ProjectsList.HideSelection = false;
            this.ProjectsList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ProjectsList.LargeImageList = this.ProjectIcon;
            this.ProjectsList.Location = new System.Drawing.Point(0, 25);
            this.ProjectsList.Margin = new System.Windows.Forms.Padding(0);
            this.ProjectsList.MultiSelect = false;
            this.ProjectsList.Name = "ProjectsList";
            this.ProjectsList.ShowItemToolTips = true;
            this.ProjectsList.Size = new System.Drawing.Size(155, 418);
            this.ProjectsList.SmallImageList = this.ProjectIcon;
            this.ProjectsList.TabIndex = 0;
            this.ProjectsList.UseCompatibleStateImageBehavior = false;
            this.ProjectsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ProjectListView_MouseDoubleClick_Open);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "工程文件";
            this.columnHeader1.Width = 101;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.ProjectsFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 25);
            this.panel2.TabIndex = 1;
            // 
            // ProjectsFiles
            // 
            this.ProjectsFiles.AutoSize = true;
            this.ProjectsFiles.BackColor = System.Drawing.Color.Transparent;
            this.ProjectsFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectsFiles.Font = new System.Drawing.Font("微软雅黑 Light", 13F);
            this.ProjectsFiles.Location = new System.Drawing.Point(0, 0);
            this.ProjectsFiles.Margin = new System.Windows.Forms.Padding(3);
            this.ProjectsFiles.Name = "ProjectsFiles";
            this.ProjectsFiles.Size = new System.Drawing.Size(136, 24);
            this.ProjectsFiles.TabIndex = 0;
            this.ProjectsFiles.Text = "未加载工程文件";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(659, 445);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabControl_RightClickMenu);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(651, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "";
            this.tabPage1.Text = "首页";
            this.tabPage1.ToolTipText = "首页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::MineImator_Import_Resources.ExecutablePrograms.NoConfig;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 409);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 450);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(844, 4);
            this.panel3.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(844, 4);
            this.progressBar1.TabIndex = 0;
            // 
            // imageListLink
            // 
            this.imageListLink.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListLink.ImageSize = new System.Drawing.Size(110, 58);
            this.imageListLink.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(844, 483);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MenuStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ProjectContextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem LoadMIProgram;
        private System.Windows.Forms.ImageList ProjectIcon;
        private System.Windows.Forms.ContextMenuStrip ProjectContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 打开工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 备份文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 源码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空选项卡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工程栏位置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部项ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.ListView ProjectsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ProjectsFiles;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minecraft资源导出ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListLink;
    }
}