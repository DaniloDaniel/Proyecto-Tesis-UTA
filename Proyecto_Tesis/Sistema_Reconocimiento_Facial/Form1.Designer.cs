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
            this.pbImagenOriginal = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEntrenar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbC = new System.Windows.Forms.TextBox();
            this.tbGamma = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFactorFragmentacionTrain = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeleccionarRutaMuestrasEntrenamiento = new System.Windows.Forms.Button();
            this.tbRutaMuestrasEntrenamiento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbWinsize = new System.Windows.Forms.TextBox();
            this.tbBlocksize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCellsize = new System.Windows.Forms.TextBox();
            this.tbNbins = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSeleccionarMuestrasTest = new System.Windows.Forms.Button();
            this.tbRutaMuetrasTest = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbFactorFragmentacionTest = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnTestear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSujetosTest = new System.Windows.Forms.TextBox();
            this.tbSujetosIdentificados = new System.Windows.Forms.TextBox();
            this.tbSujetosSinIdentificar = new System.Windows.Forms.TextBox();
            this.tbPorcetajeAsiertos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenOriginal)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImagenOriginal
            // 
            this.pbImagenOriginal.Location = new System.Drawing.Point(16, 16);
            this.pbImagenOriginal.Name = "pbImagenOriginal";
            this.pbImagenOriginal.Size = new System.Drawing.Size(540, 540);
            this.pbImagenOriginal.TabIndex = 1;
            this.pbImagenOriginal.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(945, 629);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pbImagenOriginal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(937, 603);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vivo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnEntrenar);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.cbFactorFragmentacionTrain);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnSeleccionarRutaMuestrasEntrenamiento);
            this.tabPage2.Controls.Add(this.tbRutaMuestrasEntrenamiento);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(937, 603);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Entrenamiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEntrenar
            // 
            this.btnEntrenar.Location = new System.Drawing.Point(403, 431);
            this.btnEntrenar.Name = "btnEntrenar";
            this.btnEntrenar.Size = new System.Drawing.Size(75, 23);
            this.btnEntrenar.TabIndex = 6;
            this.btnEntrenar.Text = "&Entrenar";
            this.btnEntrenar.UseVisualStyleBackColor = true;
            this.btnEntrenar.Click += new System.EventHandler(this.btnEntrenar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbC);
            this.groupBox1.Controls.Add(this.tbGamma);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(674, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 179);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros SVM\'s";
            // 
            // tbC
            // 
            this.tbC.Location = new System.Drawing.Point(70, 36);
            this.tbC.Name = "tbC";
            this.tbC.Size = new System.Drawing.Size(100, 20);
            this.tbC.TabIndex = 9;
            // 
            // tbGamma
            // 
            this.tbGamma.Location = new System.Drawing.Point(70, 67);
            this.tbGamma.Name = "tbGamma";
            this.tbGamma.Size = new System.Drawing.Size(100, 20);
            this.tbGamma.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Gamma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "C:";
            // 
            // cbFactorFragmentacionTrain
            // 
            this.cbFactorFragmentacionTrain.FormattingEnabled = true;
            this.cbFactorFragmentacionTrain.Items.AddRange(new object[] {
            "Factor 4",
            "Factor 16",
            "Factor 64"});
            this.cbFactorFragmentacionTrain.Location = new System.Drawing.Point(140, 100);
            this.cbFactorFragmentacionTrain.Name = "cbFactorFragmentacionTrain";
            this.cbFactorFragmentacionTrain.Size = new System.Drawing.Size(121, 21);
            this.cbFactorFragmentacionTrain.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Factor fragmentación:";
            // 
            // btnSeleccionarRutaMuestrasEntrenamiento
            // 
            this.btnSeleccionarRutaMuestrasEntrenamiento.Location = new System.Drawing.Point(583, 29);
            this.btnSeleccionarRutaMuestrasEntrenamiento.Name = "btnSeleccionarRutaMuestrasEntrenamiento";
            this.btnSeleccionarRutaMuestrasEntrenamiento.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarRutaMuestrasEntrenamiento.TabIndex = 2;
            this.btnSeleccionarRutaMuestrasEntrenamiento.Text = "&Seleccionar";
            this.btnSeleccionarRutaMuestrasEntrenamiento.UseVisualStyleBackColor = true;
            this.btnSeleccionarRutaMuestrasEntrenamiento.Click += new System.EventHandler(this.btnSeleccionarRutaMuestrasEntrenamiento_Click);
            // 
            // tbRutaMuestrasEntrenamiento
            // 
            this.tbRutaMuestrasEntrenamiento.Location = new System.Drawing.Point(140, 31);
            this.tbRutaMuestrasEntrenamiento.Name = "tbRutaMuestrasEntrenamiento";
            this.tbRutaMuestrasEntrenamiento.ReadOnly = true;
            this.tbRutaMuestrasEntrenamiento.Size = new System.Drawing.Size(437, 20);
            this.tbRutaMuestrasEntrenamiento.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ruta muestras:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbNbins);
            this.groupBox2.Controls.Add(this.tbCellsize);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbWinsize);
            this.groupBox2.Controls.Add(this.tbBlocksize);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(674, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 182);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parámetros HOG";
            // 
            // tbWinsize
            // 
            this.tbWinsize.Location = new System.Drawing.Point(104, 36);
            this.tbWinsize.Name = "tbWinsize";
            this.tbWinsize.Size = new System.Drawing.Size(100, 20);
            this.tbWinsize.TabIndex = 9;
            // 
            // tbBlocksize
            // 
            this.tbBlocksize.Location = new System.Drawing.Point(104, 67);
            this.tbBlocksize.Name = "tbBlocksize";
            this.tbBlocksize.Size = new System.Drawing.Size(100, 20);
            this.tbBlocksize.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "BlockSize:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "WinSize:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "CellSize:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "NBins:";
            // 
            // tbCellsize
            // 
            this.tbCellsize.Location = new System.Drawing.Point(104, 95);
            this.tbCellsize.Name = "tbCellsize";
            this.tbCellsize.Size = new System.Drawing.Size(100, 20);
            this.tbCellsize.TabIndex = 12;
            // 
            // tbNbins
            // 
            this.tbNbins.Location = new System.Drawing.Point(104, 125);
            this.tbNbins.Name = "tbNbins";
            this.tbNbins.Size = new System.Drawing.Size(100, 20);
            this.tbNbins.TabIndex = 13;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.btnTestear);
            this.tabPage3.Controls.Add(this.cbFactorFragmentacionTest);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.btnSeleccionarMuestrasTest);
            this.tabPage3.Controls.Add(this.tbRutaMuetrasTest);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(937, 603);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Prueba Estática";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionarMuestrasTest
            // 
            this.btnSeleccionarMuestrasTest.Location = new System.Drawing.Point(537, 26);
            this.btnSeleccionarMuestrasTest.Name = "btnSeleccionarMuestrasTest";
            this.btnSeleccionarMuestrasTest.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarMuestrasTest.TabIndex = 5;
            this.btnSeleccionarMuestrasTest.Text = "&Seleccionar";
            this.btnSeleccionarMuestrasTest.UseVisualStyleBackColor = true;
            this.btnSeleccionarMuestrasTest.Click += new System.EventHandler(this.btnSeleccionarMuestrasTest_Click);
            // 
            // tbRutaMuetrasTest
            // 
            this.tbRutaMuetrasTest.Location = new System.Drawing.Point(140, 28);
            this.tbRutaMuetrasTest.Name = "tbRutaMuetrasTest";
            this.tbRutaMuetrasTest.ReadOnly = true;
            this.tbRutaMuetrasTest.Size = new System.Drawing.Size(391, 20);
            this.tbRutaMuetrasTest.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Ruta muestras test:";
            // 
            // cbFactorFragmentacionTest
            // 
            this.cbFactorFragmentacionTest.FormattingEnabled = true;
            this.cbFactorFragmentacionTest.Items.AddRange(new object[] {
            "Factor 4",
            "Factor 16",
            "Factor 64"});
            this.cbFactorFragmentacionTest.Location = new System.Drawing.Point(140, 83);
            this.cbFactorFragmentacionTest.Name = "cbFactorFragmentacionTest";
            this.cbFactorFragmentacionTest.Size = new System.Drawing.Size(121, 21);
            this.cbFactorFragmentacionTest.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Factor fragmentación:";
            // 
            // btnTestear
            // 
            this.btnTestear.Location = new System.Drawing.Point(433, 401);
            this.btnTestear.Name = "btnTestear";
            this.btnTestear.Size = new System.Drawing.Size(75, 23);
            this.btnTestear.TabIndex = 8;
            this.btnTestear.Text = "&Testear";
            this.btnTestear.UseVisualStyleBackColor = true;
            this.btnTestear.Click += new System.EventHandler(this.btnTestear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbPorcetajeAsiertos);
            this.groupBox3.Controls.Add(this.tbSujetosSinIdentificar);
            this.groupBox3.Controls.Add(this.tbSujetosIdentificados);
            this.groupBox3.Controls.Add(this.tbSujetosTest);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(641, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 179);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resultados";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "N° sujetos identificados:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "N° sujetos test:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "N° sujetos sin identificar:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 132);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Porcentaje de asiertos:";
            // 
            // tbSujetosTest
            // 
            this.tbSujetosTest.Location = new System.Drawing.Point(162, 36);
            this.tbSujetosTest.Name = "tbSujetosTest";
            this.tbSujetosTest.Size = new System.Drawing.Size(100, 20);
            this.tbSujetosTest.TabIndex = 10;
            // 
            // tbSujetosIdentificados
            // 
            this.tbSujetosIdentificados.Location = new System.Drawing.Point(162, 67);
            this.tbSujetosIdentificados.Name = "tbSujetosIdentificados";
            this.tbSujetosIdentificados.Size = new System.Drawing.Size(100, 20);
            this.tbSujetosIdentificados.TabIndex = 11;
            // 
            // tbSujetosSinIdentificar
            // 
            this.tbSujetosSinIdentificar.Location = new System.Drawing.Point(162, 96);
            this.tbSujetosSinIdentificar.Name = "tbSujetosSinIdentificar";
            this.tbSujetosSinIdentificar.Size = new System.Drawing.Size(100, 20);
            this.tbSujetosSinIdentificar.TabIndex = 12;
            // 
            // tbPorcetajeAsiertos
            // 
            this.tbPorcetajeAsiertos.Location = new System.Drawing.Point(162, 129);
            this.tbPorcetajeAsiertos.Name = "tbPorcetajeAsiertos";
            this.tbPorcetajeAsiertos.Size = new System.Drawing.Size(100, 20);
            this.tbPorcetajeAsiertos.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 669);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "HKM | Sistema de Reconocimiento Facial ";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenOriginal)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbImagenOriginal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRutaMuestrasEntrenamiento;
        private System.Windows.Forms.Button btnSeleccionarRutaMuestrasEntrenamiento;
        private System.Windows.Forms.ComboBox cbFactorFragmentacionTrain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbC;
        private System.Windows.Forms.TextBox tbGamma;
        private System.Windows.Forms.Button btnEntrenar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbWinsize;
        private System.Windows.Forms.TextBox tbBlocksize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbNbins;
        private System.Windows.Forms.TextBox tbCellsize;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbFactorFragmentacionTest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSeleccionarMuestrasTest;
        private System.Windows.Forms.TextBox tbRutaMuetrasTest;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTestear;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbPorcetajeAsiertos;
        private System.Windows.Forms.TextBox tbSujetosSinIdentificar;
        private System.Windows.Forms.TextBox tbSujetosIdentificados;
        private System.Windows.Forms.TextBox tbSujetosTest;
    }
}

