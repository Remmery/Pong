   M S B A M L   `   `   `  ����?  ;Pong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Pong.Presentation.SetupPong.Presentation.Setup  5      [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5      (    "Pong.Presentation.Setup.secondStep   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Pong.Presentation.Setup     5      Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5      $��706.502��5   3   .��5	      � $	��510��6   $��0,21,0,0q�6   .+�5   
   �� -   5          ��Name$  
labelTitle��5      $
��PONG��6$   $��216,10,206,0q�63   $	��Top=�6I   $��Center=�6a   $
��Bold"�6~   $��29.333(�6�   $��Poor Richard)�6�   $��43��6�   $��88��6�   �� 5   
   -   5        $  labelDescription��5      $&�� This is the setup of the camera.��6*   $��Center=�6U   $	��Top=�6r   $��148,48,138,0q�6�   $��16(�6�   $��Italic$�6�   $��31��6�   $	��224��6�   �� 5   
   -   5         ��Name$ groupBox��5      $��Video input��6%   $
��Left=�6:   $��
10,145,0,0q�6U   $	��Top=�6i   $	��142��6�   $	��490��6�   .��5      � .+�5      �� -   5        $  labelVideoSelection��5      $��Select video source:��65   $
��Left=�6T   $��10,9,0,0q�6o   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   �� 5      -   5         ��Name$ comboBoxVideoInput��5      $
��Left=�67   $	��Top=�6R   $	��241��6j   $��
231,18,0,0q�6v   6�   �� 5      -   5        $  labelVideoResolution��5      $��Select video resolution:��66   $
��Left=�6Y   $��	10,45,0,0q�6t   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   �� 5      -   5        $ comboBoxResolution��5      $
��Left=�67   $��
231,54,0,0q�6R   $	��Top=�6f   $	��241��6~   6�   �� 5      -   5         ��Name$ btnStartStop��5      $��Start��6/   $
��Left=�6?   $��
397,84,0,0q�6Z   $	��Top=�6n   $��75��6�   $��26��6�   5      5      �� 5   
   -	   5        $ 	groupBox1��5      $��Video finetuning��6&   $
��Left=�6@   $��
10,292,0,0q�6[   $	��Top=�6o   $	��360��6�   $	��490��6�   .��5      � $��0,0,0,29q�6   .+�5      �� -
   5        $  labelVideoFeed��5      $��	Videofeed��60   $
��Left=�6D   $	��Top=�6_   $��	10,74,0,0q�6w   �� 5      -   5        $  labelFps��5      $
��FPS:��6*   $
��Left=�69   $��
173,74,0,0q�6T   $	��Top=�6h   7  1System.Windows.Forms.Integration.WindowsFormsHost  5      -   5          Name$ windowsFormHost��5   #   $
��Left=�6<   $	��225��6W   $	��Top=�6d   $	��226��6|   $��10,105,0,-21q�6�      Child. 5      %  System.Windows.Forms.PictureBox  -   5        pictureBoxVideo��   BorderStyle$ FixedSingle=�5   =      SizeMode$ StretchImage=�6W   5        5      -   5        $��windowsFormHost1��5   #   $
��Left=�6;   $	��225��6V   $	��Top=�6c   $	��226��6{   $��246,105,0,-21q�6�   . 5         -   5        pictureBoxHanddetection��$ FixedSingle=�5    E   $ StretchImage=�6_   6y   5!      �� 5"      -   5         ��Name$ sliderThreshold��5"      $
��Left=�62   $��
175,17,0,0q�6M   $	��Top=�6a   	 J� RenderTransformOrigin$	 1.797,-0.518&�6y   $	��199��6�   
 � Maximum$	
 255Q�6�    � Value$	 120Q�6�   6�   �� 5#      -   5        $  labelHanddetection��5#      $��Hand detection��64   $
��Left=�6M   $��
313,74,0,0q�6h   $	��Top=�6|   �� 5$      -   5        $  labelThreshold��5$      $��	Threshold��60   $
��Left=�6D   $	��Top=�6_   $��	10,10,0,0q�6w   $
��Bold"�6�   $��16(�6�   �� 5%      -   5        $  labelThresholdValue��5%      $��(120)��65   $
��Left=�6E   $	��Top=�6`   $��
100,14,0,0q�6x   �� 5&      -   5        $  labelMirror��5&      $��Mirror video?��6-   $
��Left=�6E   $	��Top=�6`   $��	10,41,0,0q�6x   $��Italic$�6�   �� 5'      -   5         ��Name$ checkBoxMirror��5'      $�� ��63   $
��Left=�6>   $��	93,47,0,0q�6Y   $	��Top=�6l   6�   5(      5)      �� 5+   
   -   5        $ buttonContinue��5+      $��Continue��6)   $
��Left=�6<   $��279,657,0,0q�6W   $	��Top=�6l   $	��100��6�   $
��Bold"�6�   6�   �� 5,   
   -   5        $ buttonCancel��5,      $��Cancel��6'   $
��Left=�68   $��384,657,0,0q�6S   $	��Top=�6h   $	��100��6�   $��Italic$�6�   6�   5.      5/      