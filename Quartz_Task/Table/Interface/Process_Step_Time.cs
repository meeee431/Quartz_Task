using System;
using System.Collections.Generic;

namespace Quartz_Task.Table.Interface
{
	public interface IProcess_Step_Time
	{
		/// <summary>
		/// 新增
		/// </summary>
		long Add(Quartz_Task.Table.Model.Process_Step_Time model);

		/// <summary>
		/// 更新
		/// </summary>
		int Update(Quartz_Task.Table.Model.Process_Step_Time model);

		/// <summary>
		/// 查询所有记录
		/// </summary>
		List<Quartz_Task.Table.Model.Process_Step_Time> GetAll(string process, string step);
        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.Process_Step_Time Get(long id);
        /// <summary>
        /// 删除
        /// </summary>
        int Delete(long id);

		/// <summary>
		/// 查询记录条数
		/// </summary>
		long GetCount();
	}
}
