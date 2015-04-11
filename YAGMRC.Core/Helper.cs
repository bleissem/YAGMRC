using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using YAGMRC.Core.OS;

namespace YAGMRC.Core
{
    public class Helper
    {
        public static string Filename(int gameID)
        {
            return "(YAGMRC) Play This One! " + gameID.ToString() + ".Civ5Save";
        }

        public static FileInfo File(int gameID, IOSSetting ossetting)
        {
            string path = ossetting.CIVSaveGamePath.FullName;

            Directory.CreateDirectory(path);

            string file = Helper.Filename(gameID);

            return new FileInfo(Path.Combine(path, file));
        }

        public static string GetHashCode(byte[] bytes)
        {

            using (SHA256 sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(computedHash);
            }

        }
                
    }
}