namespace Carrot.Messaging
{
    public class EmptyMessageType : MessageType
    {
        public static readonly MessageType Instance = new EmptyMessageType();

        private EmptyMessageType()
            : base(null, null)
        {
        }
    }
}