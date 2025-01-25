using System.Reflection;
using TMath.Extensions;

namespace TMath.Tests;

[TestFixture]
public class FunctionConsistencyTests
{
    [Test]
    public void MathTFunctions_ShouldHave_IEnumerableExtensionEquivalent()
    {
        // Get methods from MathFunctions and MathFunctionsExtensions
        var mathFunctionsMethods = typeof(MathT).GetMethods(BindingFlags.Public | BindingFlags.Static);
        var extensionMethods = typeof(IEnumerableExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static);

        // Remove the extension methods' first parameter (the 'this' parameter)
        var extensionMethodNames = extensionMethods
            .Where(m => m.IsPublic && m.IsStatic)
            .Select(m => m.Name)
            .ToHashSet();

        // Compare the method names from both classes
        foreach (var method in mathFunctionsMethods)
        {
            // Ignore constructors, and only check methods
            if (method.IsConstructor) continue;

            var methodName = method.Name;

            Assert.IsTrue(extensionMethodNames.Contains(methodName),
                $"Method {methodName} from MathFunctions was not found in MathFunctionsExtensions.");
        }
    }
}