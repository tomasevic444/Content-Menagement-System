   M S B A M L   `   `   `  ����R  NContentManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ContentManagementSystem.WindowsContentManagementSystem.Windows  5      .    (ContentManagementSystem.Windows.UserView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:ContentManagementSystem.Windows     5        N� Title$  UserView��5      .��5
      ��  �� CornerRadius$ 12��6   ._�5   
   �� $ 10��6   $��2q�5       J� Opacity$
 0.95Q�5       �� Padding$ 15q�6   $	��600��6)   $	��500��66   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #462AD8��6#    � Offset$ 0Q�63   � 5      $ #DA34AE��6#   $
 0.75Q�63   � 5      $ #8A16C1��6#   $ 1Q�63   5      ��5      �� 5      $	 0,1&�6&   $	 1,0&�67   .��5      � $ #060531��6#   $ 0Q�63   � 5      $ #1B1448��6#   $ 1Q�63   5      ._�5      �  � RowDefinitions 5      �� 5      $
��0.4* �6$   �� 5      $
��1.2* �6$   �� 5      $
��0.2* �6$   	 � ColumnDefinitions	 5!      �� 5"      $��* �6'   63   �� 5#      $��* �6'   63   .+�5%      �� -   5        
 ��Name$
 imgView��5%      $��0��6)   $��1��66   $"��/Images/scenery_12195694.png��6F   $	��100��6l   $	��130��6y   $��0 20 0 0q�6�   $	��Top=�6�   �� 5&      -   5         ��Name$ txtName��5'      $��Holder:��5&      
�������$��24(�5)       $��Medium"�5*       $��
Montserrat)�5+       $��Center=�5,       $��Center=�5-   !   $��0��5.   !   �� 5/      $��1��6   $��0��6*   $��2��6:   .+�50      �� $��0 15 0 0q�6"    �� Orientation$ 
Horizontal=�64   .+�51      �� $��Release year: ��6    
�������$��15(�53       $��Medium"�54       $��
Montserrat)�55       $
��Left=�56       $	��Top=�57   !   �� 59      -   5        $ txtReleaseYearView��5:       $��Holder��59       
�������$��14(�5<       $��
Montserrat)�5>       $
��Left=�5?       $	��Top=�5@   !   5B      �� 5C      $��	Details: ��6    
�������$��15(�5E       $��Medium"�5F       $��
Montserrat)�5G       $
��Left=�5H       $	��Top=�5I   !   $��0 5 0 0 q�5J       ,� 5L      -   5        $��flowDocumentViewer��5L   /   .��5M      /� .T�5N      J� 5O      5P      5Q      �� 5S      -   5         ��Name$ btnBack��5S      $��0q�5T      $
��Back��5U      
�������$��12(�5W      $��
Montserrat)�5X       � Cursor$
 Hand��5Y      $��2��5Z      $��0��5[      $
��Left=�5\      $
��10 0q�5]      ��5^      �� 5_       �� 
TargetType" ��6    .�5`      ��  �� Property � �� �� Value �#462AD86;    �� Triggers 5a      P� 5b   "    P� Property �@J�IsMouseOver P� Value . . �5c   &   ��  � �� �#28AEED6C   5d   #   5f      ��5h      �� 5i       �� 
TargetType" ��6*   .R�5j      �� $	��150��6%   $��40��61   $ 20��5k   )   #��z��5l   )   ._�5m   "   �� $��Center=�63   $��Center=�5n   7   5o      5p      5r      5}      5~      5      5�      