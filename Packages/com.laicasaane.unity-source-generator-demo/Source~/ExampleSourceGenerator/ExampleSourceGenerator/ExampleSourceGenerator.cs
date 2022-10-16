using System;
using System.Text;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis;

namespace ExampleSourceGenerator
{
    [Generator]
    public class ExampleGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            Console.WriteLine(DateTime.Now.ToString());

            var sourceBuilder = new StringBuilder(
            @"
            using System;
            namespace ExampleSourceGenerated
            {
                public static class Example
                {
                    public static string GetTestText() 
                    {
                        return ""This is from source generator ");

            sourceBuilder.Append(DateTime.Now.ToString());

            sourceBuilder.Append(
                @""";
                    }
    }
}
");

            context.AddSource("ExampleSourceGenerator", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context) { }
    }
}
