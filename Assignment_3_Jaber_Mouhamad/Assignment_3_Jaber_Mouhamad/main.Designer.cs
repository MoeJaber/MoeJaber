namespace Assignment_3_Jaber_Mouhamad
{
    partial class main
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.map_tab = new MetroFramework.Controls.MetroTabPage();
            this.data_tab = new MetroFramework.Controls.MetroTabPage();
            this.main_DataFromCSVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_DataFromCSVBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.map_tab);
            this.metroTabControl1.Controls.Add(this.data_tab);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 54);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(700, 336);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // map_tab
            // 
            this.map_tab.HorizontalScrollbarBarColor = true;
            this.map_tab.HorizontalScrollbarHighlightOnWheel = false;
            this.map_tab.HorizontalScrollbarSize = 10;
            this.map_tab.Location = new System.Drawing.Point(4, 38);
            this.map_tab.Name = "map_tab";
            this.map_tab.Size = new System.Drawing.Size(692, 294);
            this.map_tab.TabIndex = 2;
            this.map_tab.Text = "Map";
            this.map_tab.VerticalScrollbarBarColor = true;
            this.map_tab.VerticalScrollbarHighlightOnWheel = false;
            this.map_tab.VerticalScrollbarSize = 10;
            // 
            // data_tab
            // 
            this.data_tab.AutoScroll = true;
            this.data_tab.HorizontalScrollbar = true;
            this.data_tab.HorizontalScrollbarBarColor = true;
            this.data_tab.HorizontalScrollbarHighlightOnWheel = false;
            this.data_tab.HorizontalScrollbarSize = 10;
            this.data_tab.Location = new System.Drawing.Point(4, 38);
            this.data_tab.Name = "data_tab";
            this.data_tab.Size = new System.Drawing.Size(692, 294);
            this.data_tab.TabIndex = 3;
            this.data_tab.Text = "Data";
            this.data_tab.VerticalScrollbar = true;
            this.data_tab.VerticalScrollbarBarColor = true;
            this.data_tab.VerticalScrollbarHighlightOnWheel = false;
            this.data_tab.VerticalScrollbarSize = 10;
            // 
            // main_DataFromCSVBindingSource
            // 
            this.main_DataFromCSVBindingSource.DataSource = typeof(Assignment_3_Jaber_Mouhamad.main.DataFromCSV);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 413);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "main";
            this.Text = "Main";
            this.metroTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_DataFromCSVBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage map_tab;
        private MetroFramework.Controls.MetroTabPage data_tab;
        private System.Windows.Forms.BindingSource main_DataFromCSVBindingSource;
    }
}

