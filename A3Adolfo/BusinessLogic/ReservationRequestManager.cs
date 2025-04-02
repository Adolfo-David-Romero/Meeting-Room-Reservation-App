using System.Collections.ObjectModel;

namespace A3Adolfo.BusinessLogic;

public class ReservationRequestManager
{
    public ObservableCollection<MeetingRoom> _meetingRooms;
    public ObservableCollection<ReservationRequest> _reservationRequests;
    private int _nextRequestId = 1;

    public ReservationRequestManager()
    {
        _meetingRooms = new ObservableCollection<MeetingRoom>();
        _reservationRequests = new ObservableCollection<ReservationRequest>();
    }

    public ObservableCollection<MeetingRoom> GetMeetingRooms() => _meetingRooms;
    public ObservableCollection<ReservationRequest> GetReservationRequests() => _reservationRequests;

    public void AddMeetingRoom(MeetingRoom room)
    {
        if (!_meetingRooms.Any(r => r.RoomNumber.Equals(room.RoomNumber, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Added Meeting Room: "+room.RoomNumber);
            _meetingRooms.Add(room);
        }
        else
        {
            throw new BookingException($"Room number {room.RoomNumber} already exists.");
        }
    }

    public MeetingRoom GetMeetingRoomByNumber(string roomNumber)
    {
        return _meetingRooms.FirstOrDefault(r => r.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase));
    }

    public bool AddReservationRequest(string roomNumber, string requestedBy, string description, DateTime meetingDate, DateTime startTime, DateTime endTime, int participantCount)
    {
        var room = GetMeetingRoomByNumber(roomNumber);
        if (room == null || participantCount > room.SeatingCapacity)
            throw new BookingException("Room does not exist or capacity is exceeded");

        var request = new ReservationRequest(
            _nextRequestId++,
            requestedBy,
            description,
            meetingDate,
            startTime,
            endTime,
            participantCount,
            RequestStatus.Pending,
            room
        );

        _reservationRequests.Add(request);
        return true;
    }

    // public ObservableCollection<ReservationRequest> GetRequestsByRoomNumber(string roomNumber)
    // {
    //     var requests = _reservationRequests
    //         .Where(r => r.MeetingRoom.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase))
    //         .ToList();
    //
    //     return new ObservableCollection<ReservationRequest>(requests);
    // }

    public ReservationRequest GetReservationById(int id)
    {
        foreach (var reservation in _reservationRequests)
        {
            if (reservation.RequestId == id)
            {
                return reservation;
            }
        }
        throw new BookingException("Reservation: "+id+", Not found");
    }

    public bool DeleteReservation(int id)
    {
        var request = GetReservationById(id);
        if (request != null)
        {
            _reservationRequests.Remove(request);
            return true;
        }

        return false;
    }

    public void UpdateReservation(ReservationRequest updated)
    {
        var existing = GetReservationById(updated.RequestId);
        if (existing != null)
        {
            existing.RequestedBy = updated.RequestedBy;
            existing.Description = updated.Description;
            existing.MeetingDate = updated.MeetingDate;
            existing.StartTime = updated.StartTime;
            existing.EndTime = updated.EndTime;
            existing.ParticipantCount = updated.ParticipantCount;
            existing.MeetingRoom = updated.MeetingRoom;
        }
        else
        {
            _reservationRequests.Add(updated);
        }
    }

    public ObservableCollection<ReservationRequest> GetReservationRequsts()
    {
        return _reservationRequests;
    }
}