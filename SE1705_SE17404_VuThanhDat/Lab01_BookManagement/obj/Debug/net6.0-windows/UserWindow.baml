   M S B A M L   `   `   `  ����O  KLab01_BookManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Lab01_BookManagementLab01_BookManagement  5   	   %    Lab01_BookManagement.UserWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Lab01_BookManagement     5   	     � Title$  
UserWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5   
   �� $��Your Orders��6   $��18(�6&   $
��Left=�64   $	��Top=�6O   $��	10,10,0,0q�6g   $
��Bold"�6z   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgUserOrders��5      $��10,50,400,217q�6)      AutoGenerateColumns$ False��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Order ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Id+6N     5      $ 
Order Date��6%   $ * 6W    69   �� *	OrderDate+6W     5      $ Total Amount��6%   $ * 6[    6;   �� *TotalAmount+6[   5      �� 5   
   $��Order Details��6   $��18(�6(   $
��Left=�66   $	��Top=�6Q   $��
420,10,0,0q�6i   $
��Bold"�6}     5   
   -   5        $ dgOrderDetails��5      $��420,50,10,217q�6+   $ False��6B    5        5      $ 
Book Title��6%   $ * 6W    69   �� *	BookTitle+6W     5      $ Quantity��6%   $ * 6T    67   �� *
Quantity+6T     5      $ Price��6%   $ * 6N    64   �� *Price+6N   5      �� 5    
   $��Create New Order��6   $��18(�6+   $
��Left=�69   $	��Top=�6T   $��
10,261,0,0q�6l   $
��Bold"�6�   �� 5!   
   -   5         ��Name$ txtQuantity��5!      $��221,314,400,0q�6'   $	��Top=�6>   $��32��6V   �� 5"   
   -   5        $��Add to Order��5"      $
��Left=�6(   $��105,365,0,0q�6C   $	��Top=�6X   $	��140��6p   $��35��6�   ���	#FFC841416�   �� 5#   
   -   5        $��Place Order��5#      $
��Left=�6'   $��350,365,0,0q�6B   $	��Top=�6W   $	��118��6o    J� RenderTransformOrigin$ 0.508,0.643&�6�   $��35��6�   ���	#FFDDCA136�   �� 5$   
   -   5        	 ��Name$	 lblQuantity��5$      $��	Quantity:��6%   $
��Left=�69   $��31��6T   $��221,278,0,0q�6`   $	��Top=�6u   $	��105��6�   �� 5%   
   -   5        $	 lblBookTitle��5%      $��Book Title:��6&   $
��Left=�6<   $��33��6W   $��477,276,0,0q�6c   $	��Top=�6x   $	��115��6�   �� 5&   
   -   5        
 ��Name$
 cboBooks��5&      $
��Left=�6%   $��32��6@   $��478,314,0,0q�6L   $	��Top=�6a   $	��276��6y   �� 5'   
   -	   5         ��Name$ btnClose��5'      $��Close��6#   $
��Left=�63   $��35��6N   $��605,365,0,0q�6Z   $	��Top=�6o   $	��125��6�   ���	#FF26D6C96�   5)      5*      