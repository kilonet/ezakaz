namespace EZakaz.Office.RichClient
{
    partial class MainForm
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
            this.btnSendToAccess = new System.Windows.Forms.Button();
            this.lvOrderItems = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.lvOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOrder = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendToAccess
            // 
            this.btnSendToAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToAccess.Location = new System.Drawing.Point(12, 22);
            this.btnSendToAccess.Name = "btnSendToAccess";
            this.btnSendToAccess.Size = new System.Drawing.Size(118, 23);
            this.btnSendToAccess.TabIndex = 2;
            this.btnSendToAccess.Text = "Экспорт в Access";
            this.btnSendToAccess.UseVisualStyleBackColor = true;
            this.btnSendToAccess.Click += new System.EventHandler(this.btnSendToAccess_Click);
            // 
            // lvOrderItems
            // 
            this.lvOrderItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOrderItems.FullRowSelect = true;
            this.lvOrderItems.GridLines = true;
            this.lvOrderItems.Location = new System.Drawing.Point(0, 0);
            this.lvOrderItems.Name = "lvOrderItems";
            this.lvOrderItems.Size = new System.Drawing.Size(450, 216);
            this.lvOrderItems.TabIndex = 1;
            this.lvOrderItems.UseCompatibleStateImageBehavior = false;
            this.lvOrderItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "№";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Наименование";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Количество";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Цена";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Сумма";
            // 
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOrders.FullRowSelect = true;
            this.lvOrders.GridLines = true;
            this.lvOrders.HideSelection = false;
            this.lvOrders.Location = new System.Drawing.Point(0, 0);
            this.lvOrders.MultiSelect = false;
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(408, 216);
            this.lvOrders.TabIndex = 0;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            this.lvOrders.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Клиент";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Дата заказа";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblOrder);
            this.panel1.Controls.Add(this.btnSendToAccess);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 57);
            this.panel1.TabIndex = 3;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(136, 32);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(0, 13);
            this.lblOrder.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvOrders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvOrderItems);
            this.splitContainer1.Size = new System.Drawing.Size(862, 216);
            this.splitContainer1.SplitterDistance = 408;
            this.splitContainer1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 273);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Система электронных заказов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendToAccess;
        private System.Windows.Forms.ListView lvOrderItems;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListView lvOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblOrder;

    }
}

