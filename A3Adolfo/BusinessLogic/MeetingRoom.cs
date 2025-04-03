namespace A3Adolfo.BusinessLogic;

public class MeetingRoom
{
    //fields
    private string _roomNumber; //Required
    private int _seatingCapacity;
    private RoomLayoutType _roomLayoutType;
    private string _roomImageFileName; //Required
    private string _roomTypeIcon;
    
    //constructor
    /// <summary> Represents the possible meeting venues. </summary>
    public MeetingRoom(string roomNumber, string roomImageFileName)
    {
        //Required
        this._roomNumber = roomNumber;
        this._roomImageFileName = roomImageFileName;
        //defualts
        this.SeatingCapacity = 1; 
        this.RoomLayoutType = RoomLayoutType.Classroom; 
    }
    
    //Properties
    public string RoomNumber
    {
        get => _roomNumber;
        set
        {
            // if (string.IsNullOrWhiteSpace(value))
            //     throw new ArgumentException("Required: Room number.");
            _roomNumber = value;
        }
    }
    public int SeatingCapacity
    {
        get => _seatingCapacity;
        set
        {
            // if (value <= 0)
            //     throw new ArgumentException("Seating capacity must be greater than 0.");
            _seatingCapacity = value;
        }
    }
    public RoomLayoutType RoomLayoutType
    {
        get => _roomLayoutType;
        set => _roomLayoutType = value;
    }
    public string RoomImageFileName
    {
        get => _roomImageFileName;
        set
        {
            // if (string.IsNullOrWhiteSpace(value))
            //     throw new ArgumentException("Required: Room image file name.");
            _roomImageFileName = value;
        }
    }
    public string RoomTypeIcon => $"{RoomLayoutType.ToString().ToLower()}_icon"; //Computed Property
}