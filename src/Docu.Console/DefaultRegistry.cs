using Docu.Console;
using Docu.Events;
using Docu.Output;
using Docu.IO;
using Docu.Parsing.Comments;
using StructureMap.Configuration.DSL;

namespace Docu
{
    internal class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(x =>
            {
                x.AssemblyContainingType<DocumentationGenerator>();
                x.WithDefaultConventions();
                x.AddAllTypesOf<ICommentNodeParser>();
            });

            ForRequestedType<IOutputGenerator>()
                .TheDefault.IsThis(new HtmlGenerator());
            ForRequestedType<IOutputWriter>()
                .TheDefaultIsConcreteType<FileSystemOutputWriter>();
            ForRequestedType<IScreenWriter>()
                .TheDefaultIsConcreteType<ConsoleScreenWriter>();
            ForRequestedType<IScreenMessage>()
                .AsSingletons();
            ForRequestedType<IEventAggregator>()
                .AsSingletons();
        }
    }
}