﻿using AgileDev.Interface.IServices;
using AgileDev.Entity;

namespace AgileDev.Interface.IApp
{
    /// <summary>
    /// 记录接口
    /// </summary>
    public interface IRecordServices : IBaseServices<T_Record>
    {
        void Get_Record_Test();
    }
}