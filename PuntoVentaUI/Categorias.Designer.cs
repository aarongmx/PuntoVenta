namespace PuntoVentaUI
{
    partial class Categorias
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
            dataCategorias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataCategorias).BeginInit();
            SuspendLayout();
            // 
            // dataCategorias
            // 
            dataCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCategorias.Location = new Point(255, 156);
            dataCategorias.Name = "dataCategorias";
            dataCategorias.Size = new Size(240, 150);
            dataCategorias.TabIndex = 0;
            // 
            // Categorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 450);
            Controls.Add(dataCategorias);
            Name = "Categorias";
            Text = "Categorias";
            Load += Categorias_Load;
            ((System.ComponentModel.ISupportInitialize)dataCategorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataCategorias;
    }
}