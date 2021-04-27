
using Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace BNewsPortal.Controllers
{
    [Route("newsportal/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        // Implementing repository
        // private readonly StoreContext _context;
        // public NewsController(StoreContext context)
        // {
        //     _context = context;
        private readonly INewsRepository _repo;

        // }
        public NewsController(INewsRepository repo)
        {
            _repo = repo;
        }
        // Implementing rep
        [HttpGet]
        public async Task<ActionResult<List<News>>> GetNews()
        {

            // var news = await _context.News.ToListAsync();
            var news = await _repo.GetNewsAsync();

            return Ok(news);

        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNewsById(int id)
        {
            // return await _context.News.FindAsync(id);
            return await _repo.GetNewsByIdAsync(id);
        }


    }
}
