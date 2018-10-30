# Aur.AspNetCore.Mvc.Modularity

![Aur.AspNetCore.Mvc.Modularity logo](doc/resource/logo/Aur.AspNetCore.Mvc.Modularity.png?raw=true)

> :warning: è ancora in fase di sviluppo la prima versione. non è ancora usabile :warning:

**Aur.AspNetCore.Mvc.Modularity** is a library that helps to realize applications, based on the concept of **mvc**, in a **modular** way.

all realization is completely expandable through **properties** that allow you to **configure all aspects** of both the module and the mvc

###### before seeing the features we see the concept that is at the basis of the project

![Aur.AspNetCore.Mvc.Modularity Concept 1](doc/resource/img/Aur.AspNetCore.Mvc.Modularity%20Concept.png?raw=true)
![Aur.AspNetCore.Mvc.Modularity Concept 1](doc/resource/img/Aur.AspNetCore.Mvc.Modularity%20Concept%202.png?raw=true)

## Fatures:
* The module is a DLL **out of context**
* Controller in a module
  * **Assembly**
  * none
* Views in a module
  * **Assembly**
  * Embedded
  * FileSystem
  * None
* A **Property Factory** to conveniently manage all the properties of a module
* A **Plugin Factory** to efficiently manage all modules
* If a module throws an exception the program is not interrupted
* Module injection in Startup.ConfigureServices()
* Module injection in Startup.Configure()
## Future fatures:
* module requiments
* module view ovveride
* module view append to other view
* and much more


> :warning: è ancora in fase di sviluppo la prima versione. non è ancora usabile :warning: