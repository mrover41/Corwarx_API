namespace Corwarx_Project.Events.Args.Plugin {
    public class UnLoadPluginEventArgs {
        public UnLoadPluginEventArgs(string name) {
            Name = name;
        }
        public string Name { get; set; }
    }
}
