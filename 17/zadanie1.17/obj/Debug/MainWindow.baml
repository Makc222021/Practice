   M S B A M L   `   `   `  ����F  Bzadanie1.17, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:zadanie1._17zadanie1._17  5   	       zadanie1._17.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:zadanie1._17     5   	     � Title$  Event Organizer��5   	   $	��400��6!   $	��600��6.    � 	Resources 5
         BackgroundAnimation �� 
TargetName �� TargetProperty �� From	 �� To g� Duration g� RepeatBehavior g� AutoReverse��%�   &	        �� 5   
   .��5      �� $ 
MainWindow��5      $1 +(Window.Background).(SolidColorBrush.Color)�5      $ 	LightBlueX�5      $ 
LightGreenX�6"   $ 2D�62   $ Forever��5       . 6*   5      5      .��5      � -   5        	 �Name$	 MainGrid��5      .+�5   
   �� -   5        
 ��Name$
 ScheduleItemsControl��5      ��5      �� 5      .R�5      ��  ��Name$ 
EventBlock��6   
�������$��10q�6H    J� Opacity$ 0Q�6T   ._�5      �� $��20(�6?    �� Padding$ 10q�6M   ��6$   �� *	EventName+6M    � Triggers 5      :� 5       :� RoutedEvent$ Border.Loaded��6+   .[�5   "   �� .��5   &   �� .��5   *   W� $ 
EventBlock��5   -   $ Opacity�5    -    W� From$ 0X�5!   -   	 W� To$ 1X�66   $ 0:0:0.5D�6=   5"   '   5#   #   5$      5&      5'      5)      �� 5*   
   -   5        $��Start Animation��5*      $��Right=�6H   $	��Top=�6d   $��10q�6|   5+      5,      