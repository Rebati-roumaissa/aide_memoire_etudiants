   M S B A M L   `   `   `  ����K  GWpfApplication12, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApplication12WpfApplication12  5      !    WpfApplication12.carnet_adr   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:WpfApplication12     5      ` \Xceed.Wpf.Toolkit, Version=3.3.17121.18230, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        N� Title$  
carnet_adr��5
       � 	Resources 5         	ListStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Padding J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value �� 
TargetName��%f  &	        �� 5   
   " ��6"   .�5      -   5        �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ _Border��6!   $ 2q�5   !    . ._�5      �� 5      	 5      P� 5      
 �@��
IsSelected . . �5   "   �� $ _Border��6)    � �� �#d3eef56T   5      5      5      5      5      .��5       � $��-3,0,4,4q�6   ���#7a9d96 � ColumnDefinitions 5!   
   �� 5"      $
��239* �6   �� 5#      $
��560* �6    � RowDefinitions 5%   
   �� 5&      $
��299* �6   �� 5'      $
��242* �6   .+�5)   
   &   Xceed.Wpf.Toolkit.MaterialButton  -   5          Name$ add_contact��5)      $
��Left=�63   $��40��6N   $��7,3,0,0q�6Z   $	��Top=�6k   $��48��6�   $��22(�6�   $
��Bold"�6�   ���	#FF1A3C42$��0q�6�    � ToolTip$  Ajouter un nouveau contact��6�   ��5*      �� 5+       �� ImageSource$ 	add_p.png��6   5-      �� 5.   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��81��6I   $��	1,47,-3,0q�6U   $	��Top=�6h   $
��1195��6�   
�������$��2��6�   .+�5/      �� -   5         ��Name$ checkBox��5/      $��
20,13,0,52q�6)   $��14��6=    J� RenderTransformOrigin$ 0.571,0.952&�6H   6�   �� 50      -   5         ��Name$ 
textBlock1��50      $
��Wrap=�6,   $��8,7,0,48q�6@   ���	#FF0E2E34$��18(�6i   $	��160��6w   �� 6�   $	�Sé��6�   �� 6�   $�l��6�   �� 6�   $�é��6�   �� 6�   $�ctionner tout ��6�   6�   51      �� 52   
   -   5         ��Name$ listBox��52      #���   6$   $
��Left=�6U   $	��810��6p   $��
1,88,-2,-2q�6}   $	��Top=�6�   $
��1194��6�   $��2��6�   $ 0.504,0.555&�6�   $��18(�6�   $��2��6  ��6�   Z� 54      �� 55   
   -   5         ��Name$ comboBox��55      $
��Left=�6%   $��34��6@   $��	444,7,0,0q�6L   $	��Top=�6_   $	��126��6w   ���	#FFFFA424���	#FF0E2E34$��20(�6�    �� SelectedIndex$ 0��6�   $��1��6�    J� Effect 56      3  -System.Windows.Media.Effects.DropShadowEffect  57         
BlurRadius$ 3Q�6#      ShadowDepth$ 3Q�62      	Direction$	 300Q�6B      Opacity$	 0.3Q�6R   .@�59      �� $
�� Nom��6   $
��Left=�6*   $	��127��6E   �� 5:      $�� Adresse��6   $
��Left=�6.   $	��127��6I   �� 5;      $��
 Telephone��6   $
��Left=�60   $	��127��6K   �� 5<      $�� Email��6   $
��Left=�6,   $	��127��6G   �� 5=      $�� Siteweb��6   $
��Left=�6.   $	��127��6I   5>      �� 5?   
   -   5        $ 	textBlock��5?      $
��Left=�6'   $��32��6B   $��	282,7,0,0q�6N   $
��Wrap=�6a   $	��Top=�6u   $	��155��6�   ���	#FF0E2E34$��20(�6�   $
��Bold"�6�   $��1��6�   �� 6�   $�Rechercher par��6�   �� 6�   $� ��6  �� 6  $�:��6  6  �� 5@   
   -   5         ��Name$ textBox��5@      $
��Left=�6#   $��32��6>   $��	578,6,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��174��6�   ���	#FF707070���	#FF0E2E34$��20(�6�   $��1��6�   .��6   5A        5B      $ 3Q�6#   $ 3Q�62   $	 0.3Q�6B   .��5C      5D        5E   
   -	   5        $ materialButton��5E      $�� ��66   $
��Left=�6A   $��36��6\   $��	765,4,0,0q�6h   $	��Top=�6{   $��48��6�   $ 0.946,0.588&�6�   $ 
Rechercher��6�   $��1��6�   ��5F      �� 5G      $ 
search.png��6   5I        5J   
   -
   5        $ multi_delete��5J      $
��Left=�64   $��38��6O   $��63,5,0,0q�6[   $	��Top=�6m   $��46��6�   $��22(�6�   $
��Bold"�6�   ���	#FF1A3C42$��0q�6�   $  Ajouter un nouveau contact��6�   ��5K      �� 5L      $ delete icon.png��6   5N      5P      5Q      