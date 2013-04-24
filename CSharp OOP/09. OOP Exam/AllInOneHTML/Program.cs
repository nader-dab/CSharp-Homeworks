using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            HTMLElement element = new HTMLElement(name, null);

            return element;
        }

        public IElement CreateElement(string name, string content)
        {
            HTMLElement element = new HTMLElement(name, content);

            return element;
        }

        public ITable CreateTable(int rows, int cols)
        {
            HTMLTable table = new HTMLTable(rows, cols);

            return table;
        }
    }

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }

    public class HTMLElement : IElement
    {
        public string Name { get; set; }
        public string TextContent { get; set; }
        public IEnumerable<IElement> ChildElements { get; set; }

        private List<IElement> innerList = new List<IElement>();
        public HTMLElement(string name, string textContent)
        {
            this.Name = name;
            this.TextContent = textContent;
            this.ChildElements = new List<HTMLElement>();
        }

        public void AddElement(IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            
            innerList.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.Append("<");
                output.Append(this.Name);
                output.Append(">");
            }

            if (this.TextContent != null)
            {
                this.TextContent = this.TextContent.Replace("&", "&amp;");
                this.TextContent = this.TextContent.Replace("<", "&lt;");
                this.TextContent = this.TextContent.Replace(">", "&gt;");

                output.Append(this.TextContent);
            }

            //TODO add child content
            foreach (var item in this.innerList)
            {
                StringBuilder childSb = new StringBuilder();
                item.Render(childSb);
                output.Append(childSb.ToString());
            }

            if (this.Name != null)
            {
                output.Append("</");
                output.Append(this.Name);
                output.Append(">");
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.Render(sb);
            return sb.ToString();
        }
    }

    public class HTMLTable : HTMLElement, ITable
    {
        public int Rows { get; protected set; }

        public int Cols { get; protected set; }

        private IElement[,] innerTable;

        public HTMLTable(int rows, int cols)
            : base("table", null)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.innerTable = new IElement[Rows, Cols];
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.innerTable[row, col];
            }
            set
            {
                this.innerTable[row, col] = value;
            }
        }

        public override void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.Append("<");
                output.Append(this.Name);
                output.Append(">");
            }


            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("<td>");
                    output.Append(this[row, col]);
                    output.Append("</td>");
                }

                output.Append("</tr>");
            }

            if (this.Name != null)
            {
                output.Append("</");
                output.Append(this.Name);
                output.Append(">");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.Render(sb);
            return sb.ToString();
        }
    }
}
