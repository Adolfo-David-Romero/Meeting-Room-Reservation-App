namespace A3Adolfo.BusinessLogic;

/// <summary> Represents the request of a room booking. </summary>
public class ReservationRequest
{
    //fields
    private int _requestId;
    private string _requestedBy;
    private string _description;
    private DateTime _meetingDate;
    private DateTime _startTime;
    private DateTime _endTime;
    private int _participantCount;
    private RequestStatus _requestStatus;
    private MeetingRoom _meetingRoom;
    
    // Constructor
    public ReservationRequest(int requestId, string requestedBy, string description, DateTime meetingDate, DateTime startTime, DateTime endTime, int participantCount, RequestStatus requestStatus, MeetingRoom meetingRoom)
    {
        this._requestId = requestId;
        this._requestedBy = requestedBy;
        this._description = description;
        this._meetingDate = meetingDate;
        this._startTime = startTime;
        this._endTime = endTime;
        this._participantCount = participantCount;
        this._requestStatus = requestStatus; 
        this._meetingRoom = meetingRoom;
    }
    
    // Properties
    public int RequestId
        {
            get => _requestId;
            set => _requestId = value;
        }

        public string RequestedBy
        {
            get => _requestedBy;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new BookingException("Required: RequestedBy.");
                _requestedBy = value;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new BookingException("Required: Description.");
                _description = value;
            }
        }

        public DateTime MeetingDate
        {
            get => _meetingDate;
            set => _meetingDate = value.Date;
        }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                if (_endTime != default && value >= _endTime)
                    throw new BookingException("StartTime must be before EndTime.");
                _startTime = value;
            }
        }

        public DateTime EndTime
        {
            get => _endTime;
            set
            {
                if (_startTime != default && value <= _startTime)
                    throw new BookingException("EndTime must be after StartTime.");
                _endTime = value;
            }
        }

        public int ParticipantCount
        {
            get => _participantCount;
            set
            {
                if (value <= 0)
                    throw new BookingException("ParticipantCount must be greater than 0.");
                _participantCount = value;
            }
        }

        public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;

        public MeetingRoom MeetingRoom
        {
            get => _meetingRoom;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(MeetingRoom), "Required: MeetingRoom.");
                _meetingRoom = value;
            }
        }
}