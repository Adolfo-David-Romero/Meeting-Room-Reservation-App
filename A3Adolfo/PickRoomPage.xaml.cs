using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A3Adolfo.BusinessLogic;

namespace A3Adolfo;

public partial class PickRoomPage : ContentPage
{
    public ObservableCollection<MeetingRoom> MeetingRooms { get; set; }
    private ReservationRequestManager _manager = new ReservationRequestManager();
    public PickRoomPage()
    {
        
        _manager.AddMeetingRoom(new MeetingRoom("1", "auditorium_image.jpeg") { SeatingCapacity = 10, RoomLayoutType = RoomLayoutType.HollowSquare });
        _manager.AddMeetingRoom(new MeetingRoom("2", "banquet_image.jpeg") { SeatingCapacity = 15, RoomLayoutType = RoomLayoutType.UShape });
        _manager.AddMeetingRoom(new MeetingRoom("3", "classroom_image.jpeg") { SeatingCapacity = 20, RoomLayoutType = RoomLayoutType.Classroom });
        _manager.AddMeetingRoom(new MeetingRoom("4", "auditorium_image.jpeg") { SeatingCapacity = 8, RoomLayoutType = RoomLayoutType.Auditorium });
        
        // Initialize bindable collection
        MeetingRooms = new ObservableCollection<MeetingRoom>(_manager.GetMeetingRooms());
        BindingContext = this;
        InitializeComponent();
    }

    private void RoomListView_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        throw new NotImplementedException();
    }
}