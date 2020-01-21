using EF.ORM.Application.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.ORM.Application
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
                EF_ORM_TestDataBaseEntities context = new EF_ORM_TestDataBaseEntities();

                #region EF较为原始的CRUD操作方法举例
                // 新增
                //Student s1 = new Student() { sName = "Tom", sAddress = "2432423@qq.com" };
                //context.Students.Add(s1);
                //context.SaveChanges();

                // 更新
                //Student s1 = new Student() { sID = 0, sName = "Jack" };
                //var s2 = from s in context.Students where s.sID == s1.sID select s;
                //Student s3 = s2.FirstOrDefault();
                //s3.sName = s1.sName;
                //context.SaveChanges();
                //Console.WriteLine("修改成功");

                // 查询
                //context.Students.Select(s => s);
                //var queryResult = from s in context.Students select s;
                //foreach (var item in queryResult)
                //{
                //    Console.WriteLine(string.Format("ID:{0},Name={1},Address={2}", item.sID, item.sName, item.sAddress));
                //}

                // 删除
                //int sid = 0;
                //var s1 = from s in context.Students where s.sID == sid select s;
                //context.Students.Remove(s1.FirstOrDefault());
                //context.SaveChanges();
                //Console.WriteLine("删除成功");
                #endregion EF较为原始的CRUD操作方法举例

                #region EF标记方式实现CRUD
                // 新增
                //Student s1 = new Student() { sName = "Yiwanka", sAddress = "4654534@qq.com",sSex="F" };
                //context.Entry<Student>(s1).State = EntityState.Added;
                //context.SaveChanges();

                // 删除
                //Student s1 = new Student() { sID = 0, sName = "Yiwanka" };
                //context.Entry<Student>(s1).State = EntityState.Deleted;
                //context.SaveChanges();

                // 更新
                Student s1 = new Student() { sID = 0, sName = "1111", sAddress = "22", sSex = "M" };
                context.Entry<Student>(s1).State = EntityState.Modified;
                context.SaveChanges();

                // 查询
                //var user = context.Students.Select(s => s);
                //Console.WriteLine(user.Count());
                #endregion EF标记方式实现CRUD

                Console.ReadKey();
            }
			catch(DbEntityValidationException dbEx)
			{
				throw;
			}
        }
    }
}
