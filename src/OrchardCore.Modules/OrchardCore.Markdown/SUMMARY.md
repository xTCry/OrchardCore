# Markdown. [Content Management]
The markdown module enables content items to have markdown editors.

## Module catalog tree

* `Assets/`
  > Stores front-end assets.
* `Drivers/`
  * `MarkdownBodyPartDisplay.cs`
    > Display driver for Markdown body part display in content part. 
  * `MarkdownBodyPartDisplay.cs`
    > 
* `Fields/`
  * `MarkdownField.cs`
    > Markdown field from content field.
* `Filters/`
  * `Markdownify.cs`
    > Markdown to liquid filter.
* `GraphQL/`
  * ``
    > 
  * ``
    > 
  * ``
    > 
* `Handlers/`
  * `MarkdownBodyPartHandler.cs`
    > 
* `Indexing/`
  * `MarkdownFieldIndexHandler.cs`
    > Setting options from context settings for fields.
  * `MarkdownBodyPartIndexHandler.cs`
    > Setting options from context settings (with additional sanitize and analyze doc options) for fields.
* `Media/`
  * `MediaShapes.cs`
    > 
  * `Startup.cs`
    > Add scoped in services for Media shapes in the shape table provider.
* `Models/`
  * `MarkdownBodyPart.cs`
    > Model of content part as markdown body part.
* `Properties/`
  * `AssemblyInfo.cs`
    > General information about the assembly.
* `Razor/`
  * `MarkdownHelperExtensions.cs`
    > Helper extensions convert the Markdown string to HTML.
* `RemotePublishing/`
* `Settings/`
* `ViewModels/`
* `Views/`
* `wwwroot/`
  > Generated files for the frontend.
* `Migrations.cs`
  > Migrate existing MarkdownField to MigrateFieldSettings. This only needs to run on old content definition schemas.
* `Startup.cs`
  > Registeration, configuration Markdown Part and Field and adding filters.
