   M S B A M L   `   `   `  ����  HotelManagement8    2HotelManagement.Views.CheckRoomAvailabilityControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $
��Auto��5      $
��Auto��6-   .��5      �� $��10q�6   .+�5	   
   ��   �� Orientation$  
Horizontal=�6   $��0 0 0 10q�6.   .+�5
      �� $  Vertical=�6   $��5q�60   .+�5      �� $��Check-in Date��6   $
��Bold"�61   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 	dpCheckIn��5      $	��150��60   5      �� 5      $  Vertical=�6   $��5q�60   .+�5      �� $��Check-out Date��6   $
��Bold"�62     5      -   5        $ 
dpCheckOut��5      $	��150��61   5      �� 5      -   5        $��Check Availability��5      $��	10 20 0 0q�6R   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgAvailableRooms��5         AutoGenerateColumns$ False��6-      CanUserAddRows$ False��6I      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Room ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *RoomId+6Q     5      $ Room Number��6%   $	 120 6Y    6:   �� *
RoomNumber+6Y     5      $
 Type��6%   $	 150 6P    63   �� *
RoomType+6P     5      $ Price��6%   $	 100 6N    64   �� *Price+6N   5      5      5       