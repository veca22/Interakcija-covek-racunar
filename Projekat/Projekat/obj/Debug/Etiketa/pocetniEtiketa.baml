   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Projekat.EtiketaProjekat.Etiketa  5   	   %    Projekat.Etiketa.pocetniEtiketa   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Projekat.Etiketa     5   	     � Title$  Pregled etiketa��5   	   $	��540��6!   $	��960��6.   $��20(�5	      .��5
      �� 
���  ��$��5q�6   ._�5      � 
�������.+�5      �� -   5        $��U redu��5      $
��Left=�6   $��799,450,0,0q�68   $	��Top=�6M   $	��126��6e   $��36��6q   6}   �� 5      -   5        $��Dodaj��5      $
��Left=�6   $��
170,34,0,0q�67   $	��Top=�6K   $	��126��6c   $��36��6o   6{   �� 5      -   5        $��Izmeni��5      $
��Left=�6   $��
390,34,0,0q�68   $	��Top=�6L   $	��126��6d   $��36��6p   6|   �� 5      -   5        $��Obriši��5      $
��Left=�6,   $��
611,34,0,0q�6G   $	��Top=�6[   $	��126��6s   $��36��6   � 5      $
��Left=�6
   $	��342��6%   $��
71,103,0,0q�62   $	��Top=�6F   $	��800��6^   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ TabelaEtiketa��5         AutoGenerateColumns .     
IsReadOnly . $��0,0,0,23q�6y   ��6B   ��  �� Path$ Etikete�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6+   �� *Oznaka+6G     5      $
 Opis��6   $ 4* 6B    6)   �� *Opis+6B     5      $
 Boja��6   $ 3* 6B    6)   �� *Boja+6B   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Prikaz Boje��6    	   MinWidth$	 60Q�65   $ 3* 6C   
   CellTemplate
 5   	   �� 5   
   .R�5      �� $��30��6+   $��30��67   ��6   �� *Boja+67   5      5   	      RowDetailsTemplate 5      �� 5    	   5"   
   5$      5&      �� 5'      $��Pretraga po oznaci:��6   $
��Left=�6)   $��
71,445,0,0q�6D   $	��Top=�6X   $	��178��6p   �� 5(      -   5         � ToolTip$" Pretraga etiketa po oznakama��5(      $
��Left=�64   $��36��6O   $��275,450,0,0q�6[    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��241��6�    J� RenderTransformOrigin$ 0.346,0.483&�6�   6�   5)      5*      5+      