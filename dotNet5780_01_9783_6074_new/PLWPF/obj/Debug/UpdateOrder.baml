   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.UpdateOrder   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  UpdateOrder��5   	   $	��415��6   $	��500��6*    � Icon$c ]https://cdn.shopify.com/s/files/1/2033/9929/products/product-image-736810739.jpg?v=1571610026��66    � 	Resources 5	       �� 
TargetType �� Property �� Value��%  '��       '�� �     �� 5
   
   " ��6   .�5      ��  � ��$ 10(�5      �� 5       � ��$ Rockwell)�5      �� 5       � ��
 �����5      �� 5       � ��$ 23��5      �� 5       � ��$	 100��5      5      �� 5   
   " ��6   .�5      ��  � ��$ 17(�5      �� 5       � ��$ Rockwell)�5      �� 5       � ��$
 Bold"�5      �� 5       � ��
 ���� 5      �� 5       � ��
 �����5       5!      5"      .��5#      � .+�5$   
   �� $
��Left=�6   $	��410��6+   $��3��68   $	��Top=�6I   $	��510��6a   $c��]https://cdn.shopify.com/s/files/1/2033/9929/products/product-image-736810739.jpg?v=1571610026��6m   $��-10,-26,-10,0q�6�   &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ TableOrderDataGrid��5%      $��Rockwell)�6/      AutoGenerateColumns .     
IsReadOnly . $
��Left=�6�   $	��249��6�   $��	10,47,0,0q�6�   $	��Top=�6�   $	��473��6�   $��16(�6�   ��6E   Z� 	   Columns	 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Hosting Unit Key��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *HostingUnitKey+  5(      $
 Guest Request Key��6%    6@   �� *GuestRequestKey+  5)      $
 	Order Key��6%    68   �� *
OrderKey+  5*      $
 Status��6%    65   �� *Status+  5+      $
 Create Date��6%    6:   �� *
CreateDate+  5,      $
 
Order Date��6%    69   �� *	OrderDate+5.      �� 5/   
   -   5        $��Close The Order��5/      $
��Left=�6+   $��
33,329,0,0q�6F   $	��Top=�6Z   $	��167��6r   $��38��6~   $��14(�6�   6�   �� 50   
   -   5        $��Cancel The Order��50      $
��Left=�6,   $��286,329,0,0q�6G   $	��Top=�6\   $	��167��6t   $��38��6�   $��14(�6�   6�   �� 51   
   $��Plaese Chose And Complete��6   $
��Left=�64   $��	24,10,0,0q�6O   $	��Top=�6b   $��42��6z   $	��212��6�   52      53      