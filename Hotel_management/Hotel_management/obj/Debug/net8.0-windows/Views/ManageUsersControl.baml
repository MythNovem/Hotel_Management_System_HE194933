   M S B A M L   `   `   `  ����  HotelManagement.    (HotelManagement.Views.ManageUsersControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $
��Auto��5      $
��Auto��6-   .��5      �� .+�5	   
   ��   �� Orientation$  
Horizontal=�6   $��0 0 0 10q�6.   .+�5
      �� $  Vertical=�6   $��5q�60   .+�5      �� $��Username��6   $
��Bold"�6,   �� 5      -   5         ��Name$ txtUsername��5      $	��150��6/   5      �� 5      $  Vertical=�6   $��5q�60   .+�5      �� $��Password��6   $
��Bold"�6,   G� 5      -   5         G�Name$ txtPassword��5      $	��150��63   5      �� 5      $  Vertical=�6   $��5q�60   .+�5      �� $
��Role��6   $
��Bold"�6(   �� 5      -   5         ��Name$ cbRole��5      $	��120��6+   5      �� 5      $  Vertical=�6   $��5q�60   .+�5      �� -   5        $��Add User��5      $��0 0 0 5q�6B   $��Bottom=�6S   �� 5      -   5         ��Name$ 	btnUpdate��5   /   $��Update User��6   $��0q�6[   $��Bottom=�6f   $y�	Collapsed=�6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgUsers��5         AutoGenerateColumns$ False��6$      CanUserAddRows$ False��6@      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *UserId+6L     5"      $	 Username��6%   $	
 150 6T    67   �� *
Username+6T     5#      $
	 Role��6%   $	
 100 6U    63   �� *Role.RoleName+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5$      $	 Actions��6)   $	
 150 6:      CellTemplate 5%      �� 5&      .R�5'      �� $  
Horizontal=�6)   $��Center=�6B   .+�5(   "   �� -   5        $
��Edit��5(   )   
����ح�$��2q�6}   
 � Tag 6O   �� *UserId+6}   �� 5)   "   -   5        $��Delete��5)   )   
���Gc��$��2q�6~    6S   �� *UserId+6~   5*      5+      5-      5/      50      51      