using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.Utility.AutoMapping
{
    /// <summary>
    /// AutoMapper扩展帮助类
    /// </summary>
    public static class AutoMapperHelper
    {
        /// <summary>
        ///  类型映射
        /// </summary>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null)
            {
                return default(T);
            }
            Mapper.Map(obj.GetType(), typeof(T));
            return Mapper.Map<T>(obj);
        }
        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
        {
            foreach (var first in source)
            {
                var type = first.GetType();
                Mapper.Map(type, typeof(TDestination));
                break;
            }
            return Mapper.Map<List<TDestination>>(source);
        }

    }
}
