   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Projekat.EtiketaProjekat.Etiketa  5   	   $    Projekat.Etiketa.EtiketaIzmena   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Projekat.Etiketa     5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Izmena podataka o etiketi��5	   	   $	��500��6+   $	��800��68   $��20(�5
       � 	Resources 5       �� 
TargetType �� Property �� Value��%R   '_�       �� 5      " _�6#   .�5      ��  � ��$ 20(�6    5      5      .��5      �� 
������$��5q�6   ._�5      � .+�5      � $��	0,0,305,0q�6
   
�������.+�5      �� $��Oznaka:��6   $
��Left=�6   $��	10,10,0,0q�69   $	��Top=�6L    J� RenderTransformOrigin$ -0.142,0.173&�6d   $��38��6�   $	��104��6�   �� 5      -   5         ��Name$ 	oznaka_tb��5      {�.  $
��Left=�6K   $��51��6f   $��	10,53,0,0q�6r    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��251��6�    � ToolTip$v pObavezan unos oznake etikete. Dozvoljen je samo unos slova,brojeva i razmaka.Za veliko slovo koristiti dugme TAB��6�   ��6!   �� *Oznaka+6�   �� 5      $��Opis:��6   $
��Left=�6   $��
10,144,0,0q�67   $	��Top=�6K   $ -0.142,0.173&�6c   $��38��6�   $	��104��6�   �� 5      -   5        $ opis_tb��5      $
��Left=�66   $	��212��6Q   $��
10,187,0,0q�6^   $
 Wrap=�6r   $	��Top=�6�   $	��251��6�   ��6   �� *Opis+6�   �� 5      $/��)Polja označena zvezdicom (*) su obavezna��6   $
��Left=�6?   $��
10,413,0,0q�6Z   $	��Top=�6n   
���  ��$
��Bold"�6�   5      � 5      $
��Left=�6
   $	��176��6%   $��492,143,0,0q�62   $	��Top=�6G   $	��300��6_   � 5      
�������$
��Left=�6$   $	��141��6?   $��457,319,0,0q�6L   $	��Top=�6a   $	��325��6y   	 � RowDefinitions	 5      �� 5      $	��24* �6   �� 5      $	��77* �6   .+�5       �� -   5        $��Izmeni��5       $
��Left=�6   $��	10,51,0,0q�69   $	��Top=�6L   $	��122��6d   $��41��6p   $��1��6|   6�   �� 5!      -   5        $��Odustani��5!      $
��Left=�6    $��
170,52,0,0q�6;   $	��Top=�6O   $	��122��6g   $��41��6s   $��1��6   6�   5"      � 5#      
�������$
��Left=�6$   $	��143��6?   $��	457,0,0,0q�6L   $	��Top=�6_   $	��325��6w   .+�5%      �� $��Odabir boje��6   $
��Left=�6"   $��	68,32,0,0q�6=   $	��Top=�6P   $��44��6h   $	��167��6t   #  Xceed.Wpf.Toolkit.ColorPicker  5&      -   5        $��	cmbColors��5&   `   $
��Left=�6q   $��	31,81,0,0q�6�   $	��Top=�6�   $	��231��6�   $��45��6�   $ Obavezan odabir boje��6�   
   SelectedColor
 6   �� *
Mediacolor+6�   5'      �� 5(      $��*��6   $
��Left=�6   $��
266,64,0,0q�62   $	��Top=�6F   
���  ��$
��Bold"�6o   �� 5)      $��*��6   $
��Left=�6   $��
724,88,0,0q�62   $	��Top=�6F   
���  ��$
��Bold"�6o   $��24��6�   5*      5+      5,      