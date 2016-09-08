using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Controllers {
    public interface IView {
        void SetController(IChatLieuController controller);
        void ClearGrid();
        void View();
        void Create();
        void Update();
        void Delete();
    }
}
