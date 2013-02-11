using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Glimpse.Core.Extensibility;

[assembly: ComVisible(false)]
[assembly: Guid("39a13dc2-4cdf-4f80-b994-f858ef998510")]

[assembly: AssemblyTitle("Glimpse for ASP.NET MVC 4 Assembly")]
[assembly: AssemblyDescription("Glimpse extensions and tabs for ASP.NET MVC 4.")]
[assembly: AssemblyProduct("Glimpse.Mvc4")]
[assembly: AssemblyCopyright("© 2012 Nik Molnar & Anthony van der Hoorn")]
[assembly: AssemblyTrademark("Glimpse")]

// Version is in major.minor.build format to support http://semver.org/
// Keep these three attributes in sync
[assembly: AssemblyVersion("1.0.0")]
[assembly: AssemblyFileVersion("1.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0-rc2")] // Used to specify the NuGet version number at build time

[assembly: InternalsVisibleTo("Glimpse.Test.Mvc4")]
[assembly: NuGetPackage]