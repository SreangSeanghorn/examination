using MassTransit;

public class KafkaMessageConsumer
:
        IConsumer<KafkaMessage>
{
    public Task Consume(ConsumeContext<KafkaMessage> context)
    {
        Console.WriteLine($"Received: {context.Message.Text}");
        return Task.CompletedTask;
    }
}



