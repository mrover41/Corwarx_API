using Corwarx_Project.Events.Args.Modules;
using System;

namespace Corwarx_Project.Events.Handles {
    public static class Module {
        public static event Action<RegModuleEventArg> RegModuleEvent;
        public static event Action<EnableModuleEventArg> EnableModuleEvent;
        public static event Action<EnabledModuleEventArg> EnabledModuleEvent;
        public static event Action<DisableModuleEventArg> DisableModuleEvent;
        public static event Action<UnregisterModuleEventArg> UnregisterModuleEvent;

        public static RegModuleEventArg OnRegModuleEvent(RegModuleEventArg arg) {
            RegModuleEvent?.Invoke(arg);
            return arg;
        }

        public static EnableModuleEventArg OnEnableModuleEvent(EnableModuleEventArg arg) {
            EnableModuleEvent?.Invoke(arg);
            return arg;
        }

        public static EnabledModuleEventArg OnEnabledModuleEventArg(EnabledModuleEventArg arg) { 
            EnabledModuleEvent?.Invoke(arg);
            return arg;
        }

        public static DisableModuleEventArg OnDisableModuleEventArg(DisableModuleEventArg arg) {
            DisableModuleEvent?.Invoke(arg);
            return arg;
        }

        public static UnregisterModuleEventArg OnUnregisterModuleEventArg(UnregisterModuleEventArg arg) {
            UnregisterModuleEvent?.Invoke(arg);
            return arg;
        }
    }
}
