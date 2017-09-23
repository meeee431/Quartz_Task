using System;
using System.Collections.Generic;

namespace Quartz_Task.Table.Interface
{
	public interface ITask_SendList
	{
		/// <summary>
		/// 新增
		/// </summary>
		long Add(Quartz_Task.Table.Model.Task_SendList model);

		/// <summary>
		/// 更新
		/// </summary>
		int Update(Quartz_Task.Table.Model.Task_SendList model);

		/// <summary>
		/// 查询所有记录
		/// </summary>
		List<Quartz_Task.Table.Model.Task_SendList> GetAll();

		/// <summary>
		/// 删除
		/// </summary>
		int Delete(long id);

		/// <summary>
		/// 查询记录条数
		/// </summary>
		long GetCount();
        List<Quartz_Task.Table.Model.Task_SendList> GetAll(long mainid);

        int DeleteByTask(long id);
    }
}
