using App.Controllers;

namespace App.Views {
    public interface IView {
        void ClearGrid();
        void View();
        void Create();
        void Update();
        void Delete();
    }
}
