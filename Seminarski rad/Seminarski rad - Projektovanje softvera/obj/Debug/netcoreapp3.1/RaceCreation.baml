   M S B A M L   `   `   `  ����b  ^Seminarski rad - Projektovanje softvera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Seminarski_rad___Projektovanje_softvera'Seminarski_rad___Projektovanje_softvera  5   	   :    4Seminarski_rad___Projektovanje_softvera.RaceCreation   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:Seminarski_rad___Projektovanje_softvera     5   	     � Title$  RaceCreation��5   	   $	��550��6   $	��900��6+    � 
ResizeMode$ CanMinimize=�67   ���#363062.��5	      � .+�5
   
   �� -   5         ��Name$ 	txtRasaID��5
      $
��Left=�6%   $��140,100,0,0q�6@   $�� ��6U    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��120��6�   ���	#FFE4D192���	#FF80558C$��Times New Roman)�6�   $��16(�6�   $��Normal&�6�   6(  �� 5   
   -   5        $ txtNaziv��5      $
��Left=�6$   $��140,155,0,0q�6?   $�� ��6T   $
 Wrap=�6\   $	��Top=�6p   $	��120��6�   ���	#FFE4D192���	#FF80558C$��Times New Roman)�6�   $��16(�6�   $��Normal&�6�   �� 5   
   -   5        $ txtOpis��5      $
��Left=�6#   $��
391,99,0,0q�6>   $�� ��6R   $
 Wrap=�6Z   $	��Top=�6n   $	��210��6�   ���	#FFDCD2AF���	#FF80558C$��Times New Roman)�6�   $��16(�6�   $��Normal&�6�   $	��105��6  60  �� 5   
   -   5         ��Name$ btnBack��5      $
��Back��6"   $
��Left=�61   $	��Top=�6L   $��
90,466,0,0q�6z   ���	#FFE9D5DA���	#FF80558C$��Times New Roman)�6�   $��18(�6�   $��Normal&�6�    � Cursor$
 Hand��6�    J� RenderTransformOrigin$ 
0.5,-1.456&�6  $	��160��6.  $��35��6:  �� 5   
   -   5        $ btnUnesi��5      $��Unesi��6#   $��60��63   $
��Left=�6>   $	��Top=�6Y   $��
40,360,0,0q�6r   ���	#FFE9D5DA���	#FF80558C$��Times New Roman)�6�   $��18(�6�   $��Normal&�6�   6�   �� 5   
   -   5        $ 	btnIzmeni��5      $��Izmeni��6$   $��60��65   $
��Left=�6@   $	��Top=�6[   $��140,360,0,0q�6t   ���	#FFE9D5DA���	#FF80558C$��Times New Roman)�6�   $��18(�6�   $��Normal&�6�   6�   �� 5   
   -   5        $ 
btnIzbrisi��5      $��Izbrisi��6%   $��60��67   $
��Left=�6B   $	��Top=�6]   $��240,360,0,0q�6v   ���	#FFE9D5DA���	#FF80558C$��Times New Roman)�6�   $��18(�6�   $��Normal&�6�   6�   �� 5   
   -   5         ��Name$ cmbBonus��5      $
��Left=�6%   $��140,209,0,0q�6@   $	��Top=�6U   $��20��6m   $	��120��6y   ���	#FF80558C���	#FF80558C6�   &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ tabela��5      $��352,357,10,10q�6#   
�������	   AlternatingRowBackground	 �	#FFE9D5DA
   
IsReadOnly$

 True��6u    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%c   '        7 �� 5      8   "  6Q   .�5      ��  � �� �	#FF80558C63   5      5      5      �� 5   
   $��RaceID:��6   $��30��6"   $��75��6.   $
��Left=�69   $��	40,95,0,0q�6T   $	��Top=�6g   ���	#FFD8BBC3$��Times New Roman)�6�   $��16(�6�   $��Normal&�6�   $��Normal$�6�   �� 5   
   $��Naziv:��6   $��30��6!   $��70��6-   $
��Left=�69   $��
40,150,0,0q�6T   $	��Top=�6h   ���	#FFD8BBC3$��Times New Roman)�6�   $��16(�6�   $��Normal&�6�   $��Normal$�6�   �� 5   
   $��Bonus:��6   $��30��6!   $��75��6-   $
��Left=�68   $��
40,204,0,0q�6S   $	��Top=�6g   ���	#FFD8BBC3$��Times New Roman)�6�   $��16(�6�   $��Normal&�6�   $��Normal$�6�   �� 5   
   $��Opis:��6   $��30��6    $��70��6,   $
��Left=�67   $��
330,94,0,0q�6R   $	��Top=�6f   ���	#FFD8BBC3$��Times New Roman)�6�   $��16(�6�   $��Normal&�6�   $��Normal$�6�   �� 5   
   $
��Left=�6   $��	35,22,0,0q�6/   $��Race Creation��6B   $
��Wrap=�6W   $	��Top=�6k   $��Times New Roman)�6�   $��20(�6�   $��Normal"�6�   $ Arrow��6�   ���	#FFE4D192���	#FF80558C �� Padding$ 20,10,700,10q�6�    J� Opacity$	 0.9Q�6  $��Expanded&�6$  �� 5   
   $��3q�6   ���	#FFE4D192$��350,355,8,8q�6=   ._�5      �� $��1q�6   
���   �._�5       �� $��1q�6   
���   �$��-4,-4,-4,-4q�6A   5!      5"      �� 5#   
   -
   5         ��Name$ txtBrKaraktera��5#      $��Right=�6,   $��0,204,299,0q�6H   $��(200)��6]   $
��Wrap=�6j   $	��Top=�6~   ���	#FFD8BBC3 �� TextAlignment$ Center=�6�   5$      5%      