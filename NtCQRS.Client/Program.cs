using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Models;
using NtCQRS.Models.EF;
using NtCQRS.Models.Models;
using NtCQRS.Models.SearchFilters;

namespace NtCQRS.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // блоги с фильтром
            Console.WriteLine();
            Console.WriteLine($"Все блоги от авторов с именем Ni* с кол-вом постов > 30 :");
            var blogSvc = new BlogService();
            var filter = new BlogFilter()
            {
                UserName = "Ni",
                PostCountGreaterThen = 20
            };
            
            var blogs = blogSvc.GetBlogList(filter);
            PrintBlogs(blogs);

            Console.WriteLine();
            Console.WriteLine($"Блоги в которых были посты за последнюю неделю :");
            filter = new BlogFilter()
            {
                HasPostLaterThen = DateTime.Now.AddDays(-7)
            };

            var count = blogSvc.GetBlogCount(filter);
            Console.WriteLine($"Количество : {count}");

            // посты с фильтром и сортироовкой
            var postSvc = new PostService();
            Console.WriteLine();
            Console.WriteLine($"Все посты в блоге №1, с 2015, сортировка по дате: ");
            var postFilter = new PostFilter()
            {
                BlogId = 1,
                PostDateLaterThen = new DateTime(2015, 1, 1)
            };

            var posts = postSvc.GetBlogPosts(postFilter);
            PrintPosts(posts);

            // получение статистики по блогам кастомным запросом
            Console.WriteLine();
            Console.WriteLine("Статистика по постам #1,2,3:");
            var stastFilter = new List<int>() {1, 2, 3};
            var stats = blogSvc.GetBlogStats(stastFilter)
                .GetAwaiter().GetResult();

            PrintStats(stats);

            Console.ReadKey();
        }

        static void PrintBlogs(List<Blog> blogs)
        {
            foreach (var blog in blogs)
            {
                Console.WriteLine($"Blog: {blog.Name} Author: {blog.Author.Name} ");
            }
        }

        static void PrintPosts(List<Post> posts)
        {
            foreach (var p in posts)
            {
                Console.WriteLine($"Post: {p.Name}, Date: {p.PostDate}, Blog: {p.Blog.Name},  ");
            }
        }

        static void PrintStats(List<BlogStatistics> bs)
        {
            foreach (var blog in bs)
            {
                Console.WriteLine($"Blog: {blog.BlogName}, FirstPost: {blog.FirstPost}, Posts in 2015: {blog.PostCount2015}, Posts in 2016: {blog.PostCount2016} ");
            }
        }
    }
}
