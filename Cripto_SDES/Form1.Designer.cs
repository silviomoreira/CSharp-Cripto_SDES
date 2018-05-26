namespace Cripto_SDES
{
    partial class frmEntradaDados
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
            this.txtChave = new System.Windows.Forms.TextBox();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.lblChave = new System.Windows.Forms.Label();
            this.lblTexto = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnCrip = new System.Windows.Forms.Button();
            this.btnDecrip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtChave
            // 
            this.txtChave.Location = new System.Drawing.Point(24, 34);
            this.txtChave.Name = "txtChave";
            this.txtChave.Size = new System.Drawing.Size(450, 20);
            this.txtChave.TabIndex = 0;
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(24, 95);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(450, 20);
            this.txtTexto.TabIndex = 1;
            // 
            // lblChave
            // 
            this.lblChave.AutoSize = true;
            this.lblChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblChave.Location = new System.Drawing.Point(21, 14);
            this.lblChave.Name = "lblChave";
            this.lblChave.Size = new System.Drawing.Size(52, 16);
            this.lblChave.TabIndex = 2;
            this.lblChave.Text = "Chave";
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTexto.Location = new System.Drawing.Point(21, 76);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(47, 16);
            this.lblTexto.TabIndex = 3;
            this.lblTexto.Text = "Texto";
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(24, 155);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(450, 20);
            this.txtResultado.TabIndex = 4;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblResultado.Location = new System.Drawing.Point(21, 136);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(79, 16);
            this.lblResultado.TabIndex = 5;
            this.lblResultado.Text = "Resultado";
            // 
            // btnCrip
            // 
            this.btnCrip.Location = new System.Drawing.Point(140, 205);
            this.btnCrip.Name = "btnCrip";
            this.btnCrip.Size = new System.Drawing.Size(90, 27);
            this.btnCrip.TabIndex = 6;
            this.btnCrip.Text = "Criptografa";
            this.btnCrip.UseVisualStyleBackColor = true;
            // 
            // btnDecrip
            // 
            this.btnDecrip.Location = new System.Drawing.Point(277, 205);
            this.btnDecrip.Name = "btnDecrip";
            this.btnDecrip.Size = new System.Drawing.Size(90, 27);
            this.btnDecrip.TabIndex = 7;
            this.btnDecrip.Text = "Descriptografa";
            this.btnDecrip.UseVisualStyleBackColor = true;
            // 
            // frmEntradaDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 262);
            this.Controls.Add(this.btnDecrip);
            this.Controls.Add(this.btnCrip);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.lblChave);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.txtChave);
            this.Name = "frmEntradaDados";
            this.Text = "Criptografa/Descriptografa - S-DES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChave;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label lblChave;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnCrip;
        private System.Windows.Forms.Button btnDecrip;
    }
}

