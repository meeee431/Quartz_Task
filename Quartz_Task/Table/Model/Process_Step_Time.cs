using System;
using System.ComponentModel;
 
namespace Quartz_Task.Table.Model
{
	[Serializable]
	public class Process_Step_Time
	{
		/// <summary>
		/// id
		/// </summary>
		[DisplayName("id")]
		public long id { get; set; }

		/// <summary>
		/// Processname
		/// </summary>
		[DisplayName("Processname")]
		public string Processname { get; set; }

		/// <summary>
		/// StepID
		/// </summary>
		[DisplayName("StepID")]
		public string StepID { get; set; }

		/// <summary>
		/// Stepname
		/// </summary>
		[DisplayName("Stepname")]
		public string Stepname { get; set; }

		/// <summary>
		/// DoHour
		/// </summary>
		[DisplayName("DoHour")]
		public int? DoHour { get; set; }

	}
}
