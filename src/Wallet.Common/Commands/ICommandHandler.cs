using System.Threading.Tasks;

namespace Wallet.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task Handle(T command);
    }
}
