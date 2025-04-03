using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A3Adolfo.BusinessLogic;

namespace A3Adolfo;

/// <summary> Page that displays all rooms. </summary>
public partial class PickRoomPage : ContentPage
{
    public ObservableCollection<MeetingRoom> MeetingRooms { get; set; }
    private ReservationRequestManager _manager = new ReservationRequestManager();
    public MeetingRoom SelectedRoom { get; set; } //Represents the user's selected room 

    public PickRoomPage()
    {
        //Four items (hard coded)
        _manager.AddMeetingRoom(new MeetingRoom("1", "auditorium_image.jpeg") { SeatingCapacity = 10, RoomLayoutType = RoomLayoutType.HollowSquare });
        _manager.AddMeetingRoom(new MeetingRoom("2", "banquet_image.jpeg") { SeatingCapacity = 15, RoomLayoutType = RoomLayoutType.UShape });
        _manager.AddMeetingRoom(new MeetingRoom("3", "classroom_image.jpeg") { SeatingCapacity = 20, RoomLayoutType = RoomLayoutType.Classroom });
        _manager.AddMeetingRoom(new MeetingRoom("4", "auditorium_image.jpeg") { SeatingCapacity = 8, RoomLayoutType = RoomLayoutType.Auditorium });

        MeetingRooms = new ObservableCollection<MeetingRoom>(_manager.GetMeetingRooms());

        BindingContext = this;
        InitializeComponent();

        //select first item (to automatically display first image)
        if (MeetingRooms.Any())
        {
            SelectedRoom = MeetingRooms[0];
            RoomListView.SelectedItem = SelectedRoom;
            OnPropertyChanged(nameof(SelectedRoom));
        }
    }

    private void RoomListView_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        SelectedRoom = e.SelectedItem as MeetingRoom;
        OnPropertyChanged(nameof(SelectedRoom)); // Notifies UI to update binding
    }

    private async void OnAddBtnClicked(object? sender, EventArgs e)
    {
        if (SelectedRoom == null)
        {
            await DisplayAlert("Error", "Please select a room first.", "OK");
            return;
        }

        await Navigation.PushAsync(new AddRequestPage(SelectedRoom, _manager)); //Navigates
    }

    private async void ViewRequestBtnClicked(object? sender, EventArgs e)
    {
        if (SelectedRoom == null)
        {
            await DisplayAlert("Error", "Please select a room first.", "OK");
            return;
        }

        await Navigation.PushAsync(new ViewRequestsPage(SelectedRoom, _manager)); //Navigates
    }
}