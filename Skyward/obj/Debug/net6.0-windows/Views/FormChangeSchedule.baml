   M S B A M L   `   `   `  ����B  >Skyward, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Skyward.ViewsSkyward.Views  5   	   &     Skyward.Views.FormChangeSchedule   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Skyward.Views     5   	     � Title$  FormAddClient��5   	   $	��300��6   $	��400��6,    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N    � WindowStyle$
 None=�6s   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   � -   5        $��ToolBar��5      $��3��6   64   �� 5   
   $��	15,4,15,0q�6      
time_label#���   6#   $��0��6J   $��3��6Z   $��Center=�6g   $	��Top=�6�   6�   �� 5   
   $	��100��6h   $��
8,42,159,0q�6t   $	��Top=�6�   $��0��6�   $��3��6�   ��6   �� *
TimeHour+ �� SelectedItem 64   �� *TimeHourStart+ �� Mode$ TwoWay=�6�   �� 5   
   $	��100��6i   $��
158,44,9,0q�6u   $	��Top=�6�   $��0��6�   $��3��6�   ��6   �� *
TimeHour+ 64   �� *TimeHourFinish+$ TwoWay=�6�   �� 5   
   $	��200��6     change_button#���  6G   $��Bottom=�6q   $��30q�6�   $��2��6�   $��4��6�   ��6   �� *ChangeScheduleCommand+6�   �� 5   
   $��
15,78,15,0q�6     trainingDays_label#���  6$   $��0��6S   $��3��6c   $��Center=�6p   $	��Top=�6�   �� 5   
   -   5        $��button_Product��5      $��+��6E   $��18(�6Q   $��1��6_   $��0��6l   $
��Left=�6|   $	��Top=�6�   $��36��6�   $��34��6�   $��224,126,0,0q�6�   ��6'   �� *	InsertDay+6�   �� 5   
   $	��100��6^   $��108,126,192,0q�6j   $	��Top=�6�   $��0��6�   $��1��6�   ��6   �� *
WorkDays+ 64   �� *Day+$ TwoWay=�6�   5      5      