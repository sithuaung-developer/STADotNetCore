using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STADotNetCore.ConsoleApp.Dtos;

namespace STADotNetCore.ConsoleApp.EFCoreExamples
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext(); //Database
        public void Run()
        {
            //Read();
            //Edit(14);
            //Edit(12);
            //Create("STA", "C#", "You don't know C#");
            //Update(3, "Nyein", "Java", "You don't know Java");
            Delete(15);

        }
        private void Read()
        {

            var lst = db.Blogs.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("-----------------");

            }
        }
        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);


        }
        private void Create(string title, string author, string content)
        {
            var item = new BlogDto //obj create
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges(); //Query Run

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);

        }
        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Update Failed";
            Console.WriteLine(message);
        }
        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            Console.WriteLine(message);

        }
    }
}
