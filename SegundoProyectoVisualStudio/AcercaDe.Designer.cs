namespace SegundoProyectoVisualStudio
{
    partial class AcercaDe
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(691, 15);
            label1.TabIndex = 0;
            label1.Text = "Proyecto desarrollado para el curso de desarrollo de aplicaciones empresariales por: Andres-Jafet-Alejandra. Esta es la versión 2.0.0";
            label1.Click += label1_Click;
            // 
            // AcercaDe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 89);
            Controls.Add(label1);
            Name = "AcercaDe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acerca de";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}