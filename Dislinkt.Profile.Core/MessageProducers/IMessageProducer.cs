
namespace Dislinkt.Profile.Core.MessageProducers
{
    public interface IMessageProducer
    {
        void SendRegistrationMessage<T>(T message);
    }
}
