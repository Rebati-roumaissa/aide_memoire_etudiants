   M S B A M L   `   `   `  ����K  GWpfApplication12, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApplication12WpfApplication12  5   	   %    WpfApplication12.User_Affichage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WpfApplication12     5   	     N� Title$  User_Affichage��5   	   $	��700��6!   $
��1194��6.    N� 
Background
 ����� � 	Resources 5	         BackgroundHighlighted �� Color  BorderBrushHighlighted  BackgroundSelected  BorderBrushSelected  
Background  BackgroundButton  LightBackground  
Foreground  BorderBrushNormal 	 StandardButton �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value��%�  &	        &	 !     &	 B     &	 e     &	 �     &	 �     &	 �     &	 �     &	     &		 0    7  7  7  7  7  7  �� 5   
   $ #54545C��68   �� 5   
   $ #6A6A75��69   �� 5   
   $ 	#FFFFA424��65   �� 5   
   $ #1C97EA��66   �� 5   
   $ #1C1C1C��6-   �� 5   
   $ 
#FFFFA424 ��63   �� 5   
   $ #2D2D30��62   �� 5   
   $ 	#FF0E2E34��6-   �� 5   
   $ #54545C��64   �� 5   
   " ��6'   .�5      ��  � y�$ Visible=�6+   �� 5       � ��8   6+   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5       � �� 5       �� 5!      " ��6&   .R�5"      ��  . $��1q�5#      #��z��5$      #��z��5%      ._�5&      �  . .+�5'   "   �� $��Center=�63   $��Center=�6P   5(      5)      	 5*      P� 5+      
 �@J�IsMouseOver . . �5,   "   �� 8   � ��6@   �� 5-   "    � �� �	#FF0E2E346?   5.      P� 5/      
 � �� . . �50   "   �� 8   � ��6?   �� 51   "   8   � ��6@   52      P� 53      
 � {� .  . �54   "   ��  �@J�Opacity$ .5Q�6<   55      57      59      5:      5<      .��5=      � $��305,-3,344,-3q�6   
�������.+�5B   
   �� -   5         ��Name$ 	textBlock��5B      $
��Left=�6'   $��46��6B   $��	110,8,0,0q�6N   $
��Wrap=�6a   $	��Top=�6u   $	��370��6�   ���	#FFFFA424$��36(�6�    �� TextAlignment$ Center=�6�   $��Utilisateur��6�   �� 5C   
   -   5        $ pseu_ext��5C      $
��Wrap=�6&   $5��/Pseudo existe déjà veuillez insérer un autre��6:   
���  ��$��20(�6   $��96,54,49,624q�6�   $y�	Collapsed=�6�   �� 5D   
   -   5        $ 
textBlock1��5D      $
��Left=�6(   $
��Wrap=�6C   $	��Top=�6W   $��
75,133,0,0q�6o   $��34��6�   $	��159��6�   ���	#FF40A497$��24(�6�   $	��Nom��6�   $��1��6�   �� 5E   
   -   5        $ textBlock1_Copy��5E      $
��Left=�6-   $
��Wrap=�6H   $	��Top=�6\   $��
75,190,0,0q�6t   $��34��6�   $	��159��6�   ���	#FF40A497$��24(�6�   $��Prenom��6�   $��1��6�   �� 5F   
   -   5        $ textBlock1_Copy1��5F      $
��Left=�6.   $
��Wrap=�6I   $	��Top=�6]   $��
76,251,0,0q�6u   $��34��6�   $	��159��6�   ���	#FF40A497$��24(�6�   $��
Pseudonyme��6�   $��1��6�   �� 5G   
   -   5         ��Name$ Modifier_mot_depasse��5G      $
��Left=�6/   $��453,302,0,0q�6J   $	��Top=�6_   $��36��6w   $��33��6�   ��6�   Z� .��5H      �� $��	modif.png��6   6)   5I      �� 5J   
   -   5        $ 
Enrigstrer��5J      #��[	 6%   $��
Enrigstrer��6N   $
��Left=�6c   $��40��6~   $��372,533,0,0q�6�   $	��Top=�6�   $	��135��6�   
�������6�   �� 5K   
   -   5        $ textBlock1_Copy2��5K      $
��Left=�6.   $
��Wrap=�6I   $	��Top=�6]   $��
75,301,0,0q�6u   $��34��6�   $	��295��6�   ���	#FF40A497$��24(�6�   $��Modifier Le mot de passe��6�   $��2��6�   $��1��6�   �� 5L   
   -	   5         ��Name$	 Nom��5L      $
��Left=�6   $��41��68   $	��Top=�6D   $	��230��6\   ���	#FF40A497$
��Bold"�6   $��18(�6�   ���	#FF40A497$��0,0,0,2q�6�   $��265,116,0,0q�6�   $��5��6�   $��1��6  ��6�   Z�  J� Effect 5M      3  -System.Windows.Media.Effects.DropShadowEffect  5N         Opacity$	 0.3Q�6#   5P      �� 5Q   
   -
   5         ��Name$
 Nom2��5Q      $
��Left=�6    $��41��6;   $��265,115,0,0q�6G   $	��Top=�6\   $	��230��6t   ���	#FF40A497$
��Bold"�6�   $��20(�6�   ���	#FF40A497$��0,0,0,3q�6�   $��5��6  $��1��6)  ��6�   Z� .��66   5R        5S      $	 0.3Q�6#   .��5T      5U      �� 5V   
   -   5        $ Prenom��5V      $
��Left=�6    $��41��6;   $��265,170,0,0q�6G   $	��Top=�6\   $	��230��6t   ���	#FF40A497$
��Bold"�6�   $��18(�6�   ���	#FF40A497$��0,0,0,2q�6�   $��5��6   $��1��6  ��6�   Z�  5W        5X      $	 0.3Q�6#   5Z      �� 5[   
   -   5        $ Prenom2��5[      $
��Left=�6#   $��41��6>   $��265,171,0,0q�6J   $	��Top=�6_   $	��230��6w   ���	#FF40A497$
��Bold"�6�   $��20(�6�   ���	#FF40A497$��0,0,0,2q�6�   $��5��6  $��1��6+  ��6  Z� .��68   5\        5]      $	 0.3Q�6#   .��5^      5_      �� 5`   
   -   5        $ Pseudo2��5`      $
��Left=�6#   $��41��6>   $��265,231,0,0q�6J   $	��Top=�6_   ���	#FF40A497$
��Bold"�6�   $��20(�6�   ���	#FF40A497$��0,0,0,4q�6�   $	��230��6�   $��5��6  $��1��6  ��6�   Z� .��6F   5a        5b      $	 0.3Q�6#   .��5c      5d      G� 5f   
   -   5         G�Name$ Password��5f      $
��Left=�6(   $��41��6C   $��273,347,0,0q�6O   $	��Top=�6d   $	��230��6|   ���	#FF40A497$
��Bold"�6�   $��18(�6�   ���	#FF40A497$��0,0,0,3q�6�   $��5��6  $��1��6  ��6�   Z�  5g        5h      $	 0.3Q�6#   5j      G� 5k   
   -   5        $ 	Password2��5k      $
��Left=�6)   $��41��6D   $��271,406,0,0q�6P   $	��Top=�6e   $	��230��6}   ���	#FF40A497$
��Bold"�6�   $��18(�6�   ���	#FF40A497$��0,0,0,3q�6�   $��5��6  $��1��6  ��6�   Z�  5l        5m      $	 0.3Q�6#   5o      �� 5p   
   -   5        $ Ancien_mot_de_passe��5p      $
��Left=�61   $
��Wrap=�6L   $	��Top=�6`   $��
75,367,0,0q�6x   $��34��6�   $	��175��6�   ���	#FF40A497$��18(�6�   $��Ancien mot de passe��6�   $��1��6�   �� 5q   
   -   5        $ Nouveau_mot_de_passe��5q      $
��Left=�62   $
��Wrap=�6M   $	��Top=�6a   $��
75,429,0,0q�6y   $��34��6�   $	��189��6�   ���	#FF40A497$��18(�6�   $��1��6�   �� 6�   $�Nouveau mot de passe��6�   6�   �� 5r   
   -   5        $ Annuler��5r      #��[	 6"   $��Annuler��6J   $
��Left=�6\   $��40��6w   $��114,535,0,0q�6�   $	��Top=�6�   $	��135��6�   
������� J� RenderTransformOrigin$ -1.238,1.801&�6�   �� 5s   
   -   5        $ incorect��5s      $
��Left=�6&   $��34��6A   $��
108,79,0,0q�6M   $
��Wrap=�6a   $-��'Votre ancien mot de passe est incorecte��6u   $	��Top=�6�   $	��420��6�   ���	#FFFF0202$y�	Collapsed=�6�   $��20(�6�   5t      5u      