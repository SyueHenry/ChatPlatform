   M S B A M L   `   `   `  ����D  @聊天室, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:聊天室	聊天室  5   	       聊天室.LoginScreen   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:聊天室     5   	     � Title$  LoginScreen��5   	   $	��400��6   $	��420��6*    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � $��	0,0,-17,0q�6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF5F2F2��6    � Offset$ 1Q�61   � 5      $ 	#FF77CBE8��6   $ 0.134Q�61   5       J� 	CacheMode 5   
   &   System.Windows.Media.BitmapCache  5      .+�5   
   �� $��Chat Platform��5      $��Center=�5      $��0,10,0,0q�5      $	��Top=�5       J� RenderTransformOrigin$ 0.647,1.882&�5      $��Segoe Print)�5      $��32(�5      ���	#FF3244445       �� 5"   
   -   5        	 ��Name$	 	separator��5"      $��0,-64,0,134q�6'   
���   �
 J� Effect
 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$      5&      �� 5(   
   $
��Left=�5)      $��30��5*      $��
60,120,0,0q�5+      $	��Top=�5,      $��30��5-      $��/charactor icon.png��5.      $ 1.304,0.763&�5/      
 50        51      53      �� 55   
   $
��Left=�56      $��40��57      $��
56,217,0,0q�58      $	��Top=�59      $��40��5:      $��/lock icon.png��5;      $ 0.813,0.569&�6%   
 5<        5=      5?      �� 5A   
   -   5         ��Name$ Account��5B      $��Center=�5C      $��	0,120,0,0q�5D       �� TextWrapping$
 Wrap=�5E      $	��Top=�5F      $	��200��5G      $��30��6   
�������
���   �$��20(�5J       � Cursor$  ��5K       �� 	MaxLength$ 16��5L      G� 5N   
   -   5         G�Name$ Password��5O      $��Center=�5P      $��	0,229,0,0q�5Q      $	��Top=�5R      $	��200��5S      $��28��5T      
���   �$��20(�5V      
���   � G� 	MaxLength$ 9��5X       G� Password$  ��5Y      $ 0.508,0.116&�6   �� 5[   
   -   5         ��Name$ Login��5\      $��Login��5]      $
��Left=�5^      $��
30,300,0,0q�5_      $	��Top=�5`      $��Segoe Print)�5a      $��20(�5b      ���	#FFD1E7EF���	#FF324545$	��100��5f      $
��Bold"�5g      
 5h        5i      5k      �� 5m   
   -   5        $ Register��5n      $��Register��5o      $
��Left=�5p      $��152,300,0,0q�5q      $	��Top=�5r      $��Segoe Print)�5s      $��20(�5t      ���	#FFD1E7EF���	#FF354A50$	��100��5w      $
��Bold"�5x      
 5y        5z      5|      �� 5~   
   -   5        $ Forgot��5      $��Forgot��5�      $
��Left=�5�      $��272,300,30,0q�5�      $	��Top=�5�      $��Segoe Print)�5�      $��20(�5�      ���	#FFD1E7EF���	#FF354A50$	��100��5�      $
��Bold"�5�      
 5�        5�      5�      5�      5�      