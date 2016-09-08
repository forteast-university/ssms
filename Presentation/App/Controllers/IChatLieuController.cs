using App.Core.Domain;

namespace App.Controllers{
    public interface IChatLieuController{
        void View();
        void Insert(ChatLieu value);
    }
}