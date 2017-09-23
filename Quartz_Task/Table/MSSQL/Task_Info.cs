using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Quartz_Task.Base;
 
namespace Quartz_Task.Table.MSSQL
{
	public class Task_Info : Quartz_Task.Table.Interface.ITask_Info
	{
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Task_Info()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">JGSTEEL.Data.Model.Task_Info实体类</param>
        /// <returns>新增记录的ID</returns>
        public long Add(Quartz_Task.Table.Model.Task_Info model)
        {
            string sql = @"INSERT INTO Task_Info
				(Name,Phone,Mail,Incident,BusinessName,SendNum,MessageBack,Status,TaskID,ReceiveDate) 
				VALUES(@Name,@Phone,@Mail,@Incident,@BusinessName,@SendNum,@MessageBack,@Status,@TaskID,@ReceiveDate);
				SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = new SqlParameter[]{
                model.Name == null ? new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = model.Name },
                model.Phone == null ? new SqlParameter("@Phone", SqlDbType.VarChar, 20) { Value = DBNull.Value } : new SqlParameter("@Phone", SqlDbType.VarChar, 20) { Value = model.Phone },
                model.Mail == null ? new SqlParameter("@Mail", SqlDbType.VarChar, 30) { Value = DBNull.Value } : new SqlParameter("@Mail", SqlDbType.VarChar, 30) { Value = model.Mail },
                model.Incident == null ? new SqlParameter("@Incident", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@Incident", SqlDbType.VarChar, 100) { Value = model.Incident },
                model.BusinessName == null ? new SqlParameter("@BusinessName", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@BusinessName", SqlDbType.VarChar, 100) { Value = model.BusinessName },
                model.SendNum == null ? new SqlParameter("@SendNum", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@SendNum", SqlDbType.Int, -1) { Value = model.SendNum },
                model.MessageBack == null ? new SqlParameter("@MessageBack", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@MessageBack", SqlDbType.VarChar, 50) { Value = model.MessageBack },
                model.Status == null ? new SqlParameter("@Status", SqlDbType.Bit, -1) { Value = DBNull.Value } : new SqlParameter("@Status", SqlDbType.Bit, -1) { Value = model.Status },
                model.TaskID == null ? new SqlParameter("@TaskID", SqlDbType.VarChar, 200) { Value = DBNull.Value } : new SqlParameter("@TaskID", SqlDbType.VarChar, 200) { Value = model.TaskID },
                model.ReceiveDate == null ? new SqlParameter("@ReceiveDate", SqlDbType.DateTime, 8) { Value = DBNull.Value } : new SqlParameter("@ReceiveDate", SqlDbType.DateTime, 8) { Value = model.ReceiveDate }
            };
            long maxID;
            return long.TryParse(dbHelper.ExecuteScalar(sql, parameters), out maxID) ? maxID : -1;
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">JGSTEEL.Data.Model.Task_Info实体类</param>
        public int Update(Quartz_Task.Table.Model.Task_Info model)
        {
            string sql = @"UPDATE Task_Info SET 
				Name=@Name,Phone=@Phone,Mail=@Mail,Incident=@Incident,BusinessName=@BusinessName,SendNum=@SendNum,MessageBack=@MessageBack,Status=@Status,TaskID=@TaskID,ReceiveDate=@ReceiveDate
				WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
                model.Name == null ? new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = model.Name },
                model.Phone == null ? new SqlParameter("@Phone", SqlDbType.VarChar, 20) { Value = DBNull.Value } : new SqlParameter("@Phone", SqlDbType.VarChar, 20) { Value = model.Phone },
                model.Mail == null ? new SqlParameter("@Mail", SqlDbType.VarChar, 30) { Value = DBNull.Value } : new SqlParameter("@Mail", SqlDbType.VarChar, 30) { Value = model.Mail },
                model.Incident == null ? new SqlParameter("@Incident", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@Incident", SqlDbType.VarChar, 100) { Value = model.Incident },
                model.BusinessName == null ? new SqlParameter("@BusinessName", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@BusinessName", SqlDbType.VarChar, 100) { Value = model.BusinessName },
                model.SendNum == null ? new SqlParameter("@SendNum", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@SendNum", SqlDbType.Int, -1) { Value = model.SendNum },
                model.MessageBack == null ? new SqlParameter("@MessageBack", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@MessageBack", SqlDbType.VarChar, 50) { Value = model.MessageBack },
                model.Status == null ? new SqlParameter("@Status", SqlDbType.Bit, -1) { Value = DBNull.Value } : new SqlParameter("@Status", SqlDbType.Bit, -1) { Value = model.Status },
                model.TaskID == null ? new SqlParameter("@TaskID", SqlDbType.VarChar, 200) { Value = DBNull.Value } : new SqlParameter("@TaskID", SqlDbType.VarChar, 200) { Value = model.TaskID },
                model.ReceiveDate == null ? new SqlParameter("@ReceiveDate", SqlDbType.DateTime, 8) { Value = DBNull.Value } : new SqlParameter("@ReceiveDate", SqlDbType.DateTime, 8) { Value = model.ReceiveDate },
                new SqlParameter("@id", SqlDbType.BigInt, -1){ Value = model.id }
            };
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(long id)
        {
            string sql = "DELETE FROM Task_Info WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@id", SqlDbType.BigInt){ Value = id }
            };
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Quartz_Task.Table.Model.Task_Info> DataReaderToList(SqlDataReader dataReader)
        {
            List< Quartz_Task.Table.Model.Task_Info> List = new List<Quartz_Task.Table.Model.Task_Info>();
            Quartz_Task.Table.Model.Task_Info model = null;
            while (dataReader.Read())
            {
                model = new Quartz_Task.Table.Model.Task_Info();
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
                    model.SendNum = dataReader.GetInt32(6);
                if (!dataReader.IsDBNull(7))
                    model.MessageBack = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8))
                    model.Status = dataReader.GetBoolean(8);
                if (!dataReader.IsDBNull(9))
                    model.TaskID = dataReader.GetString(9);
                if (!dataReader.IsDBNull(10))
                    model.ReceiveDate = dataReader.GetDateTime(10);
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Quartz_Task.Table.Model.Task_Info> GetAll()
        {
            string sql = "SELECT * FROM Task_Info";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Quartz_Task.Table.Model.Task_Info> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM Task_Info";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        public Quartz_Task.Table.Model.Task_Info GetByTaskID(string szTaskID) {
            string sql =string.Format( "SELECT * FROM Task_Info where taskid='{0}'",szTaskID);
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Quartz_Task.Table.Model.Task_Info> List = DataReaderToList(dataReader);
            dataReader.Close();
            if (List.Count > 0)
                return List[0];
            else
                return null;
        }
        public bool ExistCode(long id) {
            string sql = string.Format("SELECT * FROM Task_Info t,Task_SendList l where t.id=l.task and  srcid='{0}'", id);
            DataTable oTable = dbHelper.GetDataTable(sql);
            if (oTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public DataTable  GetByID(long id)
        {
            string sql = string.Format("SELECT * FROM Task_Info t,Task_SendList l where t.id=l.task and  task='{0}'", id);
            DataTable oTable = dbHelper.GetDataTable(sql);
            return oTable;
        }
    }
}