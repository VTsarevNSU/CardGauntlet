# CardGauntlet

Запуск:
1. clone
2. dotnet add package Microsoft.Extensions.Hosting в Sandbox
3. dotnet build в InterfacesLibrary
4. dotnet build в StrategyLibrary
5. dotnet run в Card Gauntlet

Coding style:

1. https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
2. https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md

TLDR:
Стиль Олмана: фигурные скобки после объявления, а не вместе с (обычный стиль это Керниган Ритчи)
PascalCase: константы, методы, свойства и публичные поля с большой буквы
\_camelCase: для private и полей используем \_name (позволяент не использовать this)