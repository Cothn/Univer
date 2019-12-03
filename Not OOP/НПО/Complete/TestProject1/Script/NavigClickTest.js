function Test1()
{
  TestedApps.cr3.Run();
  let cr3 = Aliases.cr32;
  let mainWindow = cr3.MainWindowClass;
  let menuBar = mainWindow.menuBar;
  menuBar.QtMenu.Click("Navigation|Page Down");
  menuBar.QtMenu.Click("Navigation|Page Up");
  menuBar.QtMenu.Click("Navigation|Line Down");
  menuBar.QtMenu.Click("Navigation|Line Up");
  menuBar.QtMenu.Click("Navigation|Last Page");
  menuBar.QtMenu.Click("Navigation|First Page");
  menuBar.QtMenu.Click("Navigation|Next Chapter");
  menuBar.QtMenu.Click("Navigation|Previous Chapter");
  menuBar.QtMenu.Click("Navigation|Back");
  menuBar.QtMenu.Click("Navigation|Forward");
  let scrollBar = Aliases.cr32.MainWindowClass.centralWidget.scroll;
  scrollBar.wPosition = 34;
  scrollBar.MouseWheel(-1);
  scrollBar.MouseWheel(-1);
  scrollBar.MouseWheel(-1);
  scrollBar.MouseWheel(-1);
  scrollBar.MouseWheel(-1);
  scrollBar.MouseWheel(1);
  scrollBar.MouseWheel(1);
  scrollBar.MouseWheel(1);
  scrollBar.MouseWheel(1);
  mainWindow.Close();


}
