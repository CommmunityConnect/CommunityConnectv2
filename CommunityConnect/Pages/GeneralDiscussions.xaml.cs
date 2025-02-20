using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace CommunityConnect.Pages
{
    public partial class GeneralDiscussions : ContentPage
    {
        public ObservableCollection<Post> Posts { get; set; }

        public GeneralDiscussions()
        {
            InitializeComponent();
            Posts = new ObservableCollection<Post>();
            BindingContext = this; // Set the BindingContext to this page
        }

        private async void OnPostClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewPostContentEntry.Text))
            {
                Posts.Add(new Post { Content = NewPostContentEntry.Text });
                NewPostContentEntry.Text = string.Empty; // Clear the input field

                // Show success message
                await DisplayAlert("Success", "Posted successfully", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Post content cannot be empty.", "OK");
            }
        }

        private void OnCommentClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var post = (Post)button.CommandParameter; // Get the associated post

            if (post != null && !string.IsNullOrWhiteSpace(post.NewCommentContent))
            {
                post.Comments.Add(new Comment { Content = post.NewCommentContent });
                post.NewCommentContent = string.Empty; // Clear the comment input
            }
        }

        private void OnLikeClicked(Post post)
        {
            if (post != null)
            {
                post.LikeCount++;
            }
        }

        private void OnReplyClicked(Post post)
        {
            // Implement your reply logic here
            // This can involve displaying a new Entry for the user to write their reply
        }
    }

    public class Post
    {
        public string Content { get; set; }
        public ObservableCollection<Comment> Comments { get; } = new ObservableCollection<Comment>();
        public string NewCommentContent { get; set; }
        public int LikeCount { get; set; } // Like count for the post
    }

    public class Comment
    {
        public string Content { get; set; }
        public int LikeCount { get; set; } // Like count for the comment
    }
}
