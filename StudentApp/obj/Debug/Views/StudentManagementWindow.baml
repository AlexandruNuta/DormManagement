   M S B A M L   `   `   `  ����E  AStudentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:StudentApp.ViewModelsStudentApp.ViewModels  5   	   .    (StudentApp.Views.StudentManagementWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:StudentApp.ViewModels     5   	     � Title$  StudentManagementWindow��5   	   $	��450��6)   $	��800��66    � DataContext 5	      ,   &StudentApp.ViewModels.StudentViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *
Students+ �� SelectedItem 63   �� *SelectedStudent+��5      �� 5      .R�5      �� ��6    �� *	FirstName+5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� $	��Add��6   $��60��6I   $��30��6T   $��5q�6`   ��6#   �� *AddStudentCommand+6`   �� 5      $
��Edit��6   $��60��6K   $��30��6V   $��5q�6b   ��6$   �� *EditStudentCommand+6b   �� 5      $��Delete��6   $��60��6O   $��30��6Z   $��5q�6f   ��6&   �� *DeleteStudentCommand+6f   5      �� 5    
   $��1��6   $ Vertical=�6"   $��Right=�69   $��10q�6U   .+�5!      �� $��Student ID:��6   �� 5"      $��0,5,0,10q�6>   ��6   �� *	StudentId+ �� Mode$ TwoWay=�6>   �� 5$      $��First Name:��6   �� 5%      $��0,5,0,10q�6>   ��6   �� *	FirstName+$ TwoWay=�6>   �� 5'      $��
Last Name:��6   �� 5(      $��0,5,0,10q�6=   ��6   �� *
LastName+$ TwoWay=�6=   �� 5*      $
��CNP:��6   �� 5+      $��0,5,0,10q�68   ��6   �� *CNP+$ TwoWay=�68   �� 5-      $��Faculty ID:��6   �� 5.      $��0,5,0,10q�6>   ��6   �� *	FacultyId+$ TwoWay=�6>   �� 50      $��Has Fees��6   $��0,5,0,10q�6H    d� 	IsChecked 6*   �� *	HasFees+6H   �� 51      $��Is Exempted��6   $��0,5,0,10q�6N    6-   �� *
IsExempted+6N   52      53      55      