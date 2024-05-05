using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STADotNetCore.RestApi.Model;
using STADotNetCore.Shared;
using System.Data;
using System.Data.SqlClient;

namespace STADotNetCore.RestApi.Controllers
{
    //BlogDapper => endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController1 : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString)
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            
            var lst = _dapperService.Query<BlogModel>(query); 
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            /*string query = "Select * from tbl_blog where blogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();//Change */

           var item = FindById(id);

            if (item is null)
            {
                return NotFound("No Data Found.");
            }
            return Ok(item);
        }


        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

 
            int result = _dapperService.Execute(query,blog);

            string message = result > 0 ? "Saving Successful." : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {

            var item = FindById(id);
            if(item is null)
            {
                return NotFound("No Data Found.");
            }

            blog.BlogId = id; //need to exchange value id cuz default 0 

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            

            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Updated Successful." : "Update Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")] //desire field update
        public IActionResult PatchBlog(int id, BlogModel blog) //id, obj
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }

            string conditions = string.Empty; //condition for update set ...
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";
            }
            if(!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
            }
            if(!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += " [BlogContent] = @BlogContent, ";
            }
           
            if(conditions.Length == 0) //for null case defense
            {
                return NotFound("No Data Found.");
            }
            conditions = conditions.Substring(0, conditions.Length - 2); //remove last two characters(, )

            blog.BlogId = id;

            //add $ for join c# and string
            string query = $@"UPDATE [dbo].[Tbl_Blog] 
   SET {conditions}
 WHERE BlogId = @BlogId";

            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Updated Successful." : "Update Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id) 
        {

            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }

            string qurey = "delete from Tbl_Blog where BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int resule = db.Execute(qurey, new BlogModel { BlogId =id}); //change

            string message = resule > 0 ? "Delete Successful." : "Delete Failed";
            return Ok(message);
        }

        private BlogModel? FindById(int id)
        {
            string query = "Select * from tbl_blog where blogId = @BlogId";
           
            var item = _dapperService.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });

            return item!;       
        }
    }
}
