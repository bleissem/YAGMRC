using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.Common
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
        Task<AuthenticateCommandResult> Authenticate(AuthenticateCommandParam auth);

        /// <summary>
        /// get games and players
        /// </summary>
        /// <param name="authKey"><seealso cref="AuthenticateCommandResult"/></param>
        /// <returns><seealso cref="GetGamesPlayersCommandResult"/></returns>
        GetGamesPlayersCommandResult GetGamesAndPlayers(string authKey);



    }
}
