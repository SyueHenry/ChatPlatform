   M S B A M L   `   `   `  ����D  @聊天室, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:聊天室	聊天室  5   	       聊天室.RegisterScreen   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:聊天室     5   	     � Title$  RegisterScreen��5   	   $	��545��6    $	��365��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFF5F2F2��6    � Offset$ 1Q�61   � 5      $ 	#FF9A77E8��6   $ 0.134Q�61   5       J� 	CacheMode 5   
   &   System.Windows.Media.BitmapCache  5      .+�5   
   �� $��Chat Platform��5      $��Center=�5      $��0,10,0,0q�5      $	��Top=�5       J� RenderTransformOrigin$ 0.647,1.882&�5      $��Segoe Print)�5      $��32(�5      ���	#FF3244445       �� 5"   
   -   5        	 ��Name$	 	separator��5"      $��0,-130,0,226q�6'   
���   �
 J� Effect
 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$      5&      �� 5(   
   -   5         ��Name$ Account��5)      $��Center=�5*      $��	0,265,0,0q�5+       �� TextWrapping$
 Wrap=�5,      $	��Top=�5-      $	��200��5.      $��30��5/      
�������
���   �$��20(�52       � Cursor$  ��53       �� 	MaxLength$ 16��54      G� 56   
   -   5         G�Name$ Password��57      $��Center=�58      $��	0,375,0,0q�59      $	��Top=�5:      $	��200��5;      $��28��5<      
���   �$��20(�5>      
���   � G� 	MaxLength$ 9��5@      �� 5B   
   -   5         ��Name$ Register��5C      $��Register��5D      $
��Left=�5E      $��
37,439,0,0q�5F      $	��Top=�5G      $��Segoe Print)�5H      $��20(�5I      ���	#FFDCD0EF���	#FF324444$	��100��5M      $
��Bold"�5N      
 5O        5P      5R      �� 5T   
   -   5        $
 Back��5U      $
��Back��5V      $
��Left=�5W      $��224,439,0,0q�5X      $	��Top=�5Y      $��Segoe Print)�5Z      $��20(�5[      ���	#FFDCD0EF���	#FF354648$	��100��5_      $
��Bold"�5`      
 5a        5b      5d      �� 5f   
   -   5        $ ID��5g      $��Center=�5h      $��	0,155,0,0q�5i      $
 Wrap=�5j      $	��Top=�5k      $	��200��5l      $��30��5m      
�������
���   �$��20(�5p      $  ��5q      $ 10��5r      �� 5t   
   $��ID��5u      $��Center=�5v      $��0,89,0,0q�5w      $	��Top=�5x      $ 0.647,1.882&�5y      $��Segoe Print)�5z      $��32(�5{      ���	#FF3244445|      �� 5~   
   $��Account��5      $��Center=�5�      $��	0,199,0,0q�5�      $	��Top=�5�      $ 0.647,1.882&�5�      $��Segoe Print)�5�      $��32(�5�      ���	#FF3244445�      �� 5�   
   $��Password��5�      $��Center=�5�      $��	0,309,0,0q�5�      $	��Top=�5�      $ 0.647,1.882&�5�      $��Segoe Print)�5�      $��32(�5�      ���	#FF37484A5�      5�      5�      