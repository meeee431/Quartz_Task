using System;
using System.Collections.Generic;
using System.Text;

namespace JGSTEEL.Business.Applications
{
	public class Process_Step_Time
	{
		private JGSTEEL.Data.Interface.IProcess_Step_Time dataProcess_Step_Time;
		public Process_Step_Time()
		{
			this.dataProcess_Step_Time = new JGSTEEL.Data.MSSQL.Process_Step_Time();
		}
		/// <summary>
		/// 新增
		/// </summary>
		public long Add(JGSTEEL.Data.Model.Process_Step_Time model)
		{
			return dataProcess_Step_Time.Add(model);
		}
		/// <summary>
		/// 更新
		/// </summary>
		public int Update(JGSTEEL.Data.Model.Process_Step_Time model)
		{
			return dataProcess_Step_Time.Update(model);
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<JGSTEEL.Data.Model.Process_Step_Time> GetAll(string process,string step)
		{
			return dataProcess_Step_Time.GetAll(  process,   step);
		}
        /// <summary>
        /// 查询单条记录
        /// </summary>
        public JGSTEEL.Data.Model.Process_Step_Time Get(long id)
        {
            return dataProcess_Step_Time.Get(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public int Delete(long id)
		{
			return dataProcess_Step_Time.Delete(id);
		}
		/// <summary>
		/// 查询记录条数
		/// </summary>
		public long GetCount()
		{
			return dataProcess_Step_Time.GetCount();
		}
	}
}
