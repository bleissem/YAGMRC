using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace YAGMRC.GoogleStorage
{
    public class GoogleStorage
    {
        #region constructor

        public GoogleStorage(string user)
        {
            m_User = user;
        }

        #endregion constructor

        #region nested classes

        public class GoogleStorageResult
        {
            public string GameFileID { get; set; }

            public string DatabaseFileID { get; set; }
        }

        #endregion nested classes

        private string m_User;

        private const string RootFolder = "YAGMRC_Storage";

        public Google.Apis.Drive.v2.Data.File AddFolder(string name, string parent)
        {
            Google.Apis.Drive.v2.Data.File insertFolder = new Google.Apis.Drive.v2.Data.File();
            insertFolder.Title = name;
            insertFolder.Description = name;
            insertFolder.MimeType = "application/vnd.google-apps.folder";
            if (null != parent)
            {
                insertFolder.Parents = new List<ParentReference> { new ParentReference() { Id = parent } };
            }
            FilesResource.InsertRequest request = GoogleService.GetInstance().Service(this.m_User).Files.Insert(insertFolder);
            return request.Execute();
        }

        public Google.Apis.Drive.v2.Data.File GetRootFolder()
        {
            FilesResource.ListRequest searchFolderRequest = GoogleService.GetInstance().Service(this.m_User).Files.List();
            searchFolderRequest.MaxResults = 1000;
            searchFolderRequest.Q = "mimeType='application/vnd.google-apps.folder' and trashed=false and title='" + RootFolder + "'";
            FileList rootFolderList = searchFolderRequest.Execute();
            IList<Google.Apis.Drive.v2.Data.File> rootFolderItems = rootFolderList.Items;
            if ((null != rootFolderItems) && (rootFolderItems.Count > 0))
            {
                return rootFolderItems[0];
            }

            return AddFolder(RootFolder, null);
        }

        public Google.Apis.Drive.v2.Data.File InsertFile(FileInfo file, Google.Apis.Drive.v2.Data.File folder)
        {
            return InsertFile(file.Name, "", folder.Id, "application/unknown", file);
        }

        public string ShareFileOrFolder(Google.Apis.Drive.v2.Data.File file)
        {
            Permission permission = new Permission();
            permission.Value = null;
            permission.Type = "anyone";
            permission.Role = "writer";
            permission.WithLink = true;

            Permission responsePermission = GoogleService.GetInstance().Service(this.m_User).Permissions.Insert(permission, file.Id).Execute();
            if (null == responsePermission)
            {
                throw new GoogleDriveException("permission could not be set for: " + file.Id);
            }

            //  file.WebContentLink as file
            return file.Id;
        }

        public Google.Apis.Drive.v2.Data.File InsertFile(String title, String description, String parentId, String mimeType, FileInfo filename)
        {
            // File's metadata.
            Google.Apis.Drive.v2.Data.File gooleFile = new Google.Apis.Drive.v2.Data.File();
            gooleFile.Title = title;
            gooleFile.Description = description;
            gooleFile.MimeType = mimeType;

            gooleFile.Shared = true;
            gooleFile.Editable = true;

            if (!String.IsNullOrEmpty(parentId))
            {
                gooleFile.Parents = new List<ParentReference>() { new ParentReference() { Id = parentId } };
            }

            byte[] byteArray = System.IO.File.ReadAllBytes(filename.FullName);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                FilesResource.InsertMediaUpload request = GoogleService.GetInstance().Service(this.m_User).Files.Insert(gooleFile, stream, mimeType);
                request.Upload();

                return request.ResponseBody;
            }
        }
    }
}