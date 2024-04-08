using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upr_4
{
    public class ChatRoom
    {
        public string? Name { get; set; }
        public List<Contact> Users { get; set; } = new List<Contact>();
        public List<Message> Messages { get; set; } = new List<Message>();

        public static Tuple<string, int, string> GetChatRoomStatistics(ChatRoom chatRoom)
        {
            var userWithMostMessages = chatRoom.Messages
                .GroupBy(m => m.Author.Name)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            if (userWithMostMessages == null)
            {
                return Tuple.Create<string, int, string>(null, 0, null);
            }

            var shortestMessage = userWithMostMessages
                .OrderBy(m => m.Text.Length)
                .FirstOrDefault()?.Text;

            return Tuple.Create(userWithMostMessages.Key, userWithMostMessages.Count(), shortestMessage);
        }

        public static void AddContactOrMessage(ChatRoom chatRoom, object item)
        {
            switch (item)
            {
                case Contact contact when string.IsNullOrEmpty(contact.Name):
                    Console.WriteLine("Contact name cannot be empty.");
                    break;
                case Contact contact:
                    chatRoom.Users.Add(contact);
                    Console.WriteLine($"Contact {contact.Name} added.");
                    break;
                case Message message:
                    chatRoom.Messages.Add(message);
                    Console.WriteLine($"Message from {message.Author.Name} added.");
                    break;
                default:
                    Console.WriteLine("Unsupported item type.");
                    break;
            }
        }
    }
}
