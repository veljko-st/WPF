   M S B A M L   `   `   `  ????K  GAukcijskaProdaja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AukcijskaProdajaAukcijskaProdaja  5   	   #    AukcijskaProdaja.SingInWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AukcijskaProdaja     5   	   -   5        $	??450??5   (   $	??380??65     ? WindowStartupLocation$  CenterScreen=?6A    ? Title 6	   ?? *WindowTitle1+.??5	      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??3* ?6    ? Triggers 5   
   :? 5       :? RoutedEvent$ Grid.Loaded??6   .[?5      ?? .??5      ?? .??5      ??  ?? 
TargetName$ 	rectangle??6)    ?? TargetProperty$! Fill.GradientStops[1].Color?5   !   	 ?? To$ BlackX?5   !    g? Duration$ 0:0:10D?6,   	 g? AutoReverse	 . 
 g? RepeatBehavior$
 Forever??5   !   5      5      5      5      .+?5    
   ?? -   5         ??Name$ 	rectangle??5       $??2??6'    ?? Stretch$ UniformToFill=?68   ??5!      
? 5"       
? RadiusX$ 1Q?6&    
? RadiusY$ 1Q?62    
? GradientOrigin$ 0.7,0.3&?6>   .??5#      ?  ? Color$ White??6#    ? Offset$ 0Q?61   6>   ? 5$      $
 Gray??6#   $ 1Q?60   6=   5%      5'      ?? 5*   
   $??Center=?61   $??Center=?6N   $??Arial)?6i   
?????? $
??Bold"?5+      $??32(?6"   ??5*      ?? *WindowTitle1+5+   2   ?? 5.   
   $??0,72,0,0q?6   $??2??6'   .+?51      ?? $??	User Name??6   $??57, 0q?6(   $??15(?67   $??Segoe UI Historic)?6E   $	??250??6d   ?? 52      -   5         ??Name$ txtUsername??52      $??Segoe UI Historic)?6+   
?????? $??Light"?6c   $??22(?6v   $??Center=?6?   $??0q?53      $	??250??6*   $
??Left=?66    J? Opacity$	 0.7Q?6X   ??54      ?? *Currentuser.UserName+ ?? NotifyOnValidationError . ?? 55      $	??250??6   $??2??6!   
???????$	 0.5Q?6?   $??Center=?6M   $??Center=?6j   ?? 57      $??	User Pass??6   $??57, 40,57,0q?6(   $??15(?6=   $??Segoe UI Historic)?6K   $	??250??6j   ?? 58      -   5        $ txtpassword??58      $??Segoe UI Historic)?6+   
?????? $??Light"?6c   $??22(?6v   $??Center=?6?   $??0q?59      $	??250??6*   $
??Left=?66   $	 0.7Q?6X   ??5:      ?? *Currentuser.UserPass+ . ?? 5;      $	??250??6   $??2??6!   
???????$	 0.5Q?6?   $??Center=?6M   $??Center=?6j   ?? 5<      $??Status??6   $??57, 40,57,0q?6%   $??15(?6:   $??Segoe UI Historic)?6H   $	??250??6g   ?? 5=      -   5        $ txtisAdmin1??5=      $??Segoe UI Historic)?6+   
?????? $??Light"?6c   $??22(?6v   $??Center=?6?   $??0q?5>      $	??250??6*   $
??Left=?66   $	 0.7Q?6X   ??5?      ?? *Currentuser.Status+ . ?? 5@      $	??250??6   $??2??6!   
???????$	 0.5Q?6?   $??Center=?6M   $??Center=?6j   ?? 5C       ?? Orientation$ 
Horizontal=?6   $??Right=?62   $??Center=?6N   .+?5D      ?? -   5         ??Name$ editBtn??5D   a      ButtonStyle1#???   6:   $
??Save??6r   $	??100??6?   $??30??6?   ???	#FF64CCF1
???????$??14(?6?   $??	0,40,30,0q?6?   ??6   ?? *SaveCommand1+6?   5E      5F      5G      5H      