using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeCard.Datas
{
	public class DayTimeCard
	{
		public DayTimeCard(string reportLoaded)
		{
			if (!string.IsNullOrEmpty(reportLoaded))
			{
				List<string> shiftsLines = reportLoaded.Split('\n').ToList();

				foreach (string shiftLine in shiftsLines)
				{
					WorkingShift info = new WorkingShift();
					if (DateTime.TryParse(shiftLine.Substring(6, shiftLine.IndexOf(',')), out DateTime begin))
					{
						info.begin = begin;
					}

					m_workShifts.Add(info);
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

		private class WorkingShift
		{
			public DateTime begin;
			public DateTime end;
		}

		private List<WorkingShift> m_workShifts = new List<WorkingShift>();
	}
}
