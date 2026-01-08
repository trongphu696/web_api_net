using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Controllers.Model;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> danhSachHangHoa = new List<HangHoa>();
        [HttpGet("LayDanhSachHangHoa")]
        public IActionResult GetAll()
        {
            return Ok(danhSachHangHoa);
        }
        [HttpGet("LayHangHoaTheoId/{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = danhSachHangHoa.FirstOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ThemHangHoa")]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hangHoa = new HangHoa()
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            danhSachHangHoa.Add(hangHoa);
            return Ok(new
            {
                Success = true,
                Data = hangHoa
            });
        }

        [HttpPut("SuaHangHangTheoId/{id}")]
        public IActionResult Edit(string id,HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = danhSachHangHoa.FirstOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                if(id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
