   M S B A M L   `   `   `  ����K  GWpfApplication12, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApplication12WpfApplication12  5      $    WpfApplication12.document_page   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:WpfApplication12     5      ` \Xceed.Wpf.Toolkit, Version=3.3.17121.18230, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        N� Title$  activ��5
      $
��1194��6   $��805.97��6#    � 	Resources 5         	ListStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Padding J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value �� 
TargetName��%f  &	        �� 5   
   " ��6"   .�5      -   5        �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ _Border��6!   $ 2q�5   !    . ._�5      �� 5      	 5      P� 5      
 �@��
IsSelected . . �5   "   �� $ _Border��6)    � �� �#d3eef56T   5      5      5      5      5       .��5!      � $��-5,0,6,7q�6   ���#7a9d96 � ColumnDefinitions 5"   
   �� 5#      $
��239* �6   �� 5$      $
��560* �6    � RowDefinitions 5&   
   �� 5'      $
��299* �6   �� 5(      $
��242* �6   .+�5*   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��81��6I   $��1,47,0,0q�6U   $	��Top=�6g   $
��1173��6   
�������$��2��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   .+�5+      �� -   5         ��Name$ checkBox��5+      $��
10,13,0,52q�6)   $��14��6=   $ 0.571,0.952&�6H   6�   �� 5,      -   5         ��Name$ 
textBlock1��5,      $
��Wrap=�6,   $��8,7,0,48q�6@   ���	#FF0E2E34$��18(�6i   $	��160��6w   �� 6�   $	�Sé��6�   �� 6�   $�l��6�   �� 6�   $�é��6�   �� 6�   $�ctionner tout ��6�   6�   5-      �� 5.   
   -   5         ��Name$ listBox��5.      #���   6$   $	��608��6U   $��	1,98,15,0q�6b   $	��Top=�6u   $��2��6�   $ 0.504,0.555&�6�   $��18(�6�   $��2��6�   ��6�   Z� 6�   �� 5/   
   -   5         ��Name$ comboBox��5/      $
��Left=�6%   $��34��6@   $��	428,7,0,0q�6L   $	��Top=�6_   $	��137��6w   ���	#FFFFA424���	#FF0E2E34$��20(�6�    �� SelectedIndex$ 0��6�   $��1��6�    J� Effect 50      3  -System.Windows.Media.Effects.DropShadowEffect  51         
BlurRadius$ 3Q�6#      ShadowDepth$ 3Q�62      	Direction$	 300Q�6B      Opacity$	 0.3Q�6R   .@�53      �� $�� Titre��6   $
��Left=�6,   $	��127��6G   54      �� 55   
   -   5        $ 	textBlock��55      $
��Left=�6'   $��32��6B   $��	272,7,0,0q�6N   $
��Wrap=�6a   $	��Top=�6u   $	��155��6�   ���	#FF0E2E34$��20(�6�   $
��Bold"�6�   $��1��6�   �� 6�   $�Rechercher par��6�   �� 6�   $� ��6  �� 6  $�:��6  6  �� 56   
   -   5         ��Name$ textBox��56      $
��Left=�6#   $��32��6>   $��	572,8,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��174��6�   ���	#FF707070���	#FF0E2E34$��20(�6�   $��1��6�   .��6   57        58      $ 3Q�6#   $ 3Q�62   $	 0.3Q�6B   .��59      5:      &   Xceed.Wpf.Toolkit.MaterialButton  5;   
   -   5          Name$ materialButton2��5;      $
��Left=�67   $��34��6R   $��15,3,0,0q�6^   $	��Top=�6p   $��41��6�    � ToolTip$ supression multiple��6�   ��5<      �� 5=       �� ImageSource$ delete icon.png��6   5?        5@   
   -	   5        $ materialButton3��5@      $��41��67   $��
750,2,32,0q�6C   $	��Top=�6W   $ 0.614,-0.361&�6o   $��1��6�   $ 
rechercher��6�   ��5A      �� 5B      $ 
search.png��6   5D      5F      5G      