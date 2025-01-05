using System;

namespace QualityExam.TestClasses.Be;

public class Room
{
    public required List<TimeSlot> Availability { get; set; }

    public bool IsAvailable(DateTime startTime, DateTime endTime)
    {
        return Availability.Any(slot => slot.StartTime <= startTime && slot.EndTime >= endTime);
    }

    public void Book(DateTime startTime, DateTime endTime)
    {
        Availability.RemoveAll(slot => slot.StartTime <= startTime && slot.EndTime >= endTime);
    }
}
