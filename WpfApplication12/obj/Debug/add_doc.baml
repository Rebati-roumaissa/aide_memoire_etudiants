   M S B A M L   `   `   `  ����K  GWpfApplication12, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApplication12WpfApplication12  5   	       WpfApplication12.add_doc   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WpfApplication12     5   	   ` \Xceed.Wpf.Toolkit, Version=3.3.17121.18230, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Document��5
   	   $��409.099��6   $��570.692��6+   ���	#FF47AAA6��5      �� 5   
    �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6/    �� 
StartPoint$ 0.5,0&�6S   .��5      �  � Color$ Black��6    � Offset$ 1Q�6)   � 5      $ 	#FF245260��6   5      .��5      � $��0q�6    J� RenderTransformOrigin$ 1,0.5&�6   z�5   
   V� 5      .~�5      ��  �� ScaleY$ 1Q�6!    �� ScaleX$ 1Q�6,   �� 5      	 �� AngleY$	 0Q�6    
 �� AngleX$
 0Q�6+   �� 5       �� Angle$ 0Q�6"   T� 5       T� X$ 4Q�6%    T� Y$ 4Q�6+   5       � ColumnDefinitions 5   
   �� 5      $
��403* �6   �� 5      $	��10* �6   .+�5   
   �� $
��Left=�6   $	��300��60   $	��Top=�6=   $	��279��6U   $��10,100,0,38q�6a   
�������$y�	Collapsed=�6�   $��2��6�    J� Effect 5!      3  -System.Windows.Media.Effects.DropShadowEffect  5"      5$      �� 5%   
   -   5         ��Name$ 	textBlock��5%      $
��Left=�6'   $��46��6B   $��	80,23,0,0q�6N   $
��Wrap=�6a   $	��Top=�6u   $	��405��6�   ���	#FFFFA424$��36(�6�    �� TextAlignment$ Center=�6�   �� 6�   $�N��6�   �� 6�   $
�ouve��6�   �� 6�   $�au document��6�   6  �� 5&   
   -   5         ��Name$ Valider��5&      $��Valider��6"   $
��Left=�64   $��358,286,0,0q�6O   $	��Top=�6d   $	��127��6|   $��42��6�   $��24(�6�   ���	#FF0E2E34$��0q�6�   $ 2.119,0.962&�6�   ���	#FFFFA424$
��Bold"�65  ��6�   Z�  5'        5(         Opacity$ 0Q�6#   5*      �� 5+   
   -   5        $ Annuler��5+      $��Annuler��6"   $
��Left=�64   $��
71,286,0,0q�6O   $	��Top=�6c   $	��129��6{   $��42��6�   $��24(�6�   ���	#FF0E2E34$��0q�6�   ���	#FFFFA424$
��Bold"�6  $ -0.178,0.571&�6"  ��6�   Z�  5,        5-      $	 0.8Q�6#   5/      �� 50   
   -   5        $ 
textBlock3��50      $
��Left=�6(   $��36��6C   $��	0,146,0,0q�6O   $
��Wrap=�6b   $	��Top=�6v   $	��129��6�   $��24(�6�   $��Titre��6�   �� 51   
   -   5        $ er��51      $y�	Collapsed=�6    $
��Left=�67   $��24��6R   $��
111,93,0,0q�6^   $
��Wrap=�6r   $	��Top=�6�   $	��435��6�   ���	#FFF5370D�� 6�   $�                         ��6�   �� 6�   $�	Veuillez ��6�   �� 6   $� ��6  �� 6  $�remplir tout les champs��6  65  �� 52   
   -   5        $ textBlock3_Copy��52      $
��Left=�6-   $��36��6H   $��	0,204,0,0q�6T   $
��Wrap=�6g   $	��Top=�6{   $	��144��6�   $��24(�6�   $ 0.493,2.515&�6�   $��Emplacement��6�   �� 53   
   -   5         ��Name$ emplacement��53      $
��Left=�6'   $��37��6B   $��160,204,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��240��6�   $��18(�6�   �� 54   
   -   5        $ 	parcourir��54      $��	Parcourir��6$   $
��Left=�68   $��36��6S   $��405,204,0,0q�6_   $	��Top=�6t   $	��117��6�   6�   �� 55   
   -	   5        $ titre��55      $
��Left=�6!   $��37��6<   $��160,146,0,0q�6H   $
 Wrap=�6]   $	��Top=�6q   $	��240��6�   $��18(�6�   56      57      