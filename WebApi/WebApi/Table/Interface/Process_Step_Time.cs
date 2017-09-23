using System;
using System.Collections.Generic;

namespace JGSTEEL.Data.Interface
{
	public interface IProcess_Step_Time
	{
		/// <summary>
		/// 新增
		/// </summary>
		long Add(JGSTEEL.Data.Model.Process_Step_Time model);

		/// <summary>
		/// 更新
		/// </summary>
		int Update(JGSTEEL.Data.Model.Process_Step_Time model);

		/// <summary>
		/// 查询所有记录
		/// </summary>
		List<JGSTEEL.Data.Model.Process_Step_Time> GetAll(string process, string step);
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
