using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard
{
	internal class Reports : IEnumerable<KeyValuePair<DateTime, string>>
	{
		private Dictionary<DateTime, string> m_reports = new Dictionary<DateTime, string>();

		public string this[DateTime date]
		{
			get
			{
				if (!m_reports.ContainsKey(date))
				{
					return "";
				}
				return m_reports[date];
			}
		}

		public Reports()
		{
		}

		public Reports(DateTime _dt)
		{
			m_reports.Add(_dt, "");
		}

		public Reports(DateTime _dt, string _tsk)
		{
			m_reports.Add(_dt, _tsk);
		}

		public Reports(List<DateTime> _dt, List<string> _tsks)
		{
			int j = 0;
			int i = 0;
			for (i = 0, j = 0; i < _dt.Count || j < _tsks.Count; i++, j++)
			{
				m_reports.Add(_dt[i], _tsks[j]);
			}
		}

		public void AddReport(DateTime _dt, string _task = "")
		{
			if (!m_reports.ContainsKey(_dt))
			{
				m_reports.Add(_dt, _task);
			}
		}

		public void Sort()
		{
			Dictionary<DateTime, string> sortedDic = new Dictionary<DateTime, string>();
			List<DateTime> sortedKeys = m_reports.Keys.ToList();
			sortedKeys.Sort();

			foreach (DateTime dt in sortedKeys)
			{
				sortedDic.Add(dt, m_reports[dt]);
			}
			m_reports = sortedDic;
		}

		public void SetReport(DateTime _dt, string _task = "")
		{
			if (!m_reports.ContainsKey(_dt))
			{
				m_reports.Add(_dt, _task);
			}
			else
			{
				m_reports[_dt] = _task;
			}
		}

		public string ToString(DateTime _dt, bool isTextBoxDisplay = false)
		{
			string str = m_reports[_dt] + '\n';
			if (!isTextBoxDisplay)
			{
				string formatedMonth = (_dt.Month < 10 ? "0" : "") + _dt.Month;
				string formatedDay = (_dt.Day < 10 ? "0" : "") + _dt.Day;
				str = str.Insert(0, "[CR][" + "] Loïc MEUNIER [" + _dt.Year + "_" + formatedMonth + "_" + formatedDay + "]\n");
			}
			return str;
		}

		public KeyValuePair<DateTime, string> Last()
		{
			return m_reports.Last();
		}

		public KeyValuePair<DateTime, string> First()
		{
			return m_reports.First();
		}

		public bool ContainsKey(DateTime _dt)
		{
			return m_reports.ContainsKey(_dt);
		}

		static public Reports LoadFromString(string text)
		{
			Reports reports = new Reports();
			string reportText = ExtractReport(ref text);
			while (reportText != "")
			{
				List<string> splited = reportText.Split('\n').ToList();
				string dateLine = splited[0];
				string[] dateParams = dateLine.Split('_');
				dateParams[0] = dateParams[0].Substring(dateParams[0].Length - 4);
				dateParams[1] = dateParams[1].Substring(dateParams[0].Length - 4);
				dateParams[2] = dateParams[2].Substring(0, 2);

				DateTime reportDate = new DateTime(int.Parse(dateParams[0]), int.Parse(dateParams[1]), int.Parse(dateParams[2]));
				string content;
				splited.RemoveAt(0);
				if (splited.Count > 0)
				{
					content = splited.Aggregate((x, y) => x + '\n' + y);
				}
				else
				{
					content = "";
				}
				reports.SetReport(reportDate, content);

				reportText = ExtractReport(ref text);
			}
			return reports.m_reports.Count > 0 ? reports : null;
		}

		private static string ExtractReport(ref string text)
		{
			string report = text.Replace('\r', ' ');
			int start = report.IndexOf("[CR]", StringComparison.CurrentCulture);
			if (start >= 0)
			{
				int end = report.IndexOf("[CR]", start + 4);
				if (end != -1)
				{
					text = text.Substring(end);

					//Removing empty lines
					report = report.Substring(start, end - start);
					List<string> lines = report.Split('\n').ToList();
					lines.RemoveAll(x => x == "");
					report = lines.Aggregate((x, y) => x + '\n' + y);

					return report;
				}
				else
				{
					text = "";
					return report.Substring(start);
				}
			}
			return "";
		}

		public IEnumerator<KeyValuePair<DateTime, string>> GetEnumerator()
		{
			return m_reports.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
