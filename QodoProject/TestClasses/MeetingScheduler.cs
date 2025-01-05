
using System;
using QualityExam.TestClasses.Be;

namespace TestClasses;
public class MeetingScheduler
{
    public bool ScheduleMeeting(List<Participant> participants, List<Room> rooms, DateTime startTime, int durationMinutes)
    {
        var endTime = startTime.AddMinutes(durationMinutes);

        foreach (var room in rooms)
        {
            if (room.IsAvailable(startTime, endTime))
            {
                bool allParticipantsAvailable = participants.All(p => p.IsAvailable(startTime, endTime));
                if (allParticipantsAvailable)
                {
                    room.Book(startTime, endTime);
                    foreach (var participant in participants)
                    {
                        participant.Book(startTime, endTime);
                    }
                    return true;
                }
            }
        }
        return false;
    }
}