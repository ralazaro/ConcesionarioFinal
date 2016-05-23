using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WForms
{
    partial class Inicio
    {


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
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnVehiculo = new System.Windows.Forms.Button();
            this.btnPresupuesto = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(12, 43);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(260, 52);
            this.btnCliente.TabIndex = 0;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnVehiculo
            // 
            this.btnVehiculo.Location = new System.Drawing.Point(12, 101);
            this.btnVehiculo.Name = "btnVehiculo";
            this.btnVehiculo.Size = new System.Drawing.Size(260, 53);
            this.btnVehiculo.TabIndex = 1;
            this.btnVehiculo.Text = "Vehiculo";
            this.btnVehiculo.UseVisualStyleBackColor = true;
            this.btnVehiculo.Click += new System.EventHandler(this.btnVehiculo_Click);
            // 
            // btnPresupuesto
            // 
            this.btnPresupuesto.Location = new System.Drawing.Point(12, 160);
            this.btnPresupuesto.Name = "btnPresupuesto";
            this.btnPresupuesto.Size = new System.Drawing.Size(260, 54);
            this.btnPresupuesto.TabIndex = 2;
            this.btnPresupuesto.Text = "Presupuesto";
            this.btnPresupuesto.UseVisualStyleBackColor = true;
            this.btnPresupuesto.Click += new System.EventHandler(this.btnPresupuesto_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.vehiculosToolStripMenuItem,
            this.presupuestosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(828, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaClienteToolStripMenuItem,
            this.bajaClienteToolStripMenuItem,
            this.modificarClienteToolStripMenuItem,
            this.listadoClienteToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // altaClienteToolStripMenuItem
            // 
            this.altaClienteToolStripMenuItem.Name = "altaClienteToolStripMenuItem";
            this.altaClienteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.altaClienteToolStripMenuItem.Text = "Alta";
            this.altaClienteToolStripMenuItem.Click += new System.EventHandler(this.altaClienteToolStripMenuItem_Click);
            // 
            // bajaClienteToolStripMenuItem
            // 
            this.bajaClienteToolStripMenuItem.Name = "bajaClienteToolStripMenuItem";
            this.bajaClienteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.bajaClienteToolStripMenuItem.Text = "Baja";
            this.bajaClienteToolStripMenuItem.Click += new System.EventHandler(this.bajaToolStripMenuItem_Click);
            // 
            // modificarClienteToolStripMenuItem
            // 
            this.modificarClienteToolStripMenuItem.Name = "modificarClienteToolStripMenuItem";
            this.modificarClienteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.modificarClienteToolStripMenuItem.Text = "Modificar";
            this.modificarClienteToolStripMenuItem.Click += new System.EventHandler(this.modificarClienteToolStripMenuItem_Click);
            // 
            // listadoClienteToolStripMenuItem
            // 
            this.listadoClienteToolStripMenuItem.Name = "listadoClienteToolStripMenuItem";
            this.listadoClienteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.listadoClienteToolStripMenuItem.Text = "Listado";
            this.listadoClienteToolStripMenuItem.Click += new System.EventHandler(this.listadoClienteToolStripMenuItem_Click);
            // 
            // vehiculosToolStripMenuItem
            // 
            this.vehiculosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaVehiculoToolStripMenuItem,
            this.bajaVehiculoToolStripMenuItem,
            this.modificarVehiculoToolStripMenuItem,
            this.listadoVehiculoToolStripMenuItem});
            this.vehiculosToolStripMenuItem.Name = "vehiculosToolStripMenuItem";
            this.vehiculosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.vehiculosToolStripMenuItem.Text = "Vehiculos";
            // 
            // altaVehiculoToolStripMenuItem
            // 
            this.altaVehiculoToolStripMenuItem.Name = "altaVehiculoToolStripMenuItem";
            this.altaVehiculoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.altaVehiculoToolStripMenuItem.Text = "Alta";
            this.altaVehiculoToolStripMenuItem.Click += new System.EventHandler(this.altaVehiculoToolStripMenuItem_Click);
            // 
            // bajaVehiculoToolStripMenuItem
            // 
            this.bajaVehiculoToolStripMenuItem.Name = "bajaVehiculoToolStripMenuItem";
            this.bajaVehiculoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bajaVehiculoToolStripMenuItem.Text = "Baja";
            this.bajaVehiculoToolStripMenuItem.Click += new System.EventHandler(this.bajaVehiculoToolStripMenuItem_Click);
            // 
            // modificarVehiculoToolStripMenuItem
            // 
            this.modificarVehiculoToolStripMenuItem.Name = "modificarVehiculoToolStripMenuItem";
            this.modificarVehiculoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modificarVehiculoToolStripMenuItem.Text = "Modificar";
            this.modificarVehiculoToolStripMenuItem.Click += new System.EventHandler(this.modificarVehiculoToolStripMenuItem_Click);
            // 
            // listadoVehiculoToolStripMenuItem
            // 
            this.listadoVehiculoToolStripMenuItem.Name = "listadoVehiculoToolStripMenuItem";
            this.listadoVehiculoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listadoVehiculoToolStripMenuItem.Text = "Listado";
            this.listadoVehiculoToolStripMenuItem.Click += new System.EventHandler(this.listadoVehiculoToolStripMenuItem_Click);
            // 
            // presupuestosToolStripMenuItem
            // 
            this.presupuestosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaPresupuestoToolStripMenuItem,
            this.bajaPresupuestoToolStripMenuItem,
            this.modificarPresupuestoToolStripMenuItem,
            this.listadoPresupuestoToolStripMenuItem});
            this.presupuestosToolStripMenuItem.Name = "presupuestosToolStripMenuItem";
            this.presupuestosToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.presupuestosToolStripMenuItem.Text = "Presupuestos";
            // 
            // altaPresupuestoToolStripMenuItem
            // 
            this.altaPresupuestoToolStripMenuItem.Name = "altaPresupuestoToolStripMenuItem";
            this.altaPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.altaPresupuestoToolStripMenuItem.Text = "Alta";
            this.altaPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.altaPresupuestoToolStripMenuItem_Click);
            // 
            // bajaPresupuestoToolStripMenuItem
            // 
            this.bajaPresupuestoToolStripMenuItem.Name = "bajaPresupuestoToolStripMenuItem";
            this.bajaPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bajaPresupuestoToolStripMenuItem.Text = "Baja";
            this.bajaPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.bajaPresupuestoToolStripMenuItem_Click);
            // 
            // modificarPresupuestoToolStripMenuItem
            // 
            this.modificarPresupuestoToolStripMenuItem.Name = "modificarPresupuestoToolStripMenuItem";
            this.modificarPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modificarPresupuestoToolStripMenuItem.Text = "Modificar";
            this.modificarPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.modificarPresupuestoToolStripMenuItem_Click);
            // 
            // listadoPresupuestoToolStripMenuItem
            // 
            this.listadoPresupuestoToolStripMenuItem.Name = "listadoPresupuestoToolStripMenuItem";
            this.listadoPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listadoPresupuestoToolStripMenuItem.Text = "Listado";
            this.listadoPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.listadoPresupuestoToolStripMenuItem_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 333);
            this.Controls.Add(this.btnPresupuesto);
            this.Controls.Add(this.btnVehiculo);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Inicio";
            this.Text = "Concesionario ADO.Net";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnVehiculo;
        private System.Windows.Forms.Button btnPresupuesto;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoPresupuestoToolStripMenuItem;
    }
}

