   M S B A M L   `   `   `  ����K  GInventoryTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:InventoryTrackerInventoryTracker  5   	       InventoryTracker.Sell   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:InventoryTracker     5   	     � Title$  
Sell items��5   	    � Icon$ /Images/Icon.ico��5	   	   $	��400��5
   	   $	��600��6      BackgroundColor#���   5   	     ForegroundColor#���  5   	    � 	Resources 5        ItemListColor1  ItemListColor2  ItemListBGColor��%�   &	        &	      &	 >     &	 ]     &	 |     ��5   
   #1b1b1c��6;   ��5   
   #d2d2d9��6;   ��5   
   #3b3b3c��6:   ��5   
   #2b2b2c��6:   ��5   
   #0b0b0c��6;   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��
Sell items��6   $��30(�6&   $
��Bold"�64   $��0��6F   �� 5   
   
 � Tag$ 0��6   $��20,10,20,20q�6   $��1��64   .��5       �� -   5         ��Name$ 
spItemList��5       #��[ 6-   52      53      � 56   
   $��2��6    � ColumnDefinitions 57      �� 58      $��* �6#   �� 59      $��* �6#   .+�5;      �� -   5        $
��Sell��5;   +   $	��150��6:   $��5q�6I   $	��5,0q�6U   $��0��6b   �� 5<       �� IsCancel$
 True��6   $��Cancel��6%   $	��150��66   $��5q�6E   $	��5,0q�6Q   $��1��6^   5=      5>      5?      