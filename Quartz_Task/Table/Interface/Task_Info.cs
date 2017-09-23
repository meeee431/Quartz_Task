using System;
using System.Collections.Generic;
using System.Data;
namespace Quartz_Task.Table.Interface
{
	public interface ITask_Info
	{
		/// <summary>
		/// 新增
		/// </summary>
		long Add(Quartz_Task.Table.Model.Task_Info model);

		/// <summary>
		/// 更新
		/// </summary>
		int Update(Quartz_Task.Table.Model.Task_Info model);

		/// <summary>
		/// 查询所有记录
		/// </summary>
		List<Quartz_Task.Table.Model.Task_Info> GetAll();

		/// <summary>
		/// 删除
		/// </summary>
		int Delete(long id);

		/// <summary>
		/// 查询记录条数
		/// </summary>
		long GetCount();


        Quartz_Task.Table.Model.Task_Info GetByTaskID(string szTaskID);

        bool ExistCode(long id);
        DataTable GetByID(long id);
    }
}
