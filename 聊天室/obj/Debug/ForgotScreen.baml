   M S B A M L   `   `   `  ����D  @聊天室, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:聊天室	聊天室  5   	       聊天室.ForgotScreen   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:聊天室     5   	     � Title$  RegisterScreen��5   	   $	��525��6    $	��365��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF5F2F2��6    � Offset$ 1Q�61   � 5      $ 	#FFE89677��6   $ 0.134Q�61   5       J� 	CacheMode 5   
   &   System.Windows.Media.BitmapCache  5      .+�5   
   �� $��Chat Platform��5      $��Center=�5      $��0,10,0,0q�5      $	��Top=�5       J� RenderTransformOrigin$ 0.647,1.882&�5      $��Segoe Print)�5      $��32(�5      ���	#FF3244445       �� 5"   
   -   5        	 ��Name$	 	separator��5"      $��0,-130,0,226q�6'   
���   �
 J� Effect
 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$      5&      �� 5(   
   -   5         ��Name$ UserData_TB1��5)      $��Center=�5*      $��	0,215,0,0q�5+       �� TextWrapping$
 Wrap=�5,      $	��Top=�5-      $	��200��5.      $��30��5/      
�������
���   �$��20(�52       � Cursor$  ��53       �� 	MaxLength$ 10��54      G� 56   
   -   5         G�Name$ UserData_TB2��57      $��Center=�58      $��	0,336,0,0q�59      $	��Top=�5:      $	��200��5;      $��28��5<      
���   �$��20(�5>      
���   � G� 	MaxLength$ 9��5@      �� 5B   
   -   5         ��Name$ Submit��5C      $��Submit��5D      $
��Left=�5E      $��
37,412,0,0q�5F      $	��Top=�5G      $��Segoe Print)�5H      $��20(�5I      ���	#FFF0D2C7���	#FF324444$	��100��5L      $
��Bold"�5M      
 5N        5O      5Q      �� 5S   
   -   5        $
 Back��5T      $
��Back��5U      $
��Left=�5V      $��223,412,0,0q�5W      $	��Top=�5X      $��Segoe Print)�5Y      $��20(�5Z      ���	#FFF0D2C7���	#FF354648$	��100��5]      $
��Bold"�5^      $ 
0.53,0.045&�6   
 5_        5`      5b      �� 5d   
   -   5         ��Name$ UserData_Label1��5d      $��ID��5e      $��Center=�5f      $��	0,149,0,0q�5g      $	��Top=�5h      $ 0.647,1.882&�5i      $��Segoe Print)�5j      $��32(�5k      ���	#FF394A4C5l      �� 5n   
   -   5        $ UserData_Label2��5n      $��Password��5o      $��Center=�5p      $��	0,265,0,0q�5q      $	��Top=�5r      $ 0.647,1.882&�5s      $��Segoe Print)�5t      $��32(�5u      ���	#FF37484A5v      	� 5x   
   -   5         	�Name$ ForgotAccount��5x      $��忘記帳號��5y      $
��Left=�5z      $��
37,120,0,0q�5{      $	��Top=�5|      $��Microsoft Yi Baiti)�5}      $��24(�5~      
���   �$
��Bold"�5�      $��Italic$�5�       d� 	IsChecked$
 TrueY�5�      6   	� 5�   
   -	   5        $ ForgotPassword��5�      $��忘記密碼��5�      $
��Left=�5�      $��189,120,0,0q�5�      $	��Top=�5�      $��Microsoft Yi Baiti)�5�      $��24(�5�      
���   �$
��Bold"�5�      $��Italic$�5�      6    5�      5�      