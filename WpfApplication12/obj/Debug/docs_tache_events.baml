   M S B A M L   `   `   `  ����  WpfApplication12(    "WpfApplication12.docs_tache_events   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ` \Xceed.Wpf.Toolkit, Version=3.3.17121.18230, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        N� Title$  list_taches��5      $	��900��6   $
��1194��6(    � 	Resources 5
         	ListStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Padding J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value �� 
TargetName��%f  &	        �� 5   
   " ��6"   .�5      -   5        �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ _Border��6!   $ 2q�5   !    . ._�5      �� 5      	 5      P� 5      
 �@��
IsSelected . . �5   "   �� $ _Border��6)    � �� �#d3eef56T   5      5      5      5      5      .��5      � $��-3,0,4,4q�6   ���#7a9d96 � ColumnDefinitions 5    
   �� 5!      $
��239* �6   �� 5"      $
��560* �6    � RowDefinitions 5$   
   �� 5%      $
��299* �6   �� 5&      $
��242* �6   .+�5(   
   &   Xceed.Wpf.Toolkit.MaterialButton  -   5          Name$ add_contact��5(      $
��Left=�63   $��38��6N   $��43,3,0,0q�6Z   $	��Top=�6l   $��43��6�   $��22(�6�   $
��Bold"�6�   ���	#FF1A3C42$��0q�6�    � ToolTip$! Ajouter un nouveau document��6�   ��5)      �� 5*       �� ImageSource$ 	add_p.png��6   5,      �� 5-   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��78��6I   $��1,47,0,0q�6U   $	��Top=�6g   $
��1173��6   
�������$��2��6�   .+�5.      �� -   5         ��Name$ checkBox��5.      $��
20,13,0,48q�6)   $��20��6=    J� RenderTransformOrigin$ 0.571,0.952&�6H   6�   �� 5/      -   5         ��Name$ 
textBlock1��5/      $
��Wrap=�6,   $��8,7,0,48q�6@   ���	#FF0E2E34$��18(�6i   $	��160��6w   �� 6�   $	�Sé��6�   �� 6�   $�l��6�   �� 6�   $�é��6�   �� 6�   $�ctionner tout ��6�   6�   50      �� 51   
   -   5         ��Name$ list_box��51      #���   6%   $	��625��6V   $��	1,91,19,0q�6c   $	��Top=�6v   $��2��6�   $ 0.504,0.555&�6�   $��18(�6�   $��2��6�   ��6�   Z� 6�     52   
   -   5        $ multi_delete��52      $
��Left=�64   $��33��6O   $��87,5,0,0q�6[   $	��Top=�6m   $��38��6�   $��22(�6�   $
��Bold"�6�   ���	#FF1A3C42$��0q�6�   $ suppresion multiple��6�   ��53      �� 54      $ delete icon.png��6   56        57   
   -   5        $ materialButton2��57      $�� ��67   $
��Left=�6B   $	��Top=�6]   $��38��6u   $��40��6�   $��3,3,0,0q�6�   $ 	Retourner��6�   ��58      �� 59      $ 
return.png��6   5;      �� 5<   
   -   5        $
 info��5<      $��2��6"   $
��Left=�66   $��31��6Q   $��	310,7,0,0q�6]   $
��Wrap=�6p   $	��Top=�6�   $	��468��6�   $��20(�6�    �� TextAlignment$ Center=�6�   
�������$
��Bold"�6�   5>      5?      