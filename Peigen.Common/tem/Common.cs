using System;
using System.IO;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using CodeSmith.Engine;
using SchemaExplorer;

namespace Sainty
{
    public class Common : CodeTemplate
	{

		#region Common类属性

		const string Enter = "\r\n";
		const string Tab = "\t";

		private TableSchema _sourceTable;

        [Category("02.绑定数据表")]
        [Description("生成代码所设计的数据表集合")]
        public TableSchema SourceTable
        {
            get { return _sourceTable; }
            set { _sourceTable = value; }
        }

        #endregion

		#region SQL Parameter参数

		/// <summary>
        /// 获取参数声明
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public string GetSqlParameterStatement(ColumnSchema column)
        {
            string param = "@" + column.Name + " " + column.NativeType;

            switch (column.DataType)
            {
                case DbType.Decimal:
                    {
                        param += "(" + column.Precision + ", " + column.Scale + ")";
                        break;
                    }
                default:
                    {
                        if (column.Size > 0)
                        {
                            param += "(" + column.Size + ")";
                        }
                        break;
                    }
            }

            return param;
		}

		/// <summary>
		/// 获取参数声明
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetSqlParameterCondition(ColumnSchema column)
		{
			string txtCondition = "";

			switch (column.DataType)
			{
				case DbType.String:
					{
						txtCondition = "if (model." + column.Name + " != null) {";
						break;
					}
				case DbType.DateTime:
					{
						txtCondition = "if (model." + column.Name + " !=  DateTime.MinValue) {";
						break;
					}
				case DbType.Guid:
					{
						//txtCondition = "if (model." + column.Name + ".ToString() != null) {";
						txtCondition = "if (model." + column.Name + " != Guid.Empty) {";
						break;
					}
				default:
					{
						txtCondition = "";
						break;
					}
			}

			return txtCondition;
		}
		/// <summary>
		/// 获取参数声明结束
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetSqlParameterConditionEnd(ColumnSchema column)
		{
			string txtCondition = "";
			switch (column.DataType)
			{
				case DbType.String:
					{
						txtCondition = "}";
						break;
					}
				case DbType.DateTime:
					{
						txtCondition = "}";
						break;
					}
				case DbType.Guid:
					{
						//txtCondition = "}";
						txtCondition = "}";
						break;
					}
				default:
					{
						txtCondition = "";
						break;
					}
			}
			return txtCondition;
		}

		/// <summary>
		/// 添加参数声明
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetAddParametersString(ColumnSchema column)
		{
			DbType dbtype = column.DataType;
			string result = String.Empty;
			switch (dbtype)
			{
				case DbType.Byte:
				case DbType.Currency:
				case DbType.Decimal:
				case DbType.Int16:
				case DbType.Int32:
				case DbType.Int64:
					if (column.AllowDBNull)
					{
						result = "if(" + GetModuleInstanceName(column.Table) + "." + column.Name + ".ToString()!=null&&" + GetModuleInstanceName(column.Table) + "." + column.Name + ">0){db.AddParameter(\"@" + column.Name + "\"," + GetModuleInstanceName(column.Table) + "." + column.Name + ");}";
					}
					else
					{
						result = "db.AddParameter(\"@" + column.Name + "\"," + GetModuleInstanceName(column.Table) + "." + column.Name + ");";
					}
					break;
				case DbType.AnsiStringFixedLength:
				case DbType.AnsiString:
				case DbType.String:
				case DbType.StringFixedLength:
				case DbType.Binary:
					if (column.AllowDBNull)
					{
						result = "if(" + GetModuleInstanceName(column.Table) + "." + column.Name + "!=null&&" + GetModuleInstanceName(column.Table) + "." + column.Name + ".Length>0){db.AddParameter(\"@" + column.Name + "\"," + GetModuleInstanceName(column.Table) + "." + column.Name + "," + column.Size + ");}";
					}
					else
					{
						result = "db.AddParameter(\"@" + column.Name + "\"," + GetModuleInstanceName(column.Table) + "." + column.Name + "," + column.Size + ");";
					}
					break;
				case DbType.Guid:
					if (column.AllowDBNull)
					{
						result = "if(" + GetModuleInstanceName(column.Table) + "." + column.Name + ".ToString()!=null){db.AddParameter(\"@" + column.Name + "\"," + GetModuleInstanceName(column.Table) + "." + column.Name + ");}";
					}
					else
					{
						result = "db.AddParameter(\"@" + column.Name + "\"," + GetModuleInstanceName(column.Table) + "." + column.Name + ");";
					}
					break;
				case DbType.DateTime:
				case DbType.Date:
					if (column.AllowDBNull)
					{
						result = "if(" + GetModuleInstanceName(column.Table) + "." + column.Name + "!=deadDate){db.AddParameter(\"@" + column.Name + "\"," + GetModuleInstanceName(column.Table) + "." + column.Name + ");}";
					}
					else
					{
						result = "db.AddParameter(\"@" + column.Name + "\"," + GetModuleInstanceName(column.Table) + "." + column.Name + ");";
					}
					break;
				default:
					result = "db.AddParameter(\"@" + column.Name + "\"," + GetModuleInstanceName(column.Table) + "." + column.Name + ");";
					break;
			}
			return result;
		}

