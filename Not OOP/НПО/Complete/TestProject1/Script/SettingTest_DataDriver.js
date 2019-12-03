function Test1()
{
  //var fs = require("fs");

  TestedApps.cr3.Run();
  let cr3 = Aliases.cr32;
  let settingsDlg = cr3.SettingsDlg;
  let Widget = settingsDlg.tabWidget;
  let tabWidget = Widget.qt_tabwidget_stackedwidget.tabPage; 
      
  //cr3.MainWindowClass.mainToolBar.ToolButton10.ClickButton();
  //Widget.ClickTab("Page");
  var myFile = aqFile.OpenTextFile("D:\\RepositHub\\Complete\\TestData\\settingTestPageMargin.txt", aqFile.faRead, aqFile.ctUTF8);
  while(!myFile.IsEndOfFile()){
    cr3.MainWindowClass.mainToolBar.ToolButton10.ClickButton();
    Widget.ClickTab("Page");
    var s = myFile.readLine();
    tabWidget.cbMargins.ClickItem(s);
    settingsDlg.buttonBox.buttonOk.ClickButton();
  }
  myFile = aqFile.OpenTextFile("D:\\RepositHub\\Complete\\TestData\\settingTestPageViewMode.txt", aqFile.faRead, aqFile.ctUTF8);
  while(!myFile.IsEndOfFile()){
    cr3.MainWindowClass.mainToolBar.ToolButton10.ClickButton();
    Widget.ClickTab("Page");
    var s = myFile.readLine();
    tabWidget.cbViewMode.ClickItem(s);
    settingsDlg.buttonBox.buttonOk.ClickButton();
  }
  myFile = aqFile.OpenTextFile("D:\\RepositHub\\Complete\\TestData\\settingTestFontSize.txt", aqFile.faRead, aqFile.ctUTF8);
  while(!myFile.IsEndOfFile()){
    cr3.MainWindowClass.mainToolBar.ToolButton10.ClickButton();
    Widget.ClickTab("Page");
    var s = myFile.readLine();
    tabWidget.cbTitleFontSize.ClickItem(s);
    settingsDlg.buttonBox.buttonOk.ClickButton();
  }
  
  //settingsDlg.buttonBox.buttonOk.ClickButton();
  cr3.MainWindowClass.Close();
}
