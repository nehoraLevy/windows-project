   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.AddOrder   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  AddOrder��5   	   $	��450��6   $	��800��6'    � Icon$c ]https://cdn.shopify.com/s/files/1/2033/9929/products/product-image-736810739.jpg?v=1571610026��63    � 	Resources 5	       �� 
TargetType �� Property �� Value��%  '��       '�� �     �� 5
      " ��6   .�5      ��  � ��$ 10(�5      �� 5       � ��$ Rockwell)�5      �� 5       � ��
 �����5      �� 5       � ��$ 23��5      �� 5       � ��$	 100��5      5      �� 5      " ��6   .�5      ��  � ��$ 25(�5      �� 5       � ��$ Rockwell)�5      �� 5       � ��$
 Bold"�5      �� 5       � ��
 ���� 5      �� 5       � ��
 �����5       5!      5"      .��5$      � .+�5%      �� $��Stretch=�6   $c��]https://cdn.shopify.com/s/files/1/2033/9929/products/product-image-736810739.jpg?v=1571610026��6*   $��-184,0,-169.667,-243.333q�6�   &   System.Windows.Controls.DataGrid  5&      -   5          Name$! TableGuestReuquestsDataGrid��5&      
���   �
�������$��Rockwell)�6r      AutoGenerateColumns .     
IsReadOnly . $
��Left=�6�   $	��248��6�   $��
400,97,0,0q�6�   $	��Top=�6�   $	��383��6
  $��16(�6  ��64   Z� 	   Columns	 5'      0  *System.Windows.Controls.DataGridTextColumn  5(   
   ,  &System.Windows.Controls.DataGridColumn
   Header$
 Guest Request Key��6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *GuestRequestKey+  5)   
   $
 Private Name��6    63   �� *PrivateName+  5*   
   $
 Family Name��6    62   �� *
FamilyName+  5+   
   $
 Mail Address��6    63   �� *MailAddress+  5,   
   $
 Status��6    6-   �� *Status+  5-   
   $
 
Entry Date��6    61   �� *	EntryDate+  5.   
   $
 Release Date��6    63   �� *ReleaseDate+  5/   
   $

 City��6    6+   �� *	SubArea+  50   
   $

 Type��6    6+   �� *Type+  51   
   $
 Num Of Persons��6    65   �� *	Persons+  52   
   $

 Pool��6    6+   �� *Pool+  53   
   $
 Jacuzzi��6    6.   �� *	Jacuzzi+  54   
   $
 Garden��6    6-   �� *Garden+  55   
   $
  Childrens Attractions��6    6=   �� *ChildrensAttractions+57        58      -   5        $ TableHostingUnitsDataGrid��58      
���   �
�������$��Rockwell)�6p    .   . $
��Left=�6�   $	��249��6�   $��4,97,0,0q�6�   $	��Top=�6�   $	��388��6  $��16(�6  ��62   Z� 	 59        5:   
   $
 Hosting Unit Key��6    67   �� *HostingUnitKey+  5;   
   $
 Hosting Unit Name��6    68   �� *HostingUnitName+  5<   
   $
 Host Key��6    6/   �� *Owner.HostKey+  5=   
   $
 Host Private Name��6    68   �� *Owner.PrivateName+  5>   
   $
 Host Family Name��6    67   �� *Owner.FamilyName+  5?   
   $
 Host Phone Number��6    68   �� *Owner.PhoneNumber+  5@   
   $
 Host Mail Address��6    68   �� *Owner.MailAddress+  5A   
   $
 Host Collection Clearance��6    6@   �� *Owner.CollectionClearance+  5B   
   $

 City��6    6+   �� *	SubArea+  5C   
   $

 Type��6    6+   �� *Type+  5D   
   $
 Num Of Persons��6    65   �� *	Persons+  5E   
   $

 Pool��6    6+   �� *Pool+  5F   
   $
 Jacuzzi��6    6.   �� *	Jacuzzi+  5G   
   $
 Garden��6    6-   �� *Garden+  5H   
   $
  Childrens Attractions��6    6=   �� *ChildrensAttractions+5J      �� 5K      $��Hosting Unit Table:��6   $
��Left=�6*   $��32��6E   $��	10,64,0,0q�6Q   $	��Top=�6d   $	��130��6|   $��14(�6�   �� 5L      $��Guest Request Table:��6   $
��Left=�6+   $��
399,66,0,0q�6F   $	��Top=�6Z   $	��174��6r   $��23��6~   $��14(�6�   �� 5M      $5��/Select Your Hosting Unit And one Guest Request:��6   $
��Left=�6F   $��38��6a   $��	10,23,0,0q�6m   $	��Top=�6�   $	��411��6�   $��16(�6�   �� 5N      -   5        $��	Add Order��5N      $
��Left=�6!   $��287,354,0,0q�6<   $	��Top=�6Q   $	��219��6i   $��50��6u   $��14(�6�   6�   5O      5P      