using Carrot.Amqp.Frames;

namespace Carrot.Amqp
{
    internal interface IMethodFrameBag
    {
        MethodFrameBag.IMethodFrameDictionary For(MethodFrameDescriptor descriptor);
    }
}