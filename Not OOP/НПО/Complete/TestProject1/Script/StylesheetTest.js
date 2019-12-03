function Test1()
{
  TestedApps.cr3.Run();
  let cr3 = Aliases.cr32;
  cr3.MainWindowClass.mainToolBar.ToolButton10.ClickButton();
  let settingsDlg = cr3.SettingsDlg;
  let tabWidget = settingsDlg.tabWidget;
  tabWidget.ClickTab("Stylesheet");
  let widget = tabWidget.qt_tabwidget_stackedwidget.tabMoreStyles;
  let comboBox = widget.cbStyleName;
  comboBox.ClickItem("Title");
  comboBox.ClickItem("Subtitle");
  comboBox.ClickItem("Preformatted text");
  comboBox.ClickItem("Link");
  let widget2 = widget.scrollArea.qt_scrollarea_viewport.scrollAreaWidgetContents;
  widget2.cbDefAlignment.ClickItem("Justify");
  widget2.cbDefFirstLine.ClickItem("No indent");
  widget2.cbDefFontSize.ClickItem("Increase: 110%");
  widget2.cbDefFontFace.ClickItem("[Default Sans Serif]");
  widget2.cbDefFontWeight.ClickItem("Bold");
  widget2.cbDefFontStyle.ClickItem("Normal");
  widget2.cbDefFontColor.ClickItem("Green");
  widget2.cbDefLineHeight.ClickItem("85%");
  widget2.cbDefVerticalAlign.ClickItem("Subscript");
  widget2.cbDefTextDecoration.ClickItem("Underline");
  widget2.cbDefMarginBefore.ClickItem("150% of line height");
  widget2.cbDefMarginAfter.ClickItem("20% of line height");
  widget2.cbDefMarginLeft.ClickItem("400% of line height");
  widget2.cbDefMarginRight.ClickItem("5% of line width");
  settingsDlg.buttonBox.buttonOk.ClickButton();
  cr3.MainWindowClass.mainToolBar.ToolButton10.ClickButton();
  settingsDlg = cr3.SettingsDlg;
  tabWidget = settingsDlg.tabWidget;
  tabWidget.ClickTab("Stylesheet");
  widget = tabWidget.qt_tabwidget_stackedwidget.tabMoreStyles;
  widget.cbStyleName.ClickItem("Title");
  widget2 = widget.scrollArea.qt_scrollarea_viewport.scrollAreaWidgetContents;
  widget2.cbDefAlignment.ClickItem("Justify");
  widget2.cbDefFirstLine.ClickItem("Small Indent");
  widget2.cbDefFontFace.ClickItem("Arial");
  widget2.cbDefFontStyle.ClickItem("Italic");
  widget2.cbDefFontColor.ClickItem("Gray");
  widget2.cbDefLineHeight.ClickItem("130%");
  widget2.cbDefTextDecoration.ClickItem("Overline");
  widget2.cbDefVerticalAlign.ClickItem("Superscript");
  widget2.cbDefMarginLeft.ClickItem("400% of line height");
  widget2.cbDefMarginRight.ClickItem("400% of line height");
  settingsDlg.buttonBox.buttonCancel.ClickButton();
  let toolButton = cr3.MainWindowClass.mainToolBar.ToolButton10;
  toolButton.ClickButton();
  settingsDlg = cr3.SettingsDlg;
  tabWidget = settingsDlg.tabWidget;
  tabWidget.ClickTab("Stylesheet");
  comboBox = tabWidget.qt_tabwidget_stackedwidget.tabMoreStyles.scrollArea.qt_scrollarea_viewport.scrollAreaWidgetContents.cbDefFontSize;
  comboBox.ClickItem("Increase: 150%");
  let buttonOk = settingsDlg.buttonBox.buttonOk;
  buttonOk.ClickButton();
  toolButton.ClickButton();
  tabWidget.ClickTab("Stylesheet");
  comboBox.ClickItem("-");
  buttonOk.ClickButton();
  cr3.MainWindowClass.Close();
  
  
  
}
