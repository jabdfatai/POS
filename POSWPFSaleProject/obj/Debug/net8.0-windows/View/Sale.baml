   M S B A M L   `   `   `  ����L  HPOSWPFSaleProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POSWPFSaleProject.ViewPOSWPFSaleProject.View  5   	   ] YMicrosoft.VisualBasic, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a\Bclr-namespace:Microsoft.VisualBasic;assembly=Microsoft.VisualBasicMicrosoft.VisualBasic 6<   !    POSWPFSaleProject.View.Sale   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   0local$clr-namespace:POSWPFSaleProject.View  5   	   Ki1Bclr-namespace:Microsoft.VisualBasic;assembly=Microsoft.VisualBasic  6<     � Title$
  Sale��5
   	   $	��450��6   $	��800��6#   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��10 �6   .+�5   
   ]� $��0��6   ���#093C3C$��30��66   .+�5      �� $��Jide Abdfatai��6   
�������$��12(�5      $
��Left=�6   $��10,0,0,0q�64   �� 5       $��Sunday, 09-Nov-2024��6   
�������$��12(�5!      $��Right=�6   $��0,0,10,0q�65   �� 5$      $��Welcome��6   
�������$��12(�5%      $��Center=�6   $��Center=�6;   5&      ]� 5*   
   $��1��6   ���#F0F0F0$��30��66   $��10,10,10,10q�6B   .+�5+      �� $��0,0,10,0q�6   .+�5,      �� $��Store��6   
���   �$
��Bold"�6<   �� 5-      $��Store Details��6   
�������61   5.      �� 5/      $��0,0,10,0q�6   .+�50      �� $��
Till Point��6   
���   �$
��Bold"�6A   �� 51      $��Till Details��6   
�������60   52      �� 53      $��0,0,10,0q�6   .+�54      �� $
��Date��6   
���   �$
��Bold"�6;   �� 55      $��DateVal��6   
�������6+   56      58      � 5<   
   $��2��6   $��	0,10,0,10q�6    � ColumnDefinitions 5=      �� 5>      $	��.2* �6#   �� 5?      $	��.6* �6#   �� 5A      $	��.2* �6#   .+�5F      � $��0��6    5G      �� 5H      5J      �� 5K      5M      .+�5P      ]� $��	0,0,10,10q�6   $��0��6/   .+�5Q      �� $��0��6   
�������.+�5R      �� -   5         ��Name$ txtSearchItem��5R   "   
�������$��2,2,2,2q�5S   &   
�������$��Center=�5T      .��6/   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5V      +  %Microsoft.Xaml.Behaviors.EventTrigger  5W   "      	EventName$ TextChanged��61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5X   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6<   �� *SearchProducts+5Y   #   .��5Z   6   5[      &   System.Windows.Controls.DataGrid  5]         AutoGenerateColumns$ False��5^   #   $��20��6?   $��0,0,0,0q�6K   ��5]   #   �� *SearchResults+	 �� SelectedItem	 6I   �� *	SelResult+
   Columns
 5_      0  *System.Windows.Controls.DataGridTextColumn  5`      ,  &System.Windows.Controls.DataGridColumn   Header$ Barcode��61     5a      $
 Item��61   5c      5d      5e      ]� 5f      $��	0,0,10,10q�6   $��1��6/   .+�5g      �� $��0��6!   
�������5h      5i      5j      � 5m      $��1��6    5n      �� 5o      $
��Auto �6$   �� 5p      $
��Auto �6$   �� 5q      $
��Auto �6$   .+�5u        $ False��6   $��1��67   $��0,0,0,0q�5v      ��5w      �� *posscanentries+	 6B   �� *SelectedScanEntry+
 5x        5y      $ Barcode��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6>   �� *UPC+6V     5z      $
 Item��6-   $ 2* 6Y    6;   �� *	item_name+6Y     5{      $ 	UnitPrice��6-   $ * 6_    6@   �� *
unit_price+6_   4
  .System.Windows.Controls.DataGridTemplateColumn
  5}      $ Quantity��61   $
 1.5* 6C    
  CellTemplate 5~      �� 5   "   .R�5�   &   ��  �� Orientation$ 
Horizontal=�61   $��Center=�6J   .+�5�   *   �� $��-��61   $��20��6=   $��2q�6H   �� 5�   *   $��2��62   $��30��6;    �� TextAlignment$ Center=�6F   �� 5�   *   $��+��61   $��20��6=   $��2q�6H   5�   '   5�   #   5�        5�      $ Subtotal��6-   $ * 6^    6?   �� *
line_total+6^     5�      $ Discount��6-   $ * 6\    6?   �� *
discount+6\   
  5�      $  ��61   $
 Auto 6;    5�      �� 5�   "   .R�5�   &   �� $
��🗑��6-   
������ 
���  ��6S   5�   #   5�      5�      5�      �� 5�      $��2��6   ���#F8F8F8$��10,0,0,0q�6>   .+�5�      ]� $��80��6   .+�5�      �� $
��Item��6    $��10��6,   $��40��68   $��0,0,0,5q�6C   6V   �� 5�      -   5        $ txtitem��5�      $��10��6/   $
��Left=�6;   $��40��6V   $��0,5,0,5q�6a   6t   5�      �� 5�      $��Select Payment Method��6   $
��Bold"�69   $��16(�6K   $��0,0,0,10q�6Y   �� 5�      $��Pay with Cash��6   $��0,5,0,5q�61   ���#E6F7F26B   �� 5�      $��Pay with Card��6   $��0,5,0,5q�61   �� 5�      $ Vertical=�6   $	��120��65   .+�5�      �� $��Subtotal: 11,900.00��6    $
��Bold"�6;   $��Right=�6M   �� 5�      $��Discount: (1,900.00)��6    $��Right=�6<   �� 5�      $��VAT (15%): 0.00��6    $��Right=�67   �� 5�      $��Total: 11,900.00��6    $
��Bold"�68   $��Right=�6J   $��14(�6f   5�      �� 5�      $��Send Payment��6   
��� d �
�������$��40��5�      $��0,20,0,0q�6%   5�      5�      �� 5�   
   $��3��6   ���#093C3C5�      5�      5�      