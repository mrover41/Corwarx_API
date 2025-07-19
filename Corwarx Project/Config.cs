using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace Corwarx_Project.Core {
    public class Config : IConfig {
        [Description("Plugin config")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("List of modules that will be blocked from being enabled by the Module System. \n" +
            "You can use the module name or the nameof of the module class. \n" +
            "If you want to block a module by its class name, use the nameof of the class, e.g., 'ExampleModule_1'.")]

        public List<string> BlackListModules { get; set; } = new List<string> {
            "Example module 1",
            "Example module 2",
        };
        
        public List<string> BlackListModulesNameof { get; set; } = new List<string> {
            "ExampleModule_1",
            "ExampleModule_2",
        };
    }
}
