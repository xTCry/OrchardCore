XML-RPC is a remote procedure call (RPC) protocol which uses XML to encode its calls and HTTP as a transport mechanism
(eXtensible Markup Language Remote Procedure Call)
---
* Contollers/: ...
    * HomeController.cs
    * MetaWeblogContoller.cs
* Services/: XML-RPC reader, writer
    * XmlRpcReader.cs: "straction to read XML and convert it to rpc entities"
    * XmlRpcWriter.cs: "bstraction to write XML based on rpc entities"
* MethodCallModelBinder.cs: ...
    * `...write...`
* Startup.cs: configures: +-
    * xml-rpc reader and writer
    * `...routes?...(xml-rpc, xmlrpc/metaweblog)`
