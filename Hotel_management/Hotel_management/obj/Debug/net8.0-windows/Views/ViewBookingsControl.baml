   M S B A M L   `   `   `  ����  HotelManagement/    )HotelManagement.Views.ViewBookingsControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $
��Auto��5      $
��Auto��6-   .��5      � $��10q�6   .+�5	   
   &   System.Windows.Controls.DataGrid  -   5           Name$  
dgBookings��5	         AutoGenerateColumns$ False��6'      
IsReadOnly$
 True��6C      Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Booking ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	BookingId+6W     5      $ Room Number��6%   $	 100 6Y    6:   �� *
RoomNumber+6Y     5      $ Customer��6%   $	 150 6T    67   �� *
FullName+6T     5      $ Check-in��6%   $	 120 6g    67   �� *CheckInDate+ �� StringFormat$ d��6g     5      $ 	Check-out��6%   $	 120 6i    68   �� *CheckOutDate+$ d��6i   5      5      5      