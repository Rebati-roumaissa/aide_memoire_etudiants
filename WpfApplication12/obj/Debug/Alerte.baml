   M S B A M L   `   `   `  ����K  GWpfApplication12, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApplication12WpfApplication12  5   	       WpfApplication12.Alerte   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WpfApplication12     5   	   ` \Xceed.Wpf.Toolkit, Version=3.3.17121.18230, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Alerte��5
   	   $��409.099��6   $��570.692��6)   ���	#FF47AAA6��5      �� 5   
    �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6/    �� 
StartPoint$ 0.5,0&�6S   .��5      �  � Color$ Black��6    � Offset$ 1Q�6)   � 5      $ 	#FF245260��6   5      .��5      � $��0,1,0,-1q�6    J� RenderTransformOrigin$ 1,0.5&�6   z�5   
   V� 5      .~�5      ��  �� ScaleY$ 1Q�6!    �� ScaleX$ 1Q�6,   �� 5      	 �� AngleY$	 0Q�6    
 �� AngleX$
 0Q�6+   �� 5       �� Angle$ 0Q�6"   T� 5       T� X$ 4Q�6%    T� Y$ 4Q�6+   5       � ColumnDefinitions 5   
   �� 5      $
��403* �6   �� 5      $	��10* �6   .+�5   
   �� $
��Left=�6   $	��300��60   $	��Top=�6=   $	��279��6U   $��10,100,0,38q�6a   
�������$y�	Collapsed=�6�   $��2��6�    J� Effect 5!      3  -System.Windows.Media.Effects.DropShadowEffect  5"      5$      �� 5%   
   -   5         ��Name$ 	textBlock��5%      $
��Left=�6'   $��46��6B   $��	81,11,0,0q�6N   $
��Wrap=�6a   $	��Top=�6u   $	��405��6�   ���	#FFFFA424$��36(�6�    �� TextAlignment$ Center=�6�   �� 6�   $�N��6�   �� 6�   $�ouvelle��6�   �� 6�   $� ��6�   �� 6	  $�Alerte��6  6  �� 5&   
   -   5         ��Name$ Valider��5&      $��Valider��6"   $
��Left=�64   $��358,286,0,0q�6O   $	��Top=�6d   $	��127��6|   $��42��6�   $��24(�6�   ���	#FF0E2E34$��0q�6�   $ 2.119,0.962&�6�   ���	#FFFFA424$
��Bold"�65  ��6�   Z�  5'        5(         Opacity$ 0Q�6#   5*      �� 5+   
   -   5        $ Annuler��5+      $��Annuler��6"   $
��Left=�64   $��
71,286,0,0q�6O   $	��Top=�6c   $	��129��6{   $��42��6�   $��24(�6�   ���	#FF0E2E34$��0q�6�   ���	#FFFFA424$
��Bold"�6  $ -0.178,0.571&�6"  ��6�   Z�  5,        5-      $	 0.8Q�6#   5/      �� 50   
   -   5        $ er��50      $y�	collapsed=�6    $
��Left=�67   $��35��6R   $��	40,58,0,0q�6^   $
��Wrap=�6q   $3��-veuillez-insérer les informations demandées��6�   $	��Top=�6�   $	��349��6�   $��16(�6�   ���	#FFD62B1A6�   �� 51   
   -   5        $ 
textBlock3��51      $
��Left=�6(   $��36��6C   $��
15,145,0,0q�6O   $
��Wrap=�6c   $	��Top=�6w   $	��129��6�   $��24(�6�   �� 6�   $
�Date��6�   �� 6�   $�Heure��6�   6�   �� 52   
   -   5        $ erreur��52      $y�	Collapsed=�6$   $
��Left=�6;   $��42��6V   $��0,51,0,0q�6b   $
��Wrap=�6t   $	��Top=�6�   $	��412��6�   $'��!veuillez-vérifier la date donée��6�   $��2��6�   ���	#FFF5370D�� 6�   $�                         ��6  �� 6&  $7�1Vous ne pouvez pas insérer une date antèrieure ��6*  �� 6c  �� 6i  �� 6u  $!�                           ��6y  �� 6�  $�ou heure��6�  �� 6�  $� de fin��6�  �� 6�  $� ��6�  �� 6�  $�inferieur a l'heure��6�  �� 6�  $�	 du debut��6�  �� 6  $� !��6  6!  &   Xceed.Wpf.Toolkit.DateTimePicker  53   
   -   5          Name$
 Date��53      $
��Left=�6,   $��36��6G   $��149,145,0,0q�6S   $	��Top=�6h   $	��240��6�   �� 54   
   -   5        $ textBlock3_Copy��54      $
��Left=�6-   $��36��6H   $��
15,204,0,0q�6T   $
��Wrap=�6h   $	��Top=�6|   $��56��6�   $��24(�6�   $ 0.493,2.515&�6�   $	��Son��6�   �� 55   
   -	   5         ��Name$ music��55      $
��Left=�6!   $��37��6<   $��149,203,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��240��6�   �� 56   
   -
   5        $ 	parcourir��56      $��	Parcourir��6$   $
��Left=�68   $��36��6S   $��405,204,0,0q�6_   $	��Top=�6t   $	��117��6�   6�   57      58      