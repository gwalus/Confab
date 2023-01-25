using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confab.Shared.Infrastructure.Modules
{
    public interface IModuleRegistry
    {
        IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistrations(string key);
        void AddBroadcastAction(Type requestType, Func<object, Task> action);
    }

    public sealed class ModuleRegistry : IModuleRegistry
    {
        private readonly List<ModuleBroadcastRegistration> _broadcastRegistrations = new();

        public void AddBroadcastAction(Type requestType, Func<object, Task> action)
        {
            if(string.IsNullOrWhiteSpace(requestType.Namespace))
            {
                throw new InvalidOperationException("Missing namespace.");
            }

            var registration = new ModuleBroadcastRegistration(requestType, action);
            _broadcastRegistrations.Add(registration);
        }

        public IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistrations(string key)
            => _broadcastRegistrations.Where(x => x.Key == key);
    }

    public sealed class ModuleBroadcastRegistration
    {
        public ModuleBroadcastRegistration(Type receiverType, Func<object, Task> action)
        {
            ReceiverType = receiverType;
            Action = action;
        }

        public Type ReceiverType { get; }
        public Func<object,Task> Action { get;}
        public string Key => ReceiverType.Name;
    }
}
