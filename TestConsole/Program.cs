using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new JustBlogContext())
            {
                var a = context.Categories.Find(1);
                Console.WriteLine(a.Name);
                Console.ReadKey();
            }
        }
    }
}
