   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Projekat.ManifestacijaProjekat.Manifestacija  5   	   $    Projekat.Manifestacija.pocetni   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Projekat.Manifestacija     5   	     � Title$  Pregled manifestacija��5   	   $	��540��6'   $	��960��64   $��20(�5	      .��5      � 
�������.+�5      �� 
���  ��$��5q�6   �� 5      -   5        $��U redu��5      $
��Left=�6   $��791,450,0,0q�67   $	��Top=�6L   $	��126��6d   $��36��6p   6|   �� 5      -   5        $��Dodaj��5      $
��Left=�6   $��
170,34,0,0q�66   $	��Top=�6J   $	��126��6b   $��36��6n   6z   �� 5      -   5        $��Izmeni��5      $
��Left=�6   $��
390,34,0,0q�67   $	��Top=�6K   $	��126��6c   $��36��6o   6{   �� 5      -   5        $��Obriši��5      $
��Left=�6   $��
611,34,0,0q�67   $	��Top=�6K   $	��126��6c   $��36��6o   6{   � 5      $
��Left=�6	   $	��342��6$   $��
71,103,0,0q�61   $	��Top=�6E   $	��800��6]   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ TabelaManifestacija��5   +      
IsReadOnly .    AutoGenerateColumns .  $��0,0,0,24q�6v   ��6   �� *Mpom+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6*   �� *Oznaka+6F     5      $ Naziv��6   $ 2* 6C    6)   �� *Naziv+6C     5      $ Datum održavanja��6   $
 2.5* 6n    64   �� *Datum+ �� StringFormat$ {0:dd.MM.yyyy}��6n     5      $ Kratak opis��6   $ 3* 6H    6/   �� *Opis+6H   	   RowDetailsTemplate	 5      �� 5      .R�5       ]� 
����ح�.+�5!   	   �� $
��Left=�6   $��80��6%   ��62   �� 
 �� Path$
 Slika�� 5"   	   $	��5,5q�6    � ColumnDefinitions 5#   
   �� 5$      $
��Auto �6   �� 5%      $��* �6   �� 5&      $��* �6    � RowDefinitions 5(   
   �� 5)      $
��Auto �6   �� 5*      $
��Auto �6   �� 5+      $
��Auto �6   .+�5-   
   �� $��Tip manifestacije:��6   $��0��6.   $��0��6>   $��Black"�6K   $	��5,5q�6^   �� 5.   
   $��
Opis tipa:��6   $��0��6'   $��1��67   $��Black"�6D   $	��5,5q�6W   �� 5/   
   $��Etikete:��6   $��0��6%   $��2��65   $��Black"�6B   $	��5,5q�6U   �� 50   
   $��Opis manifestacije��6   $��2��6.   $��0��6>   $��Black"�6K   $	��5,5q�6^   �� 51   
   $��1��65   $��0��6E   $	��5,5q�6R   ��6   �� $
 	Tip.Naziv�6R   �� 52   
   $��1��6.   $��1��6>   $	��5,5q�6K   ��6   �� *
Tip.Opis+6K   �� 53   
   $��1��63   $��2��6C   $	��200��6P   $��60��6\   $
��Left=�6h   ��6   �� *	Etikete+��54      �� 55      .R�56      �� ��6   �� *Oznaka+58      59      5;      �� 5<   
   $��2��6(   $��1��68   $	��200��6E   $��60��6Q   $
��Left=�6]   ��6   �� *Opis+6]   5?   
   5@   	   5A      5C      5E      �� 5F      $��Pretraga po oznaci:��6
   $
��Left=�6(   $��
71,445,0,0q�6C   $	��Top=�6W   $	��178��6o   �� 5G      -   5         � ToolTip$( "Pretraga manifestacija po oznakama��5G      $
��Left=�69   $��36��6T   $��275,450,0,0q�6`    �� TextWrapping$
 Wrap=�6u   $	��Top=�6�   $	��241��6�    J� RenderTransformOrigin$ 0.346,0.483&�6�   6�   5K      5L      