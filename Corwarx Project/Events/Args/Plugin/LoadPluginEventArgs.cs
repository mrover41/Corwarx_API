namespace Corwarx_Project.Events.Args.Plugin {
    public class LoadPluginEventArgs {
        public LoadPluginEventArgs(string name) {
            Name = name;
        }
        public string Name { get; set; }
    }
}
