using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolingerBands.Source.Services
{
    public interface IControlsDrawer
    {
        void DrawRectangle(MainWindow mainWindow);

        void DrawMesh(MainWindow mainWindow);
    }
}
