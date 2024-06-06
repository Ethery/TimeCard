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
		private DayTimeCard m_timeCard;
		private bool IsWorking = false;

		public TimeCardForm()
		{
			InitializeComponent();
			m_timeCard = new DayTimeCard(LoadReport(DateTime.Now));
		}

		public string DateToString(DateTime date, char separator)
		{
			string month = (date.Month < 10 ? "0" : string.Empty) + date.Month;
			string day = (date.Day < 10 ? "0" : string.Empty) + date.Day;
			return string.Empty + date.Year + separator + month + separator + day;
		}

		private void IsWorkingCheckBox_CheckedChanged(object sender, EventArgs e)
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
		}

		private string SaveReport(DateTime dT)
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

	}
}
