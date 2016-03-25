#ifndef VERSION
  #define VERSION "1.0.0"
#endif
 
#ifndef RESOURCE_VERSION
  #define RESOURCE_VERSION "1.0.0"
#endif

[Setup]
AppName=RiotPls
AppVersion={#VERSION}
DefaultDirName={pf}\RiotPls   
DisableProgramGroupPage=auto
OutputDir=Compiled
OutputBaseFilename=RiotPls Installer v{#VERSION}       
ShowLanguageDialog=auto  
UninstallDisplayName=RiotPls    

[Files]
; Program Files ;
Source: "Compiled\RiotPls.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Compiled\*"; DestDir: "{app}"; Flags: ignoreversion; Excludes: "*.exe, *.pdb, *.Test.dll, *.txt, *.xml, *.vshost.*"
; Resources ;
Source: "Compiled\json\*"; DestDir: "{app}\json"; Flags: ignoreversion createallsubdirs recursesubdirs; Components: Resources
Source: "Compiled\Resources\*"; DestDir: "{app}\Resources"; Flags: ignoreversion createallsubdirs recursesubdirs; Components: Resources

[Icons]
Name: "{userdesktop}\RiotPls"; Filename: "{app}\RiotPls.exe"; WorkingDir: "{app}"; IconFilename: "{app}\RiotPls.exe"; IconIndex: 0

[Components]
Name: "Resources"; Description: "Resource Pack v{#RESOURCE_VERSION}"; Types: Custom

[Types]
Name: "Custom"; Description: "Custom"; Flags: iscustom
