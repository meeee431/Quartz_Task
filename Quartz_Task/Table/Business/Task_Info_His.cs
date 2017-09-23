using System;
using System.Collections.Generic;
using System.Text;

namespace Quartz_Task.Table.Business
{
	public class Task_Info_His
	{
		private Quartz_Task.Table.Interface.ITask_Info_His dataTask_Info_His;
		public Task_Info_His()
		{
			this.dataTask_Info_His = new Quartz_Task.Table.MSSQL.Task_Info_His ();
		}
		/// <summary>
		/// 新增
		/// </summary>
		public long Add(Quartz_Task.Table.Model.Task_Info_His model)
		{
			return dataTask_Info_His.Add(model);
		}
		/// <summary>
		/// 更新
		/// </summary>
		public int Update(Quartz_Task.Table.Model.Task_Info_His model)
		{
			return dataTask_Info_His.Update(model);
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Quartz_Task.Table.Model.Task_Info_His> GetAll()
		{
			return dataTask_Info_His.GetAll();
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int Delete(long id)
		{
			return dataTask_Info_His.Delete(id);
		}
		/// <summary>
		/// 查询记录条数
		/// </summary>
		public long GetCount()
		{
			return dataTask_Info_His.GetCount();
		}
	}
}
