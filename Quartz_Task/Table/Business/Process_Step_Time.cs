using System;
using System.Collections.Generic;
using System.Text;

namespace Quartz_Task.Table.Business
{
	public class Process_Step_Time
	{
		private Quartz_Task.Table.Interface.IProcess_Step_Time dataProcess_Step_Time;
		public Process_Step_Time()
		{
			this.dataProcess_Step_Time = new Quartz_Task.Table.MSSQL.Process_Step_Time();
		}
		/// <summary>
		/// 新增
		/// </summary>
		public long Add(Quartz_Task.Table.Model.Process_Step_Time model)
		{
			return dataProcess_Step_Time.Add(model);
		}
		/// <summary>
		/// 更新
		/// </summary>
		public int Update(Quartz_Task.Table.Model.Process_Step_Time model)
		{
			return dataProcess_Step_Time.Update(model);
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Quartz_Task.Table.Model.Process_Step_Time> GetAll(string process,string step)
		{
			return dataProcess_Step_Time.GetAll(  process,   step);
		}
        /// <summary>
        /// 查询单条记录
        /// </summary>
        public Quartz_Task.Table.Model.Process_Step_Time Get(long id)
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
