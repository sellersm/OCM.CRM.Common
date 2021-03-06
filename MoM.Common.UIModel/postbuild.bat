echo copy uimodel assembly to local bin and release folders...
xcopy "C:\MissionOfMercy\CRM\Source\MoM.Common\MoM.Common.UIModel\bin\Release\MoM.Common.UIModel.dll" "C:\Program Files\Blackbaud\bbappfx\vroot\bin\custom" /y /d

echo.
echo copy all htmlforms to the appropriate location on the webserver...
xcopy "C:\MissionOfMercy\CRM\Source\MoM.Common\MoM.Common.UIModel\Interaction\InteractionExtension.AddForm.html" "C:\Program Files\Blackbaud\bbappfx\vroot\browser\htmlforms\custom" /y /d
xcopy "C:\MissionOfMercy\CRM\Source\MoM.Common\MoM.Common.UIModel\Interaction\InteractionExtension.EditForm.html" "C:\Program Files\Blackbaud\bbappfx\vroot\browser\htmlforms\custom" /y /d
xcopy "C:\MissionOfMercy\CRM\Source\MoM.Common\MoM.Common.UIModel\Interaction\InteractionExtension.ViewForm.html" "C:\Program Files\Blackbaud\bbappfx\vroot\browser\htmlforms\custom" /y /d

rem echo copy all htmlforms to the appropriate location on the webserver...
rem xcopy %~dp0htmlforms\*.* %~dp0..\..\..\..\Blackbaud.AppFx.Server\Deploy\browser\htmlforms\ /e /y /r

rem echo minify the html and js files to optimize their payload on the wire
rem %~dp0..\..\..\..\Utils\Blackbaud.AppFx.JSMinifier\bin\JSMinifier.exe %~dp0..\..\..\..\Blackbaud.AppFx.Server\Deploy\browser\htmlforms\<subfolder>\*.html /pre
rem %~dp0..\..\..\..\Utils\Blackbaud.AppFx.JSMinifier\bin\JSMinifier.exe %~dp0..\..\..\..\Blackbaud.AppFx.Server\Deploy\browser\htmlforms\<subfolder>\*.js