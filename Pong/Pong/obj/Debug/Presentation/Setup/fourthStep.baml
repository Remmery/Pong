   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      ? ;Pong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Pong.Presentation.SetupPong.Presentation.Setup 5      (   "Pong.Presentation.Setup.fourthStep   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      6sys&clr-namespace:System;assembly=mscorlib     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Pong.Presentation.Setup     5      X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      $��512.203��5	      $	��561��6/   .��5
      � $	��510��6   $��1,21,1,0q�6   .+�5   
   �� -   5          ��Name$  
labelTitle��5      $
��PONG��6$   $��216,10,206,0q�63   $	��Top=�6I   $��Center=�6a   $
��Bold"�6~   $��29.333(�6�   $��Poor Richard)�6�   $��43��6�   $��88��6�   �� 5   
   -   5        $  labelDescription��5      $,��&This is the general setup of the game.��6*   $��Center=�6[   $	��Top=�6x   $��129,53,106,0q�6�   $��16(�6�   $��Italic$�6�   $��31��6�   $	��275��6�   �� 5   
   -   5         ��Name$ groupBoxGeneral��5      $��General��6,   $
��Left=�6=   $��	18,95,0,0q�6X   $	��Top=�6k   $��90��6�   $	��220��6�   
���   ����	#05000000.��5      � $��2,0,-2,0q�6   .+�5      �� -   5        $  labelTimeLimit��5      $��Time limit:��60   $
��Left=�6F   $��	10,10,0,0q�6a   $	��Top=�6t   $��Normal"�6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5      -   5          Name$ integerUpDownTimeLimit��5   %   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 5X�6E   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	Increment$ 1X�6O      Maximum$ 30X�6]      Minimum$ 1X�6j   $��90,15,70,35q�6v   $��48��6�   $��18��6�   �� 5      -   5        $  LabelMaxScore��5      $��
Max score:��6/   $
��Left=�6D   $��	10,41,0,0q�6_   $	��Top=�6r   $��Normal"�6�     5      -   5        $ IntegerUpDownMaxScore��5   %   $ 10X�6D   $ 1X�6O   $ 20X�6]   $ 3X�6j   $��
90,47,70,3q�6v   &   System.Windows.Media.TextOptions   TextHintingMode$ Fixed=�6�   $��48��6�   $��18��6�   �� 5      -   5        $  labelMinutes��5      $��minutes��6.   $
��Left=�6@   $��
143,10,0,0q�6[   $	��Top=�6o   $��Italic$�6�   �� 5      -	   5        $  labelMaxScore��5      $��points��6/   $
��Left=�6@   $��
141,41,0,0q�6[   $	��Top=�6o   $��Italic$�6�   5      5      �� 5   
   -
   5        $ groupBoxPlayer��5      $��Player��6+   $
��Left=�6;   $��
18,190,0,0q�6V   $	��Top=�6j   $	��146��6�   $	��220��6�   ���	#05000000.��5      � .+�5      �� -   5        $  labelStartHealth��5      $��Start health:��62   $
��Left=�6J   $��	10,10,0,0q�6e   $	��Top=�6x     5      -   5        $ IntegerUpDownStartHealth��5   %   $ 5X�6G   $ 1X�6Q   $ 10X�6_   $ 5X�6l   $��94,16,66,90q�6x   $ Fixed=�6�   $��18��6�   $��48��6�   �� 5      -   5        $  LabelMaxHealth��5      $��Max health:��60   $
��Left=�6F   $��	10,41,0,0q�6a   $	��Top=�6t     5      -   5        $ IntegerUpDownMaxHealth��5   %   $ 10X�6E   $ 1X�6P   $ 15X�6^   $ 3X�6k   $��94,46,66,60q�6w   $ Fixed=�6�   $��18��6�   $��48��6�   �� 5       -   5        $  labelMinHealth��5       $��Min health:��60   $
��Left=�6F   $��	10,72,0,0q�6a   $	��Top=�6t     5!      -   5        $ IntegerUpDownMinHealth��5!   %   $ 3X�6E   $ 1X�6O   $ 5X�6]   $ 1X�6i   $��94,77,66,29q�6u   $ Fixed=�6�   $��18��6�   $��48��6�   5"      5#      �� 5%   
   -   5        $ groupBoxPowerups��5%      $��	Power-ups��6-   $
��Left=�6@   $��
243,95,0,0q�6[   $	��Top=�6o   $	��392��6�   $	��257��6�   ���	#05000000.��5&      � .+�5'      �� -   5         ��Name$ rectanglePowerups��5'      ���	#FFF4F4F5$
��Left=�6H   $��70��6c   ���	#7F000000$	��Top=�6�   $	��240��6�   $��3,3,0,0q�6�   $��2��6�   �� 5(      -   5        	 ��Name$	 checkBoxBombPowerup��5(      $
��Bomb��68   
 d� 	IsChecked$

 TrueY�6G   $
��Left=�6X   $	��Top=�6s   $��
27,107,0,0q�6�   6�   �� 5)      -   5        $	 checkBoxHealthPowerUp��5)      $��Health��6:   $

 TrueY�6K   $
��Left=�6\   $	��Top=�6w   $��
27,127,0,0q�6�   6�   �� 5*      -   5        $	 checkBoxMultiballPowerup��5*      $��	Multiball��6=   $

 TrueY�6Q   $
��Left=�6b   $	��Top=�6}   $��
27,147,0,0q�6�   6�   �� 5+      -   5        $	 checkBoxReversePowerup��5+      $��Reverse��6;   $

 TrueY�6M   $
��Left=�6^   $	��Top=�6y   $��
27,167,0,0q�6�   6�   �� 5,      -   5        $	 checkBoxSpeedPowerup��5,      $��	Speedball��69   $

 TrueY�6M   $
��Left=�6^   $	��Top=�6y   $��
27,187,0,0q�6�   6�   �� 5-      -   5        $  LabelPowerupQuestion��5-      $(��"What power-ups would you activate?��66   $
��Left=�6c   $��	10,78,0,0q�6~   $	��Top=�6�   $��Italic$�6�   �� 5.      -   5        $  labelChanceOfAppearance��5.      $��Chance of appearance:��69   $
��Left=�6Y   $��
10,215,0,0q�6t   $	��Top=�6�   �� 5/      -   5        $  LabelDamage��5/      $��Damage Bomb��6-   $
��Left=�6C   $��
10,246,0,0q�6^   $	��Top=�6r   �� 50      -   5        $  LabelShieldHealing��50      $��Healing shield��64   $
��Left=�6M   $��
10,277,0,0q�6h   $	��Top=�6|   �� 51      -   5        $  	LabelPlus��51      $��+��6+   $
��Left=�67   $��125,307,0,0q�6R   $	��Top=�6g   �� 52      -   5        $  LabelSpeedBall��52      $��	Speedball��60   $
��Left=�6D   $��
10,308,0,0q�6_   $	��Top=�6s   �� 53      -   5        $  labelReverseTime��53      $��Reverse time��62   $
��Left=�6I   $��
10,339,0,0q�6d   $	��Top=�6x     54      -   5        $ IntegerUpDownChance��54   %   $ 20X�6B   $ 1X�6M   $ 50X�6[   $ 5X�6h   $��143,220,55,132q�6t   $ Fixed=�6�   $��18��6�   $��47��6�   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   IsUndoEnabled .  6�   �� 55      -    5        $  labelProcent��55      $��%��6.   $
��Left=�6:   $��193,216,0,0q�6U   $	��Top=�6j   �� 56      -!   5        $  labelProcent2��56      $��%��6/   $
��Left=�6;   $��193,307,0,0q�6V   $	��Top=�6k   �� 57      -"   5        $  labelSeconds��57      $��seconds��6.   $
��Left=�6@   $��193,339,-1,0q�6[   $	��Top=�6q     58      -#   5        $ IntegerUpDownDamageBomb��58   %   $ 2X�6F   $ 1X�6P   $ 5X�6^   $ 1X�6j   $��143,254,55,98q�6v   $ Fixed=�6�   $��18��6�   $��47��6�     59      -$   5        $  IntegerUpDownHealingShield��59   %   $ 2X�6I   $ 1X�6S   $ 5X�6a   $ 1X�6m   $��143,280,55,72q�6y   $ Fixed=�6�   $��18��6�   $��47��6�     5:      -%   5        $ IntegerUpDownSpeedball��5:   %   $ 50X�6E   $ 1X�6P   $	 200X�6^   $ 10X�6l   $��143,311,55,41q�6y   $ Fixed=�6�   $��18��6�   $��47��6�     5;      -&   5        $ IntegerUpDownReverseTime��5;   %   $ 10X�6G   $ 5X�6R   $ 20X�6`   $ 5X�6m   $��145,344,53,8q�6y   $ Fixed=�6�   $��18��6�   $��47��6�      Text$ 10��6�      UpdateValueOnEnterKey . 6�   �� 5<      -'   5         ��Name$ 	imageBomb��5<      $
��Left=�6+   $��35��6F   $	��Top=�6R   $��35��6j   $��	10,11,0,0q�6u    J� OpacityMask �	#FC000000$:��4/Pong;component/Presentation/Images/BombPowerUp2.png��6�   �� 5=      -(   5        $ imageHealth��5=      $
��Left=�6-   $��35��6H   $	��Top=�6T   $��35��6l   $��	59,12,0,0q�6w    �	#FC000000$<��6/Pong;component/Presentation/Images/HealthPowerUp2.png��6�   �� 5>      -)   5        $ imageMultiball��5>      $
��Left=�60   $��35��6K   $	��Top=�6W   $��35��6o   $��
105,12,0,0q�6z    �	#FC000000$>��8/Pong;component/Presentation/Images/MultiBallPowerUp.png��6�   �� 5?      -*   5        $ imageReverse��5?      $
��Left=�6.   $��35��6I   $	��Top=�6U   $��35��6m   $��
152,12,0,0q�6x    �	#FC000000$=��7/Pong;component/Presentation/Images/ReversePowerUp2.png��6�   �� 5@      -+   5        $ imageSpeedball��5@      $
��Left=�60   $��35��6K   $	��Top=�6W   $��35��6o   $��
197,12,0,0q�6z    �	#FC000000$;��5/Pong;component/Presentation/Images/SpeedPowerUp3.png��6�   �� 5A      -,   5        $  	labelBomb��5A      $
��Bomb��6+   $
��Left=�6:   $	��Top=�6U   $��9,45,0,0q�6m   �� 5B      --   5        $  labelShield��5B      $��Health��6-   $
��Left=�6>   $	��Top=�6Y   $��	53,45,0,0q�6q   �� 5C      -.   5        $  labelMultiball��5C      $��	Multiball��60   $
��Left=�6D   $	��Top=�6_   $��	93,45,0,0q�6w   �� 5D      -/   5        $  labelReverse��5D      $��Reverse��6.   $
��Left=�6@   $	��Top=�6[   $��
144,45,0,0q�6s   �� 5E      -0   5        $  
labelSpeed��5E      $��Speed��6,   $
��Left=�6<   $	��Top=�6W   $��
193,45,0,0q�6o   5F      5G      �� 5I   
   -1   5        $ groupBoxBall��5I      $
��Ball��6)   $
��Left=�67   $��18,341,0,-8q�6R   $	��Top=�6g   $	��146��6   $	��220��6�   ���	#05000000.��5J      � .+�5K      �� -2   5        $  labelStartVelocity��5K      $��Start velocity:��64   $
��Left=�6N   $��	10,10,0,0q�6i   $	��Top=�6|     5L      -3   5        $  IntegerUpDownStartVelocity��5L   %   $ 4X�6I   $ 1X�6S   $ 10X�6a   $ 2X�6n   $��94,16,66,90q�6z   $ Fixed=�6�   $��18��6�   $��48��6�   �� 5M      -4   5        $  LabelMaxVelocity��5M      $��Max velocity:��62   $
��Left=�6J   $��	10,41,0,0q�6e   $	��Top=�6x     5N      -5   5        $ IntegerUpDownMaxVelocity��5N   %   $ 10X�6G   $ 1X�6R   $ 20X�6`   $ 3X�6m   $��94,47,66,59q�6y   $ Fixed=�6�   $��18��6�   $��48��6�   �� 5O      -6   5        $  labelAcceleration��5O      $��Acceleration:��63   $
��Left=�6K   $��	10,72,0,0q�6f   $	��Top=�6y     5P      -7   5        $ IntegerUpDownAcceleration��5P   %   $ 5X�6H   $ 1X�6R   $ 20X�6`   $ 3X�6m   $��94,77,66,29q�6y   $ Fixed=�6�   $��18��6�   $��48��6�   �� 5Q      -8   5        $  labelProcent3��5Q      $��%��6/   $
��Left=�6;   $��
144,73,0,0q�6V   $	��Top=�6j   5R      5S      �� 5U   
   -9   5         ��Name$ 
buttonPlay��5U      $��Play the game��6%   $
��Left=�6=   $��295,503,0,0q�6X   $	��Top=�6m   $	��100��6�   $
��Bold"�6�   6�   �� 5V   
   -:   5        $ buttonCancel��5V      $��Cancel��6'   $
��Left=�68   $��400,503,0,0q�6S   $	��Top=�6h   $	��100��6�   $��Italic$�6�   6�   5W      5X      