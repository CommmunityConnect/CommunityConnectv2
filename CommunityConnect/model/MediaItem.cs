using CommunityConnect.model.Enums;

namespace CommunityConnect.model
{
    public class MediaItem : ObservableObject
    {
        private string _id;
        private string _url;
        private string _localPath;
        private MediaType _type;
        private DateTime _uploadedDate;

        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        public string LocalPath
        {
            get => _localPath;
            set => SetProperty(ref _localPath, value);
        }

        public MediaType Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        public DateTime UploadedDate
        {
            get => _uploadedDate;
            set => SetProperty(ref _uploadedDate, value);
        }
    }
}