   M S B A M L   `   `   `  ����K  GInventoryTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:InventoryTrackerInventoryTracker  5   	       InventoryTracker.Create   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:InventoryTracker     5   	     � Title$  Create a new item��5   	    � Icon$ /Images/Icon.ico��5	   	    � SizeToContent$ Height=�5
   	   $	��350��6       BackgroundColor#���   5   	     ForegroundColor#���  5   	    � 	Resources 5      ��%R   &	        &	      ��5   
   #1b1b1c��6;   ��5   
   #d2d2d9��6;   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��10��6   $��* �6+   �� 5      $
��auto �6   .+�5   
   �� $��Create a new item��6   $��30(�6-   $
��Bold"�6;   $��0��6M   � 5    
   $��2��6    � ColumnDefinitions 5!      �� 5"      $
��auto �6#   �� 5#      $��20 �6#   �� 5$      $��* �6#    5&      �� 5'      $��5 �6    �� 5(      $
��auto �6    �� 5)      $��10 �6    �� 5*      $
��auto �6    �� 5+      $��10 �6    �� 5,      $
��auto �6    �� 5-      $��10 �6    �� 5.      $
��auto �6    �� 5/      $��10 �6    �� 50      $
��auto �6    �� 51      $��10 �6    �� 52      $
��auto �6    �� 53      $��5 �6    .+�57      �� $��Name *��6   $��DemiBold"�6&   $��Center=�6<   $��1��6W   $��0��6d   �� 58      -   5         ��Name$ txtName��58      $��1��6'   $��2��64   �� 5;      $��
Cost ($) *��6   $��DemiBold"�6*   $��Center=�6@   $��3��6[   $��0��6h   �� 5<      -   5        $ txtCost��5<      $
��1.00��6'   $��3��63   $��2��6@   �� 5?      $��Optimal Quantity *��6   $��DemiBold"�62   $��Center=�6H   $��5��6c   $��0��6p   �� 5@      -   5        $ txtOptimalQuantity��5@      $��1��62   $��5��6;   $��2��6H   �� 5C      $��Category��6   $��Center=�6(   $��7��6C   $��0��6P   �� 5D      -   5        $ txtCategory��5D      $��7��6+   $��2��68   �� 5G      $��Supplier��6   $��Center=�6(   $��9��6C   $��0��6P   �� 5H      -   5        $ txtSupplier��5H      $��9��6+   $��2��68   �� 5K      $��Location��6   $��Center=�6(   $��11��6C   $��0��6Q   �� 5L      -   5        $ txtLocation��5L      $��11��6+   $��2��69   5M      �� 5O   
   $0��*Note: Entries with * cannot be left empty.��6   $��10(�6F   $��Italic$�6T   $��4��6g   � 5R   
   $��6��6    5S      �� 5T      $��* �6#   �� 5U      $��* �6#   .+�5W      �� -   5        $��Create��5W   -   $	��150��6>   $��5q�6M   $	��5,0q�6Y   $��0��6f   �� 5X       �� IsCancel$
 True��6   $��Cancel��6%   $	��150��66   $��5q�6E   $	��5,0q�6Q   $��1��6^   5Y      5Z      5[      