   M S B A M L   `   `   `  ����K  GInventoryTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:InventoryTrackerInventoryTracker  5   	       InventoryTracker.Create   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:InventoryTracker     5   	     � Title$  Create a new item��5   	    � SizeToContent$ Height=�5	   	   $	��350��6     � WindowStartupLocation$ CenterOwner=�5
   	      GeneralWindow#��[  5   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��10��6   $��* �6+   �� 5      $
��auto �6   .+�5   
   �� $��Create a new item��6   $��30(�6-   $
��Bold"�6;   $��0��6M   � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��20 �6#   �� 5       $��* �6#    5"      �� 5#      $��5 �6    �� 5$      $
��auto �6    �� 5%      $��10 �6    �� 5&      $
��auto �6    �� 5'      $��10 �6    �� 5(      $
��auto �6    �� 5)      $��10 �6    �� 5*      $
��auto �6    �� 5+      $��10 �6    �� 5,      $
��auto �6    �� 5-      $��10 �6    �� 5.      $
��auto �6    �� 5/      $��5 �6    .+�53      �� $��Name *��6   $��DemiBold"�6&   $��Center=�6<   $��1��6W   $��0��6d   �� 54      -   5         ��Name$ txtName��54      $��1��6'   $��2��64   �� 57      $��
Cost ($) *��6   $��DemiBold"�6*   $��Center=�6@   $��3��6[   $��0��6h   �� 58      -   5        $ txtCost��58      $
��1.00��6'   $��3��63   $��2��6@   �� 5;      $��Optimal Quantity *��6   $��DemiBold"�62   $��Center=�6H   $��5��6c   $��0��6p   �� 5<      -   5        $ txtOptimalQuantity��5<      $��1��62   $��5��6;   $��2��6H   �� 5?      $��Category��6   $��Center=�6(   $��7��6C   $��0��6P   �� 5@      -   5        $ txtCategory��5@      $��7��6+   $��2��68   �� 5C      $��Supplier��6   $��Center=�6(   $��9��6C   $��0��6P   �� 5D      -   5        $ txtSupplier��5D      $��9��6+   $��2��68   �� 5G      $��Location��6   $��Center=�6(   $��11��6C   $��0��6Q   �� 5H      -   5        $ txtLocation��5H      $��11��6+   $��2��69   5I      �� 5K   
   $0��*Note: Entries with * cannot be left empty.��6   $��10(�6F   $��Italic$�6T   $��4��6g   � 5N   
   $��6��6    5O      �� 5P      $��* �6#   �� 5Q      $��* �6#   .+�5S      �� -   5        $��Create��5S   -   $	��150��6>   $	��5,0q�6M   $��0��6Z   �� 5T       �� IsCancel$
 True��6   $��Cancel��6%   $	��150��66   $	��5,0q�6E   $��1��6R   5U      5V      5W      