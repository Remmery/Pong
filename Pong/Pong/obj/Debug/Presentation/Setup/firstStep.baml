   M S B A M L   `   `   `  ����?  ;Pong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Pong.Presentation.SetupPong.Presentation.Setup  5      '    !Pong.Presentation.Setup.firstStep   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Pong.Presentation.Setup     5      $��315.266��5   7   $	��510��6H   .��5	      � .+�5
   
   �� -   5          ��Name$  
labelTitle��5
      $
��PONG��6$   $��	10,10,0,0q�63   $	��Top=�6F   $��Center=�6^   $
��Bold"�6{   $��29.333(�6�   $��Poor Richard)�6�   �� 5   
   -   5        $  labelDescription��5      $G��AThis is the initial setup of our game. Please fill in the fields.��6*   $��Center=�6v   $	��Top=�6�   $��	10,48,0,0q�6�   $��16(�6�   $��Italic$�6�   �� 5   
   -   5        $  labelNameFirst��5      $��First player name:��6(   $
��Left=�6E   $��
10,120,0,0q�6`   $	��Top=�6t    J� RenderTransformOrigin$ -0.028,-0.35&�6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $  labelNameSecond��5      $��Second player name:��6)   $
��Left=�6G   $��
10,156,0,0q�6b   $	��Top=�6v   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ textBoxFirstName��5      $
��Left=�6,   $��23��6G   $��216,128,0,0q�6S    �� TextWrapping$
 Wrap=�6h   $��Please fill in your name��6|   $	��Top=�6�   $	��268��6�   $��Italic$�6�   �� 5   
   -   5        $ textBoxSecondName��5      $
��Left=�6-   $��23��6H   $��216,164,0,0q�6T   $
 Wrap=�6i   $��Please fill in your name��6}   $	��Top=�6�   $	��268��6�   $��Italic$�6�   �� 5   
   -   5        $  labelNumberOfPlayers��5      $��Number of players:��6.   $
��Left=�6K   $	��Top=�6f   $��	10,89,0,0q�6~   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ textBoxNumberOfPlayers��5      $
��Left=�62   $��20��6M   $
 Wrap=�6Y   $	��Top=�6m   $��50��6�   $��
216,97,0,0q�6�   $��2��6�   �� 5   
   -	   5         ��Name$ cmdDown��5      $	��▼��6"   $
��Left=�6.   $��
285,97,0,0q�6I   $	��Top=�6]   $��20��6u   $��20��6�   6�   �� 5   
   -
   5        $ cmdUp��5      $	��▲��6    $
��Left=�6,   $	��Top=�6G   $��20��6_   $��
265,97,0,0q�6j   $��20��6�   �� 5   
   -   5        $  labelNameThird��5      $��Third player name:��6(   $
��Left=�6E   $��
10,192,0,0q�6`   $	��Top=�6t   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ textBoxThirdName��5      $
��Left=�6,   $��23��6G   $��216,200,0,0q�6S   $
 Wrap=�6h   $��Please fill in your name��6|   $	��Top=�6�   $	��268��6�   $��Italic$�6�   �� 5   
   -   5        $  labelNameFourth��5      $��Fourth player name:��6)   $
��Left=�6G   $��
10,228,0,0q�6b   $	��Top=�6v   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ textBoxFourthName��5      $
��Left=�6-   $��23��6H   $��216,236,0,0q�6T   $
 Wrap=�6i   $��Please fill in your name��6}   $	��Top=�6�   $	��268��6�   $��Italic$�6�   �� 5   
   -   5        $ buttonContinue��5      $��Continue��6)   $
��Left=�6<   $��279,284,0,0q�6W   $	��Top=�6l   $	��100��6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ buttonCancel��5      $��Cancel��6'   $
��Left=�68   $��384,284,0,0q�6S   $	��Top=�6h   $	��100��6�   $��Italic$�6�   6�   5      5      