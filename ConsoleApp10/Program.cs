using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        private static DataContext dataContext;
        static void Main(string[] args)
        {
            dataContext = new DataContext(@"Data Source=(LocalDB)\LocalDBQ;Initial Catalog=CRCMS_new; User ID=sa;Password=Qwerty123");

            zapros_a();
            //zapros_b();
            //zapros_c();
            //zapros_d();
            //zapros_e();
            //zapros_f();

            void zapros_a()
            {
                Table<Area> areas = dataContext.GetTable<Area>();

                List<Area> temp = dataContext.GetTable<Area>().Where(o => o.TypeArea == 1).OrderByDescending(o => o.TypeArea).ToList();

                Console.WriteLine("{0,-50}{1,-50}{2}", "Name", "FullName", "IP");
                Console.WriteLine();
                foreach (Area item in temp)
                {
                    Console.WriteLine("{0,-50}{1,-50}{2}", item.Name, item.FullName, item.IP);

                }

            }

            void zapros_b()
            {
                Table<Area> areas = dataContext.GetTable<Area>();

                List<Area> temp;

                Console.WriteLine("{0,-60}{1,-60}{2}", "Name", "FullName", "IP");
                Console.WriteLine();
                foreach (Area item in temp = (from o in areas where o.ParentId == 0 select o).ToList())
                {
                    Console.WriteLine("{0,-60}{1,-60}{2}", item.Name, item.FullName, item.IP);

                }
            }

            void zapros_c()
            {
                int[] Pavilion = { 1, 2, 3, 4, 5, 6 };

                Table<Area> areas = dataContext.GetTable<Area>();

                List<Area> temp = dataContext.GetTable<Area>().Where(o => Pavilion.Where(w => w % 2 == 0).Contains(o.PavilionId)).ToList();

                Console.WriteLine("{0,-15}{1,-60}{2,-60}{3}", "PavilionId", "Name", "FullName", "IP");
                Console.WriteLine();
                foreach (Area item in temp)
                {
                    Console.WriteLine("{0,-15}{1,-60}{2,-60}{3}", item.PavilionId, item.Name, item.FullName, item.IP);

                }
            }

            void zapros_d()
            {
                int[] Pavilion = { 1, 2, 3, 4, 5, 6 };

                Table<Area> areas = dataContext.GetTable<Area>();

                List<Area> temp = (from o in dataContext.GetTable<Area>()
                                   where (Pavilion.Where(w => w % 2 == 0).Contains(o.PavilionId))  //Правильно???
                                   select o).ToList();

                Console.WriteLine("{0,-15}{1,-60}{2,-60}{3}", "PavilionId", "Name", "FullName", "IP");
                Console.WriteLine();
                foreach (Area item in temp)
                {
                    Console.WriteLine("{0,-15}{1,-60}{2,-60}{3}", item.PavilionId, item.Name, item.FullName, item.IP);

                }

            }

            void zapros_e()
            {
                Table<Area> areas = dataContext.GetTable<Area>();
                List<Area> temp = (from o in areas
                                   let WorkingPeoples = areas
                                   where o.WorkingPeople > 1
                                   select o).ToList();

                Console.WriteLine("{0,-15}{1,-60}{2,-60}{3}", "WorkingPeople", "Name", "FullName", "IP");
                Console.WriteLine();
                foreach (Area item in temp)
                {
                    Console.WriteLine("{0,-15}{1,-60}{2,-60}{3}", item.WorkingPeople, item.Name, item.FullName, item.IP);

                }
            }

            void zapros_f()
            {
                Table<Area> areas = dataContext.GetTable<Area>();
                List<Area> temp = areas.ToList();

                Console.WriteLine("{0,-15}{1,-60}{2}", "ParentId", "FullName", "Dependence");
                Console.WriteLine();
                foreach (Area item in temp)
                {
                    Console.WriteLine("{0,-15}{1,-60}{2}", item.ParentId, item.FullName, item.Dependence);

                }
  
                temp = (from o in areas             //Зачем здесь into?
                        where o.Dependence > 0
                        select o).ToList();

                Console.WriteLine("\nТолько те зоны у которых Dependence > 0\n");

                Console.WriteLine("{0,-15}{1,-60}{2}", "ParentId", "FullName", "Dependence");
                Console.WriteLine();
                foreach (Area item in temp)
                {
                    Console.WriteLine("{0,-15}{1,-60}{2}", item.ParentId, item.FullName, item.Dependence);

                }
            }
        }
    }
}