		#endregion

		#region 获取数据类型
		/// <summary>
        /// 获取变量类型
        /// </summary>
        /// <param name="column"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetCSharpVariableType(ColumnSchema column, string str)
        {
            if (column.Name.EndsWith("TypeCode")) return str;

            switch (column.DataType)
            {
                case DbType.AnsiString: return str + ".ToString()";
                case DbType.AnsiStringFixedLength: return str + ".ToString()";
                case DbType.Binary: return "((" + str + ")==DBNull.Value) ? new byte[0] : (Byte[])(" + str + ")";
                case DbType.Boolean: return "(bool)" + str;
                case DbType.Byte: return "((" + str + ")==DBNull.Value)?Convert.ToByte(0):Convert.ToByte(" + str + ")";
                case DbType.Currency: return "((" + str + ")==DBNull.Value)?0:Convert.ToDecimal(" + str + ")";
                case DbType.Date: return "((" + str + ")==DBNull.Value)?" + DateTime.Now + ":Convert.ToDateTime(" + str + ")";
                case DbType.DateTime: return "((" + str + ")==DBNull.Value)?Convert.ToDateTime(1900-1-1):Convert.ToDateTime(" + str + ")";
                case DbType.Decimal: return "((" + str + ")==DBNull.Value)?0:Convert.ToDecimal(" + str + ")";
                case DbType.Double: return "((" + str + ")==DBNull.Value)?0:Convert.ToDouble(" + str + ")";
                case DbType.Guid: return "(Guid)" + str;
                case DbType.Int16: return "(short)" + str;
                case DbType.Int32: return "((" + str + ")==DBNull.Value)?0:Convert.ToInt32(" + str + ")";
                case DbType.Int64: return "(long)" + str;
                case DbType.Object: return "(object)" + str;
                case DbType.SByte: return "Convert.ToSByte(" + str + ")";
                case DbType.Single: return "(float)" + str;
                case DbType.String: return str + ".ToString()";
                case DbType.StringFixedLength: return str + ".ToString()";
                case DbType.Time: return "(DateTime)" + str;
                case DbType.UInt16: return "(ushort)" + str;
                case DbType.UInt32: return "(uint)" + str;
                case DbType.UInt64: return "(ulong)" + str;
                case DbType.VarNumeric: return "Convert.ToDecimal(" + str + ")";
                default:
                    {
                        return "__UNKNOWN__" + str;
                    }
            }
        }
		/// <summary>
		/// 获取变量类型
		/// </summary>
		/// <param name="column"></param>
		/// <param name="str"></param>
		/// <returns></returns>
		public string GetCSharpVariableType(ColumnSchema column)
		{
			if (column.Name.EndsWith("TypeCode")) return column.Name;
            
            
            switch (column.NativeType)
			{
				case "bigint": return "long";
				case "binary": return  "byte[]";
				case "bit": return "bool";
				case "char": return "char";
				case "datetime": return "DateTime";
				case "decimal": return "decimal";
				case "float": return "float";
				case "image": return "byte[]";
				case "int": return "int";
				case "money": return "double";
				case "nchar": return "char";
				case "ntext": return "string";
				case "numeric": return "decimal";
				case "nvarchar": return "string";
				case "real": return "float";
				case "smalldatetime": return "DateTime";
				case "smallint": return "short";
				case "smallmoney": return "float";
				case "sql_variant": return "string";
				case "sysname": return "char";
				case "text": return "string";		
				case "tinyint": return "short";
				case "uniqueidentifier": return "string";
				case "varbinary": return "byte[]";
				case "varchar": return "string";
				default: return "__UNKNOWN__" + column.NativeType;
			}
            
            
			//switch (column.DataType)
			//{
				//case DbType.AnsiString: return "string";
				//case DbType.AnsiStringFixedLength: return "string";
				//case DbType.Binary: return "byte[]";
				//case DbType.Boolean: return "bool";
				//case DbType.Byte: return "byte";
				//case DbType.Currency: return "decimal";
				//case DbType.Date: return "DateTime";
				//case DbType.DateTime: return "DateTime";
				//case DbType.Decimal: return "decimal";
				//case DbType.Double: return "double";
				//case DbType.Guid: return "Guid";
				//case DbType.Int16: return "short";
				//case DbType.Int32: return "int";
				//case DbType.Int64: return "long";
				//case DbType.Object: return "object";
				//case DbType.SByte: return "sbyte";
				//case DbType.Single: return "float";
				//case DbType.String: return "string";
				//case DbType.StringFixedLength: return "string";
				//case DbType.Time: return "TimeSpan";
				//case DbType.UInt16: return "ushort";
				//case DbType.UInt32: return "uint";
				//case DbType.UInt64: return "ulong";
				//case DbType.VarNumeric: return "decimal";
				//default:
					//{
					//	return "__UNKNOWN__" + column.NativeType;
					//}
			//}
            
		}
		/// <summary>
		/// 获取C#数据类型
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
        public string GetCSharpSqlType(ColumnSchema column)
        {
            if (column.Name.EndsWith("TypeCode")) return "";

            switch (column.DataType)
            {
                case DbType.AnsiString: return ".VarChar";
                case DbType.AnsiStringFixedLength: return ".VarChar";
                case DbType.Binary: return ".Binary";
                case DbType.Boolean: return ".Bit";
                case DbType.Byte: return ".TinyInt";
                case DbType.Currency: return "";
                case DbType.Date: return "";
                case DbType.DateTime: return ".DateTime";
                case DbType.Decimal: return ".Decimal";
                case DbType.Double: return ".Float";
                case DbType.Guid: return ".UniqueIdentifier";
                case DbType.Int16: return ".SmallInt";
                case DbType.Int32: return ".Int";
                case DbType.Int64: return ".BigInt";
                case DbType.Object: return "";
                case DbType.SByte: return "";
                case DbType.Single: return ".Float";
                case DbType.String: return ".VarChar";
                case DbType.StringFixedLength: return ".VarChar";
                case DbType.Time: return ".DateTime";
                case DbType.UInt16: return ".";
                case DbType.UInt32: return "";
                case DbType.UInt64: return "";
                case DbType.VarNumeric: return "";

                default:
                    {
                        return "__UNKNOWN__";
                    }
            }
		}
		/// <summary>
		/// 获取DB数据类型
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetSqlDbType(ColumnSchema column)
		{
			switch (column.NativeType)
			{
				case "bigint": return "BigInt";
				case "binary": return "Binary";
				case "bit": return "Bit";
				case "char": return "Char";
				case "datetime": return "DateTime";
				case "decimal": return "Decimal";
				case "float": return "Float";
				case "image": return "Image";
				case "int": return "Int";
				case "money": return "Money";
				case "nchar": return "NChar";
				case "ntext": return "NText";
				case "numeric": return "Decimal";
				case "nvarchar": return "NVarChar";
				case "real": return "Real";
				case "smalldatetime": return "SmallDateTime";
				case "smallint": return "SmallInt";
				case "smallmoney": return "SmallMoney";
				case "sql_variant": return "Variant";
				case "sysname": return "NChar";
				case "text": return "Text";
				case "timestamp": return "Timestamp";
				case "tinyint": return "TinyInt";
				case "uniqueidentifier": return "UniqueIdentifier";
				case "varbinary": return "VarBinary";
				case "varchar": return "VarChar";
				default: return "__UNKNOWN__" + column.NativeType;
			}
		}


