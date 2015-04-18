using System;

namespace YAGMRC.GoogleStorage
{
    public class GoogleDriveException : Exception
    {
        public GoogleDriveException(string message)
            : base(message)
        {
        }
    }
}