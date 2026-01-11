using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Model;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet("LayDanhSachLoai")]
        public IActionResult GetAll()
        {
            var loaiList = _context.Loais.ToList();
            return Ok(loaiList);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(c => c.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Create(LoaiModel model)
        {
            try
            {
               var loai = new Loai
               {
                   TenLoai = model.TenLoai
               } ;
                _context.Loais.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(c => c.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
