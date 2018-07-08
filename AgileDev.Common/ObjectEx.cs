using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using LinqKit;

namespace AgileDev.Common
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ObjectEx
    {
        #region 表达式树扩展

        /// <summary>
        /// 合并表达式 expr1 AND expr2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return PredicateBuilder.And(expr1, expr2);

        }
        /// <summary>
        /// 合并表达式 expr1 Or expr2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return PredicateBuilder.Or(expr1, expr2);
        }


        #endregion

        #region JSON扩展

        public static object ToJson(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json);
        }
        public static string ToJson(this object obj, string format = "yyyy-MM-dd HH:mm:ss")
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }
        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
        }
        public static DataTable ToTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
        }
        public static JObject ToJObject(this string Json)
        {
            return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
        }

        #endregion

        public static int ConvertToIntBaseZero(this object o)
        {
            int intRtn = 0;

            if (o != null)
            {
                int.TryParse(o.ToString(), out intRtn);
            }

            return intRtn;
        }

        public static int ConvertToIntBaseNegativeOne(this object o)
        {
            int intRtn = -1;

            if (o != null && o.ToString() != string.Empty)
            {
                int.TryParse(o.ToString(), out intRtn);
            }

            return intRtn;
        }
        public static decimal ConvertToDecimalBaseMinValue(this object o)
        {
            decimal decRtn = decimal.MinValue;

            if (o == null || o == DBNull.Value)
            {
                decRtn = decimal.MinValue;
            }
            else
            {
                if (!decimal.TryParse(o.ToString(), out decRtn))
                {
                    decRtn = decimal.MinValue;
                }
            }

            return decRtn;
        }

        public static bool ConvertToBool(this object o)
        {
            bool bolRtn = false;

            try
            {
                if (o != null && o != DBNull.Value)
                {
                    string str = o.ToString().ToLower();

                    string[] trueStrings = new string[] { "true", "yes", "1", "√", "Y", "T", "是", "对" };

                    if (trueStrings.Contains(str))
                    {

                        bolRtn = true;
                    }
                }
            }
            catch
            {

            }

            return bolRtn;
        }

        public static string ConvertToString(this object o, string replaceString)
        {
            string strRtn = "";

            if (o == null || o == DBNull.Value)
            {
                strRtn = replaceString;
            }
            else
            {
                strRtn = o.ToString();
            }

            return strRtn;
        }

        public static decimal ConvertToDecimal(this object o)
        {
            decimal decRtn = 0m;

            if (o == null || o == DBNull.Value)
            {
                decRtn = 0m;
            }
            else
            {
                decimal.TryParse(o.ToString(), out decRtn);
            }

            return decRtn;
        }

        public static string ConvertToString(this object o)
        {
            return ConvertToString(o, string.Empty);
        }

        public static DateTime ConvertToDateTime(this object o)
        {
            DateTime dtRtn = DateTime.MinValue;

            try
            {
                if (o != null)
                {
                    DateTime.TryParse(o.ToString(), out dtRtn);
                }
            }
            catch
            {

            }

            return dtRtn;
        }

        public static object ConvertToDataCellValue(this object o)
        {
            object objRtn = o;

            switch (o.GetType().ToString())
            {
                case "System.String":
                case "System.Char":
                    if (o.ToString().Trim() == string.Empty)
                        objRtn = DBNull.Value;
                    break;
                case "System.Int32":
                case "System.Decimal":
                case "System.Int16":
                case "System.Int64":
                case "System.UInt16":
                case "System.UInt32":
                case "System.UInt64":
                    if (o.ConvertToIntBaseNegativeOne() == -1)
                        objRtn = DBNull.Value;
                    break;
                case "System.DateTime":
                    if (o.ConvertToDateTime() == DateTime.MinValue)
                        objRtn = DBNull.Value;
                    break;
                case "System.Boolean":
                    break;
                default:
                    break;
            }

            return objRtn;
        }

        public static string ConvertToDataCellValueInSQL(this object o)
        {
            string strRtn = string.Empty;

            switch (o.GetType().ToString())
            {
                case "System.String":
                case "System.Char":
                    if (o.ToString().Trim() == string.Empty)
                    {
                        strRtn = "NULL";
                    }
                    else
                    {
                        strRtn = "'" + o + "'";
                    }
                    break;
                case "System.Int32":
                case "System.Decimal":
                case "System.Int16":
                case "System.Int64":
                case "System.UInt16":
                case "System.UInt32":
                case "System.UInt64":
                    if (o.ToString() == string.Empty || o.ConvertToIntBaseNegativeOne() == -1)
                    {
                        strRtn = "NULL";
                    }
                    else
                    {
                        strRtn = o.ToString();
                    }
                    break;
                case "System.DateTime":
                    if (o.ConvertToDateTime() == DateTime.MinValue)
                    {
                        strRtn = "NULL";
                    }
                    else
                    {
                        strRtn = "'" + o.ToString() + "'";
                    }
                    break;
                case "System.Boolean":
                    strRtn = Convert.ToBoolean(o) ? "1" : "0";
                    break;
                default:
                    if (o == null || o == DBNull.Value)
                    {
                        strRtn = "NULL";
                    }
                    else
                    {
                        strRtn = "'" + o.ToString() + "'";
                    }
                    break;
            }

            return strRtn;
        }
    }
}
