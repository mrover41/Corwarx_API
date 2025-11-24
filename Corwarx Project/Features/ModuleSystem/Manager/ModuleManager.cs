using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Corwarx_Project.Features.ModuleSystem.Manager {
    public static class ModuleManager {
        public static List<ModuleBase> Modules { get; private set; } = new List<ModuleBase>();

        [Obsolete("Pleas use attributies")]
        internal static void RegisterModule(ModuleBase module, bool isEnabled = true) {
            if (module != null && !Modules.Contains(module)) {
                Modules.Add(module);
                if (module.Id == -1)
                    module.Id = Modules.Count + 1;
                Corwarx_Project.Events.Handles.Module.OnRegModuleEvent(new Events.Args.Modules.RegModuleEventArg(module));
                if (isEnabled) {
                    if (!Corwarx_Project.Events.Handles.Module.OnEnableModuleEvent(new Events.Args.Modules.EnableModuleEventArg(module)).IsAllowed)
                        return;
                    module.OnEnable();
                    Corwarx_Project.Events.Handles.Module.OnEnabledModuleEventArg(new Events.Args.Modules.EnabledModuleEventArg(module));
                }
            } else {
                Log.Error($"Module {module.Name} with ID {module.Id} is null or already registered.");
            }
        }

        public static void RegisterModules(params Assembly[] assemblies) {
            foreach (Assembly asm in assemblies) {
                foreach (Type type in asm.GetTypes()) {
                    if (type.GetCustomAttribute<LoadModuleAttribute>() != null) {
                        if (!typeof(ModuleBase).IsAssignableFrom(type))
                            throw new Exception($"Error in class: {type.FullName}\n Can`t load module");
                        ModuleBase instance = (ModuleBase)Activator.CreateInstance(type);
                        RegisterModule(instance, false);
                    }
                }
            }
        }

        internal static void EnableAllModules() {
            foreach (ModuleBase module in Modules) {
                if (!Corwarx_Project.Events.Handles.Module.OnEnableModuleEvent(new Events.Args.Modules.EnableModuleEventArg(module)).IsAllowed)
                    continue;
                module.OnEnable();
                Corwarx_Project.Events.Handles.Module.OnEnabledModuleEventArg(new Events.Args.Modules.EnabledModuleEventArg(module));
            }
        }

        public static void EnableModule(uint id) {
            ModuleBase module = Modules.FirstOrDefault(m => m.Id == id);
            if (module != null) {
                if (!Corwarx_Project.Events.Handles.Module.OnEnableModuleEvent(new Events.Args.Modules.EnableModuleEventArg(module)).IsAllowed)
                    return;
                module.OnEnable();
                Corwarx_Project.Events.Handles.Module.OnEnabledModuleEventArg(new Events.Args.Modules.EnabledModuleEventArg(module));
            } else {
                Log.Error($"Module with ID {id} not found.");
            }
        }

        public static void DisableModule(uint id) {
            ModuleBase module = Modules.FirstOrDefault(m => m.Id == id);
            if (module != null) {
                module.OnDisable();
                Corwarx_Project.Events.Handles.Module.OnDisableModuleEventArg(new Events.Args.Modules.DisableModuleEventArg(module));
            } else {
                Log.Error($"Module with ID {id} not found.");
            }
        }

        internal static void DisableAllModules() {
            foreach (ModuleBase module in Modules) {
                module.OnDisable();
                Corwarx_Project.Events.Handles.Module.OnDisableModuleEventArg(new Events.Args.Modules.DisableModuleEventArg(module));
            }
        }

        public static void UnregisterModule(ModuleBase module) {
            if (module != null && Modules.Contains(module)) {
                Modules.Remove(module);
                Corwarx_Project.Events.Handles.Module.OnUnregisterModuleEventArg(new Events.Args.Modules.UnregisterModuleEventArg(module));
            } else {
                Log.Error($"Module {module.Name} with ID {module.Id} is null or not registered.");
            }
        }

        public static void UnregisterModule(uint ID) {
            ModuleBase module = Modules.FirstOrDefault(m => m.Id == ID);
            if (module != null && Modules.Contains(module)) {
                Modules.Remove(module);
                Corwarx_Project.Events.Handles.Module.OnUnregisterModuleEventArg(new Events.Args.Modules.UnregisterModuleEventArg(module));
            } else {
                Log.Error($"Module {module.Name} with ID {module.Id} is null or not registered.");
            }
        }
    }
}
