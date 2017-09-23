using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Quartz_Task.Base;
namespace JGSTEEL.Data.MSSQL
{
	public class Process_Step_Time : JGSTEEL.Data.Interface.IProcess_Step_Time
	{
		private DBHelper dbHelper = new DBHelper();
		/// <summary>
		/// 构造函数
		/// </summary>
		public Process_Step_Time()
		{
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="model">JGSTEEL.Data.Model.Process_Step_Time实体类</param>
		/// <returns>新增记录的ID</returns>
		public long Add(JGSTEEL.Data.Model.Process_Step_Time model)
		{
			string sql = @"INSERT INTO Process_Step_Time
				(Processname,StepID,Stepname,DoHour) 
				VALUES(@Processname,@StepID,@Stepname,@DoHour);
				SELECT SCOPE_IDENTITY();";
			SqlParameter[] parameters = new SqlParameter[]{
				model.Processname == null ? new SqlParameter("@Processname", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@Processname", SqlDbType.VarChar, 100) { Value = model.Processname },
				model.StepID == null ? new SqlParameter("@StepID", SqlDbType.VarChar, 200) { Value = DBNull.Value } : new SqlParameter("@StepID", SqlDbType.VarChar, 200) { Value = model.StepID },
				model.Stepname == null ? new SqlParameter("@Stepname", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@Stepname", SqlDbType.VarChar, 100) { Value = model.Stepname },
				model.DoHour == null ? new SqlParameter("@DoHour", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@DoHour", SqlDbType.Int, -1) { Value = model.DoHour }
			};
			long maxID;
			return long.TryParse(dbHelper.ExecuteScalar(sql, parameters),out maxID) ? maxID : -1;
		}
		/// <summary>
		/// 更新记录
		/// </summary>
		/// <param name="model">JGSTEEL.Data.Model.Process_Step_Time实体类</param>
		public int Update(JGSTEEL.Data.Model.Process_Step_Time model)
		{
			string sql = @"UPDATE Process_Step_Time SET 
				Processname=@Processname,StepID=@StepID,Stepname=@Stepname,DoHour=@DoHour
				WHERE id=@id";
			SqlParameter[] parameters = new SqlParameter[]{
				model.Processname == null ? new SqlParameter("@Processname", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@Processname", SqlDbType.VarChar, 100) { Value = model.Processname },
				model.StepID == null ? new SqlParameter("@StepID", SqlDbType.VarChar, 200) { Value = DBNull.Value } : new SqlParameter("@StepID", SqlDbType.VarChar, 200) { Value = model.StepID },
				model.Stepname == null ? new SqlParameter("@Stepname", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@Stepname", SqlDbType.VarChar, 100) { Value = model.Stepname },
				model.DoHour == null ? new SqlParameter("@DoHour", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@DoHour", SqlDbType.Int, -1) { Value = model.DoHour },
				new SqlParameter("@id", SqlDbType.BigInt, -1){ Value = model.id }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		public int Delete(long id)
		{
			string sql = "DELETE FROM Process_Step_Time WHERE id=@id";
			SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.BigInt){ Value = id }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 将DataRedar转换为List
		/// </summary>
		private List<JGSTEEL.Data.Model.Process_Step_Time> DataReaderToList(SqlDataReader dataReader)
		{
			List<JGSTEEL.Data.Model.Process_Step_Time> List = new List<JGSTEEL.Data.Model.Process_Step_Time>();
			JGSTEEL.Data.Model.Process_Step_Time model = null;
			while(dataReader.Read())
			{
				model = new JGSTEEL.Data.Model.Process_Step_Time();
				model.id = dataReader.GetInt64(0);
				if (!dataReader.IsDBNull(1))
					model.Processname = dataReader.GetString(1);
				if (!dataReader.IsDBNull(2))
					model.StepID = dataReader.GetString(2);
				if (!dataReader.IsDBNull(3))
					model.Stepname = dataReader.GetString(3);
				if (!dataReader.IsDBNull(4))
					model.DoHour = dataReader.GetInt32(4);
				List.Add(model);
			}
			return List;
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<JGSTEEL.Data.Model.Process_Step_Time> GetAll(string process, string step)
		{
			string sql = "SELECT * FROM Process_Step_Time where 1=1 ";
            if(!string.IsNullOrEmpty(process) && process.Trim()!="")
                sql+= " and Processname='"+ process + "'";
            if (!string.IsNullOrEmpty(step) &&step.Trim() != "")
                sql += " and Stepname='" + step + "'";

            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<JGSTEEL.Data.Model.Process_Step_Time> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List;
		}
		/// <summary>
		/// 查询记录数
		/// </summary>
		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Process_Step_Time";
			long count;
			return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
		}
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public JGSTEEL.Data.Model.Process_Step_Time Get(long id)
        {
            string sql = "SELECT * FROM Process_Step_Time WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@id", SqlDbType.BigInt){ Value = id }
            };
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<JGSTEEL.Data.Model.Process_Step_Time> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }
    }
}