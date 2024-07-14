
namespace EventCase.Application.Contract.Events.Dtos;

public class EventDto
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public string Name { get; set; }
    public DateOnly Date { get; set; } = new DateOnly();
    public TimeOnly Time { get; set; } = new TimeOnly();
    public string Location { get; set; }

}
