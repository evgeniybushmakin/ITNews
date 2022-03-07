using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Domain.Services
{
    public class CommentService: ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }
        public int Create(string message, int postId, string userId)
        {
            Comment comment = new Comment();
            comment.Content = message;
            comment.Created = DateTime.Now;
            comment.PostId = postId;
            comment.UserId = userId;
            commentRepository.CreateComment(comment);
            commentRepository.Save();
            return commentRepository.GetCommentId(comment);
        }

        public void DeleteComments(string userId)
        {
            commentRepository.DeleteComments(userId);
            commentRepository.Save();
        }

        public List<CommentDomainModel> GetComments(int postId)
        {
            var comments = commentRepository.GetComments(postId);
            var commentsDomainModel = mapper.Map<List<CommentDomainModel>>(comments);
            return commentsDomainModel;
        }

        public int GetCommentsCount(int postId)
        {
            return commentRepository.GetCommentsCount(postId);
        }
    }
}
