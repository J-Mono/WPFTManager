   M S B A M L   `   `   `  ����T  PTime Management App (POE), Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Time_Management_App__POE_Time_Management_App__POE_  5   	   ,    &Time_Management_App__POE_.Registration   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Time_Management_App__POE_     5   	     � Title$  Registration��5   	   $	��387��6   $	��528��6+   
���   �.��5	      � $	��350��6   $	��525��6   ��5
   
   �� 5       �� ImageSource$ /Poe_Background.jpg��6    j� Stretch$
 Fill=�6;   .+�5   
   �� -   5        $��textBlockHeading��5   M   $��23��6   $
��Left=�6    $��10,5,0,0q�6;   $��Registration:��6e   $	��Top=�6z   $	��110��6�   $��17(�6�   $��ExtraCondensed&�6�   �� 5   
   -   5        $��451,5,12,288q�5      $��Login��6'    � Cursor$
 Hand��67   ��5      �� 5       �� 
TargetType" ��6"   .R�5      �� $��	Underline{�6    �� 5      5      5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ��  �63    �� Triggers 5      P� 5      	 P� Property	 �@J�IsMouseOver
 P� Value$

 true��69   . �5      ��  � ��
 �  ��6;   5      5      5!      � 5#   
   $��
31,0,29,23q�6   
�������$	��264��66   $��Bottom=�6C    � RowDefinitions 5$      �� 5%      $
��252* �6    .+�5(      �� -   5         ��Name$ errormessage��5(   Q   $��20��6   $
��Left=�6$   $��67,0,0,0q�6?   $	��Top=�6h   $	��247��6�    J� OpacityMask
 �<�����	#FFE5572C6�   �� 5)      -   5        $��textBlockFirstname��5)   R   $��23��6   $
��Left=�6$   $��	67,20,0,0q�6?   $��Name:��6l   $	��Top=�6y   $	��110��6�   �� 5*      -   5        $��textBlockLastName��5*   R   $��23��6   $
��Left=�6$   $��	67,50,0,0q�6?   $��Surname:��6k   $	��Top=�6{   $	��110��6�   �� 5+      -   5        $��textBlockEmailId��5+   R   $��23��6   $
��Left=�6$   $��	67,80,0,0q�6?   $��Student Email��6j   $	��Top=�6   $	��110��6�   �� 5,      -   5        $��textBlockPassword��5,   S   $��23��6   $
��Left=�6$   $��
67,107,0,0q�6?   $��	Password:��6l   $	��Top=�6}   $	��110��6�   �� 5-      -   5        $��textBlockConfirmPwd��5-   S   $��23��6   $
��Left=�6$   $��
67,136,0,0q�6?   $��ConfirmPassword:��6n   $	��Top=�6�   $	��110��6�   $��2��6�   �� 5/      -	   5        $��textBoxFirstName��5/   Q   $��23��6   $
��Left=�6"   $��
183,20,0,0q�6=   $	��Top=�6i   $	��222��6�   �� 50      -
   5        $��textBoxLastName��50   Q   $��23��6   $
��Left=�6"   $��
183,50,0,0q�6=   $	��Top=�6h   $	��222��6�   �� 51      -   5        $��textBoxEmail��51   Q   $��23��6   $
��Left=�6"   $��
183,80,0,0q�6=   $	��Top=�6e   $	��222��6}   G� 52      -   5        $��passwordBox1��52   V   $��23��6   $
��Left=�6&   $��183,107,0,0q�6A   $	��Top=�6j   $	��222��6�   G� 54      -   5        $��passwordBoxConfirm��54   V   $��23��6   $
��Left=�6&   $��183,136,0,0q�6A   $	��Top=�6p   $	��222��6�   �� 56      -   5        $��Submit��56   b   $��Submit��6   $��23��6&   $
��Left=�62   $��183,204,0,0q�6M   $	��Top=�6p   $��70��6�   6�   �� 57      -   5        $��button2��57   a   $��Reset��6   $��23��6%   $
��Left=�61   $��259,204,0,0q�6L   $	��Top=�6p   $��70��6�   6�   �� 58      -   5        $��button3��58   b   $��Cancel��6   $��23��6&   $��Right=�62   $��
0,204,60,0q�6N   $	��Top=�6q   $��70��6�   6�   59      5:      5;      