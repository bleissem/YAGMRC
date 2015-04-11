using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YAGMRC.Core.Commands;
using YAGMRC.Core.Models.SubmitTurn;
using YAGMRC.GMR.Core.Commands;

namespace YAGMRC.GMR.Core.Web
{
    /// <summary>
    /// this is the interface for developing any kind of multiplayer host to store Civ V games
    /// </summary>
    public interface IWebCommunitcation
    {
        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        AuthenticateCommandResult Authenticate(Commands.AuthenticateCommandParam auth);

        /// <summary>
        /// get games and players
        /// </summary>
        /// <param name="authKey"><seealso cref="AuthenticateCommandResult"/></param>
        /// <returns><seealso cref="GetGamesPlayersCommandResult"/></returns>
        GetGamesPlayersCommandResult GetGamesAndPlayers(string authKey);

        /// <summary>
        /// download a game
        /// </summary>
        /// <param name="authKey"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        byte[] DownloadSaveGame(string authKey, int gameId);


        /// <summary>
        /// upload a game
        /// </summary>
        /// <param name="fileToUpload"></param>
        /// <param name="authKey"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        WebUploadResult UploadGame(FileInfo fileToUpload, string authKey, int gameId);

    }
}
