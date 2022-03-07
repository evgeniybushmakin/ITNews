using ITNews.Domain.Contracts;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace ITNews.Web1
{
    public class CommentHub:Hub
    {
        private readonly ICommentService commentService;

        public CommentHub(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public async Task SendMessage(string message, int postId, string userId)
        {       

            if ((userId == null) || (message == null))
            {
                return;
            }
            else
            {
                var commentId = commentService.Create(message, postId, userId);

                await Clients.All.SendAsync("ReceiveMessage", message, commentId);
            }

        }
    }
}
