

namespace WorriedWednesday.Models
{
  public class Reply
  {
    public string Message { get; set; }
    public string AuthorId { get; set; } // stretch goal: be able to report people who send troll/hate messages by remembering who wrote replies
  }
}