   M S B A M L   `   `   `  ����B  >Skyward, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Skyward.ViewsSkyward.Views  5   	   $    Skyward.Views.ConsultantWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Skyward.Views     5   	     � Title$   ��5   	   $	��600��6   $	��800��6"   $	��600��61   $	��800��6>   $
��1080��6J   $
��1920��6[    � 
ResizeMode$ NoResize=�6k    � WindowStartupLocation$ CenterScreen=�6�    � WindowStyle$
 None=�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $	��200 �6    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��50 �6   �� 5      .+�5   
   � -   5        $��ToolBar��5      $��3��6   64   &   System.Windows.Controls.DataGrid  5   
   -   5        $��Humens_table��5   C   $��	10,0,0,10q�6   $��2��6&   $��0��63   $
��True��6W      AutoGenerateColumns$ False��6|      
IsReadOnly$
 True��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   	   RowBackground
	 �����
   AlternatingRowBackground

 �������6�   �� *Humens+ �� SelectedItem 6�   �� *Humen+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5          firstName_dataGridTextColumn,  &System.Windows.Controls.DataGridColumn   Header# �   6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6]   �� *	FirstName+6}     5        name_dataGridTextColumn# �  6%    6X   �� *Name+6s     5        lastName_dataGridTextColumn# �  6%    6\   �� *
LastName+6{     5        phone_dataGridTextColumn# �  6%    6Y   �� *Phone+6u     5        age_dataGridTextColumn# �  6%    6W   �� *Age+6q      RowDetailsTemplate 5      �� 5      .R�5      �� 
���������6   �� *ScheduleHumens+��5      �� 5       .R�5!   "   � 
������� 5"   &   �� 5#   *   $��35 �68   �� 5$   *   $��35 �68   .+�5&   &   � $��0��6+   
������� 5'   *   �� 5(   .   $
��Auto �6?   �� 5)   .   $
��Auto �6?   �� 5*   .   $
��Auto �6?   �� 5+   .   $
��Auto �6?   .+�5-   *   �� 
���   �  freeFrom_label#���  6C   $��0��6n   6�   �� 5.   *   
���   �$��1��6�   ��6G   �� *Schedule.WorkTimeStart+ �� StringFormat$ HH:mm��6�   �� 5/   *   
���   �  to_label#���  6C   $��2��6h   6z   �� 50   *   
���   �$��3��6�   ��6G   �� *Schedule.WorkTimeEnd+$ HH:mm��6�   51   '   � 52   &   $��1��6+   
������� 53   *   �� 54   .   $
��Auto �6?   �� 55   .   $
��Auto �6?   .+�57   *   �� 
���   �  trainingDays_label#���  6C   $��0��6r   6�   �� 58   *   
���   �$��1��6j   ��6G   �� *Schedule.WorkDays+6j   59   '   5:   #   5;      5=      5>      5@      �� 5A   
   $��1��6     search_label#���  6   $��Center=�6F   $��Center=�6c   �� 5B   
   -   5        $3��-DynamicSearchTextBoxConsultantWindowViewModel��5B      $��0��6G   $��1��6W   $�� ��6�   $��18(�6�   $��340,10,10,10q�6�   $	��250��6�   $��30��6�   �� 5C   
    J� IsHitTestVisible$ False��6   $��Иван Иванович��6-   $��30��6B   $��1��6N   $��0��6[   $��Center=�6k   $��18(�6�   $
��Left=�6�   $	��250��6�   $��	345,0,0,0q�6�   
���������5D      �� 5E       �� 
TargetType" ��6   .�5F      ��  �� Property � y� �� Value$ 	Collapsed=�63    �� Triggers 5G      �� 5H       �� Binding 6&   �� *Text+ �� ElementName$3 -DynamicSearchTextBoxConsultantWindowViewModel�� �� Value  6z   .a�5I      ��  � y�$ Visible=�6;   5J      5L      5N      �� 5O   
   $��1��6    	 reset_button#��� 	 6   $
��Left=�6G   $��10,0,0,0q�6b   ��6t   �� *	StartView+6�   �� 5P   
   $��1��6    
 
all_button#��� 
 6   $
��Left=�6E   $��	140,0,0,0q�6`   ��6s   �� *AllClientsView+6�   �� 5Q   
   $��1��6     logOut_button#���  6   $��1��6H   $��Center=�6X   ��6u   �� *TerminateSession+6�   �� 5R   
   $��2��6     insert_button#���  6   $
��Auto��6H   $��1��6U   $��0,10,0,0q�6e   $��Center=�6w   $	��Top=�6�   ��6�   �� *OpenFormAddClient+6�   �� 5S   
   $��2��6     change_button#���  6   $
��Auto��6H   $��1��6U   $��0,60,0,0q�6e   $��Center=�6w   $	��Top=�6�   ��6�   �� *OpenFormChangeSchedule+6�   �� 5T   
   $��2��6     GenerateAReport_button#���  6   $
��Auto��6Q   $��1��6^   $��	0,110,0,0q�6n   $��Center=�6�   $	��Top=�6�   ��6�   �� *GenerateAReport+6�   �� 5U   
   $��2��6   $��1��6     allConsultants_button#���  6.   $��	0,0,0,110q�6`   $��Center=�6s   $��Bottom=�6�   ��6�   �� *AllConsultantsView+6�   �� 5V   
   $��2��6   $��1��6     allTrainers_button#���  6.   $��0,0,0,60q�6]   $��Center=�6o   $��Bottom=�6�   ��6�   �� *AllTrainersView+6�   �� 5W   
   $��2��6   $��1��6     allTickets_button#���  6.   $��0,0,0,10q�6\   $��Center=�6n   $��Bottom=�6�   ��6�   �� *AllTypesTickets+6�   5X      5Y      