﻿namespace Entities
{
    public class Post
    {
        public Post(string title, string body, int userId)
        {
            this.Title = title;
            this.Body = body;
            this.UserId = userId;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}