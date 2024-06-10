// Author : MEUNIER Loïc
// This tool is designed to personnal use only.

using System;
using System.IO;
using System.Windows.Forms;
using TimeCard.Datas;

namespace TimeCard
{
	public partial class TimeCardForm : Form
	{
		private DayShifts m_timeCard;
		private bool IsWorking = false;
		private bool IsInitialized = false;
		public TimeCardForm()
		{
			InitializeComponent();

			TimeSpanInDayText.Text = TimeSpan.MinValue.ToString();

			LoadCurrentDayShift();

			Timer tmr = new Timer();
			tmr.Interval = 1000;   // milliseconds
			tmr.Tick += Tmr_Tick;  // set handler
			tmr.Start();
			IsInitialized = true;
		}

		private void LoadCurrentDayShift()
		{
			m_timeCard = new DayShifts(LoadReport(DateTime.Now));
			IsWorking = m_timeCard.LastShift != null && m_timeCard.LastShift.IsRunning;
			IsWorkingCheckBox.Checked = IsWorking;
			RefreshShiftsDisplay();
		}

		private void Tmr_Tick(object sender, EventArgs e)  //run this logic each timer tick
		{
			if (IsWorking)
			{
				TimeSpan span = new TimeSpan();
				for (int i = 0; i < m_timeCard.Shifts.Count; i++)
				{
					DayShifts.WorkingShift shift = m_timeCard.Shifts[i];
					if (!shift.IsRunning)
					{
						span += shift.GetSpan();
					}
					else
					{
						span += DateTime.Now - shift.begin;
					}
				}
				TimeSpanInDayText.Text = span.ToString(@"dd\.hh\:mm\:ss");
			}
		}

		public string DateToString(DateTime date, char separator)
		{
			string month = (date.Month < 10 ? "0" : string.Empty) + date.Month;
			string day = (date.Day < 10 ? "0" : string.Empty) + date.Day;
			return string.Empty + date.Year + separator + month + separator + day;
		}

		private void IsWorkingCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (IsInitialized)
			{
				IsWorking = IsWorkingCheckBox.Checked;
				if (IsWorking)
				{
					m_timeCard.BeginNewShift();
				}
				else
				{
					m_timeCard.EndCurrentShift();
				}
				RefreshShiftsDisplay();
			}
		}

		private void RefreshShiftsDisplay()
		{
			ShiftsList.Text = string.Empty;
			TimeSpan span = new TimeSpan();
			for (int i = 0; i < m_timeCard.Shifts.Count; i++)
			{
				DayShifts.WorkingShift shift = m_timeCard.Shifts[i];
				ShiftsList.AppendText($"{shift.begin.ToLongTimeString()}");
				if (!shift.IsRunning)
				{
					span += shift.GetSpan();
					ShiftsList.AppendText($" -> {shift.end.ToLongTimeString()}");
				}
				else
				{
					span += DateTime.Now - shift.begin;
					ShiftsList.AppendText($"(current)");
				}
				if (i < m_timeCard.Shifts.Count - 1)
				{
					ShiftsList.Text += Environment.NewLine;
				}
			}
			TimeSpanInDayText.Text = span.ToString(@"dd\.hh\:mm\:ss");
		}

		private string SaveReport()
		{
			DateTime dateToSend = DateTime.Now;
			string textToSend = m_timeCard.ToString();
			if (!Directory.Exists("ReportsBodys"))
				Directory.CreateDirectory("ReportsBodys");

			StreamWriter writer = new StreamWriter("ReportsBodys\\[HS]Loïc MEUNIER[" + DateToString(dateToSend, '_') + "].txt");
			writer.Write(textToSend);
			writer.Dispose();
			writer.Close();
			return textToSend;
		}

		private string LoadReport(DateTime dT)
		{
			string textReaded = string.Empty;
			if (!Directory.Exists("ReportsBodys"))
				return textReaded;

			string fileNameSearch = "[" + DateToString(dT, '_') + "]";
			string fileName = string.Empty;
			foreach (string f in Directory.GetFiles("ReportsBodys"))
			{
				if (f.Contains(fileNameSearch))
				{
					fileName = f;
					break;
				}
			}
			if (fileName == string.Empty)
				return textReaded;

			StreamReader Reader = new StreamReader(fileName);
			textReaded = Reader.ReadToEnd();
			Reader.Dispose();
			Reader.Close();
			return textReaded;
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			SaveReport();
		}

		private void LoadButton_Click(object sender, EventArgs e)
		{
			LoadCurrentDayShift();
		}
	}
}
