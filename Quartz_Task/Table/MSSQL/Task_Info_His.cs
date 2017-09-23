using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Quartz_Task.Base;
namespace Quartz_Task.Table.MSSQL
{
	public class Task_Info_His : Quartz_Task.Table.Interface.ITask_Info_His
	{
		private DBHelper dbHelper = new DBHelper();
		/// <summary>
		/// 构造函数
		/// </summary>
		public Task_Info_His()
		{
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="model">Quartz_Task.Table.Model.Task_Info_His实体类</param>
		/// <returns>新增记录的ID</returns>
		public long Add(Quartz_Task.Table.Model.Task_Info_His model)
		{
			string sql = @"INSERT INTO Task_Info_His
				(Name,Phone,Mail,Incident,BusinessName,MessageBack,Status,TaskID,ReceiveDate,SendDate,SendType,TimeType,SrcID) 
				VALUES(@Name,@Phone,@Mail,@Incident,@BusinessName,@MessageBack,@Status,@TaskID,@ReceiveDate,@SendDate,@SendType,@TimeType,@SrcID);
				SELECT SCOPE_IDENTITY();";
			SqlParameter[] parameters = new SqlParameter[]{
				model.Name == null ? new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = model.Name },
				model.Phone == null ? new SqlParameter("@Phone", SqlDbType.VarChar, 20) { Value = DBNull.Value } : new SqlParameter("@Phone", SqlDbType.VarChar, 20) { Value = model.Phone },
				model.Mail == null ? new SqlParameter("@Mail", SqlDbType.VarChar, 30) { Value = DBNull.Value } : new SqlParameter("@Mail", SqlDbType.VarChar, 30) { Value = model.Mail },
				model.Incident == null ? new SqlParameter("@Incident", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@Incident", SqlDbType.VarChar, 100) { Value = model.Incident },
				model.BusinessName == null ? new SqlParameter("@BusinessName", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@BusinessName", SqlDbType.VarChar, 100) { Value = model.BusinessName },
				model.MessageBack == null ? new SqlParameter("@MessageBack", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@MessageBack", SqlDbType.VarChar, 50) { Value = model.MessageBack },
				model.Status == null ? new SqlParameter("@Status", SqlDbType.Bit, -1) { Value = DBNull.Value } : new SqlParameter("@Status", SqlDbType.Bit, -1) { Value = model.Status },
				model.TaskID == null ? new SqlParameter("@TaskID", SqlDbType.VarChar, 200) { Value = DBNull.Value } : new SqlParameter("@TaskID", SqlDbType.VarChar, 200) { Value = model.TaskID },
				model.ReceiveDate == null ? new SqlParameter("@ReceiveDate", SqlDbType.DateTime, 8) { Value = DBNull.Value } : new SqlParameter("@ReceiveDate", SqlDbType.DateTime, 8) { Value = model.ReceiveDate },
				model.SendDate == null ? new SqlParameter("@SendDate", SqlDbType.DateTime, 8) { Value = DBNull.Value } : new SqlParameter("@SendDate", SqlDbType.DateTime, 8) { Value = model.SendDate },
				model.SendType == null ? new SqlParameter("@SendType", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@SendType", SqlDbType.Int, -1) { Value = model.SendType },
				model.TimeType == null ? new SqlParameter("@TimeType", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@TimeType", SqlDbType.Int, -1) { Value = model.TimeType },
				model.SrcID == null ? new SqlParameter("@SrcID", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@SrcID", SqlDbType.Int, -1) { Value = model.SrcID }
			};
			long maxID;
			return long.TryParse(dbHelper.ExecuteScalar(sql, parameters),out maxID) ? maxID : -1;
		}
		/// <summary>
		/// 更新记录
		/// </summary>
		/// <param name="model">Quartz_Task.Table.Model.Task_Info_His实体类</param>
		public int Update(Quartz_Task.Table.Model.Task_Info_His model)
		{
			string sql = @"UPDATE Task_Info_His SET 
				Name=@Name,Phone=@Phone,Mail=@Mail,Incident=@Incident,BusinessName=@BusinessName,MessageBack=@MessageBack,Status=@Status,TaskID=@TaskID,ReceiveDate=@ReceiveDate,SendDate=@SendDate,SendType=@SendType,TimeType=@TimeType,SrcID=@SrcID
				WHERE id=@id";
			SqlParameter[] parameters = new SqlParameter[]{
				model.Name == null ? new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = model.Name },
				model.Phone == null ? new SqlParameter("@Phone", SqlDbType.VarChar, 20) { Value = DBNull.Value } : new SqlParameter("@Phone", SqlDbType.VarChar, 20) { Value = model.Phone },
				model.Mail == null ? new SqlParameter("@Mail", SqlDbType.VarChar, 30) { Value = DBNull.Value } : new SqlParameter("@Mail", SqlDbType.VarChar, 30) { Value = model.Mail },
				model.Incident == null ? new SqlParameter("@Incident", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@Incident", SqlDbType.VarChar, 100) { Value = model.Incident },
				model.BusinessName == null ? new SqlParameter("@BusinessName", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@BusinessName", SqlDbType.VarChar, 100) { Value = model.BusinessName },
				model.MessageBack == null ? new SqlParameter("@MessageBack", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@MessageBack", SqlDbType.VarChar, 50) { Value = model.MessageBack },
				model.Status == null ? new SqlParameter("@Status", SqlDbType.Bit, -1) { Value = DBNull.Value } : new SqlParameter("@Status", SqlDbType.Bit, -1) { Value = model.Status },
				model.TaskID == null ? new SqlParameter("@TaskID", SqlDbType.VarChar, 200) { Value = DBNull.Value } : new SqlParameter("@TaskID", SqlDbType.VarChar, 200) { Value = model.TaskID },
				model.ReceiveDate == null ? new SqlParameter("@ReceiveDate", SqlDbType.DateTime, 8) { Value = DBNull.Value } : new SqlParameter("@ReceiveDate", SqlDbType.DateTime, 8) { Value = model.ReceiveDate },
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
			string sql = "DELETE FROM Task_Info_His WHERE id=@id";
			SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.BigInt){ Value = id }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 将DataRedar转换为List
		/// </summary>
		private List<Quartz_Task.Table.Model.Task_Info_His> DataReaderToList(SqlDataReader dataReader)
		{
			List<Quartz_Task.Table.Model.Task_Info_His> List = new List<Quartz_Task.Table.Model.Task_Info_His>();
			Quartz_Task.Table.Model.Task_Info_His model = null;
			while(dataReader.Read())
			{
				model = new Quartz_Task.Table.Model.Task_Info_His();
				model.id = dataReader.GetInt64(0);
				if (!dataReader.IsDBNull(1))
					model.Name = dataReader.GetString(1);
				if (!dataReader.IsDBNull(2))
					model.Phone = dataReader.GetString(2);
				if (!dataReader.IsDBNull(3))
					model.Mail = dataReader.GetString(3);
				if (!dataReader.IsDBNull(4))
					model.Incident = dataReader.GetString(4);
				if (!dataReader.IsDBNull(5))
					model.BusinessName = dataReader.GetString(5);
				if (!dataReader.IsDBNull(6))
					model.MessageBack = dataReader.GetString(6);
				if (!dataReader.IsDBNull(7))
					model.Status = dataReader.GetBoolean(7);
				if (!dataReader.IsDBNull(8))
					model.TaskID = dataReader.GetString(8);
				if (!dataReader.IsDBNull(9))
					model.ReceiveDate = dataReader.GetDateTime(9);
				if (!dataReader.IsDBNull(10))
					model.SendDate = dataReader.GetDateTime(10);
				if (!dataReader.IsDBNull(11))
					model.SendType = dataReader.GetInt32(11);
				if (!dataReader.IsDBNull(12))
					model.TimeType = dataReader.GetInt32(12);
				if (!dataReader.IsDBNull(13))
					model.SrcID = dataReader.GetInt32(13);
				List.Add(model);
			}
			return List;
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Quartz_Task.Table.Model.Task_Info_His> GetAll()
		{
			string sql = "SELECT * FROM Task_Info_His";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<Quartz_Task.Table.Model.Task_Info_His> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List;
		}
		/// <summary>
		/// 查询记录数
		/// </summary>
		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Task_Info_His";
			long count;
			return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
		}
	}
}