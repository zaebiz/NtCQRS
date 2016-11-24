using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace NtCQRS.Models.EF
{
    public class BlogInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        private List<User> _users;
        private List<Blog> _blogs;
        private List<Post> _posts;
        private List<string> _tags;
        private Random _r;

        public BlogInitializer()
        {
            _users = new List<User>();
            _blogs = new List<Blog>();
            _posts = new List<Post>();

            _tags = new List<string>()
            {
                "health",
                "sport",
                "love",
                "war",
                "toys"
            };

            _r = new Random();
        }

        protected override void Seed(BlogContext context)
        {
            InitUsers();
            context.Users.AddRange(_users);
            context.SaveChanges();

            InitBlogs();
            context.Blogs.AddRange(_blogs);
            context.SaveChanges();

            InitPosts();
            context.Posts.AddRange(_posts);
            context.SaveChanges();

            base.Seed(context);
        }

        private void InitUsers()
        {
            _users.Add(new User() { Name = "Nikita", });
            _users.Add(new User() { Name = "Ivan", });
            _users.Add(new User() { Name = "Maxim", });
            _users.Add(new User() { Name = "Sergey", });
            _users.Add(new User() { Name = "Nastya", });
        }

        private void InitBlogs()
        {
            for (int i = 0; i < 100; i++)
            {
                var author = _users[_r.Next(_users.Count)];
                _blogs.Add(new Blog()
                {
                    Name = GetRandomText(10),
                    Author = author,
                });
            }
        }

        private void InitPosts()
        {
            for (int i = 0; i < 2000; i++)
            {
                var blog = _blogs[_r.Next(_blogs.Count)];
                var tag = _tags[_r.Next(_tags.Count)];

                _posts.Add(new Post()
                {
                    Name = GetRandomText(20),
                    BlogId = blog.Id,
                    Tag = tag,
                    PostDate = DateTime.Now.AddDays(_r.Next(1000) * -1)
                });
            }
        }

        private string GetRandomText(int length)
        {
            var dict = "abcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder text = new StringBuilder();
            Random r = new Random();

            for (int i = 0; i < length; i++)
            {
                var symbol = dict[r.Next(dict.Length)];
                text.Append(symbol);
            }

            return text.ToString();
        }
    }
}