using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace CommunityConnect.ViewModel
{
    public class GeneralDiscussionsViewModel : INotifyPropertyChanged
    {
        private string newPostContent;
        private string newCommentContent;

        public string NewPostContent
        {
            get => newPostContent;
            set
            {
                if (newPostContent != value)
                {
                    newPostContent = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewCommentContent
        {
            get => newCommentContent;
            set
            {
                if (newCommentContent != value)
                {
                    newCommentContent = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Post> Posts { get; } = new ObservableCollection<Post>();

        public ICommand PostCommand { get; }
        public ICommand CommentCommand { get; }

        public GeneralDiscussionsViewModel()
        {
            PostCommand = new Command(OnPost);
            CommentCommand = new Command<Post>(OnComment);
        }

        private void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(NewPostContent))
            {
                Posts.Add(new Post { Content = NewPostContent });
                NewPostContent = string.Empty;
            }
        }

        private void OnComment(Post post)
        {
            if (post != null && !string.IsNullOrWhiteSpace(NewCommentContent))
            {
                post.Comments.Add(new Comment { Content = NewCommentContent });
                NewCommentContent = string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Post
    {
        public string Content { get; set; }
        public ObservableCollection<Comment> Comments { get; } = new ObservableCollection<Comment>();
        public string NewCommentContent { get; set; }
    }

    public class Comment
    {
        public string Content { get; set; }
    }
}

