using Java.Sql;

namespace A3Adolfo.BusinessLogic;

public class ReservationRequest
{
    // Properties
    public int RequestId { get; private set; }
    public string RequestedBy { get; private set; }
    public string Description { get; private set; }
    public DateTime MeetingDate { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public int ParticipantCount { get; private set; }
    public RequestStatus RequestStatus { get; private set; }
    public MeetingRoom MeetingRoom { get; private set; }

    // Constructor
    public ReservationRequest(int requestId, string requestedBy, string description, DateTime meetingDate, DateTime startTime, DateTime endTime, int participantCount, MeetingRoom meetingRoom)
    {
        //error checks
        if (string.IsNullOrWhiteSpace(requestedBy))
            throw new ArgumentException("Required: RequestedBy.");
        if (participantCount <= 0)
            throw new ArgumentException("Participant count must be greater than 0.");
        if (endTime <= startTime)
            throw new ArgumentException("End time must be after start time.");
        if (meetingRoom == null)
            throw new ArgumentException("Required: MeetingRoom.");

        RequestId = requestId;
        RequestedBy = requestedBy;
        Description = description;
        MeetingDate = meetingDate.Date;
        StartTime = startTime;
        EndTime = endTime;
        ParticipantCount = participantCount;
        MeetingRoom = meetingRoom;
        RequestStatus = RequestStatus.Pending; 
    }
}