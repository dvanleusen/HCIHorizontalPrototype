   M S B A M L   `   `   `  ����P  LCookingInstructorView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CookingInstructorCookingInstructor  5      U QCookingInstructorViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullkLclr-namespace:CookingInstructorViewModel;assembly=CookingInstructorViewModelCookingInstructorViewModel 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   ListBoxNoHover �� Property �� Value �� 
TargetType  ListBoxTemplate ��Name �� LineLeftCommand �� ElementName �� LineRightCommand ��Name  
RecipeIcon  RecipeIconText  CategoryBox  SubSubTitle	 �� SelectedItem
 �� RelativeSource �� AncestorType �� Path �� Mode �� Orientation  SearchPanel �� DataType4   .CookingInstructorViewModel.MainWindowViewModel#   CookingInstructor.SearchPanel  CategoryPanel  
RecipePage"   CookingInstructor.RecipePage�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:CookingInstructor  5      SvmLclr-namespace:CookingInstructorViewModel;assembly=CookingInstructorViewModel  5      %  &	        &	 j    &	 �    7  &	 �    7  7  7  &	 �    &	 �    7   7  &	 �    �� 5      "  ��6   .�5   
   ��  � ��
 ���� 6'   �� 5	   
    � ��
 ���� 6(   �� 5
   
    � ��$ Center=�65   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $��Border��6   #��z��6+   #��z��6W   #��z��6�   ._�5      �� #��z��6'   #��z��6K   #��z��6   5      5      5      5      �� 5      " ��6.   .R�5   
   ]� .+�5      �� $ LineLeftButton��6   $
��Left=�63   $��20��6I   #��Z 5      ��5      �� $ scrollviewer����5      Z� ��5      Z� ��5      �� 5      $��	arrow.png��6   61   5       �� 5!      $ LineRightButton��6   $��Right=�64   $��20��6K   #��Z 5"      ��5#      �� $ scrollviewer����5$      Z� ��5%      Z� ��5&      �� 5'      $��arrow_flip.png��6   66   5)      �� 5*      $ scrollviewer��6   .��5+      �� 5,      5-      5.      �� 50      .R�51   
   � .+�52      �� ���	#FFFAF8F5$��10q�60   .+�53      �� $	��200��65   $	��200��6E   $��5q�6T   ��6   �� *	ImagePath+6T   �� 54      $	��200��63   8��  ��6   �� *Title+��6j   Z� 55      56      57      �� 59      .R�5:   
   �� $��0,2,0,0q�6   .+�5;      �� $��5,0,0,5q�6-   8��  ��6   �� *Key+6e   � 5<      .+�5=      �� $��Stretch=�5>      8�� $
��Left=�5@   c   $��Hidden=�5A      $��Disabled=�5B      8�� ��5=      Z� ��61   Z� 	 5?      �� 
 �� *FindAncestor+" �$  DataContext.SelectedRecipe�$ OneWayToSource=���5@      �� *Value+��5D      �� 5E      .R�5F      �� $ 
Horizontal=�6)   5G      5I      5K      5L      5M      �� 5O      "   6'   .R�5P   
     5Q      �� 5S      .R�5T   
   �� 8��  8�� $��Disabled=�5X      ��5T      Z� ��6)   Z� ��5V      �� *
Categories+5Y      5Z      �� 5\      .R�5]   
     5^      5`      