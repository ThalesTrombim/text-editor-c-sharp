using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextEditor
{
  internal class Program
  {
    static void ShowFile(string file)
    {
      try
      {
        string line = "";
        StreamReader sr = new StreamReader(file);
        line = sr.ReadLine();
        while (line != null)
        {
          Console.WriteLine(line);
          line = sr.ReadLine();
        }
        sr.Close();
        Console.ReadLine();
      }
      catch (Exception e)
      {
        Console.WriteLine("Erro! Arquivo em branco ou nao existe.");
      }
      Console.ReadKey();
    }

    static void WriteText(string file, string text, bool add)
    {
      try
      {
        StreamWriter sr = new StreamWriter(file, add);
        sr.WriteLine(text);
        sr.Close();
      }
      catch (Exception e)
      {
        Console.WriteLine("Error: " + e.Message);
        Console.ReadKey();
      }
    }

    static int ShowMenu()
    {
      Console.Clear();
      Console.WriteLine("Editor de texto");
      Console.WriteLine("Abrir/Criar um arquivo (1)");
      Console.WriteLine("Exibir texto do arquivo (2)");
      Console.WriteLine("Gravar um arquivo com novo um texto (3)");
      Console.WriteLine("Gravar um novo texto no arquivo (4)");
      Console.WriteLine("Sair (5)");

      Console.Write("opcao: ");
      int op = Convert.ToInt32(Console.ReadLine());
      return op;
    }

    static void Main(string[] args)
    {
      int op = 0;
      string file = "";
      string text = "";

      while (op != 5)
      {
        op = ShowMenu();
        Console.Clear();
        switch (op)
        {
          case 1:
            Console.Write("Informe o nome do arquivo: ");
            file = Console.ReadLine();
            break;
          case 2:
            ShowFile(file);
            break;
          case 3:
            Console.WriteLine("Informe o texto: ");
            text = Console.ReadLine();
            WriteText(file, text, false);
            ShowFile(file);
            break;
          case 4:
            Console.WriteLine("Informe o texto: ");
            text = Console.ReadLine();
            WriteText(file, text, true);
            ShowFile(file);
            break;
        }
      }
    }
  }
}