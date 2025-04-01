namespace A3Adolfo.BusinessLogic;

public class MeetingRoom
{
    //fields
    private string _roomNumber; //Required
    private int _seatingCapacity;
    private RoomLayoutType _roomLayoutType;
    private string _roomImageFileName_; //Required
    private string _roomTypeIcon; //Temp
    
    //constructor
    public MeetingRoom(string roomNumber, int seatingCapacity, RoomLayoutType roomLayoutType, string roomImageFileName, string roomTypeIcon)
    {
        this._roomNumber = roomNumber;
        this._seatingCapacity = seatingCapacity;
        this._roomLayoutType = roomLayoutType;
        this._roomImageFileName_ = roomImageFileName;
        this._roomTypeIcon = roomTypeIcon;
    }

}