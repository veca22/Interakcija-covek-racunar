   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Projekat.EtiketaProjekat.Etiketa  5   	   #    Projekat.Etiketa.EtiketaDodaj   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Projekat.Etiketa     5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Dodavanje etikete��5	   	   $	��500��6#   $	��800��60   $��20(�5
       � 	Resources 5       �� 
TargetType �� Property �� Value��%R   '_�       �� 5      " _�6#   .�5      ��  � ��$ 20(�6    5      5      .��5      �� 
����  �$��5q�6   ._�5      � .+�5      � $��	0,0,305,0q�6
   
�������.+�5      �� $��Oznaka:��6   $
��Left=�6   $��	10,10,0,0q�69   $	��Top=�6L    J� RenderTransformOrigin$ -0.142,0.173&�6d   $��38��6�   $	��104��6�   �� 5      -   5         ��Name$ 	oznaka_tb��5      $
��Left=�6!   $��51��6<   $��	10,53,0,0q�6H    �� TextWrapping$
 Wrap=�6[   $	��Top=�6o   $	��251��6�    � ToolTip$u oObavezan unos oznake etikete. Dozvoljen je samo unos brojeva,slova i razmaka.Za veliko slovo koristi dugme TAB.��6�   ��6�   �� *Oznaka+	 �� UpdateSourceTrigger$	 PropertyChanged=�6K  �� 5      $��Opis:��6   $
��Left=�6   $��
10,144,0,0q�67   $	��Top=�6K   $ -0.142,0.173&�6c   $��38��6�   $	��104��6�   �� 5      -   5        $ opis_tb��5      $
��Left=�6   $	��212��6:   $��
10,187,0,0q�6G   $
 Wrap=�6[   $	��Top=�6o   $	��251��6�   ��6�   �� *Opis+
 �� Mode$
 TwoWay=��� 5      $/��)Polja označena zvezdicom (*) su obavezna��6   $
��Left=�6?   $��
10,413,0,0q�6Z   $	��Top=�6n   $	��422��6�   
���  ��$
��Bold"�6�   5      � 5      $
��Left=�6
   $	��176��6%   $��492,143,0,0q�62   $	��Top=�6G   $	��300��6_   � 5      
�������$
��Left=�6$   $	��141��6?   $��458,319,0,0q�6L   $	��Top=�6a   $	��324��6y    � RowDefinitions 5      �� 5       $	��24* �6   �� 5!      $	��77* �6   .+�5#      �� -   5        $��Dodaj��5#      $
��Left=�6   $��	10,51,0,0q�68   $	��Top=�6K   $	��122��6c   $��41��6o   $��1��6{   6�   �� 5$      -   5        $��Odustani��5$      $
��Left=�6    $��
170,52,0,0q�6;   $	��Top=�6O   $	��122��6g   $��40��6s   $��1��6   6�   5%      � 5&      
�������$
��Left=�6$   $	��143��6?   $��	458,0,0,0q�6L   $	��Top=�6_   $	��324��6w   .+�5(      �� $��Odabir boje:��6   $
��Left=�6#   $��	74,27,0,0q�6>   $	��Top=�6Q   $��44��6i   $	��167��6u   #  Xceed.Wpf.Toolkit.ColorPicker  5)      -   5        $��	cmbColors��5)   ;   $
��Left=�6L   $��	23,88,0,0q�6g   $	��Top=�6z   $	��231��6�   $��45��6�   $ Obavezan je izbor boje��6�   5*      �� 5,      $��*��6   $
��Left=�6   $��
266,64,0,0q�62   $	��Top=�6F   
���  ��$
��Bold"�6o   �� 5-      $��*��6   $
��Left=�6   $��
717,89,0,0q�62   $	��Top=�6F   
���  ��$
��Bold"�6o   $��25��6�   5/      50      51      