using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A3Adolfo.BusinessLogic;

namespace A3Adolfo;

public partial class ViewRequestsPage : ContentPage
{
    public List<RequestStatus> StatusOptions { get; set; }  //public list of statuses for the Picker binding
    private MeetingRoom _selectedRoom;
    private ReservationRequestManager _manager;
    

    public ViewRequestsPage(MeetingRoom room, ReservationRequestManager manager)
    {
        InitializeComponent();
        _selectedRoom = room;
        _manager = manager;

        RoomLabel.Text = $"Room: {_selectedRoom.RoomNumber}";
        StatusOptions = Enum.GetValues(typeof(RequestStatus)).Cast<RequestStatus>().ToList();
        BindingContext = this; 

        RefreshRequests();
    }


    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void OnStatusChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        if (picker?.SelectedItem is RequestStatus newStatus &&
            picker.BindingContext is ReservationRequest request)
        {
            try
            {
                // Only attempt to change if it's actually different
                if (request.RequestStatus != newStatus)
                {
                    _manager.ChangeStatus(request.RequestId, newStatus);
                    await DisplayAlert("Status Updated", $"Status changed to {newStatus}.", "OK");
                }
            }
            catch (BookingException ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                picker.SelectedItem = request.RequestStatus; // Revert to actual state
            }
        }
    }



    
    //Used to refresh the page after action is taken 
    private void RefreshRequests()
    {
        var requests = _manager
            .GetReservationRequests()
            .Where(r => r.MeetingRoom.RoomNumber == _selectedRoom.RoomNumber)
            .ToList();

        RequestsCollectionView.ItemsSource = null;
        RequestsCollectionView.ItemsSource = requests;
    }


}