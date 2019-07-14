using System.Threading.Tasks;
using Wallet.Commands;

namespace Wallet.Events
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task Handle(T @event);
    }
}
