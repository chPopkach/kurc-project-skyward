   M S B A M L   `   `   `  ����B  >Skyward, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SkywardSkyward  5   	   -clr-namespace:Skyward.ToolsSkyward.Tools  6-       Skyward.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Skyward     5   	   -toolsclr-namespace:Skyward.Tools     6-     � Title$  Skyward��5   	   $	��350��6   $	��600��6&    � WindowStartupLocation$ CenterScreen=�62    � WindowStyle$
 None=�6W    � 
ResizeMode$ NoResize=�6j   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � -   5        $��ToolBar��5      $��3��6   64   �� 5   
   
���   �   login_label#���   6#   $��1��6K   $��1��6[   $��Center=�6h   $��Bottom=�6�   �� 5   
   -   5         ��Name$ textbox_Login��5      $��0,5,0,0q�6)   $��1��6V   $��2��6f   $��25��6s   $	��Top=�6   $��18(�6�   $��Center=�6�   $	��200��6�   ��6:   �� *
User.Login+6�   �� 5   
    J� IsHitTestVisible$ False��6   $�� ��6-   $��1��65   $��2��6E   $	��Top=�6R   $��18(�6j   $��Center=�6x   $	��200��6�   $��0,5,0,0q�6�   
���������5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � y�
 �� Value$
 	Collapsed=�63    �� Triggers 5      �� 5       �� Binding 6&   �� *Text+ �� ElementName$ textbox_Login�� �� Value  6Z   .a�5      �� 	 � y�$
 Visible=�6;   5       5"      5$      �� 5%   
   
���   �  password_label#���  6#   $��1��6N   $��2��6^   $��Center=�6k   $
��Auto��6�   $��Bottom=�6�   G� 5&   
   -   5        $��textBox_Password��5&   '   $��0,5,0,0q�6   
���   �$��1��6R   $��3��6b   $��25��6o   $��18(�6{   $	��Top=�6�   $��Center=�6�   $	��200��6�   �� 5'   
   $��1��6m   $��3��6}     auth_button#���  6�   $��Center=�6�   $	��Top=�6�   $��0,45,0,0q�6�   $��2��6�   ��6   �� *Authorization+��63   �� $ textBox_Password��6�   �� 5(   
   -   5        $��0��5(   (   $��0��68     changeLanguage_button#���  6E   $	��150��6w   $	��Top=�6�   $��0,45,0,0q�6�   $��2��6�   5)      5*      