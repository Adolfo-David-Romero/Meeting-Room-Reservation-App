Meeting Room Reservation App - .NET MAUI
========================================

Overview
--------

This project is a .NET MAUI application designed to allow users to browse meeting rooms, view details, make reservation requests, and manage request statuses. It was developed as a part of a course assignment and focuses on applying key concepts in mobile app development including data binding, class design, MVVM architecture principles, and exception handling.

* * * * *

Features
--------

-   View a list of meeting rooms with images and layout details

-   Make a reservation request for a selected room

-   View all requests associated with a room

-   Change the status of a reservation (Pending, Accepted, Rejected)

-   Handle errors such as conflicting bookings or booking in the past

* * * * *

Technologies Used
-----------------

-   **.NET MAUI** (Multi-platform App UI)

-   **C#**

-   **XAML** for UI layout

-   **ObservableCollection** for real-time data updates

* * * * *

Key Concepts Learned
--------------------

### 1\. **Data Binding**

-   Learned how to bind collections (like `ObservableCollection`) to `ListView` and `CollectionView`.

-   Used `BindingContext` to connect data models to UI elements.

-   Implemented `SelectedItem` and `ItemsSource` bindings for user interaction.

### 2\. **Class Design**

-   Created clean class structures like `MeetingRoom`, `ReservationRequest`, and `ReservationRequestManager`.

-   Followed the UML diagram closely to ensure relationships between classes matched expectations.

### 3\. **User Interaction & Navigation**

-   Implemented navigation between pages (e.g., from PickRoomPage to AddRequestPage).

-   Passed data between pages using constructors and managed shared state through a singleton-like manager.

### 4\. **Exception Handling**

-   Ensured the app did not crash when invalid inputs were given.

-   Caught and displayed user-friendly messages when bookings were invalid.

### 5\. **UI State Management**

-   Dynamically updated UI based on changes (e.g., Picker to change request status).

-   Used a `RefreshRequests()` method pattern to reload data as needed.

* * * * *

Folder Structure
----------------

```
/BusinessLogic
  - MeetingRoom.cs
  - ReservationRequest.cs
  - ReservationRequestManager.cs
  - RequestStatus.cs
  - RoomLayoutType.cs

/Views
  - PickRoomPage.xaml
  - AddRequestPage.xaml
  - ViewRequestsPage.xaml

/Resources
  - App.xaml
  - Images (Room images and layout icons)
```

* * * * *

How to Run
----------

1.  Open the solution in Visual Studio 2022/Rider or later.

2.  Make sure the project target is set to iOS/Android/MacCatalyst.

3.  Build and deploy to an emulator or physical device.

* * * * *

Final Notes
-----------

This project greatly improved my understanding of building interactive UIs using MAUI and C#. It reinforced key development practices like binding, exception handling, class diagram implementation, and clean navigation between views.

> "Being able to see data change in real-time and handling those updates properly made the biggest impact on my learning."
