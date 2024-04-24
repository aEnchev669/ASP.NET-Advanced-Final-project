namespace TheReader.Core.Models.Event
{
    public interface IEventModel
    {
        public string Topic { get; set; }
        public string Location { get; set; }
    }
}
