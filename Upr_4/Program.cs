namespace Upr_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chatRoom = new ChatRoom { Name = "Chat room 1" };
            var contact = new Contact { Name = "User1" };
            var message = new Message(contact, "Hello from User1");

            chatRoom.Users.Add(contact);
            chatRoom.Messages.Add(message);

            var contact1 = new Contact { Name = "User3" };
            var message1 = new Message(contact, "Hello, User3");

            chatRoom.Users.Add(contact1);
            chatRoom.Messages.Add(message1);

            ChatRoom.AddContactOrMessage(chatRoom, new Contact { Name = "User2" });
            ChatRoom.AddContactOrMessage(chatRoom, new Message(contact, "Hello from User2"));

            var (userName, messageCount, shortestMessage) = ChatRoom.GetChatRoomStatistics(chatRoom);
            Console.WriteLine($"User with most messages: {userName}, Count: {messageCount}, Shortest Message: {shortestMessage}");

            (var author, var text, var creationTime, var isEdited) = message;
            Console.WriteLine($"Author: {author.Name}, Text: {text}, Creation time: {creationTime}, Is edited: {isEdited}");

            (author, text) = message;
            Console.WriteLine($"Author: {author.Name}, Text: {text}");
        }
    }
}
