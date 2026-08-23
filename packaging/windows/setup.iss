; Inno Setup script for WinSonic (Windows)
; Built by CI with: ISCC setup.iss /DMyAppVersion=<version> /DSourceDir=<publish dir> /DOutputDir=<output dir>

#define MyAppName "WinSonic"
#define MyAppExeName "WinSonic.Gui.Xplat.Windows.exe"
#define MyAppPublisher "WinSonic"

[Setup]
AppId={{2E3F9E2A-6B1E-4E5A-9C1B-6F2C6C7B0A1D}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputDir={#OutputDir}
OutputBaseFilename=WinSonic-{#MyAppVersion}-win-x64-setup
Compression=lzma2
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64compatible
SetupIconFile=..\..\WinSonic.Gui.Xplat\Assets\avalonia-logo.ico
UninstallDisplayIcon={app}\{#MyAppExeName}
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"

[Files]
Source: "{#SourceDir}\*"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Launch {#MyAppName}"; Flags: nowait postinstall skipifsilent
