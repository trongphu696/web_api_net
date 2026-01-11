using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Model;

namespace MyWebApiApp.Services
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDbContext _context;

        public LoaiRepository(MyDbContext context)
        {
            _context = context;
        }
        public LoaiVM Add(LoaiModel loai)
        {
            var l = new Loai
            {
                TenLoai = loai.TenLoai
            };
            _context.Add(l);
            _context.SaveChanges();
            return new LoaiVM
            {
                MaLoai = l.MaLoai,
                TenLoai = l.TenLoai
            };
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<LoaiVM> GetAll()
        {
            var loaiList = _context.Loais.Select(c => new LoaiVM
            {
                MaLoai = c.MaLoai,
                TenLoai = c.TenLoai
            });
            return loaiList.ToList();
        }

        public LoaiVM GetById(int id)
        {
            var lst = _context.Loais.SingleOrDefault(c => c.MaLoai == id);
            if (lst != null) return new LoaiVM
            {
                MaLoai = lst.MaLoai,
                TenLoai = lst.TenLoai
            };
            return null;
        }

        public void Update(LoaiModel loai)
        {
            throw new NotImplementedException();
        }
    }
}
