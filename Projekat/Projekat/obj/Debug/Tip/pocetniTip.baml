   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Projekat.TipProjekat.Tip  5   	       Projekat.Tip.pocetniTip   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Projekat.Tip     5   	     � Title$  Pregled tipova��5   	   $	��540��6    $	��960��6-   $��20(�5	      .��5
      �� 
���  ��$��5q�6   ._�5      � 
�������.+�5      �� -   5        $��U redu��5      $
��Left=�6   $��795,450,0,0q�68   $	��Top=�6M   $	��126��6e   $��36��6q   6}   �� 5      -   5        $��Dodaj��5      $
��Left=�6   $��
170,34,0,0q�67   $	��Top=�6K   $	��126��6c   $��36��6o   6{   �� 5      -   5        $��Izmeni��5      $
��Left=�6   $��
390,34,0,0q�68   $	��Top=�6L   $	��126��6d   $��36��6p   6|   �� 5      -   5        $��Obriši��5      $
��Left=�6,   $��
611,34,0,0q�6G   $	��Top=�6[   $	��126��6s   $��36��6   � 5      $
��Left=�6
   $	��342��6%   $��
71,103,0,0q�62   $	��Top=�6F   $	��800��6^   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ TabelaTipova��5         AutoGenerateColumns .     
IsReadOnly . $��0,0,0,28q�6w   ��6A   ��  �� Path$ Tipovi�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6+   �� *Oznaka+6G     5      $ Naziv��6   $ 2* 6D    6*   �� *Naziv+6D     5      $
 Opis��6   $ 3* 6B    6)   �� *Opis+6B     5      $ Ikonica��6   $ 2* 6F    6,   �� *Slika+6F   	   RowDetailsTemplate	 5      �� 5      .R�5   	   ]� 
�������.+�5   
   �� $
��Left=�6   $��80��6&   ��63   �� $ Slika�� 5   
   $	��5,5q�6   
 � ColumnDefinitions
 5      �� 5       $
��Auto �6   �� 5!      $��* �6    � RowDefinitions 5#      �� 5$      $
��Auto �6   5&      5'   
   5(   	   5+      5-      �� 5.      $��Pretraga po oznaci:��6   $
��Left=�6)   $��
71,445,0,0q�6D   $	��Top=�6X   $	��178��6p   �� 5/      -   5         � ToolTip$! Pretraga tipova po oznakama��5/      $
��Left=�63   $��36��6N   $��275,450,0,0q�6Z    �� TextWrapping$
 Wrap=�6o   $	��Top=�6�   $	��241��6�    J� RenderTransformOrigin$ 0.346,0.483&�6�   6�   50      51      52      