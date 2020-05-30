* EventHandlers/:
  * `DynamicCacheShapeDisplayEvents.cs:`
    > "Caches shapes in the default <see cref="IDynamicCacheService"/> implementation. It uses the shape's metadata cache context to define the cache parameters."
* Models/: Data model
  * `CacheContextModel.cs:`
    > { cache ID, contexts, tags, (~) time triggers (ExpireOn, ExpireAfter, ExpireSliding)
      ToChaheContext method
* Services/:
  * `DefaultDynamicCache.cs:`
    > distributed cache (get/set/remove)
  * DefaultDynamicCacheService.cs
    > `cache/chached values management`
* TagHelpers/:
  * `DynamicCacheTagHelper.cs`
    > ...html attributes caches...
  * `DynamicCacheTagHelperService.cs`
    > Provide "workers" - concurrent (~ async access?) dictionary (string : task<IHtmlContent>)
* `CacheContextEntryExtensions.cs:` 
  > provide "context hast" from cache context entries in foramat "<key><value> sequence"
* CachedShapeWrapperShapes.cs: 
  > FOR DEBUGGING PURPOSE. { html content builder, metadata, cache }
* Manifest.cs: SKIP
* OrchardCore.DynamicCache.csproj: SKIP
* `Startup.cs:` 
  > "These services are registered on the tenant service collection"\
  "Register the type as it implements multiple interfaces"
