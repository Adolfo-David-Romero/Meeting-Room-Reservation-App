using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A3Adolfo.BusinessLogic;

namespace A3Adolfo;

public partial class AddRequestPage : ContentPage
{
    private MeetingRoom _selectedRoom;
    private ReservationRequestManager _manager;
    public AddRequestPage(MeetingRoom room, ReservationRequestManager manager)
    {
        InitializeComponent();
        _selectedRoom = room;
        _manager = manager;

        RoomLabel.Text = $"Room: {_selectedRoom.RoomNumber}";
        LayoutLabel.Text = $"Layout: {_selectedRoom.RoomLayoutType}";
        CapacityLabel.Text = $"Capacity: {_selectedRoom.SeatingCapacity}";
        Image.Source = _selectedRoom.RoomImageFileName;
    }
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        try
        {
            string requestedBy = RequestedByEntry.Text;
            string description = DescriptionEntry.Text;
            DateTime meetingDate = MeetingDatePicker.Date;
            TimeSpan startTime = StartTimePicker.Time;
            TimeSpan endTime = EndTimePicker.Time;
            int participantCount = int.Parse(ParticipantCountEntry.Text);

            // Merge Date + Time
            DateTime start = meetingDate.Date + startTime;
            DateTime end = meetingDate.Date + endTime;

            // Add reservation
            _manager.AddReservationRequest(
                _selectedRoom.RoomNumber,
                requestedBy,
                description,
                meetingDate,
                start,
                end,
                participantCount);

            await DisplayAlert("Success", "Reservation submitted!", "OK");
            await Navigation.PopAsync(); // Go back to PickRoomPage
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}