		#endregion

		#region 获取列默认值

		/// <summary>
		/// 获取列默认值
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetMemberVariableDefaultValue(ColumnSchema column)
		{
			string result = column.ExtendedProperties["CS_Default"].Value.ToString();
			string n = string.Empty;
			foreach (char c in result)
			{
				switch (c)
				{
					case '(':
					case ')':
					case '\'':
						break;
					default:
						n = n + c;
						break;
				}

			}
			result = "\"" + n + "\"";
			switch (column.DataType)
			{
				case DbType.Guid:
					{
						return "Guid.Empty";
					}
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
					{
						return result;
					}
				case DbType.Int16:
				case DbType.Int32:
				case DbType.Int64:
				case DbType.Single:
					{
						return "0";
					}
				case DbType.DateTime:
					{
						return result;//"DateTime.Parse(" +  result + ")"
					}
				case DbType.Date:
					{
						return result;
					}
				case DbType.Boolean:
					{
						return "false";
					}
				default:
					{
						return "";
					}
			}
		}
		/// <summary>
		/// 获取列默认值
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetDefaultValue(ColumnSchema column)
		{
			string result = column.ExtendedProperties["CS_Default"].Value.ToString();
			string n = string.Empty;
			foreach (char c in result)
			{
				switch (c)
				{
					case '(':
					case ')':
					case '\'':
						break;
					default:
						n = n + c;
						break;
				}

			}
			result = "\"" + n + "\"";
			return n;
		}

