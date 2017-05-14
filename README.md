# AntiWannaCryMutexService

Windows Service/Desktop that can run for prevent WannaCry Ransomware. Simply can push via AD to PC's

This will create mutex `MsWinZonesCacheCounterMutexA`. So WannaCry cant start

### Service 
Service can install via bat file or installUtil. Then once service started, Can run Microsoft Process Explorer and search for above mutex

### Desktop app
add to run at startup. It will run in background

  
```
Created by : Malinda Rathnayake
Fix Consult by : Dilan Walgampaya
Date : 2017-05-13
Version : v01.0
```

### Process Explorer
   
`https://technet.microsoft.com/en-us/sysinternals/processexplorer.aspx` and search for `MsWinZonesCacheCounterMutexA`

Ref
`https://gist.github.com/N3mes1s/afda0da98f6a0c63ec4a3d296d399636`

* When run service, you cant see mutex from Desktop app. So better to have Desktop hidden app. 
* I you have older windows, please recompile with lower .net version. 

Developer dont take any risk or affecct because of this tool. and developer not gaurantee about 100% safty
