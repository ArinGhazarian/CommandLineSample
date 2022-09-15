namespace CommandLineSample;

public interface ICommandHandler<in TArgs>
{
    Task Handle(TArgs args);
}