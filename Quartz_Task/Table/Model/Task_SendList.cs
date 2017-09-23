using System;
using System.ComponentModel;
 

namespace Quartz_Task.Table.Model
{
	[Serializable]
	public class Task_SendList
	{
		/// <summary>
		/// id
		/// </summary>
		[DisplayName("id")]
		public long id { get; set; }

		/// <summary>
		/// task
		/// </summary>
		[DisplayName("task")]
		public long? task { get; set; }

		/// <summary>
		/// SendDate
		/// </summary>
		[DisplayName("SendDate")]
		public DateTime? SendDate { get; set; }

        /// <summary>
        /// 0短消息
        ///1邮箱
        /// </summary>
        [DisplayName("0短消息1邮箱")]
		public int? SendType { get; set; }

        /// <summary>
        /// 0-24小时
        ///1-48小时
        ///2-72小时
        /// </summary>
        [DisplayName("0-24小时1-48小时2-72小时")]
		public int? TimeType { get; set; }
        /// <summary>
        /// SrcID
        /// </summary>
        [DisplayName("SrcID")]
        public int? SrcID { get; set; }
    }
}
