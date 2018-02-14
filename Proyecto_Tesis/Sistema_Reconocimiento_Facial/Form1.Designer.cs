namespace Sistema_Reconocimiento_Facial
{
    partial class Form1
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
            this.pbImageRecortada = new System.Windows.Forms.PictureBox();
            this.pbImagenOriginal = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbImageEcualizada = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageRecortada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageEcualizada)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImageRecortada
            // 
            this.pbImageRecortada.Location = new System.Drawing.Point(282, 64);
            this.pbImageRecortada.Name = "pbImageRecortada";
            this.pbImageRecortada.Size = new System.Drawing.Size(168, 192);
            this.pbImageRecortada.TabIndex = 0;
            this.pbImageRecortada.TabStop = false;
            // 
            // pbImagenOriginal
            // 
            this.pbImagenOriginal.Location = new System.Drawing.Point(12, 64);
            this.pbImagenOriginal.Name = "pbImagenOriginal";
            this.pbImagenOriginal.Size = new System.Drawing.Size(255, 255);
            this.pbImagenOriginal.TabIndex = 1;
            this.pbImagenOriginal.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "imagen Original 250x250 px";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "imagen Recortada 168x192 px";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "histograma imagen ecualizado 168x192 px";
            // 
            // pbImageEcualizada
            // 
            this.pbImageEcualizada.Location = new System.Drawing.Point(468, 64);
            this.pbImageEcualizada.Name = "pbImageEcualizada";
            this.pbImageEcualizada.Size = new System.Drawing.Size(168, 192);
            this.pbImageEcualizada.TabIndex = 4;
            this.pbImageEcualizada.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 391);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbImageEcualizada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbImagenOriginal);
            this.Controls.Add(this.pbImageRecortada);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbImageRecortada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageEcualizada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImageRecortada;
        private System.Windows.Forms.PictureBox pbImagenOriginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbImageEcualizada;
    }
}

