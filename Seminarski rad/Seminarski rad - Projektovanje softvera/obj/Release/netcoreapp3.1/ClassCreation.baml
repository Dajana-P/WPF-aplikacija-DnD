   M S B A M L   `   `   `  ���� b  ^Seminarski rad - Projektovanje softvera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Seminarski_rad___Projektovanje_softvera'Seminarski_rad___Projektovanje_softvera  ;    5Seminarski_rad___Projektovanje_softvera.ClassCreation   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Glocal5clr-namespace:Seminarski_rad___Projektovanje_softvera       � Title$  ClassCreation��$	��550��$	��900�� � 
ResizeMode$ CanMinimize=����#363062.��� .+��� -    ��Name$ btnBack��$
��Back��$
��Left=�$	��Top=�$��
90,466,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&� � Cursor$
 Hand�� J� RenderTransformOrigin$ 
0.5,-1.456&�$	��160��$��35���� -   $ btnUnesi��$��Unesi��$��60��$
��Left=�$	��Top=�$��
40,360,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&��� -   $ 	btnIzmeni��$��Izmeni��$��60��$
��Left=�$	��Top=�$��140,360,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&��� -   $ 
btnIzbrisi��$��Izbrisi��$��60��$
��Left=�$	��Top=�$��240,360,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&�&   System.Windows.Controls.DataGrid  -     Name$ tabela��$��352,357,10,10q�
�������   AlternatingRowBackground �	#FFE9D5DA   
IsReadOnly$
 True�� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 �� BasedOn
 �� 
TargetType �� Property �� Value��%>   '        7 �� 8	   "
  .���  � �� �	#FF80558C���� �� $��3q����	#FFE4D192$��350,355,8,8q�._��� $��1q�
���   �._��� $��1q�
���   �$��-4,-4,-4,-4q��� $��Center=�$��0,22,0,0q�$��Class Creation��$
��Wrap=�$	��Top=�$��Times New Roman)�$��20(�$��Normal"�$ Arrow�����	#FFE4D192���	#FF80558C �� Padding$ 20,10,700,10q� J� Opacity$	 0.9Q�$��Expanded&��� -    ��Name$ txtID��$
��Left=�$��140,100,0,0q�$�� �� �� TextWrapping$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -   $ txtNaziv��$
��Left=�$��140,155,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -   $ txtKolicina��$
��Left=�$��424,155,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -	    ��Name$ 	cmbResurs��$
��Left=�$��424,100,0,0q�$	��Top=�$��20��$	��120�����	#FF80558C���	#FF80558C�� $��KlasaID:��$��30��$��70��$
��Left=�$��	40,95,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��Naziv:��$��30��$��70��$
��Left=�$��
40,150,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��Resurs:��$��30��$��70��$
��Left=�$��
324,95,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��	Kolicina:��$��30��$��75��$
��Left=�$��324,150,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� -
   $ cmbSpecialAttack��$
��Left=�$��424,208,0,0q�$	��Top=�$��20��$	��120�����	#FF80558C���	#FF80558C�� $��	Kolicina:��$��30��$��75��$
��Left=�$��324,150,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��Specijalni Napad��$��32��$	��120��$
��Left=�$��299,204,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� -   $ cmbBonus��$
��Left=�$��140,209,0,0q�$	��Top=�$��20��$	��120�����	#FF80558C���	#FF80558C�� $��Bonus:��$��30��$��75��$
��Left=�$��
40,204,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$