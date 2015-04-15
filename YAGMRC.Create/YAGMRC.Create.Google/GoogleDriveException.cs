using System;

namespace YAGMRC.Create.GoogleStorage
{
    public class GoogleDriveException : Exception
    {
        public GoogleDriveException(string message)
            : base(message)
        {
        }
    }
}