		#endregion

		#region 列操作

		/// <summary>
		/// 是否空值
		/// </summary>
		/// <param name="V"></param>
		/// <returns></returns>
		public bool IsNullValue(object V)
		{
			TypeCode tCode = Type.GetTypeCode(V.GetType());
			switch (tCode)
			{
				case TypeCode.Object:
					if (V == null) return true;
					break;
				case TypeCode.String:
					if (V == String.Empty) return true;
					break;
				case TypeCode.Empty:
					return true;
					break;
			}
			return false;
		}
		/// <summary>
		/// 是否默认值
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public bool IsDefaultValue(ColumnSchema column)
		{
			return GetMemberVariableDefaultValue(column) != "";
		}

		/// <summary>
		/// 获取字段读取方法
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetReaderMethod(ColumnSchema column)
		{
			switch (column.DataType)
			{
				case DbType.Byte:
					{
						return "GetByte";
					}
				case DbType.Int16:
					{
						return "GetInt16";
					}
				case DbType.Int32:
					{
						return "GetInt";
					}
				case DbType.Int64:
					{
						return "GetLong";
					}
				case DbType.AnsiStringFixedLength:
				case DbType.AnsiString:
				case DbType.String:
				case DbType.StringFixedLength:
					{
						return "GetString";
					}
				case DbType.Boolean:
					{
						return "GetBool";
					}
				case DbType.Guid:
					{
						return "GetGuid";
					}
				case DbType.Currency:
				case DbType.Decimal:
					{
						return "GetDecimal";
					}
				case DbType.DateTime:
				case DbType.Date:
					{
						return "GetDateTime";
					}
				default:
					{
						return "__SQL__" + column.DataType;
					}
			}
		}

		/// <summary>
		/// 获取列位置
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public int GetColumnPosition(string name)
		{
			int i = 0;
			foreach (ColumnSchema column in SourceTable.Columns)
			{
				if (column.Name == name)
				{
					return i;
				}
				i++;
			}
			return i;
		}

		/// <summary>
		/// 获取字段读取声明
		/// </summary>
		/// <param name="column"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public string GetReaderAssignmentStatement(ColumnSchema column, int index)
		{
			string statement = "if (!reader.IsDBNull(" + index.ToString() + ")) ";
			statement += GetMemberVariableName(column) + " = ";

			if (column.Name.EndsWith("TypeCode")) statement += "(" + column.Name + ")";

			statement += "reader." + GetReaderMethod(column) + "(" + index.ToString() + ");";

			return statement;
		}

