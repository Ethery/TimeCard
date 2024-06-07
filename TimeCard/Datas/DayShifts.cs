using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeCard.Datas
{
	public class DayShifts
	{
		public DayShifts(string reportLoaded)
		{
			if (!string.IsNullOrEmpty(reportLoaded))
			{
				List<string> shiftsLines = reportLoaded.Split('\n').ToList();

				foreach (string shiftLine in shiftsLines)
				{
					if (shiftLine.Length > 6)
					{
						WorkingShift info = new WorkingShift();
						int endTimeBeginIndex = shiftLine.IndexOf(',');
						string beginString = shiftLine.Substring(6, endTimeBeginIndex - 6);

						if (DateTime.TryParse(beginString, out DateTime begin))
						{
							info.begin = begin;
							string endString = shiftLine.Substring(endTimeBeginIndex + 5);
							if (DateTime.TryParse(endString, out DateTime end))
							{
								info.end = end;
								m_workShifts.Add(info);
							}
						}
					}
				}

			}
		}

		public override string ToString()
		{
			string str = string.Empty;
			foreach (WorkingShift shift in m_workShifts)
			{
				str += $"begin:{shift.begin},end:{shift.end}\n";
			}
			return str;
		}

		public void BeginNewShift()
		{
			WorkingShift info = new WorkingShift();
			info.begin = DateTime.Now;
			m_workShifts.Add(info);
		}

		public void EndCurrentShift()
		{
			m_workShifts[m_workShifts.Count - 1].end = DateTime.Now;
		}

		public class WorkingShift
		{
			public DateTime begin;
			public DateTime end;

			public TimeSpan GetSpan()
			{
				return end - begin;
			}

		}
		public List<WorkingShift> Shifts => m_workShifts;
		private List<WorkingShift> m_workShifts = new List<WorkingShift>();
	}
}
