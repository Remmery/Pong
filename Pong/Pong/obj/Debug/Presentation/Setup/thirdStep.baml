   M S B A M L   `   `   `  ����?  ;Pong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Pong.Presentation.SetupPong.Presentation.Setup  5      [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5      '    !Pong.Presentation.Setup.thirdStep   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Pong.Presentation.Setup     5      Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5      $��641.502��5	   "   .��5
      � $	��510��6   $��0,21,0,0q�6   .+�5   
   �� -   5          ��Name$  
labelTitle��5      $
��PONG��6$   $��216,10,206,0q�63   $	��Top=�6I   $��Center=�6a   $
��Bold"�6~   $��29.333(�6�   $��Poor Richard)�6�   $��43��6�   $��88��6�   �� 5   
   -   5        $  labelDescription��5      $*��$This is the setup of the hand zones.��6*   $��Center=�6Y   $	��Top=�6v   $��129,53,125,0q�6�   $��16(�6�   $��Italic$�6�   $��31��6�   $	��256��6�   7  1System.Windows.Forms.Integration.WindowsFormsHost  5   
   -   5          Name$ windowsFormHost��5      $
��Left=�64   $	��225��6O   $	��Top=�6\   $	��226��6t   $��
10,157,0,0q�6�      Child. 5      %  System.Windows.Forms.PictureBox  -   5        pictureBoxHandzones��   BorderStyle$ FixedSingle=�5   9      SizeMode$ StretchImage=�6S   5        5   
   -   5        $ windowsFormHost1��5      $
��Left=�65   $	��225��6P   $	��Top=�6]   $	��226��6u   $��262,157,0,0q�6�   . 5        -   5         pictureBoxHanddetectionZones��$ FixedSingle=�5   B   $ StretchImage=�6\   5      �� 5   
   -   5         ��Name$ buttonContinue��5      $��Continue��6)   $
��Left=�6<   $��247,540,0,0q�6W   $	��Top=�6l   $	��100��6�   $
��Bold"�6�   {�.  6�   �� 5   
   -   5        $ buttonCancel��5      $��Cancel��6'   $
��Left=�68   $��352,540,0,0q�6S   $	��Top=�6h   $	��100��6�   $��Italic$�6�   6�   �� 5   
   -	   5        $  labelHandzones��5      $��
Hand zones��6(   $
��Left=�6=   $��
87,387,0,0q�6X   $	��Top=�6l   �� 5   
   -
   5        $  labelHanddetection��5      $%��Hand detection within the zones��6,   $
��Left=�6V   $��283,387,0,0q�6q   $	��Top=�6�   �� 5   
   -   5        $ 	btnSelect��5      $��Select Areas��6$   $
��Left=�6;   $��
10,133,0,0q�6V   $	��Top=�6j   $��96��6�   6�   �� 5   
   -   5        $ btnClear��5      $��Clear Areas��6#   $
��Left=�69   $��140,133,0,0q�6T   $	��Top=�6i   $��96��6�   6�   5      5      