		/// <summary>
		/// 获取应该插入值的列
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public List<ColumnSchema> GetInsertColumn(TableSchema table)
		{
			List<ColumnSchema> list = new List<ColumnSchema>();
			foreach (ColumnSchema column in table.Columns)
			{
				if ((!(bool)column.ExtendedProperties["CS_IsIdentity"].Value) && !((column.IsPrimaryKeyMember) && (GetDefaultValue(column) != "")))
				{
					list.Add(column);
				}
			}
			return list;
		}


		#endregion

		#region 主键操作

		/// <summary>
		/// 获取主键表达式
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public string GetPrimaryKeyVariableExpression(TableSchema table)
		{
			return GetCSharpVariableType(table.PrimaryKey.MemberColumns[0]) + " " + GetCamelCaseName(table.PrimaryKey.MemberColumns[0].Name);
		}
		/// <summary>
		/// 获取主键类型(单一主键)
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public string GetPrimaryKeyType(TableSchema table)
		{
			if (table.PrimaryKey.MemberColumns.Count == 1)
			{
				return GetCSharpVariableType(table.PrimaryKey.MemberColumns[0]);
			}
			else
			{
				throw new ApplicationException("本模板目前仅支持单一主键表.");
			}
		}

		#endregion

		#region 外键操作

		/// <summary>
		/// 获取外键类名
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetFKClassName(ColumnSchema column)
		{
			foreach (TableKeySchema key in this.SourceTable.ForeignKeys)
			{
				foreach (MemberColumnSchema fk in key.ForeignKeyMemberColumns)
				{
					if (fk.Name == column.Name)
					{
						return this.GetClassName(key.PrimaryKeyTable);
					}
				}
			}
			return "";
		}

		#endregion

		#region 成员变量

		/// <summary>
		/// 获取成员变量名称
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetMemberVariableName(ColumnSchema column)
		{
			string propertyName = GetPropertyName(column);
			string memberVariableName = GetCamelCaseName(propertyName);

			return memberVariableName;
		}

		/// <summary>
		/// 获取成员变量声明(private)
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetMemberVariableDeclarationStatement(ColumnSchema column)
		{
			return GetMemberVariableDeclarationStatement("private", column);
		}

		/// <summary>
		/// 获取成员变量声明
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetMemberVariableDeclarationStatement(string protectionLevel, ColumnSchema column)
		{
			string statement = protectionLevel + " ";
			statement += GetCSharpVariableType(column) + " " + GetMemberVariableName(column);

			string defaultValue = GetDefaultValue(column);
			if (defaultValue != "" && (GetCSharpVariableType(column)=="long" || GetCSharpVariableType(column)=="short" || GetCSharpVariableType(column)=="int"))
			{
				statement += " = " + defaultValue;
			}            
            if(defaultValue != "" && GetCSharpVariableType(column)=="string")            
            {
                statement += " = \"" + defaultValue + "\"";
            }
            if(defaultValue == "" && GetCSharpVariableType(column)=="string")            
            {
                statement += " = string.Empty";
            }

			statement += ";";

			return statement;
		}
		/// <summary>
		/// 获取成员变量可空声明
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetAllowNull(ColumnSchema column){
			string allowNull = "";
			if ((column.DataType ==DbType.Int32) || (column.DataType ==DbType.DateTime) ||  (column.DataType ==DbType.Byte))
			{
				allowNull = (column.AllowDBNull ) ? "?" : "" ;
			}
			return allowNull;
		}

		#endregion

		#region 属性操作

		/// <summary>
		/// 获取属性名称
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public string GetPropertyName(ColumnSchema column)
		{
			string propertyName = ConvertFirstCharToUpper(column.Name);

			if (propertyName == column.Table.Name + "Name") return "Name";
			if (propertyName == column.Table.Name + "Description") return "Description";

			if (propertyName.EndsWith("TypeCode")) propertyName = propertyName.Substring(0, propertyName.Length - 4);

			return propertyName;
		}

