   M S B A M L   `   `   `  ����  HotelManagement*    $HotelManagement.Views.ViewMyBookings   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $
��Auto��5      $
��Auto��6   .��5      �� $��10q�6   .+�5	   
   �� $��My Bookings��6   $��20(�6'   $
��Bold"�65   $��0 0 0 10q�6G   &   System.Windows.Controls.DataGrid  5   
   -   5           Name$  dgMyBookings��5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         
IsReadOnly$
 True��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Booking ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	BookingId+6W     5      $ Room Number��6%   $	 100 6Y    6:   �� *
RoomNumber+6Y     5      $ 	Room Type��6%   $	 150 6U    68   �� *
RoomType+6U     5      $ Check-In Date��6%   $	 150 6\    6<   �� *CheckInDate+6\     5      $ Check-Out Date��6%   $	 150 6^    6=   �� *CheckOutDate+6^   5      5      5      