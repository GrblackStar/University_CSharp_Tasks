using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upr_4
{
    public class Message
    {
        public Contact Author { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsEdited { get; set; }

        public Message(Contact author, string text)
        {
            Author = author;
            Text = text;
            CreationTime = DateTime.Now;
            IsEdited = false;
        }

        public void Edit(string newText)
        {
            Text = newText;
            IsEdited = true;
        }

        public void Deconstruct(out Contact author, out string text)
        {
            author = Author;
            text = Text;
        }

        public void Deconstruct(out Contact author, out string text, out DateTime creationTime)
        {
            author = Author;
            text = Text;
            creationTime = CreationTime;
        }

        public void Deconstruct(out Contact author, out string text, out DateTime creationTime, out bool isEdited)
        {
            author = Author;
            text = Text;
            creationTime = CreationTime;
            isEdited = IsEdited;
        }
    }
}
