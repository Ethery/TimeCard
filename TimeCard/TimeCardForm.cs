// Author : MEUNIER Loïc
// This tool is designed to personnal use only.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TimeCard.Datas;

namespace TimeCard
{
	public partial class TimeCardForm : Form
	{
		private DayShifts m_currentDayTimeCard;
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

#if DEBUG
			SaveButton.Enabled = true;
			SaveButton.Enabled = true;
#else
			SaveButton.Dispose();
			LoadButton.Dispose();
#endif

			IsInitialized = true;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			SaveReport();
			base.OnClosing(e);
		}

		private void LoadCurrentDayShift()
		{
			m_currentDayTimeCard = new DayShifts(LoadReport(DateTime.Today));
			IsWorking = m_currentDayTimeCard.LastShift != null && m_currentDayTimeCard.LastShift.IsRunning;
			IsWorkingCheckBox.Checked = IsWorking;
			RefreshShiftsDisplay();
		}

		private void Tmr_Tick(object sender, EventArgs e)  //run this logic each timer tick
		{
			if (IsWorking)
			{
				RefreshTimers();
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
				if (IsWorking != IsWorkingCheckBox.Checked)
				{
					IsWorking = IsWorkingCheckBox.Checked;
					if (IsWorking)
					{
						m_currentDayTimeCard.BeginNewShift();
					}
					else
					{
						m_currentDayTimeCard.EndCurrentShift();
					}
					RefreshShiftsDisplay();

					SaveReport();
				}
			}
		}

		private void RefreshTimers()
		{
			TimeSpanInDayText.Text = $"Today : {m_currentDayTimeCard.TimeSpendInDay().ToString(@"dd\.hh\:mm\:ss")}";
			TimeSpanInWeekWithoutTodayText.Text = $"Week (without today) : {GetTimeSpendInWholeWeekWithoutToday().ToString(@"dd\.hh\:mm\:ss")}";
			TimeSpanInWeekText.Text = $"Whole week : {(GetTimeSpendInWholeWeekWithoutToday() + m_currentDayTimeCard.TimeSpendInDay()).ToString(@"dd\.hh\:mm\:ss")}";
		}

		private void RefreshShiftsDisplay()
		{
			ShiftsList.Text = string.Empty;
			for (int i = 0; i < m_currentDayTimeCard.Shifts.Count; i++)
			{
				DayShifts.WorkingShift shift = m_currentDayTimeCard.Shifts[i];
				ShiftsList.AppendText($"{shift.begin.ToLongTimeString()}");
				if (!shift.IsRunning)
				{
					ShiftsList.AppendText($" -- {shift.end.ToLongTimeString()}");
				}
				else
				{
					ShiftsList.AppendText($" -- (current)");
				}
				if (i < m_currentDayTimeCard.Shifts.Count - 1)
				{
					ShiftsList.Text += Environment.NewLine;
				}
			}
			RefreshTimers();
		}

		private TimeSpan GetTimeSpendInWholeWeekWithoutToday()
		{
			DateTime startOfWeek = DateTime.Today.AddDays(
			(int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
			(int)DateTime.Today.DayOfWeek);

			List<DateTime> weekDates = new List<DateTime>(Enumerable.Range(0, 7).Select(i => startOfWeek.AddDays(i)));

			TimeSpan totalTimeSpan = new TimeSpan();
			foreach (DateTime dayOfWeek in weekDates)
			{
				if (dayOfWeek != DateTime.Today)
				{
					string reportContent = LoadReport(dayOfWeek);
					if (!string.IsNullOrEmpty(reportContent))
					{
						DayShifts dayTimeCard = new DayShifts(reportContent);
						if (!dayTimeCard.LastShift.IsRunning)
						{
							totalTimeSpan += dayTimeCard.TimeSpendInDay();
						}
					}
				}
			}
			return totalTimeSpan;
		}

		private string SaveReport()
		{
			DateTime dateToSend = DateTime.Today;
			string textToSend = m_currentDayTimeCard.ToString();
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

		private void TimeCardForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			SaveReport();
		}
	}
}
