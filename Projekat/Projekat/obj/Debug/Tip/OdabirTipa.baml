   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Projekat.TipProjekat.Tip  5   	       Projekat.Tip.OdabirTipa   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Projekat.Tip     5   	     � Title$  Odabir tipa��5   	   $	��600��6   $	��600��6*   $��20(�5	      .��5
      �� 
���\\��$��5q�6"   ._�5      � 
�������.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	data_grid��5   4      
IsReadOnly .    AutoGenerateColumns .  $��0,0,0,79q�6u   ��6   ��  �� Path$ Tipovi�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6*   �� *Oznaka+6F     5      $ Naziv��6   $ 4* 6C    6)   �� *Naziv+6C     5      $ Ikonica��6   $ 3* 6F    6+   �� *Slika+5      	   RowDetailsTemplate	 5      �� 5      .R�5      ]� 
�������.+�5   	   �� $
��Left=�6   $��80��6%   ��62   �� $ Slika�� 5   	   $	��5,5q�6   
 � ColumnDefinitions
 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   5!   
   5"   	   5#      5%      �� 5'      -   5        $��Izaberi��5'      $
��Left=�6   $��175,496,0,0q�69   $	��Top=�6N   $��94��6f   6q   �� 5(      -   5        $��Odustani��5(      $
��Left=�6   $��285,496,0,0q�6:   $	��Top=�6O   $��94��6g   6r   5)      5*      5+      