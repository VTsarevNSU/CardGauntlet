# CardGauntlet

Запуск:
1. clone
2. dotnet build в InterfacesLibrary
3. dotnet build в StrategyLibrary
4. dotnet run в Card Gauntlet

TODO: библиотеки собираются, но:
1. сам проект не запускается, выкидывает простыню текста ошибок с неясными выводами (это errors при dotnet run)
2. VSCode жалуется на конфликт всех классов с типа как импортируемыми классами, причём даже в InterfacesLibrary, хотя туда ничего не импортируется (это warnings при dotnet run)

Сам вывод:

D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\.NETCoreApp,Version=v7.0.AssemblyAttributes.cs(4,12): error CS0579: Duplicate 
'global::System.Runtime.Versioning.TargetFrameworkAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(13,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyCompanyAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(14,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyConfigurationAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(15,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyFileVersionAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(16,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyInformationalVersionAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(17,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyProductAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(18,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyTitleAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(19,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyVersionAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\.NETCoreApp,Version=v7.0.AssemblyAttributes.cs(4,12): error CS0579: Duplicate 'global::System. 
Runtime.Versioning.TargetFrameworkAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(13,12): error CS0579: Duplicate 'System.Reflection.AssemblyCompa 
nyAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(14,12): error CS0579: Duplicate 'System.Reflection.AssemblyConfi 
gurationAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(15,12): error CS0579: Duplicate 'System.Reflection.AssemblyFileV 
ersionAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(16,12): error CS0579: Duplicate 'System.Reflection.AssemblyInfor 
mationalVersionAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(17,12): error CS0579: Duplicate 'System.Reflection.AssemblyProdu 
ctAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(18,12): error CS0579: Duplicate 'System.Reflection.AssemblyTitle 
Attribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(19,12): error CS0579: Duplicate 'System.Reflection.AssemblyVersi 
onAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs(8,20): warning CS0436: The type 'CardColor' in 'D:\Inthroughder cargo\Universit 
y Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'CardColor' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicK 
eyToken=null'. Using the type defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University S 
tudying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\Strategy.cs(7,21): warning CS0436: The type 'Card' in 'D:\Inthroughder cargo\University Studyin 
g Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'Card' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. 
 Using the type defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University Studying Materi 
als\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs(16,30): warning CS0436: The type 'Card' in 'D:\Inthroughder cargo\University St 
udying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'Card' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=n 
ull'. Using the type defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University Studying M 
aterials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs(16,47): warning CS0436: The type 'Card' in 'D:\Inthroughder cargo\University St 
udying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'Card' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=n 
ull'. Using the type defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University Studying M 
aterials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs(16,65): warning CS0436: The type 'Card' in 'D:\Inthroughder cargo\University St 
udying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'Card' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=n 
ull'. Using the type defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University Studying M 
aterials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Shuffler.cs(6,49): warning CS0436: The type 'Card' in 'D:\Inthroughder cargo\University Studying Materials\4 ye 
ar\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'Card' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Using the type  
defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University Studying Materials\4 year\C#\Ca 
rdGauntlet\Card Gauntlet.csproj]

Build FAILED.

D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs(8,20): warning CS0436: The type 'CardColor' in 'D:\Inthroughder cargo\Universit 
y Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'CardColor' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicK 
eyToken=null'. Using the type defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University S 
tudying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\Strategy.cs(7,21): warning CS0436: The type 'Card' in 'D:\Inthroughder cargo\University Studyin 
g Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'Card' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. 
 Using the type defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University Studying Materi 
als\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs(16,30): warning CS0436: The type 'Card' in 'D:\Inthroughder cargo\University St 
udying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'Card' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=n 
ull'. Using the type defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University Studying M 
aterials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs(16,47): warning CS0436: The type 'Card' in 'D:\Inthroughder cargo\University St 
udying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'Card' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=n 
ull'. Using the type defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University Studying M 
aterials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs(16,65): warning CS0436: The type 'Card' in 'D:\Inthroughder cargo\University St 
udying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'Card' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=n 
ull'. Using the type defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University Studying M 
aterials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Shuffler.cs(6,49): warning CS0436: The type 'Card' in 'D:\Inthroughder cargo\University Studying Materials\4 ye 
ar\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs' conflicts with the imported type 'Card' in 'InterfacesLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Using the type  
defined in 'D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\InterfacesLibrary\Interfaces.cs'. [D:\Inthroughder cargo\University Studying Materials\4 year\C#\Ca 
rdGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\.NETCoreApp,Version=v7.0.AssemblyAttributes.cs(4,12): error CS0579: Duplicate  
'global::System.Runtime.Versioning.TargetFrameworkAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(13,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyCompanyAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(14,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyConfigurationAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(15,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyFileVersionAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(16,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyInformationalVersionAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(17,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyProductAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(18,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyTitleAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\StrategyLibrary\obj\Debug\net7.0\StrategyLibrary.AssemblyInfo.cs(19,12): error CS0579: Duplicate 'System.Reflec 
tion.AssemblyVersionAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\.NETCoreApp,Version=v7.0.AssemblyAttributes.cs(4,12): error CS0579: Duplicate 'global::System. 
Runtime.Versioning.TargetFrameworkAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(13,12): error CS0579: Duplicate 'System.Reflection.AssemblyCompa 
nyAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(14,12): error CS0579: Duplicate 'System.Reflection.AssemblyConfi 
gurationAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(15,12): error CS0579: Duplicate 'System.Reflection.AssemblyFileV 
ersionAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(16,12): error CS0579: Duplicate 'System.Reflection.AssemblyInfor 
mationalVersionAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(17,12): error CS0579: Duplicate 'System.Reflection.AssemblyProdu 
ctAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(18,12): error CS0579: Duplicate 'System.Reflection.AssemblyTitle 
Attribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\obj\Debug\net7.0\Card Gauntlet.AssemblyInfo.cs(19,12): error CS0579: Duplicate 'System.Reflection.AssemblyVersi 
onAttribute' attribute [D:\Inthroughder cargo\University Studying Materials\4 year\C#\CardGauntlet\Card Gauntlet.csproj]
    6 Warning(s)
    16 Error(s)
