string path = @"C:\Projetos\Back-End\CSharp\ProjetosPessoais\ComparadorDeArquivos\Arquivos\";
string arquivo1 = "Sudeste.csv";
string arquivo2 = "Sudeste2.csv";
List<string> lstArquivo1 = [];
List<string> lstArquivo2 = [];

GeraListaAPartirDoArquivo(path, arquivo1, lstArquivo1);
GeraListaAPartirDoArquivo(path, arquivo2, lstArquivo2);

IEnumerable<string> lstDiferenca = from regiao in lstArquivo1.Except(lstArquivo2)
                                   select regiao;

if (lstDiferenca.Any())
    foreach (string line in lstDiferenca)
        Console.WriteLine(line);
else
    Console.WriteLine($"Os arquivos {arquivo1} e {arquivo2} são iguais");

Console.WriteLine("\nFim");

static void GeraListaAPartirDoArquivo(string path, string arquivo, List<string> lstArquivo)
{
    try
    {
        using (StreamReader sr = File.OpenText($@"{path}\{arquivo}"))
        {
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                if (line is not null)
                    lstArquivo.Add(line);
            }
        }
        _ = lstArquivo.Order();
    }
    catch (Exception e)
    {
        throw new Exception($"Erro para ler arquivo: {e.Message}");
    }
}