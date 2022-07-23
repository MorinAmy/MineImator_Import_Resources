namespace MineImator_Import_Resources
{
    partial class MIConfig
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DownButton = new System.Windows.Forms.Button();
            this.TopButton = new System.Windows.Forms.Button();
            this.AddLink = new System.Windows.Forms.Button();
            this.DelLink = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProjectLinkView = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(578, 382);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "链接到Mine_Imator的本地工程";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Controls.Add(this.DelLink, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddLink, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.TopButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.DownButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 328);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(570, 34);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // DownButton
            // 
            this.DownButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DownButton.Location = new System.Drawing.Point(532, 3);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(35, 28);
            this.DownButton.TabIndex = 2;
            this.DownButton.Text = "▽";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Visible = false;
            // 
            // TopButton
            // 
            this.TopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TopButton.Location = new System.Drawing.Point(492, 3);
            this.TopButton.Name = "TopButton";
            this.TopButton.Size = new System.Drawing.Size(34, 28);
            this.TopButton.TabIndex = 1;
            this.TopButton.Text = "△";
            this.TopButton.UseVisualStyleBackColor = true;
            this.TopButton.Visible = false;
            // 
            // AddLink
            // 
            this.AddLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddLink.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddLink.Location = new System.Drawing.Point(3, 3);
            this.AddLink.Name = "AddLink";
            this.AddLink.Size = new System.Drawing.Size(238, 28);
            this.AddLink.TabIndex = 0;
            this.AddLink.Text = "添加链接";
            this.AddLink.UseVisualStyleBackColor = true;
            this.AddLink.Visible = false;
            // 
            // DelLink
            // 
            this.DelLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DelLink.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DelLink.Location = new System.Drawing.Point(247, 3);
            this.DelLink.Name = "DelLink";
            this.DelLink.Size = new System.Drawing.Size(239, 28);
            this.DelLink.TabIndex = 3;
            this.DelLink.Text = "删除链接";
            this.DelLink.UseVisualStyleBackColor = true;
            this.DelLink.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ProjectLinkView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 317);
            this.panel1.TabIndex = 1;
            // 
            // ProjectLinkView
            // 
            this.ProjectLinkView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProjectLinkView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ProjectLinkView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectLinkView.FullRowSelect = true;
            this.ProjectLinkView.GridLines = true;
            this.ProjectLinkView.HideSelection = false;
            this.ProjectLinkView.Location = new System.Drawing.Point(0, 0);
            this.ProjectLinkView.MultiSelect = false;
            this.ProjectLinkView.Name = "ProjectLinkView";
            this.ProjectLinkView.ShowItemToolTips = true;
            this.ProjectLinkView.Size = new System.Drawing.Size(570, 317);
            this.ProjectLinkView.TabIndex = 0;
            this.ProjectLinkView.UseCompatibleStateImageBehavior = false;
            this.ProjectLinkView.View = System.Windows.Forms.View.Details;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 366);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "链接的工程";
            this.columnHeader1.Width = 300;
            // 
            // MIConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MIConfig";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(598, 402);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.ListView ProjectLinkView;
        public System.Windows.Forms.Button DelLink;
        public System.Windows.Forms.Button AddLink;
        public System.Windows.Forms.Button TopButton;
        public System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
