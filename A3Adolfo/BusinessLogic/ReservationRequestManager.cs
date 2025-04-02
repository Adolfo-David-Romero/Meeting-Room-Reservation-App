using System.Collections.ObjectModel;
using Android.Service.Voice;

namespace A3Adolfo.BusinessLogic;

public class ReservationRequestManager
{ 
    private ObservableCollection<MeetingRoom> _meetingRooms; 
    private ObservableCollection<ReservationRequest> _reservationRequests;
    private int _nextRequestId = 1; 
    public ReservationRequestManager() 
    { 
        _meetingRooms = new ObservableCollection<MeetingRoom>() 
        { 
            new MeetingRoom("1", "") { SeatingCapacity = 10, RoomLayoutType = RoomLayoutType.UShape },
            new MeetingRoom("2", "") { SeatingCapacity = 15, RoomLayoutType = RoomLayoutType.Classroom },
            new MeetingRoom("3", "") { SeatingCapacity = 20, RoomLayoutType = RoomLayoutType.Auditorium },
            new MeetingRoom("4", "") { SeatingCapacity = 8, RoomLayoutType = RoomLayoutType.HollowSquare } 
        }; 
        _reservationRequests = new ObservableCollection<ReservationRequest>();
        }

        public ObservableCollection<MeetingRoom> GetMeetingRooms() => _meetingRooms;
        public ObservableCollection<ReservationRequest> GetReservationRequests() => _reservationRequests;

        public void AddMeetingRoom(MeetingRoom room)
        {
            if (!_meetingRooms.Any(r => r.RoomNumber.Equals(room.RoomNumber, StringComparison.OrdinalIgnoreCase)))
            {
                _meetingRooms.Add(room);
            }
        }

        public MeetingRoom GetMeetingRoomByNumber(string roomNumber)
        {
            return _meetingRooms.FirstOrDefault(r => r.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase));
        }

        public bool AddReservationRequest(string roomNumber, string requestedBy, string description, DateTime meetingDate, DateTime requestedDate, DateTime startTime, DateTime endTime, int participantCount)
        {
            var room = GetMeetingRoomByNumber(roomNumber);
            if (room == null || participantCount > room.SeatingCapacity)
                return false;

            var request = new ReservationRequest(
                _nextRequestId++,
                requestedBy,
                description,
                meetingDate,
                requestedDate,
                startTime,
                endTime,
                participantCount,
                RequestStatus.Pending,
                room
            );

            _reservationRequests.Add(request);
            return true;
        }

        public ObservableCollection<ReservationRequest> GetRequestsByRoomNumber(string roomNumber)
        {
            var requests = _reservationRequests
                .Where(r => r.MeetingRoom.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return new ObservableCollection<ReservationRequest>(requests);
        }

        public ReservationRequest GetReservationById(int id)
        {
            return _reservationRequests.FirstOrDefault(r => r.RequestId == id);
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
                // RequestStatus could be updated manually later
            }
            else
            {
                _reservationRequests.Add(updated);
            }
        }
}