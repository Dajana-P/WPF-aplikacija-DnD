   M S B A M L   `   `   `  ���� b  ^Seminarski rad - Projektovanje softvera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Seminarski_rad___Projektovanje_softvera'Seminarski_rad___Projektovanje_softvera  ?    9Seminarski_rad___Projektovanje_softvera.CharacterCreation   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Glocal5clr-namespace:Seminarski_rad___Projektovanje_softvera       � Title$  CharacterCreation��$	��550��$	��900�� � 
ResizeMode$ CanMinimize=����#363062.��� .+��� -    ��Name$ 	txtCharID��$
��Left=�$��
88,102,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -   $ txtIme��$
��Left=�$��
88,163,0,0q�$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -   $ 
txtPrezime��$
��Left=�$��
88,225,0,0q�$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -   $ 
txtStarost��$
��Left=�$��
88,286,0,0q�$
 Wrap=�$	��Top=�$	��120�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&��� -   $ txtSTR��$
��Left=�$��274,126,0,0q�$
 Wrap=�$	��Top=�$��32�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&�$��0�� �� 
IsReadOnly$
 true���� -    ��Name$ btnBack��$
��Back��$
��Left=�$	��Top=�$��
90,466,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&� � Cursor$
 Hand�� J� RenderTransformOrigin$ 
0.5,-1.456&�$	��160��$��35���� -   $ btnUnesi��$��Unesi��$��60��$
��Left=�$	��Top=�$��
40,360,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&��� -   $ 	btnIzmeni��$��Izmeni��$��60��$
��Left=�$	��Top=�$��140,360,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&��� -	   $ 
btnIzbrisi��$��Izbrisi��$��60��$
��Left=�$	��Top=�$��240,360,0,0q����	#FFE9D5DA���	#FF80558C$��Times New Roman)�$��18(�$��Normal&�&   System.Windows.Controls.DataGrid  -
     Name$ tabela��$��352,357,10,10q�
�������	   AlternatingRowBackground	 �	#FFE9D5DA
   
IsReadOnly$

 True�� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%>   '        7 �� 8   "  .���  � �� �	#FF80558C���� �� $��3q����	#FFE4D192$��350,355,8,8q�._��� $��1q�
���   �._��� $��1q�
���   �$��-4,-4,-4,-4q��� -   $ txtATH��$
��Left=�$��371,126,0,0q�$
 Wrap=�$	��Top=�$��32�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&�$��0��$
 true���� -   $ txtWIS��$
��Left=�$��274,163,0,0q�$
 Wrap=�$	��Top=�$��32�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&�$��0��$
 true���� -   $ txtCHA��$
��Left=�$��371,163,0,0q�$
 Wrap=�$	��Top=�$��32�����	#FFE4D192���	#FF80558C$��Times New Roman)�$��16(�$��Normal&�$��0��$
 true���� -    ��Name$ cmbSlika��$
��Left=�$��717,239,0,0q�$	��Top=�$	��130�����	#FFE4D192���	#FF80558C�� -    ��Name$ imgKarakter��$
��Left=�$��
719,88,0,0q�$	��Top=�$	��128��$	��128��$��
/Garen.png��$
��Fill=��� $��2q�
���   �$
��Left=�$	��Top=�$��
717,87,0,0q�$	��130��$	��130��	� -    	�Name$ rbMusko��$��Muško��$
��Left=�$��762,287,0,0q�$	��Top=����	#FFE4D192���	#FFD8BBC3���	#FF80558C	� -   $ rbZensko��$��Žensko��$
��Left=�$��762,307,0,0q�$	��Top=����	#FFE4D192���	#FFD8BBC3���	#FF80558C	� -   $ rbDrugo��$��Drugo��$
��Left=�$��762,327,0,0q�$	��Top=����	#FFE4D192���	#FFD8BBC3���	#FF80558C�� $
��Pol:��$��30��$��40��$
��Left=�$��717,279,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� -   $ txtOpis��$
��Left=�$��
476,98,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��210�����	#FFDCD2AF���	#FF80558C$��Times New Roman)�$��16(�$��Normal&�$	��105���� $��Opis:��$��30��$��52��$��Center=�$��0,93,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� -    ��Name$ txtBrKaraktera��$��Right=�$��0,203,214,0q�$��(200)��$
��Wrap=�$	��Top=����	#FFD8BBC3 �� TextAlignment$ Center=��� -   $ cmbRace��$
��Left=�$��276,223,0,0q�$	��Top=�$	��120���� -   $ cmbKlasa��$
��Left=�$��276,284,0,0q�$	��Top=�$	��120���� $
��Left=�$��	35,22,0,0q�$��Character Creation��$	��Top=�$��Times New Roman)�$��20(�$��Normal"�$ Arrow�����	#FFE4D192���	#FF80558C �� Padding$ 20,10,700,10q� J� Opacity$	 0.9Q�$��Expanded&�$	��835���� $��CharID:��$��30��$��70��$
��Left=�$��	24,98,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $
��Ime:��$��30��$��70��$
��Left=�$��
45,158,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��Prezime:��$��30��$��70��$
��Left=�$��
18,220,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$�$ 0.238,0.535&��� $��Starost:��$��30��$��70��$
��Left=�$��
26,282,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $
��STR:��$��30��$��43��$
��Left=�$��226,121,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $
��WIS:��$��30��$��43��$
��Left=�$��226,158,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $
��ATH:��$��30��$��48��$
��Left=�$��321,121,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $
��CHA:��$��30��$��48��$
��Left=�$��318,158,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��Rasa:��$��30��$��48��$
��Left=�$��228,219,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� $��Klasa:��$��30��$��54��$
��Left=�$��222,279,0,0q�$	��Top=����	#FFD8BBC3$��Times New Roman)�$��16(�$��Normal&�$��Normal$��� -   $ btnIncreaseSTR��$��0q�$��+��$
��Left=�$��306,126,0,0q�$	��Top=�$��20��$��10�����	#FF2CA226$
��Bold"�$��Normal$�$��	Condensed&�$��10(��� -   $ btnDecreaseSTR��$��0q�$��-��$
��Left=�$��264,126,0,0q�$	��Top=�$��20��$��10�����	#FFCD2121$
��Bold"�$��Normal$�$��	Condensed&�$��10(��� -   $ btnIncreaseATH��$��0q�$��+��$
��Left=�$��403,126,0,0q�$	��Top=�$��20��$��10�����	#FF2CA226$
��Bold"�$��Normal$�$��	Condensed&�$��10(��� -   $ btnIncreaseCHA��$��0q�$��+��$
��Left=�$��403,163,0,0q�$	��Top=�$��20��$��10�����	#FF2CA226$
��Bold"�$��Normal$�$��	Condensed&�$��10(��� -   $ btnIncreaseWIS��$��0q�$��+��$
��Left=�$��306,163,0,0q�$	��Top=�$
��20.4��$��10�����	#FF2CA226$
��Bold"�$��Normal$�$��	Condensed&�$��10(��� -   $ btnDecreaseATH��$��0q�$��-��$
��Left=�$��361,126,0,0q�$	��Top=�$��20��$��10�����	#FFCD2121$
��Bold"�$��Normal$�$��	Condensed&�$��10(��� -   $ btnDecreaseCHA��$��0q�$��-��$
��Left=�$��361,163,0,0q�$	��Top=�$
��20.4��$��10�����	#FFCD2121$
��Bold"�$��Normal$�$��	Condensed&�$��10(��� -   $ btnDecreaseWIS��$��0q�$��-��$
��Left=�$��264,163,0,0q�$	��Top=�$
��20.4��$��10�����	#FFCD2121$
��Bold"�$��Normal$�$��	Condensed&�$��10(��� -   $ txtBlockPoruka��$
��Left=�$��228,101,0,0q�$��Preostali broj poena: 8��$
��Wrap=�$	��Top=����	#FFD8BBC3$��19(�$��Times New Roman)