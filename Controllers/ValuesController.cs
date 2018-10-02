using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Community_Hub_v2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet, Authorize(Policy = "AllowUpdate")]
        public IEnumerable<Book> Get()
        {
            var currentUser = HttpContext.User;
            int userAge = 0;
            var resultBookList = new Book[]
            {
                new Book {Author="Ray Bradbury", Title="Farenheit 451", AgeRestriction=false},
                new Book {Author = "Gabriel Garcia Marquez", Title="One Hundred Years", AgeRestriction=false},
                new Book {Author = "George Orwell", Title= "1984", AgeRestriction=false },
                new Book {Author = "Anais Nin", Title="Delta of Venus",AgeRestriction=true }
            };

            if (currentUser.HasClaim(c=>c.Type==ClaimTypes.DateOfBirth))
            {
                DateTime birthdate = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.DateOfBirth).Value);
                userAge = DateTime.Today.Year - birthdate.Year;
            }

            if (userAge < 18)
            {
                resultBookList = resultBookList.Where(b => !b.AgeRestriction).ToArray();
            }

            return resultBookList;
        }
    }

    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public bool AgeRestriction { get; set; }
    }
}
