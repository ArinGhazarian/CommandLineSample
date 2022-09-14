namespace CommandLineSample;

public interface ICommandHandler<in TArgs> where TArgs : class
{
    Task Handle(TArgs args);
}