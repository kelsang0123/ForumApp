﻿namespace Entities
{
    public class Comment
    {
        public Comment(string body, int userId, int postId)
        {
            this.Body = body;
            this.UserId = userId;
            this.PostId = postId;
        }
        public int Id { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}