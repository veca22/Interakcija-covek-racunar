   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Projekat.EtiketaProjekat.Etiketa  5   	   $    Projekat.Etiketa.OdabirEtiketa   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Projekat.Etiketa     5   	     � Title$  Odabir Etiketa��5   	   $	��600��6    $	��600��6-   $��20(�5	      .��5
      �� 
���\\��$��5q�6"   ._�5      � 
�������.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	data_grid��5   5      
IsReadOnly .    AutoGenerateColumns .  $��0,0,0,63q�6v   ��6   ��  �� Path$ Etikete�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6*   �� *Oznaka+6F     5      $
 Opis��6   $ 3* 6A    6(   �� *Opis+6A     5      $
 Boja��6   $ 3* 6A    6(   �� *Boja+6A   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Prikaz Boje��6   	   MinWidth$	 60Q�64   $ 3* 6B   
   CellTemplate
 5      �� 5   	   .R�5   
   �� $��30��6*   $��30��66   ��6   �� *Boja+66   5   
   5      5      �� 5      -   5        $��Odustani��5      $
��Left=�6   $��290,502,0,0q�6:   $	��Top=�6O   $��94��6g   6r   �� 5      -   5        $��Izaberi��5      $
��Left=�6   $��180,502,0,0q�69   $	��Top=�6N   $��94��6f   6q   5      5      5      