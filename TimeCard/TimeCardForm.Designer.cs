namespace TimeCard
{
	partial class TimeCardForm
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.IsWorkingCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// IsWorkingCheckBox
			// 
			this.IsWorkingCheckBox.AutoSize = true;
			this.IsWorkingCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.IsWorkingCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.IsWorkingCheckBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.IsWorkingCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.IsWorkingCheckBox.FlatAppearance.BorderSize = 50;
			this.IsWorkingCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.IsWorkingCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.IsWorkingCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.IsWorkingCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.IsWorkingCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IsWorkingCheckBox.Location = new System.Drawing.Point(75, 52);
			this.IsWorkingCheckBox.Name = "IsWorkingCheckBox";
			this.IsWorkingCheckBox.Size = new System.Drawing.Size(228, 46);
			this.IsWorkingCheckBox.TabIndex = 0;
			this.IsWorkingCheckBox.Text = "I am working now";
			this.IsWorkingCheckBox.UseVisualStyleBackColor = false;
			this.IsWorkingCheckBox.CheckedChanged += new System.EventHandler(this.IsWorkingCheckBox_CheckedChanged);
			// 
			// TimeCard
			// 
			this.ClientSize = new System.Drawing.Size(663, 550);
			this.Controls.Add(this.IsWorkingCheckBox);
			this.Name = "TimeCard";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox IsWorkingCheckBox;
	}
}
