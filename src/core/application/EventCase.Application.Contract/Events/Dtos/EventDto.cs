
namespace EventCase.Application.Contract.Events.Dtos;

public class EventDto
{
    public Guid MemberId { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public TimeOnly Time { get; set; }
    public string Location { get; set; }
}
