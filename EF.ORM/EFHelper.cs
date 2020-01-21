using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EF.ORM
{
    /// <summary>
    /// EF ORM帮助类
    /// </summary>
    public class EFHelper
    {
        #region 字段
        /// <summary>
        /// DbContext实例
        /// </summary>
        private DbContext _dbContext = null;
        #endregion 字段

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">DbContext实例</param>
        public EFHelper(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion 构造函数

        #region 公有方法
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <typeparam name="T">待插入数据类型</typeparam>
        /// <param name="data">待插入数据</param>
        /// <returns>true-插入完成</returns>
        public bool InsertData<T>(T data) where T : class
        {
            if ((_dbContext != null) && (data != null))
            {
                _dbContext.Entry<T>(data).State = EntityState.Added;
                int effectNum = _dbContext.SaveChanges();
                if (effectNum > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T">待查询数据类型</typeparam>
        /// <param name="express">查询表达式</param>
        /// <returns>查询结果</returns>
        public List<T> QueryData<T>(Expression<Func<T, bool>> express) where T : class
        {
            try
            {
                if ((express != null) && (_dbContext != null))
                {
                    IQueryable<T> queryResult = _dbContext.Set<T>().Where(express);
                    if (queryResult == null)
                    {
                        return null;
                    }
                    else
                    {
                        return queryResult.ToList();
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <typeparam name="T">待查询数据类型</typeparam>
        /// <returns>数据集合</returns>
        public List<T> QueryAllData<T>() where T : class
        {
            try
            {
                if (_dbContext != null)
                {
                    IQueryable<T> queryResult = _dbContext.Set<T>();
                    if (queryResult == null)
                    {
                        return null;
                    }
                    else
                    {
                        return queryResult.ToList();
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T">待更新数据类型</typeparam>
        /// <param name="data">待更新数据</param>
        /// <returns>true-更新完成</returns>
        public bool UpdateData<T>(T data) where T : class
        {
            try
            {
                if ((_dbContext != null) && (data != null))
                {
                    _dbContext.Entry<T>(data).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="T">待删除数据类型</typeparam>
        /// <param name="data">待删除数据</param>
        /// <returns>true-删除完成</returns>
        public bool DeleteData<T>(T data) where T : class
        {
            try
            {
                if ((_dbContext != null) && (data != null))
                {
                    _dbContext.Entry<T>(data).State = EntityState.Deleted;
                    _dbContext.SaveChanges();

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <typeparam name="T">待判断数据类型</typeparam>
        /// <param name="express">表达式</param>
        /// <returns>true-存在</returns>
        public bool IsDataExisted<T>(Expression<Func<T, bool>> express) where T : class
        {
            try
            {
                if ((_dbContext != null) && (express != null))
                {
                    return _dbContext.Set<T>().Any(express);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">待排序数据的数据类型</typeparam>
        /// <typeparam name="S">按照某数据排序的类型</typeparam>
        /// <param name="data">待排序数据集合</param>
        /// <param name="keySelector">排序规则</param>
        /// <param name="sortType">排序类型</param>
        /// <returns>排序后数据集合</returns>
        public List<T> SortData<T,S>(List<T> data, Func<T, S> keySelector, SortType sortType) where T : class
        {
            try
            {
                if ((data != null))
                {
                    if (sortType == SortType.ASC)
                    {
                        return data.OrderBy(keySelector).ToList(); // 正序
                    }
                    else if (sortType == SortType.DESC)
                    {
                        return data.OrderByDescending(keySelector).ToList(); // 倒序
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        #endregion  公有方法
    }
}
