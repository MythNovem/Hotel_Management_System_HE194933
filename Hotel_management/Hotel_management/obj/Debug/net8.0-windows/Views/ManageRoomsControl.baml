   M S B A M L   `   `   `  ����  HotelManagement.    (HotelManagement.Views.ManageRoomsControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $
��Auto��5      $
��Auto��6-   .��5      �� .+�5	   
   ��   �� Orientation$  
Horizontal=�6   $��0 0 0 10q�6.   .+�5
      �� $  Vertical=�6   $��5q�60   .+�5      �� $��Room Number��6   $
��Bold"�6/   �� 5      -   5         ��Name$ txtRoomNumber��5      $	��150��61   5      �� 5      $  Vertical=�6   $��5q�60   .+�5      �� $��	Room Type��6   $
��Bold"�6-   �� 5      -   5        $ txtRoomType��5      $	��150��6/   5      �� 5      $  Vertical=�6   $��5q�60   .+�5      �� $��Price��6   $
��Bold"�6)   �� 5      -   5        $ txtPrice��5      $	��100��6,   5      �� 5      $  Vertical=�6   $��5q�60   .+�5      �� -   5        $��Add Room��5      $��0 0 0 5q�6B   $��Bottom=�6S   �� 5      -   5         ��Name$ btnUpdateRoom��5   /   $��Update Room��6   $y�	Collapsed=�6_   $��Bottom=�6v   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgRooms��5         AutoGenerateColumns$ False��6$      CanUserAddRows$ False��6@      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6L   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *RoomId+6L     5"      $ Room Number��6%   $	 100 6Y   	 6:   �� *
RoomNumber+6Y     5#      $
 Type��6%   $	 150 6P   	 63   �� *
RoomType+6P     5$      $ Price��6%   $	 100 6N   	 64   �� *Price+6N   4  .System.Windows.Controls.DataGridTemplateColumn  5%      $ Actions��6)   $	 150 6:   
   CellTemplate
 5&      �� 5'      .R�5(      �� $  
Horizontal=�6)   $��Center=�6B   .+�5)   "   �� -   5        $
��Edit��5)   )   
����ح�$��2q�6}   
 � Tag 6O   �� *RoomId+6}   �� 5*   "   -   5        $��Delete��5*   )   
���Gc��$��2q�6~    6S   �� *RoomId+6~   5+      5,      5.      50      51      52      