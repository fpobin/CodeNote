﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Common
{
    /// <summary>
    /// 用于封装返回数据
    /// </summary>
    public class ReturnValue
    {
        //返回其他数据
        private Dictionary<object, object> _dataTable;

        private Dictionary<object, object> DataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new Dictionary<object, object>();
                }
                return _dataTable;
            }
        }

        /// <summary>
        /// 异常信息
        /// </summary>
        public Exception Exceptioin { get; set; }


        /// <summary>
        /// 操作是否正确
        /// </summary>
        public bool IsExists { get; set; }

        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回的数据对象
        /// </summary>
        public Object RetObjec { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ReturnValue()
        {
            IsExists = true;
            Message = "操作成功！";
        }
        public ReturnValue(bool isexists, string message)
        {
            IsExists = isexists;
            Message = message;
        }

        public ReturnValue(bool isexists, string message, object retObjec)
        {
            IsExists = isexists;
            Message = message;
            RetObjec = retObjec;
        }

        public void PutValue(object key, object value)
        {
            if (DataTable.ContainsKey(key))
            {
                DataTable[key] = value;
            }
            else
            {
                DataTable.Add(key, value);
            }
        }

        public object GetVal(object key)
        {
            if (DataTable.ContainsKey(key))
            {
                return DataTable[key];
            }
            return null;
        }

        public int GetInt(string key)
        {
            return 0;
        }

        public T Get<T>(string key) where T : class
        {
            return this.GetVal(key) as T;
        }

        public string GetStrVal(string key)
        {
            object value = GetVal(key);
            if (value != null)
            {
                return value.ToString();
            }
            return string.Empty;
        }
    }
}
