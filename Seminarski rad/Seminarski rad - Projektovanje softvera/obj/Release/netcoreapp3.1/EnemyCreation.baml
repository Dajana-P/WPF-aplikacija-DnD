   M S B A M L   `   `   `  ���� b  ^Seminarski rad - Projektovanje softvera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Seminarski_rad___Projektovanje_softvera'Seminarski_rad___Projektovanje_softvera  ;    5Seminarski_rad___Projektovanje_softvera.EnemyCreation   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Glocal5clr-namespace:Seminarski_rad___Projektovanje_softvera       � Title$  Enemy Creation��$	��550��$	��900�� � 
ResizeMode$ CanMinimize=����#363062.��� .+��� -    ��Name$ 
txtEnemyID��$
��Left=�$��
140,90,0,0q�$�� �� �� TextWrapping$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -   $ txtIme��$
��Left=�$��140,140,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -   $ 	txtHealth��$
��Left=�$��140,240,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -   $ txtOpis��$
��Left=�$��435,205,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��210�����	#FFDCD2AF���	#FF80558C$��Times New Roman)�$��16(�$��Normal&�$	��105���� -   $ 	txtDamage��$
��Left=�$��480,100,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -   $ txtLevel��$
��Left=�$��480,155,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -    ��Name$ btnBack��$
��Back��$
��Left=�$	��Top=�$��
90,466,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&� � Cursor$
 Hand�� J� RenderTransformOrigin$ 
0.5,-1.456&�$	��160��$��35���� -   $ btnUnesi��$��Unesi��$��60��$
��Left=�$	��Top=�$��
40,360,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&��� -	   $ 	btnIzmeni��$��Izmeni��$��60��$
��Left=�$	��Top=�$��140,360,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&��� -
   $ 
btnIzbrisi��$��Izbrisi��$��60��$
��Left=�$	��Top=�$��240,360,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&��� -    ��Name$ cmbSlika��$
��Left=�$��698,235,0,0q�$	��Top=�$	��130�����	#FFE4D192���	#FF80558C�� -   $ cmbTip��$
��Left=�$��140,190,0,0q�$	��Top=�$��20��$	��120�����	#FF80558C���	#FF80558C&   System.Windows.Controls.DataGrid  -     Name$ tabela��$��352,357,10,10q�
�������	   AlternatingRowBackground	 �	#FFE9D5DA
   
IsReadOnly$

 True�� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%>   '        7 �� 8   "  .���  � �� �	#FF80558C   Columns �� $��EnemyID:��$��30��$��78��$
��Left=�$��	40,85,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $
��Ime:��$��30��$��70��$
��Left=�$��
40,135,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��Health:��$��30��$��75��$
��Left=�$��
40,235,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $
��Tip:��$��30��$��75��$
��Left=�$��
40,185,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��Opis:��$��30��$��70��$
��Left=�$��374,200,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��Damage:��$��30��$��70��$
��Left=�$��
374,95,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��Level:��$��30��$��70��$
��Left=�$��374,150,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $
��Left=�$��	35,22,0,0q�$��Enemy Creation��$	��Top=�$��Times New Roman)�$��20(�$��Normal"�$ Arrow�����	#FFE4D192���	#FF80558C �� Padding$ 20,10,700,10q� J� Opacity$	 0.9Q�$��Expanded&��� $��3q����	#FFE4D192$��350,355,8,8q�._��� $��1q�
���   �._��� $��1q�
���   �$��-4,-4,-4,-4q��� -    ��Name$ imgEnemy��$
��Left=�$��
700,84,0,0q�$	��Top=�$	��128��$	��128��$*��$/Images/Blade of the Ruined King.png��$
��Fill=��� $��2q�
���   �$
��Left=�$	��Top=�$��
698,83,0,0q�$	��130��$	��130���� -    ��Name$ txtBrKaraktera��$��Right=�$��0,310,255,0q�$��(200)��$
��Wrap=�$	��Top=����	#FFD8BBC3 �� TextAlignment$ Center=�	� -    	�Name$ rbMusko��$��Muško��$
��Left=�$��743,283,0,0q�$	��Top=����	#FFE4D192���	#FFD8BBC3���	#FF80558C	� -   $ rbZensko��$��Žensko��$
��Left=�$��743,303,0,0q�$	��Top=����	#FFE4D192���	#FFD8BBC3���	#FF80558C	� -   $ rbDrugo��$��Drugo��$
��Left=�$��743,323,0,0q�$	��Top=����	#FFE4D192���	#FFD8BBC3���	#FF80558C�� $
��Pol:��$��30��$��40��$
��Left=�$��698,275,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� -   $ 
txtDefense��$
��Left=�$��140,285,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� $��Defense:��$��30��$��75��$
��Left=�$��
40,280,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$