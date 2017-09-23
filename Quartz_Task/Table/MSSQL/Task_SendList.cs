using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Quartz_Task.Base;
namespace Quartz_Task.Table.MSSQL
{
	public class Task_SendList : Quartz_Task.Table.Interface.ITask_SendList
	{
		private DBHelper dbHelper = new DBHelper();
		/// <summary>
		/// 构造函数
		/// </summary>
		public Task_SendList()
		{
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="model">Quartz_Task.Table.Model.Task_SendList实体类</param>
		/// <returns>操作所影响的行数</returns>
		public long Add(Quartz_Task.Table.Model.Task_SendList model)
		{
            string sql = @"INSERT INTO Task_SendList
				(task,SendDate,SendType,TimeType,SrcID) 
				VALUES(@task,@SendDate,@SendType,@TimeType,@SrcID);
				SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = new SqlParameter[]{
                model.task == null ? new SqlParameter("@task", SqlDbType.BigInt, -1) { Value = DBNull.Value } : new SqlParameter("@task", SqlDbType.BigInt, -1) { Value = model.task },
                model.SendDate == null ? new SqlParameter("@SendDate", SqlDbType.DateTime, 8) { Value = DBNull.Value } : new SqlParameter("@SendDate", SqlDbType.DateTime, 8) { Value = model.SendDate },
                model.SendType == null ? new SqlParameter("@SendType", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@SendType", SqlDbType.Int, -1) { Value = model.SendType },
                model.TimeType == null ? new SqlParameter("@TimeType", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@TimeType", SqlDbType.Int, -1) { Value = model.TimeType },
                model.SrcID == null ? new SqlParameter("@SrcID", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@SrcID", SqlDbType.Int, -1) { Value = model.SrcID }
            };
            long maxID;
            return long.TryParse(dbHelper.ExecuteScalar(sql, parameters), out maxID) ? maxID : -1;
        }
		/// <summary>
		/// 更新记录
		/// </summary>
		/// <param name="model">Quartz_Task.Table.Model.Task_SendList实体类</param>
		public int Update(Quartz_Task.Table.Model.Task_SendList model)
		{
            string sql = @"UPDATE Task_SendList SET 
				task=@task,SendDate=@SendDate,SendType=@SendType,TimeType=@TimeType,SrcID=@SrcID
				WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
                model.task == null ? new SqlParameter("@task", SqlDbType.BigInt, -1) { Value = DBNull.Value } : new SqlParameter("@task", SqlDbType.BigInt, -1) { Value = model.task },
                model.SendDate == null ? new SqlParameter("@SendDate", SqlDbType.DateTime, 8) { Value = DBNull.Value } : new SqlParameter("@SendDate", SqlDbType.DateTime, 8) { Value = model.SendDate },
                model.SendType == null ? new SqlParameter("@SendType", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@SendType", SqlDbType.Int, -1) { Value = model.SendType },
                model.TimeType == null ? new SqlParameter("@TimeType", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@TimeType", SqlDbType.Int, -1) { Value = model.TimeType },
                model.SrcID == null ? new SqlParameter("@SrcID", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@SrcID", SqlDbType.Int, -1) { Value = model.SrcID },
                new SqlParameter("@id", SqlDbType.BigInt, -1){ Value = model.id }
            };
            return dbHelper.Execute(sql, parameters);
        }
		/// <summary>
		/// 删除记录
		/// </summary>
		public int Delete(long id)
		{
			string sql = "DELETE FROM Task_SendList WHERE id=@id";
			SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.BigInt){ Value = id }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 将DataRedar转换为List
		/// </summary>
		private List<Quartz_Task.Table.Model.Task_SendList> DataReaderToList(SqlDataReader dataReader)
		{
            List<Quartz_Task.Table.Model.Task_SendList> List = new List<Quartz_Task.Table.Model.Task_SendList>();
            Quartz_Task.Table.Model.Task_SendList model = null;
            while (dataReader.Read())
            {
                model = new Quartz_Task.Table.Model.Task_SendList();
                model.id = dataReader.GetInt64(0);
                if (!dataReader.IsDBNull(1))
                    model.task = dataReader.GetInt64(1);
                if (!dataReader.IsDBNull(2))
                    model.SendDate = dataReader.GetDateTime(2);
                if (!dataReader.IsDBNull(3))
                    model.SendType = dataReader.GetInt32(3);
                if (!dataReader.IsDBNull(4))
                    model.TimeType = dataReader.GetInt32(4);
                if (!dataReader.IsDBNull(5))
                    model.SrcID = dataReader.GetInt32(5);
                List.Add(model);
            }
            return List;
        }
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Quartz_Task.Table.Model.Task_SendList> GetAll()
		{
			string sql = "SELECT * FROM Task_SendList";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<Quartz_Task.Table.Model.Task_SendList> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List;
		}
		/// <summary>
		/// 查询记录数
		/// </summary>
		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Task_SendList";
			long count;
			return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
		}
        public List<Quartz_Task.Table.Model.Task_SendList> GetAll(long mainid)
        {
            string sql =string.Format( "SELECT * FROM Task_SendList where task='{0}'", mainid);

            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Quartz_Task.Table.Model.Task_SendList> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }

        public int DeleteByTask(long id)
        {
            string sql = "DELETE FROM Task_SendList WHERE task=@id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@id", SqlDbType.BigInt){ Value = id }
            };
            return dbHelper.Execute(sql, parameters);
        }
    }
}