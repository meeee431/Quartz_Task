using System;
using System.ComponentModel;
 

namespace Quartz_Task.Table.Model
{
	[Serializable]
	public class Task_Info_His
	{
		/// <summary>
		/// id
		/// </summary>
		[DisplayName("id")]
		public long id { get; set; }

		/// <summary>
		/// Name
		/// </summary>
		[DisplayName("Name")]
		public string Name { get; set; }

		/// <summary>
		/// Phone
		/// </summary>
		[DisplayName("Phone")]
		public string Phone { get; set; }

		/// <summary>
		/// Mail
		/// </summary>
		[DisplayName("Mail")]
		public string Mail { get; set; }

		/// <summary>
		/// Incident
		/// </summary>
		[DisplayName("Incident")]
		public string Incident { get; set; }

		/// <summary>
		/// BusinessName
		/// </summary>
		[DisplayName("BusinessName")]
		public string BusinessName { get; set; }

		/// <summary>
		/// MessageBack
		/// </summary>
		[DisplayName("MessageBack")]
		public string MessageBack { get; set; }

		/// <summary>
		/// Status
		/// </summary>
		[DisplayName("Status")]
		public bool? Status { get; set; }

		/// <summary>
		/// TaskID
		/// </summary>
		[DisplayName("TaskID")]
		public string TaskID { get; set; }

		/// <summary>
		/// ReceiveDate
		/// </summary>
		[DisplayName("ReceiveDate")]
		public DateTime? ReceiveDate { get; set; }

		/// <summary>
		/// SendDate
		/// </summary>
		[DisplayName("SendDate")]
		public DateTime? SendDate { get; set; }

		/// <summary>
		/// SendType
		/// </summary>
		[DisplayName("SendType")]
		public int? SendType { get; set; }

		/// <summary>
		/// TimeType
		/// </summary>
		[DisplayName("TimeType")]
		public int? TimeType { get; set; }

		/// <summary>
		/// SrcID
		/// </summary>
		[DisplayName("SrcID")]
		public int? SrcID { get; set; }

	}
}
