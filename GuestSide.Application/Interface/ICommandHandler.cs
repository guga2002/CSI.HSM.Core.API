namespace GuestSide.Application.Interface
{
    public interface ICommandHandler<TCommand>
    {
        Task Handle(TCommand command);
    }
}
