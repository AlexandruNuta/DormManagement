   M S B A M L   `   `   `  ����E  AStudentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:StudentApp.ViewModelsStudentApp.ViewModels  5   	   +    %StudentApp.Views.DormManagementWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:StudentApp.ViewModels     5   	     � Title$  DormManagementWindow��5   	   $	��450��6&   $	��800��63    � DataContext 5	      )   #StudentApp.ViewModels.DormViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *Dorms+ �� SelectedItem 60   �� *SelectedDorm+��5      �� 5      .R�5      �� ��6    �� *
DormNumber+5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� $	��Add��6   $��60��6F   $��30��6Q   $��5q�6]   ��6#   �� *AddDormCommand+6]   �� 5      $
��Edit��6   $��60��6H   $��30��6S   $��5q�6_   ��6$   �� *EditDormCommand+6_   �� 5      $��Delete��6   $��60��6L   $��30��6W   $��5q�6c   ��6&   �� *DeleteDormCommand+6c   5      �� 5!   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5"      �� $��Dorm ID:��6   $��Center=�6(   $��5q�6C   �� 5#      $��60��6   $��Center=�6!   $��5q�6<   ��6G   �� *DormId+�� 5%      $��Dorm Number:��6   $��Center=�6,   $��5q�6G   �� 5&      $	��100��6   $��Center=�6"   $��5q�6=   ��6H   �� *
DormNumber+�� 5(      $��	Dorm Fee:��6   $��Center=�6)   $��5q�6D   �� 5)      $	��100��6   $��Center=�6"   $��5q�6=   ��6H   �� *	DormFee+5*      5+      5,      