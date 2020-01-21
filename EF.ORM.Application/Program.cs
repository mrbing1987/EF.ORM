using EF.ORM.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.ORM.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            EF_ORM_TestDataBaseEntities context = new EF_ORM_TestDataBaseEntities();

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
            int sid = 0;
            var s1 = from s in context.Students where s.sID == sid select s;
            context.Students.Remove(s1.FirstOrDefault());
            context.SaveChanges();
            Console.WriteLine("删除成功");

            Console.ReadKey();
        }
    }
}
