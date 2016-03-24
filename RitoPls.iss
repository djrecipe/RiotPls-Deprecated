#ifndef VERSION
  #define VERSION "1.0.0"
#endif
 
#ifndef RESOURCE_VERSION
  #define RESOURCE_VERSION "1.0.0"
#endif

[Setup]
AppName=RitoPls
AppVersion={#VERSION}
DefaultDirName={pf}\RitoPls
ShowLanguageDialog=auto
DisableProgramGroupPage=auto
UninstallDisplayName=RitoPls

[Files]
; Program Files ;
Source: "Compiled\*"; DestDir: "{app}"; Flags: ignoreversion; Excludes: "*.pdb, *.Test.dll, *.txt, *.xml, *.vshost.*"
; Resources ;
Source: "Compiled\json\*"; DestDir: "{app}\json"; Flags: ignoreversion createallsubdirs recursesubdirs; Components: Resources
Source: "Compiled\Resources\*"; DestDir: "{app}\Resources"; Flags: ignoreversion createallsubdirs recursesubdirs; Components: Resources

[Icons]
Name: "{userdesktop}\RiotPls"; Filename: "RiotPls.exe"; WorkingDir: "{app}"

[Components]
Name: "Resources"; Description: "Resource Pack v{#RESOURCE_VERSION}"; Types: Custom

[Types]
Name: "Custom"; Description: "Custom"; Flags: iscustom
