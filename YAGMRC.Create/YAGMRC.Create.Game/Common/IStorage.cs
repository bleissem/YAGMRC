using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.Model;
using YAGMRC.Core.ViewModel;

namespace YAGMRC.Core.Common
{
    public interface IStorage
    {
        CreateGameViewModel.CreateGameResult Upload(Game game, FileInfo dbFile, FileInfo savedGame);
    }
}
