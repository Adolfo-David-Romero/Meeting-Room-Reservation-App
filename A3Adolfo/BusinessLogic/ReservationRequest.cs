using Java.Sql;

namespace A3Adolfo.BusinessLogic;

public class ReservationRequest
{
    //fields
    private int _requestId;
    private string _requestBy;
    private string _descripton;
    private string _meetingDate;
    private string _startTime;
    private string _endTime;
    private int _partcipantCount;
    private RequestStatus _requestStatus;
    
    //constructor
    public ReservationRequest(int requestId, string requestBy, string descripton, string meetingDate, string startTime, string endTime, int partcipantCount, RequestStatus requestStatus)
    {
        this._requestId = requestId;
        this._requestBy = requestBy;
        this._descripton = descripton;
        this._meetingDate = meetingDate;
        this._startTime = startTime;
        this._endTime = endTime;
        this._partcipantCount = partcipantCount;
        this._requestStatus = requestStatus;
    }
}