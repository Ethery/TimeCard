using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard.Datas
{
	public static class Globals
	{
		public static string MONTHREPORT_FILE_NAME
		{
#if DEBUG
			get { return "MonthReport_Debug.txt"; }
#else
			get { return "MonthReport.txt"; }
#endif //Debug
		}

		public static string PARAMETERS_FILE_NAME
		{
#if DEBUG
			get { return "ParametersInfos_Debug.txt"; }
#else
			get { return "ParametersInfos.txt"; }
#endif //Debug
		}
	}

}
