BLOB - Binary Large Object (binary array)
---
* CreateMediaBlobContainerEvent.cs:
  > 
  * Task ActivateAsync()
    > "Only create container if options are valid"\
      (no task returned, only logging, hmm)
* Manifest.cs: SKIP
* `MediaBlobStorageOptions.cs:`
  > 
  * ConfigureServices()
    > "Only replace default implementation if options are valid;\
      Register a media cache file provider;
      Replace the default media file provider with the media cache file provider;
      Register the media cache file provider as a file store cache provider;
      Replace the default media file store with a blob file store;
  * GetMediaPath()
    > create path from shells app data path, shells container name, shell settings name and assets path.
  * GetMediaCachePath()
    > create path from web-host-enviroment's web root path, assets path and shell settings name.
  * bool CheckOptions()
    > check connection and container name for "null or whitespace" 
* MediaBlobStorageOptionsConfiguration.cs:
  > 
* OrchardCore.Media.Azure.csproj: SKIP
* Startup.cs: 
  > 
