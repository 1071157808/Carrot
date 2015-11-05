# Carrot

Carrot is a .NET lightweight library that provides a couple of facilities over RabbitMQ.

[![install from nuget](https://img.shields.io/nuget/v/Carrot.svg?style=flat-square)](https://www.nuget.org/packages/Carrot)[![downloads](http://img.shields.io/nuget/dt/Carrot.svg?style=flat-square)](https://www.nuget.org/packages/Carrot)

## What is it? ##

Prompted by the need for an easy-to-use RabbitMQ access component not requiring lots of boilerplate code in order to accomplish basic operations with RabbitMQ broker.
Inspired by [MassTransit](https://github.com/MassTransit/MassTransit "MassTransit").

## Getting started ##

Just mark your POCO message contracts with `MessageBinding` attribute:

    [MessageBinding("urn:message:foo")]
    public class Foo
    {
        public Int32 Bar { get; set; }
    }

Define your message consumer:

    class FooConsumer : Consumer<Foo>
    {
        public override Task ConsumeAsync(ConsumedMessage<Foo> message)
        {
            return Task.Factory.StartNew(() =>
                                         {
                                             Console.WriteLine("received '{0}'",
                                                               message.Headers.MessageId);
                                         });
        }
    }

Create an instance of `Channel` providing the RabbitMQ host as input.

	var channel = Channel.New("amqp://guest:guest@localhost:5672/",
                              new MessageBindingResolver(typeof(Foo).Assembly));

Declare your AMQP entities as the following:

    var exchange = channel.DeclareDirectExchange("source_exchange");
	var queue = channel.DeclareQueue("my_test_queue");

Bind entities, subscribe your queue and call `IChannel.Connect`:

	channel.DeclareExchangeBinding(exchange, queue, "routing_key");
	channel.SubscribeByAtLeastOnce(queue, _ => _.Consumes(new FooConsumer()));
	var connection = channel.Connect();

You're up 'n running!
Do not forget to call `AmqpConnection.Dispose()` when your application exits.

Please note that exchanges, queues and messages are not durable by default.
You can create durable entities by calling the proper builder methods.

    var durableExchange = channel.DeclareDurableDurectExchange.Direct("source_exchange");
    var durableQueue = channel.DeclareDurableQueue.Direct("my_test_queue");

You can publish messages as the following:

    connection.PublishAsync(new OutboundMessage<Foo>(new Foo { Bar = 2 }),
                            exchange);

Please note that messages are not durable by default.
If you need durable messaging, make use of `DurableOutboundMessage<T>`:

    connection.PublishAsync(new DurableOutboundMessage<Foo>(new Foo { Bar = 2 }),
                            exchange);

## Building from Source ##

Clone the source down to your machine.

    git clone https://github.com/naighes/Carrot.wiki.git

Run `build.bat`

## Resources ##

- Carrot can be installed from [NuGet](https://www.nuget.org/packages/Carrot "Carrot")
- Find more information in the [wiki](https://github.com/naighes/Carrot/wiki "Carrot wiki")
- Follow [@nicolabaldi on Twitter](https://twitter.com/nicolabaldi "@nicolabaldi") for updates