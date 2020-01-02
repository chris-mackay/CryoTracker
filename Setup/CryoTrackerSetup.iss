#define MyAppName "CryoTracker"
#define MyAppVersion "1.0.0"
#define MyVersionInfoVersion "1.0.0"
#define MyAppPublisher "Christopher Ryan Mackay"

[Setup]
AppId={{F7BBE93A-92B0-4D1F-9129-D9AD1BBE4F09}
AppName={#MyAppName}
AppCopyright=Copyright © 2020 Christopher Ryan Mackay
AppVerName=CryoTracker
AppVersion={#MyAppVersion}
VersionInfoVersion={#MyVersionInfoVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={userdocs}\{#MyAppName}
DisableDirPage=yes
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputDir=.
OutputBaseFilename=CryoTracker-v{#MyAppVersion} Setup
Compression=lzma
SolidCompression=yes
LicenseFile=C:\Programming\CryoTracker\Setup\LICENSE.txt
PrivilegesRequired=lowest
UninstallDisplayIcon={app}\CryoTracker.ico

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "CryoTracker.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "BoxTemplate.box"; DestDir: "{app}"; Flags: ignoreversion
Source: "BoxSettingsTemplate.bxs"; DestDir: "{app}"; Flags: ignoreversion
Source: "CryoTracker.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\CryoTracker"; Filename: "{app}\CryoTracker.exe";

[UninstallDelete] 
Type: dirifempty; Name: {app}\CryoTracker;