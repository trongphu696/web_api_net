using MyWebApiApp.Model;

namespace MyWebApiApp.Services
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(LoaiModel loai);
        void Update(LoaiModel loai);
        void Delete(int id);
    }
}
