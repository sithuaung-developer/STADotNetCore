using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STADotNetCore.ConsoleApp.EFCoreExamples;
using STADotNetCore.RestApi.Model;

namespace STADotNetCore.RestApi.Controllers
{
    //https://localhost:3000 -> domain url
    //api/blog -> endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context; //database
        public BlogController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            var result = _context.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")] // Resoures update
        public IActionResult Update(int id,BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _context.SaveChanges();

            string message = result > 0 ? "Update Successful." : "Update Failed.";
            return Ok(message);
            //return Ok("Update");    // Resoures update

        }

        [HttpPatch("{id}")] //One by one update(deisre field updates)
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;

            }
            
            if(!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
          
            if(!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }
           
            var result = _context.SaveChanges();

            string message = result > 0 ? "Update Successful." : "Update Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

           _context.Blogs.Remove(item);
            var result = _context.SaveChanges();

           string message = result>0? "Delete Successful." : "Delete Failed.";
            return Ok(message);

        }
    }
}
