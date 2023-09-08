namespace Presentacion
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cargaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMAdministrativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMTratamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargaToolStripMenuItem,
            this.turnosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1484, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // cargaToolStripMenuItem
            // 
            this.cargaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMClienteToolStripMenuItem,
            this.aBMAdministrativoToolStripMenuItem,
            this.aBMProfesionalToolStripMenuItem,
            this.aBMTratamientoToolStripMenuItem});
            this.cargaToolStripMenuItem.Name = "cargaToolStripMenuItem";
            this.cargaToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.cargaToolStripMenuItem.Text = "Admin";
            // 
            // aBMClienteToolStripMenuItem
            // 
            this.aBMClienteToolStripMenuItem.Name = "aBMClienteToolStripMenuItem";
            this.aBMClienteToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.aBMClienteToolStripMenuItem.Text = "ABM Cliente";
            this.aBMClienteToolStripMenuItem.Click += new System.EventHandler(this.aBMClienteToolStripMenuItem_Click);
            // 
            // aBMAdministrativoToolStripMenuItem
            // 
            this.aBMAdministrativoToolStripMenuItem.Name = "aBMAdministrativoToolStripMenuItem";
            this.aBMAdministrativoToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.aBMAdministrativoToolStripMenuItem.Text = "ABM Administrativo";
            this.aBMAdministrativoToolStripMenuItem.Click += new System.EventHandler(this.aBMAdministrativoToolStripMenuItem_Click);
            // 
            // aBMProfesionalToolStripMenuItem
            // 
            this.aBMProfesionalToolStripMenuItem.Name = "aBMProfesionalToolStripMenuItem";
            this.aBMProfesionalToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.aBMProfesionalToolStripMenuItem.Text = "ABM Profesional";
            this.aBMProfesionalToolStripMenuItem.Click += new System.EventHandler(this.aBMProfesionalToolStripMenuItem_Click);
            // 
            // aBMTratamientoToolStripMenuItem
            // 
            this.aBMTratamientoToolStripMenuItem.Name = "aBMTratamientoToolStripMenuItem";
            this.aBMTratamientoToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.aBMTratamientoToolStripMenuItem.Text = "ABM Tratamiento";
            this.aBMTratamientoToolStripMenuItem.Click += new System.EventHandler(this.aBMTratamientoToolStripMenuItem_Click);
            // 
            // turnosToolStripMenuItem
            // 
            this.turnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turnosToolStripMenuItem1,
            this.listadoDeTurnosToolStripMenuItem});
            this.turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            this.turnosToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.turnosToolStripMenuItem.Text = "Turnos";
            // 
            // turnosToolStripMenuItem1
            // 
            this.turnosToolStripMenuItem1.Name = "turnosToolStripMenuItem1";
            this.turnosToolStripMenuItem1.Size = new System.Drawing.Size(213, 26);
            this.turnosToolStripMenuItem1.Text = "Turnos";
            this.turnosToolStripMenuItem1.Click += new System.EventHandler(this.turnosToolStripMenuItem1_Click);
            // 
            // listadoDeTurnosToolStripMenuItem
            // 
            this.listadoDeTurnosToolStripMenuItem.Name = "listadoDeTurnosToolStripMenuItem";
            this.listadoDeTurnosToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.listadoDeTurnosToolStripMenuItem.Text = "Turnos por Cliente";
            this.listadoDeTurnosToolStripMenuItem.Click += new System.EventHandler(this.listadoDeTurnosToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1484, 692);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estética";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cargaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listadoDeTurnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMAdministrativoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMProfesionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMTratamientoToolStripMenuItem;
    }
}

