   M S B A M L   `   `   `  ����O  KLab01_BookManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Lab01_BookManagementLab01_BookManagement  5   	   &     Lab01_BookManagement.AdminWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Lab01_BookManagement     5   	   -   5          � Title$  AdminWindow��5   	   $	��450��6   $	��800��6*   .��5	      � .+�5
   
   �� -   5         ��Name$ lblPage��5
      $��Admin Book Management��6!   $
��Left=�6A   $��43��6\   $��
227,10,0,0q�6h   $	��Top=�6|   $	��309��6�   $��24(�6�   $
��Bold"�6�   �� 5   
   $��Title��6   $
��Left=�6    $��28��6;   $��	62,53,0,0q�6G   $	��Top=�6Z   $��90��6r   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgBook��5      $��71,150,61,149q�6N   6e   �� 5   
   -   5         ��Name$ txtTitle��5      $
��Left=�6$   $��28��6?   $��
157,53,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��207��6�   �� 5   
   $��Author��6   $
��Left=�6!   $��
60,101,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $ 	txtAuthor��5      $
��Left=�6%   $��28��6@   $��
157,99,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��207��6�   �� 5   
   $��Category��6   $
��Left=�6#   $��28��6>   $��
404,53,0,0q�6J   $	��Top=�6^   $��91��6v   �� 5   
   $��Price��6   $
��Left=�6    $��28��6;   $��
404,99,0,0q�6G   $	��Top=�6[   $��91��6s   �� 5   
   -   5        $ TxtPrice��5      $
��Left=�6$   $��28��6?   $��
527,99,0,0q�6K   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��212��6�   �� 5   
   -   5         ��Name$ cboCategory��5      $
��Left=�6(   $��22��6C   $��
527,56,0,0q�6O   $	��Top=�6c   $	��212��6{   �� 5   
   -   5         ��Name$ 	btnCreate��5      $��Create��6$   $
��Left=�65   $��
71,332,0,0q�6P   $	��Top=�6d   $��40��6|   $	��109��6�   $
��Bold"�6�   ���	#FF14C8AE6�   �� 5   
   -	   5        $ 	btnUpdate��5      $��Update��6$   $
��Left=�65   $��227,333,0,0q�6P   $	��Top=�6e   $��41��6}   $	��104��6�   $
��Bold"�6�   ���	#FFCFCC396�   �� 5   
   -
   5        $ 	btnDelete��5      $��Delete��6$   $
��Left=�65   $��382,330,0,0q�6P   $	��Top=�6e   $��46��6}   $��86��6�    J� RenderTransformOrigin$ 0.233,0.527&�6�   $
��Bold"�6�   ���	#FFF62C0A6�   �� 5   
   -   5        $ btnClose��5      $��Close��6#   $
��Left=�63   $��635,328,0,0q�6N   $	��Top=�6c   $��46��6{   $	��104��6�   $
��Bold"�6�   ���	#FF028F856�   �� 5   
   -   5        $ 	btnOrders��5      $��Manage Orders��6$   $
��Left=�6<   $��48��6W   $��510,328,0,0q�6c   $	��Top=�6x   $	��101��6�   $
��Bold"�6�   ���	#FFECF4F36�   5      5      