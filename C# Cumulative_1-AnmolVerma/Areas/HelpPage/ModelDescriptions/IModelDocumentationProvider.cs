using System;
using System.Reflection;

namespace C__Cumulative_1_AnmolVerma.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}