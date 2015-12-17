using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeftOver10_2_RSS
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument ourBlog = XDocument.Load("http://www.stellman-greene.com/feed");
            Console.WriteLine(ourBlog.Element("rss").Element("channel").Element("title").Value);

            var posts = from post in ourBlog.Descendants("item")
                        select new
                        {
                            Title = post.Element("title").Value,
                            Date = post.Element("pubDate").Value
                        };

            foreach (var post in posts)
            {
                Console.WriteLine(post.ToString());
            }

            Console.ReadKey();
        }
    }
}
