# AntiWannaCryMutexService

Windows Service that can run for prevent WannaCry Ransomware. Simply can push via AD to PC's

This will create mutex `MsWinZonesCacheCounterMutexA`. So WannaCry cant start

Service can install via bat file or installUtil. Then once service started, Can run Microsoft Process Explorer and search for above mutex

  
	```
	Created by : Malinda Rathnayake
    Consultened by : Dilan Walgampaya
    Date : 2017-05-13
    Version : v01.0
	```

### Process Explorer
   
`https://technet.microsoft.com/en-us/sysinternals/processexplorer.aspx` and search for `MsWinZonesCacheCounterMutexA`
```

Rer 
`https://gist.github.com/N3mes1s/afda0da98f6a0c63ec4a3d296d399636`
