using System;

namespace To_do_app.Models
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}