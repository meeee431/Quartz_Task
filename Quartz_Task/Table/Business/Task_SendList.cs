using System;
using System.Collections.Generic;
using System.Text;

namespace Quartz_Task.Table.Business
{
	public class Task_SendList
	{
		private Quartz_Task.Table.Interface.ITask_SendList dataTask_SendList;
		public Task_SendList()
		{
			this.dataTask_SendList = new Quartz_Task.Table.MSSQL.Task_SendList();
        }
		/// <summary>
		/// 新增
		/// </summary>
		public long Add(Quartz_Task.Table.Model.Task_SendList model)
		{
			return dataTask_SendList.Add(model);
		}
		/// <summary>
		/// 更新
		/// </summary>
		public int Update(Quartz_Task.Table.Model.Task_SendList model)
		{
			return dataTask_SendList.Update(model);
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Quartz_Task.Table.Model.Task_SendList> GetAll()
		{
			return dataTask_SendList.GetAll();
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int Delete(long id)
		{
			return dataTask_SendList.Delete(id);
		}
		/// <summary>
		/// 查询记录条数
		/// </summary>
		public long GetCount()
		{
			return dataTask_SendList.GetCount();
		}
        public List<Quartz_Task.Table.Model.Task_SendList> GetAll(long mainid)
        {
            return dataTask_SendList.GetAll(mainid);
        }
        public int DeleteByTask(long id)
        {
            return dataTask_SendList.DeleteByTask(id);
        }
    }
}
