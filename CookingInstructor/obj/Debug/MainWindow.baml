   M S B A M L   `   `   `  ����P  LCookingInstructorView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CookingInstructorCookingInstructor  5      U QCookingInstructorViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullkLclr-namespace:CookingInstructorViewModel;assembly=CookingInstructorViewModelCookingInstructorViewModel 5      "    CookingInstructor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CookingInstructor     5      [vmLclr-namespace:CookingInstructorViewModel;assembly=CookingInstructorViewModel     5      $
��Auto��5	      $
��Auto��6     � DataContext  5      4  .CookingInstructorViewModel.MainWindowViewModel  5   
   .��5      � ���	#FFB5D9DE � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      6   .+�5   
   �� $��1��6   ��6&   �� ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      �� 5       �� Binding 6&   �� *	PageState+ �� Value 16D   .a�5      ��  �� Property � ��   CategoryPanel �� Value# [  6@   5      �� 5       6&   �� *	PageState+ 06D   .a�5      ��  � ��  SearchPanel# [ 6@   5      �� 5       6&   �� *	PageState+ 26D   .a�5       ��  � ��  
RecipePage# [ 6@   5!      5#      5%      � 5'   
   $��1��6   y�6   �� *TutorialOpen+  	BoolToVis �� 	Converter# [ .+�5(      %   CookingInstructor.TutorialPanel  6$   5)      � 5+   
   $��0��6   	 � ColumnDefinitions	 5,      �� 5-      6%   �� 5.      $��60 �6#   60   �� 5/      $��60 �6#   60   �� 50      $��60 �6#   60   �� 51      $��60 �6#   60   .+�54      �� $��0��6   $��5q�6(    	 Title#��[ 63   $��Cooking Instructor��6R   �� 56      $��1��6     Button1#��[ 6%   $��Search��6h   ��6F   �� *ButtonPressed+.��57      �� $
��Auto��6   $
��Auto��6+   .+�58      �� $��
search.png��6     
Button1Img#��[ 60   6V   �� 59      $��Search��6      
ButtonText#��[ 6.   6T   5:      5;      �� 5=      $��2��6   #��[ 6%   $��Groups��6h   ��6F   �� *ButtonPressed+.��5>      �� $
��Auto��6   $
��Auto��6+   .+�5?      �� $��categories.png��6   #��[ 64   6Z   �� 5@      $��Groups��6    #��[ 6.   6T   5A      5B      �� 5D      $��3��6   #��[ 6&   .��5E      �� $
��Auto��6   $
��Auto��6+   .+�5F      �� $��ear.png��6   #��[ 6-   �� 5G      $��Voice��6    #��[ 6-   5H      5I      �� 5K      $��4��6   #��[ 6%   $��Tutorial��6h   ��6F   �� *ButtonPressed+.��5L      �� $
��Auto��6   $
��Auto��6+   .+�5M      �� $��tutorial.png��6   #��[ 62   �� 5N      $��Tutorial��6    #��[ 60   5O      5P      5Q      5S      5T      