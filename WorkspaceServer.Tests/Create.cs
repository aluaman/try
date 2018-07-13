using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MLS.Agent.Tools;
using Recipes;
using WorkspaceServer.Models.Execution;

namespace WorkspaceServer.Tests
{
    public static class Create
    {
        public static async Task<WorkspaceBuild> ConsoleWorkspaceCopy([CallerMemberName] string testName = null) =>
            WorkspaceBuild.Copy(
                await Default.ConsoleWorkspace,
                testName);

        public static async Task<WorkspaceBuild> WebApiWorkspaceCopy([CallerMemberName] string testName = null) =>
            WorkspaceBuild.Copy(
                await Default.WebApiWorkspace,
                testName);

        public static async Task<WorkspaceBuild> XunitWorkspaceCopy([CallerMemberName] string testName = null) =>
            WorkspaceBuild.Copy(
                await Default.XunitWorkspace,
                testName);

        public static WorkspaceBuild EmptyWorkspace([CallerMemberName] string testName = null, IWorkspaceInitializer initializer = null) =>
            new WorkspaceBuild(WorkspaceBuild.CreateDirectory(testName), initializer: initializer);

        public static string SimpleWorkspaceAsJson(
            string consoleOutput = "Hello!",
            string workspaceType = null) =>
            Workspace.FromSource(
                SimpleConsoleAppCodeWithoutNamespaces(consoleOutput),
                workspaceType
            ).ToJson();

        public static string SimpleConsoleAppCodeWithoutNamespaces(string consoleOutput)
        {
            var code = $@"
using System;

public static class Hello
{{
    public static void Main()
    {{
        Console.WriteLine(""{consoleOutput}"");
    }}
}}";
            return CodeManipulation.EnforceLF(code);
        }
    }
}