		/// <summary>
		/// 获取属性长度
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public int GetPropertyNameLength(ColumnSchema column)
		{
			return (GetPropertyName(column)).Length;
		}
		/// <summary>
		/// 获取属性最大长度
		/// </summary>
		/// <returns></returns>
		public int GetPropertyNameMaxLength()
		{
			int ret = 0;
			foreach (ColumnSchema column in SourceTable.Columns)
			{
				ret = ret < GetPropertyNameLength(column) ? GetPropertyNameLength(column) : ret;
			}
			return ret;
		}        

		#endregion

		#region 语句构造

		/// <summary>
		/// 获取入口构造参数
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public string GetPopulationConstructorParams(SchemaExplorer.TableSchema table)
		{
			System.Text.StringBuilder sb = new StringBuilder();
			foreach (ColumnSchema column in table.Columns)
			{
				if (sb.Length != 0)
					sb.Append(", ");

				sb.Append(GetCSharpVariableType(column));
				sb.Append(" ");
				sb.Append(GetCamelCaseName(column.Name));
			}
			return sb.ToString();
		}


		public string GetPrimaryKeyCSharpType()
		{
			return GetCSharpVariableType(SourceTable.PrimaryKey.MemberColumns[0]);
		}
		/// <summary>
		/// 获取构造参数
		/// </summary>
		/// <returns></returns>
		public string GetConstructorParameters()
		{
			string ret = "";
			foreach (ColumnSchema column in SourceTable.Columns)
			{
				ret += GetCSharpVariableType(column) + " " + GetCamelCaseName(GetPropertyName(column)) + ",\n\t\t\t";
			}
			return ret.Substring(0, ret.Length - 5);
		}

		/// <summary>
		/// 获取赋值方法
		/// </summary>
		/// <returns></returns>
		public string GetAssignValue()
		{
			string ret = "";
			foreach (ColumnSchema column in SourceTable.Columns)
			{
				ret += "this." + GetMemberVariableName(column) + (new String(' ', GetPropertyNameMaxLength() - GetPropertyNameLength(column))) + " = " + GetCamelCaseName(GetPropertyName(column)) + ";\n\t\t\t";
			}
			return ret;
		}

		#endregion

		#region 取名命名

		/// <summary>
		/// 获取类名
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public string GetClassName(TableSchema table)
		{
			/*
			if (table.Name.EndsWith("s"))
			{
				return table.Name.Substring(0, table.Name.Length - 1);
			}
			else
			{
				return table.Name;
			}
			*/
			if (table == null)
			{
				return null;
			}
			return table.Name;
		}

		/// <summary>
		/// 获取默认类名
		/// </summary>
		/// <returns></returns>
		public string GetClassName()
		{
			string s = this.SourceTable.Name;
			if (s.EndsWith("s"))
			{
				s = s.Substring(0, s.Length - 1);
			}
			return this.ConvertFirstCharToUpper(s);
		}
		/// <summary>
		/// 获取对象名
		/// </summary>
		/// <returns></returns>
		public string GetObjectName()
		{
			return this.GetCamelCaseName(this.GetClassName());
		}

		/// <summary>
		/// 获取文件名
		/// </summary>
		/// <returns></returns>
		public override string GetFileName()
		{
			return this.GetClassName(this.SourceTable) + ".cs";
		}

		/// <summary>
		/// 骆驼命名法
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string GetCamelCaseName(string value)
		{
			return value.Substring(0, 1).ToLower() + value.Substring(1);
		}
		/// <summary>
		/// Pascal命名法
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string ConvertFirstCharToUpper(string value)
		{
			return value.Substring(0, 1).ToUpper() + value.Substring(1);
		}
		/// <summary>
		/// 大写命名法
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string GetLowerCaseName(string value)
		{
			return value.ToLower();
		}

		/// <summary>
		/// 获取集合类名
		/// </summary>
		/// <returns></returns>
		public string GetCollectionClassName()
		{
			return GetClassName(SourceTable) + "Collection";
		}
		/// <summary>
		/// 获取实体名
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public string GetModuleInstanceName(TableSchema table)
		{
			return "_" + table.Name + "Model";
		}

		#endregion

	}
}
