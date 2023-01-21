using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Discord
{
    public class Discord : IDiscord
    {
        private Dictionary<string, HashSet<Message>> _channels = new Dictionary<string, HashSet<Message>>();
        private Dictionary<string, Message> _messages = new Dictionary<string, Message>();
        
        public int Count => _messages.Count;

        public bool Contains(Message message)
        {
            return _messages.ContainsKey(message.Id);
        }

        public void DeleteMessage(string messageId)
        {
            

            if (!_messages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }
            var message = GetMessage(messageId);
            _messages.Remove(messageId);
            _channels[message.Channel].Remove(message);
            
        }

        public IEnumerable<Message> GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent()
        {
            return _messages.Values
                .OrderByDescending(msg => msg.Reactions.Count)
                .ThenBy(msg => msg.Timestamp)
                .ThenBy(msg => msg.Content.Length);
        }

        public IEnumerable<Message> GetChannelMessages(string channel)
        {
            var messages = _channels.GetValuesForKey(channel);
            return messages.Any() ? messages : throw new ArgumentException();
        }

        public Message GetMessage(string messageId)
        {
            var message = _messages.GetValueOrDefault(messageId);
            return message == null ? throw new ArgumentException() : message;
        }

        public IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound)
        {
            Predicate<int> inRange = (x) => x >= lowerBound && x <= upperBound; 

            return _messages.Values.Where(x=>inRange(x.Timestamp)).OrderByDescending((msg) => _channels[msg.Channel].Count);
        }

        public IEnumerable<Message> GetMessagesByReactions(List<string> reactions)
        {
            return _messages
                .Where(msg => reactions.All(reaction => msg.Value.Reactions.IndexOf(reaction) >= 0))
                .OrderByDescending(msg=>msg.Value.Reactions.Count)
                .ThenBy(msg => msg.Value.Timestamp)
                .Select(x=>x.Value);
        }

        public IEnumerable<Message> GetTop3MostReactedMessages()
        {
            return _messages.OrderByDescending(msg => msg.Value.Reactions.Count).Take(3).Select(x=>x.Value);
        }

        public void ReactToMessage(string messageId, string reaction)
        {
            if (!_messages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            _messages[messageId].Reactions.Add(reaction);
            
        }

        public void SendMessage(Message message)
        {
            _messages.Add(message.Id, message);
            if (!_channels.ContainsKey(message.Channel))
            {
                _channels[message.Channel] = new HashSet<Message>();
            }

            _channels[message.Channel].Add(message);
        }
    }
}
