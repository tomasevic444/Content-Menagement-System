   M S B A M L   `   `   `  ����R  NContentManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ContentManagementSystemContentManagementSystem  5   	   (    "ContentManagementSystem.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ContentManagementSystem     5   	   -   5          � Title$%  Photo editing software products��5   	   $	��700��5	   	   $
��1000��6    � Icon$ Images/logo2.png��5
   	    � 
ResizeMode$ NoResize=�5   	   
������  � WindowStyle$
 None=�5      .��5      �� -   5         ��Name$ myCanvas��5      .+�5   
   F� 
���   �$��2��6   ��5      B� 5      .��5      E�  E� 
StartPoint$
 0,50&�6!   .��5      ��  �� Point$ 0,650&�6&   �� 5       �� Size$ 50,50��6%    �� SweepDirection$ Counterclockwise=�62   	 �� 
IsLargeArc	 .  
 �� Point$
 50,700&�6g   �� 5      $ 950,700&�6&   �� 5      $ 50,50��6%   $ Counterclockwise=�62   	 .  $
 1000,650&�6g   �� 5      $ 1000,50&�6&   �� 5      $ 50,50��6%   $ Counterclockwise=�62   	 .  $
 950,0&�6g   �� 5      $
 50,0&�6&   �� 5      $ 50,50��6%   $ Counterclockwise=�62   	 .  $

 0,50&�6g   5      5       ��5"      �� 5#       �� ImageSource$ /Images/background.jpg��6   5&      � 5'   
   ��6   �� *ActualWidth+ �� ElementName$ myCanvas����5(      �� *ActualHeight+$ myCanvas��.+�5)      ��  �� Orientation$ Vertical=�6   $	��Top=�61   $��60��6I   .+�5*      �� -   5         ��Name$ btnLogfdbfin��5*      $��0q�5+      
�������$��12(�5-      $��Right=�5/      $��
Montserrat)�50      $��X��51      $
��Bold"�52      $	��Top=�53      $��20q�54      ��55      �� 56       �� 
TargetType" ��6    .�57      ��  �� Property � �� �� Value �#731a606;    �� Triggers 58      P� 59   "    P� Property �@J�IsMouseOver P� Value . . �5:   &   ��  � �� �#de2c3e6C   5;   #   5=      ��5?      �� 5@       �� 
TargetType" ��6*   .R�5A      �� $��30��6%   $��30��60    �� CornerRadius$ 30��5B   )   #��z��5C   )   ._�5D   "   �� $��Center=�63   $��Center=�5E   7   5F      5G      5I      5K       � 5M      -   5          �Name$ FrameHolder��5N        � NavigationUIVisibility$ Hidden=�5O        � Source$ Windows/Login.xaml?�5P      $��Center=�5Q      $��Center=�5R      5S      5T      5U      5V      