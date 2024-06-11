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
			this.SaveButton = new System.Windows.Forms.Button();
			this.LoadButton = new System.Windows.Forms.Button();
			this.ShiftsList = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.TimeSpanInDayText = new System.Windows.Forms.Label();
			this.TimeSpanInWeekWithoutTodayText = new System.Windows.Forms.Label();
			this.TimeSpanInWeekText = new System.Windows.Forms.Label();
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
			this.IsWorkingCheckBox.Location = new System.Drawing.Point(102, 12);
			this.IsWorkingCheckBox.Name = "IsWorkingCheckBox";
			this.IsWorkingCheckBox.Size = new System.Drawing.Size(228, 46);
			this.IsWorkingCheckBox.TabIndex = 0;
			this.IsWorkingCheckBox.Text = "I am working now";
			this.IsWorkingCheckBox.UseVisualStyleBackColor = false;
			this.IsWorkingCheckBox.CheckedChanged += new System.EventHandler(this.IsWorkingCheckBox_CheckedChanged);
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveButton.Location = new System.Drawing.Point(336, 269);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 1;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// LoadButton
			// 
			this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadButton.Location = new System.Drawing.Point(336, 298);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(75, 23);
			this.LoadButton.TabIndex = 2;
			this.LoadButton.Text = "Load today";
			this.LoadButton.UseVisualStyleBackColor = true;
			this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
			// 
			// ShiftsList
			// 
			this.ShiftsList.AcceptsReturn = true;
			this.ShiftsList.AcceptsTab = true;
			this.ShiftsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ShiftsList.Location = new System.Drawing.Point(12, 110);
			this.ShiftsList.Multiline = true;
			this.ShiftsList.Name = "ShiftsList";
			this.ShiftsList.ReadOnly = true;
			this.ShiftsList.Size = new System.Drawing.Size(226, 212);
			this.ShiftsList.TabIndex = 3;
			this.ShiftsList.WordWrap = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 90);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Shifts";
			// 
			// TimeSpanInDayText
			// 
			this.TimeSpanInDayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TimeSpanInDayText.Location = new System.Drawing.Point(250, 117);
			this.TimeSpanInDayText.Name = "TimeSpanInDayText";
			this.TimeSpanInDayText.Size = new System.Drawing.Size(171, 13);
			this.TimeSpanInDayText.TabIndex = 5;
			this.TimeSpanInDayText.Text = "TimeSpanInDay";
			this.TimeSpanInDayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TimeSpanInWeekWithoutTodayText
			// 
			this.TimeSpanInWeekWithoutTodayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TimeSpanInWeekWithoutTodayText.Location = new System.Drawing.Point(244, 142);
			this.TimeSpanInWeekWithoutTodayText.Name = "TimeSpanInWeekWithoutTodayText";
			this.TimeSpanInWeekWithoutTodayText.Size = new System.Drawing.Size(177, 13);
			this.TimeSpanInWeekWithoutTodayText.TabIndex = 6;
			this.TimeSpanInWeekWithoutTodayText.Text = "TimeSpanInWeekWithoutToday";
			this.TimeSpanInWeekWithoutTodayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TimeSpanInWeekText
			// 
			this.TimeSpanInWeekText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TimeSpanInWeekText.Location = new System.Drawing.Point(247, 172);
			this.TimeSpanInWeekText.Name = "TimeSpanInWeekText";
			this.TimeSpanInWeekText.Size = new System.Drawing.Size(174, 13);
			this.TimeSpanInWeekText.TabIndex = 7;
			this.TimeSpanInWeekText.Text = "TimeSpanInWeek";
			this.TimeSpanInWeekText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TimeCardForm
			// 
			this.ClientSize = new System.Drawing.Size(423, 333);
			this.Controls.Add(this.TimeSpanInWeekText);
			this.Controls.Add(this.TimeSpanInWeekWithoutTodayText);
			this.Controls.Add(this.TimeSpanInDayText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ShiftsList);
			this.Controls.Add(this.LoadButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.IsWorkingCheckBox);
			this.Name = "TimeCardForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TimeCardForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox IsWorkingCheckBox;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button LoadButton;
		private System.Windows.Forms.TextBox ShiftsList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label TimeSpanInDayText;
		private System.Windows.Forms.Label TimeSpanInWeekWithoutTodayText;
		private System.Windows.Forms.Label TimeSpanInWeekText;
	}
}
