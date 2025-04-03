using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A3Adolfo.BusinessLogic;

namespace A3Adolfo;

public partial class ViewRequestsPage : ContentPage
{
    private MeetingRoom _selectedRoom;
    private ReservationRequestManager _manager;

    public ViewRequestsPage(MeetingRoom room, ReservationRequestManager manager)
    {
        InitializeComponent();
        _selectedRoom = room;
        _manager = manager;

        RoomLabel.Text = $"Room: {_selectedRoom.RoomNumber}";
        
        var requests = _manager
            .GetReservationRequests()
            .Where(r => r.MeetingRoom.RoomNumber == _selectedRoom.RoomNumber)
            .ToList();

        RequestsCollectionView.ItemsSource = requests;
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}