using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Quartz_Task.Table.Business
{
	public class Task_Info
	{
        private Quartz_Task.Table.Interface.ITask_Info dataTask_Info;
		public Task_Info()
		{
            this.dataTask_Info = new Quartz_Task.Table.MSSQL.Task_Info();

        }
		/// <summary>
		/// 新增
		/// </summary>
		public long Add(Quartz_Task.Table.Model.Task_Info model)
		{
			return dataTask_Info.Add(model);
		}
		/// <summary>
		/// 更新
		/// </summary>
		public int Update(Quartz_Task.Table.Model.Task_Info model)
		{
			return dataTask_Info.Update(model);
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Quartz_Task.Table.Model.Task_Info> GetAll()
		{
			return dataTask_Info.GetAll();
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int Delete(long id)
		{
			return dataTask_Info.Delete(id);
		}
		/// <summary>
		/// 查询记录条数
		/// </summary>
		public long GetCount()
		{
			return dataTask_Info.GetCount();
		}

        public Quartz_Task.Table.Model.Task_Info GetByTaskID(string szTaskID)
        {
            return dataTask_Info.GetByTaskID(szTaskID);

        }
        public bool ExistCode(long id) 
        {
            return dataTask_Info.ExistCode(id);
        }
        public DataTable GetByID(long id)
        {
            return dataTask_Info.GetByID(id);
        }
    }
}
