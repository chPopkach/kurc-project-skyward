   M S B A M L   `   `   `  ����B  >Skyward, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Skyward.ViewsSkyward.Views  5   	   -    'Skyward.Views.ViewAllTypesTicketsWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Skyward.Views     5   	     � Title$   ��5   	   $	��400��6   $	��400��6    � 
ResizeMode$ NoResize=�6+    � WindowStartupLocation$ CenterScreen=�6A    � WindowStyle$
 None=�6f   .��5	      �  � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      .+�5   
   � -   5        $��ToolBar��5      $��3��6   64   &   System.Windows.Controls.DataGrid  5   
   -   5        $��Typetickets_table��5   <   $��10q�6   $��2��6   $��0��6,   $
��True��6U      AutoGenerateColumns$ False��6z      
IsReadOnly$
 True��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   	   RowBackground
	 �����
   AlternatingRowBackground

 �����   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         delay_dataGridTextColumn,  &System.Windows.Controls.DataGridColumn   Header# �   6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Y   �� *type_ticket+6{     5        price_dataGridTextColumn# �  6%    6Y   �� *price+6u   5      5      5      